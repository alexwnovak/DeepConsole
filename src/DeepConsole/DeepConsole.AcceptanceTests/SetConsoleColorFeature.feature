Feature: SetConsoleColorFeature
   As a terminal user
   I want to set custom colors
   So I can have a personalized terminal experience

@Acceptance
Scenario: Set a custom color
   When I call SetConsoleColor with index 1 and color red
   Then console color 1 should be red
