```gherkin
Feature: Adding a product to the cart
  As a user of the online store
  I want to be able to add products to my cart
  In order to complete my purchase

Scenario: Adding a single product to the cart
	Given the following product data:
	| name | price |
	| product1 | $10 |
	| product2 | $20 |
	When I add "product1" to my cart
	Then the cart total should be "$10"
	And the number of items in the cart should be "1"
```