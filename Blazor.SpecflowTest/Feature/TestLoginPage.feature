Feature: LoginTestCase


@mytag
Scenario: Login Blazor Page
	Given Login Blazor web page
	When go to Dashboard page
	Then in the Dashboard page, validate Statistics text is displayed
