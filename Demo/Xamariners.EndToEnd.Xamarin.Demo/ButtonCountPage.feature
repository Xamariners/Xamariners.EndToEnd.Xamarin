Feature: ButtonCountPage
	In order to keep track of the times i press that great button
	As a user
	I want to test that fantastic button

Scenario: Tapping 3 times on the button
	Given I am on "Main page" page
	And I can see "GoToClickCountTest"
	When I tap on "GoToClickCountTest" button
	Then I am on "Click Count" page
	And I can see "CountButton"
	When I tap on "CountButton" button
	Then I can see "Clicked 1 times"
	And The label "ClickCountLabel" text is "Clicked 1 times"
	When I tap on "CountButton" button
	Then I can see "Clicked 2 times"
	And The label "ClickCountLabel" text is "Clicked 2 times"
	When I tap on "CountButton" button
	Then I can see "Clicked 3 times"
	And The label "ClickCountLabel" text is "Clicked 3 times"
