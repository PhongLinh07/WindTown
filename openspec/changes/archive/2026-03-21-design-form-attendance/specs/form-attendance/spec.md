## ADDED Requirements

### Requirement: FormAttendance layout follows Form Structure Standard
The system SHALL structure formAttendance into header, body, and footer sections using Design System Core spacing, radius, and typography tokens.

#### Scenario: Standard layout applied
- **WHEN** the formAttendance UI is rendered
- **THEN** it displays a header, body, and footer with spacing and typography consistent with AGENTS — Design Planning

### Requirement: Fields map to the formAttendance schema
The system SHALL render input controls for all fields defined for formAttendance in `degsignUI.json` and bind them to the UI.

#### Scenario: Schema fields rendered
- **WHEN** formAttendance loads with a defined schema
- **THEN** each schema field appears as a corresponding input control with the correct label

### Requirement: Required field validation is enforced
The system SHALL validate required fields for formAttendance and show an error state when a required field is empty or invalid.

#### Scenario: Required field missing
- **WHEN** a required field is left empty and the user attempts to save
- **THEN** the form shows a validation error and blocks saving

### Requirement: Preview and VB.NET designer parity
The system SHALL keep `preview_formAttendance.html` and the VB.NET designer layout visually consistent for structure and spacing.

#### Scenario: Preview matches VB.NET layout
- **WHEN** the preview and VB.NET form are compared
- **THEN** the section structure and spacing match within the defined design system tolerances
