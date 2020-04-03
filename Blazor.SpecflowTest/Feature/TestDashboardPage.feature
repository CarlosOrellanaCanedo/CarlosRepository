Feature: TestDashboardPage

@mytag
Scenario: Validate the data interval in the dashboard page
	Given Login Blazor web page
	When go to Dashboard page
	When in the 'Dashboard' page, change the Data Interval to <dataInterval>
	Then in the 'Dashboard' page, the data interval was changed for <dataInterval>

Scenarios: 
	| dataInterval                     |
	| 1 Month                          |
	| 2 Weeks                          |
	| 1 Week                           |
	| Generate random data at interval |
