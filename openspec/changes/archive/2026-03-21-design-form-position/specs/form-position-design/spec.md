## ADDED Requirements

### Requirement: Popup layout structure for formPosition
The preview for formPosition MUST use popup layout with header, body, and footer sections.

#### Scenario: Popup structure rendered
- **WHEN** the preview page loads
- **THEN** the layout shows a header, a scrollable body, and a footer action area

### Requirement: Design System Core variables applied
The preview MUST use the Design System Core variables (colors, spacing, typography) defined in `AGENTS.md`.

#### Scenario: CSS variables available
- **WHEN** the preview stylesheet is loaded
- **THEN** the `:root` variables for bg, card, fg, accent, border, success, warn, danger are defined

### Requirement: Form fields for position mapping
The preview MUST include form fields that represent position mapping to contract and salary multiplier.

#### Scenario: Core fields visible
- **WHEN** the user opens the formPosition preview
- **THEN** the form displays fields for position name, contract, salary multiplier, and status

### Requirement: Mock data and render logic
The preview MUST contain mock data and a render function to simulate data binding.

#### Scenario: Mock data rendered
- **WHEN** the preview loads
- **THEN** sample data is rendered into the fields and list elements

### Requirement: QA checklist coverage
The preview MUST satisfy QA checklist items: alignment, spacing scale, hover/focus, and empty state.

#### Scenario: QA checks visible
- **WHEN** the preview is reviewed
- **THEN** labels align with inputs, spacing follows scale, focus states are visible, and empty states are present
