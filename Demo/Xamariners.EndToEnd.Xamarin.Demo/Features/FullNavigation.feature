Feature: FullNavigation

Scenario: Do eveything 
	Given I am on "Main page" page
	And I can see "GoToClickCountTest"
	Then I tap on "GoToClickCountTest" button
	And I am on "Click Count" page
	Then I can see "CountButton"
	When I tap on "CountButton" button
	Then I can see "Clicked 1 times"
	And The label "ClickCountLabel" text is "Clicked 1 times"
	When I tap on "CountButton" button
	Then I can see "Clicked 2 times"
	And The label "ClickCountLabel" text is "Clicked 2 times"
	When I tap on "CountButton" button
	Then I can see "Clicked 3 times"
	And The label "ClickCountLabel" text is "Clicked 3 times"
	Then I navigate back
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
	When I navigate back
	Then I am on "Main page" page