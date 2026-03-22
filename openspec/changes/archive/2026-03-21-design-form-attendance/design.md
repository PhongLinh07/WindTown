## Context

FormAttendance will be implemented inside the existing WinForms VB.NET project using the AGENTS — Design Planning standard. The project already has established Design System Core tokens, form structure standards, preview HTML workflow, and an auto-sync process for status tracking.

## Goals / Non-Goals

**Goals:**
- Define a clear, consistent formAttendance layout (header/body/footer) aligned with the Form Structure Standard.
- Ensure required fields and validation rules are explicit and match preview behavior.
- Keep VB.NET designer and code-behind in sync with the approved preview.
- Maintain status updates via existing auto-sync conventions.

**Non-Goals:**
- Refactor unrelated forms or global design system tokens.
- Introduce new UI frameworks or third-party dependencies.

## Decisions

- Use the existing AGENTS Design System Core for typography, spacing, radius, and color tokens to keep consistency across forms.
- Build a preview HTML for quick iteration and review, then mirror it 1:1 in VB.NET designer layout.
- Keep form layout structure fixed in the designer and use code-behind only for data binding, validation, and UI state behavior.
- Follow existing auto-sync rules to update `forms_status.md`, `degsignUI.json`, and `hrm_form_list.html` once VB.NET is finalized.

## Risks / Trade-offs

- If the preview HTML diverges from the VB.NET designer, visual mismatches can occur → Mitigation: treat preview as the single source for layout/spacing; verify pixel alignment before marking done.
- Validation rules may be inconsistently applied between preview and VB.NET → Mitigation: list all required fields explicitly and implement the same logic in code-behind.
