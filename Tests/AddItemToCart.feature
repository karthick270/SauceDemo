Feature: AddItemToCart

Navigate to the webpage and add the highest price item in the cart


Scenario: Add highest price item to cart
	Given I go to sauce demo page
	When I login using to webpage
	And I select the highest price item and add to cart
	And I click add to shopping cart link
	Then I should see the hight price item added to cart
	