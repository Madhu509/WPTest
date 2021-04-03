Feature: RegistrationTest
I want to register user successfully 
	
Background: 
	Given I am on homepage 

@smoke
Scenario Outline: Registration with valid data
	And Click registration button
	When I submit user details for registration <login>,<first>,<last>,<password>,<cpasswprd>
	Then User should be registered successfully
	Examples: 
| login			| first	   |last	|password	 |cpasswprd		 |validData |
| ab1c@123abc.com|John	   |Lin		|Testing@1212|Testing@1212   |true      |
