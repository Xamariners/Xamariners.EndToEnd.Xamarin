Feature: EntryToLabelPage

Scenario: Changing label text
	Given I am on "Main page" page
	And I can see "GoToEntryToLabelTest"
	When I tap on "GoToEntryToLabelTest" button
	Then I am on "Entry and Label" page
	Then I can see "TextEntry"
	And I can see "TextButton"
	And I can see "TextLabel"
	When I enter "Hello there!" on entry "TextEntry"
	And I tap on "TextButton" button
	Then I can see label "TextLabel" text "Hello there!"