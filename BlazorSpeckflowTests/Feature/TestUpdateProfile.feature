Feature: TestUpdateProfile
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given Login Blazor web page
	And go to MyProfile page
	When update my Account information:
		| fields    | values             |
		| user name | Matt Damon         |
		| real name | Carlos Orellana    |
		| email     | Carlos@outlook.com |
		
	Then is account page displayed
