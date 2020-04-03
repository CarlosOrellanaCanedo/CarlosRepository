Feature: TestUpdateProfile

@mytag
Scenario: Update Account data in the Account page
	Given Login Blazor web page
		And go to MyProfile page
	When in the 'Account' page, set the following values:
		| UserName   | RealName        | Email              | KeepMyEmailAddressPrivate | Company     | Location |
		| Matt Damon | Carlos Orellana | Carlos@outlook.com | True                      | SoftCompany | Home     |
		
		And in the 'Account page, click on [Update] button
		And in the 'Update' popup, click on [OK] button
	Then in the 'Account' page the 'Account' span is displayed
	Then in the 'Account' page, validate the expected values in the form:
		| UserName   | RealName        | Email              | KeepMyEmailAddressPrivate | Company     | Location |
		| Matt Damon | Carlos Orellana | Carlos@outlook.com | True                      | SoftCompany | Home     |

@mytag
Scenario: Validate the Email is Required message is displayed when it's field is empty
	Given Login Blazor web page
		And go to MyProfile page
	When in the 'Account' page, set the following values:
		| UserName   | RealName        | Email | KeepMyEmailAddressPrivate | Company     | Location |
		| Matt Damon | Carlos Orellana |       | True                      | SoftCompany | Home     |
		And in the 'Account page, click on [Update] button
	Then in the 'Email' field, 'an Email is required' message is displayed when it is empty

@mytag
Scenario: Validate the Please provide a valid email addres message is displayed when it's field constains an invalid format
	Given Login Blazor web page
		And go to MyProfile page
	When in the 'Account' page, set the following values:
		| UserName   | RealName        | Email    | KeepMyEmailAddressPrivate | Company     | Location |
		| Matt Damon | Carlos Orellana | ad.fe.cs | True                      | SoftCompany | Home     |
		And in the 'Account page, click on [Update] button
	Then in the 'Email' field, 'Please provide a valid email address' message is displayed. When it is an invalid format

@mytag
Scenario: Validate the Delete account
	Given Login Blazor web page
		And go to MyProfile page
	When in the 'Account' page, select the Delete Account button
		And in the 'Delete Account' popup, select the Delete Account button
	Then in the 'Login' page, validate the 'Issues' span is displayed
