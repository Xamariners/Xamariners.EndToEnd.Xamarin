Feature: ScrollPage
	
Scenario: Scroll around the block tonight
	Given I am on "Main page" page
	And I can see "GoToScrollTest"
	When I tap on "GoToScrollTest" button
	Then I am on "Scroll Page" page
	And I can see "Baboon"
	When I scroll down to element "BottomButton"
	Then I can see "BottomButton"
	And I flash element "BottomButton"	
	When I scroll up to element "TopButton"
	Then I can see "TopButton"
	And I flash element "TopButton"	
	When I scroll to element "Mandrill"
	Then I can see "Mandrill"
	And I flash element "Mandrill"	