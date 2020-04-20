Feature: ButtonCount
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of taps

Scenario: Tapping 3 times on the button
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
