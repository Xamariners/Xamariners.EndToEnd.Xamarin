Feature: FullNavigation


Scenario: Do eveything 
	Given I am on "Main page" page
	And I can see "GoToClickCountTest"
	Then I tap on "GoToClickCountTest" button
	And I am on "Click count" page
	Then I can see "CountButton"
	When I tap on "CountButton" button
	Then I can see "You clicked 1 time on the button"
	And The label "ClickCountLabel" text is "You clicked 1 time on the button"
	When I tap on "CountButton" button
	Then I can see "You clicked 2 times on the button"
	And The label "ClickCountLabel" text is "You clicked 2 times on the button"
	When I tap on "CountButton" button
	Then I can see "You clicked 3 times on the button"
	And The label "ClickCountLabel" text is "You clicked 3 times on the button"
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