import json
import re
from pathlib import Path

BASE = Path(__file__).resolve().parent
JSON_PATH = BASE / "degsignUI.json"
STATUS_PATH = BASE / "forms_status.md"
HTML_PATH = BASE / "hrm_form_list.html"


def load_json(path: Path):
    return json.loads(path.read_text(encoding="utf-8-sig"))


def collect_forms(data):
    done = set()
    pending = set()
    modules = []
    for m in data:
        name = m.get("module")
        forms = m.get("forms", [])
        for f in forms:
            if f.get("status") == "done":
                done.add(f.get("name"))
            else:
                pending.add(f.get("name"))
        modules.append((name, forms))
    return done, pending, modules


def update_forms_status(data, done, pending):
    if not STATUS_PATH.exists():
        return
    text = STATUS_PATH.read_text(encoding="utf-8")
    total = len(done) + len(pending)
    text = re.sub(r"- Đã hoàn thành: \d+", f"- Đã hoàn thành: {len(done)}", text)
    text = re.sub(r"- Chưa hoàn thành: \d+", f"- Chưa hoàn thành: {len(pending)}", text)

    # Update module blocks
    lines = text.splitlines()

    def replace_module(block_title, done_list, pending_list):
        idx = next((i for i, l in enumerate(lines) if l.strip() == block_title), -1)
        if idx == -1:
            return
        # remove following done/pending lines under this module
        rm = []
        for j in range(idx + 1, min(idx + 6, len(lines))):
            if lines[j].strip().startswith("- done:") or lines[j].strip().startswith("- pending:"):
                rm.append(j)
        for j in reversed(rm):
            lines.pop(j)
        insert_at = idx + 1
        if done_list:
            lines.insert(insert_at, "- done: " + ", ".join(done_list))
            insert_at += 1
        if pending_list:
            lines.insert(insert_at, "- pending: " + ", ".join(pending_list))

    # Build lists by module from JSON
    for m in data:
        mod = m.get("module")
        forms = m.get("forms", [])
        d = [f["name"] for f in forms if f.get("status") == "done"]
        p = [f["name"] for f in forms if f.get("status") != "done"]
        replace_module(f"### {mod} ({len(forms)})", d, p)

    STATUS_PATH.write_text("\n".join(lines), encoding="utf-8")


def update_hrm_list(done, pending):
    if not HTML_PATH.exists():
        return
    html = HTML_PATH.read_text(encoding="utf-8")

    # Update summary counts
    start = html.find('<div class="summary">')
    end = html.find('<div class="legend">')
    if start != -1 and end != -1:
        summary = html[start:end]
        nums = re.findall(r'(<div class="sum-num"[^>]*>)(\d+)(</div>)', summary)
        if len(nums) >= 3:
            # compute total/pending from JSON
            total = None
            try:
                data = load_json(JSON_PATH)
                total = sum(len(m.get("forms", [])) for m in data)
            except Exception:
                pass
            if total is None:
                total = len(done) + len(pending)
            pending_count = len(pending)
            replacements = [str(total), str(len(done)), str(pending_count)]

            def repl(m, it=iter(replacements)):
                return m.group(1) + next(it) + m.group(3)

            summary_new = re.sub(r'(<div class="sum-num"[^>]*>)(\d+)(</div>)', repl, summary, count=3)
            html = html[:start] + summary_new + html[end:]

    # Add done class and badge
    for name in done:
        html = re.sub(
            rf'(<div class="form-card)("[^>]*onclick="sendPrompt\([^>]*{re.escape(name)}[^>]*\))',
            r'\1 done\2',
            html,
        )

        def add_done(m):
            badges = m.group(2)
            if 'badge-done' not in badges:
                badges = '\n        <span class="badge badge-done">Xong</span>\n' + badges
            return m.group(1) + badges + m.group(3)

        html = re.sub(
            rf'(?s)(<div class="fc-name">{re.escape(name)}</div>.*?<div class="fc-badges">)(.*?)(</div>\s*</div>)',
            add_done,
            html,
        )

    # Clean blank lines inside fc-badges
    def clean(m):
        block = m.group(0)
        lines = [ln for ln in block.split('\n') if ln.strip() != '']
        return '\n'.join(lines)

    html = re.sub(r'(?s)<div class="fc-badges">.*?</div>', clean, html)

    HTML_PATH.write_text(html, encoding="utf-8")


def main():
    data = load_json(JSON_PATH)
    done, pending, _ = collect_forms(data)
    update_forms_status(data, done, pending)
    update_hrm_list(done, pending)


if __name__ == "__main__":
    main()
