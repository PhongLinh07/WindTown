## MODIFIED Requirements

### Requirement: Summary metrics reflect JSON
The system SHALL set summary counts in `hrm_form_list.html` to match totals derived from `degsignUI.json` (total forms, done forms, remaining forms, and module count), including newly added entries such as `formMainV2`.

#### Scenario: Summary totals updated
- **WHEN** `degsignUI.json` lists modules and forms with statuses
- **THEN** the summary numbers in `hrm_form_list.html` equal the JSON-derived totals

### Requirement: Form cards mirror JSON form fields
Each form card SHALL reflect the JSON fields for `name`, `tables`, `description`, `layout`, and `status`, including `formMainV2` once added.

#### Scenario: Card content and badges
- **WHEN** a form entry is read from `degsignUI.json`
- **THEN** its card shows the form name, tables list, description text, layout badge, and status badge/class consistent with the JSON values
