## ADDED Requirements

### Requirement: Update form status list and add formMainV2
The system SHALL update `degsignUI.json` so that form statuses match the provided completed/pending lists and SHALL add a `formMainV2` entry marked done.

#### Scenario: Status update applied
- **WHEN** the completed and pending form lists are applied
- **THEN** each form in `degsignUI.json` reflects the specified status and `formMainV2` exists with status `done`

### Requirement: Sync HTML after JSON update
The system SHALL regenerate `hrm_form_list.html` to reflect the updated JSON statuses and include `formMainV2` as done.

#### Scenario: HTML reflects updated statuses
- **WHEN** `degsignUI.json` is updated
- **THEN** `hrm_form_list.html` shows the updated done/pending badges and counts including `formMainV2`
