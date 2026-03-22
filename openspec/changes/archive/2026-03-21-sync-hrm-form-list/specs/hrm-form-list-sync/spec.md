## ADDED Requirements

### Requirement: Summary metrics reflect JSON
The system SHALL set summary counts in `hrm_form_list.html` to match totals derived from `degsignUI.json` (total forms, done forms, remaining forms, and module count).

#### Scenario: Summary totals updated
- **WHEN** `degsignUI.json` lists modules and forms with statuses
- **THEN** the summary numbers in `hrm_form_list.html` equal the JSON-derived totals

### Requirement: Module sections match JSON modules
The system SHALL render one module section per JSON module with matching module name, module color, and form count.

#### Scenario: Module section count and headers
- **WHEN** a module exists in `degsignUI.json`
- **THEN** `hrm_form_list.html` contains a module header with the same name, color dot, and correct form count

### Requirement: Form cards mirror JSON form fields
Each form card SHALL reflect the JSON fields for `name`, `tables`, `description`, `layout`, and `status`.

#### Scenario: Card content and badges
- **WHEN** a form entry is read from `degsignUI.json`
- **THEN** its card shows the form name, tables list, description text, layout badge, and status badge/class consistent with the JSON values

### Requirement: Layout badge mapping is consistent
The system SHALL map layout values to badges as follows: `full_layout` -> Full layout badge, `tab_layout` -> Tab layout badge, `popup` -> Popup badge.

#### Scenario: Layout badge mapping
- **WHEN** a form has `layout = "popup"`
- **THEN** the card shows the Popup badge and no conflicting layout badge
