## ADDED Requirements

### Requirement: Aggregate form status from JSON
The system SHALL read `degsignUI.json` to summarize module and form statuses for planning purposes.

#### Scenario: Status aggregation
- **WHEN** the planning step runs
- **THEN** each module and form is included with its current status

### Requirement: Define design order and preview workflow
The system SHALL produce a design order list and mark forms that require HTML preview before implementation.

#### Scenario: Design order produced
- **WHEN** forms are categorized by complexity
- **THEN** a prioritized design list and preview-required subset are produced for approval

### Requirement: Implementation only after confirmation
The system SHALL only implement forms after user confirmation of the corresponding HTML preview.

#### Scenario: Confirmation gate
- **WHEN** a form is marked complex
- **THEN** implementation starts only after the user confirms its preview
