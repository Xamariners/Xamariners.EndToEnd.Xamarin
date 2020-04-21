Feature: EntryToLabelPage

Scenario: Changing label text
	Given I am on "Main page" page
	And I can see "GoToEntryToLabelTest"
	Then I tap on "GoToEntryToLabelTest" button
	And I am on "Entry to label text" page
	Then I can see "TextEntry"
	And I can see "TextButton"
	And I can see "TextLabel"
	When I enter "Hello there!" on entry "TextEntry"
	And I tap on "TextButton" button
	Then The label "TextLabel" text is "Hello there!"