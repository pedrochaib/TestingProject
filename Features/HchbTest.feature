Feature: HchbTest

Scenario: Verify Error Messages In Form
Given the browser is opened in Google homepage
And I input "Selenium HQ" on the Google search box
And I clear the Google search box
And I input "HCHB" on the Google search box
And I hit the Google search button
When I select the result with the link "https://hchb.com/"
Then the page presented contains the URL "https://hchb.com/"
When I click on the button Request Demo
Then the page presented contains the URL "https://hchb.com/request-demo/"
When I fill the form with the following information
| First Name | Last Name | Email              | Phone      | Role     | Company     | City     | State | Census      |
| Test       | User      | testuser@gmail.com | 1234567890 | Clinical | TestCompany | TestCity | DE    |             |
And I click on the button Submit
Then the error message "Please correct the errors beelow:" is displayed
Then the field "Services" contains the error message This field is required
And the Invalid CAPTCHA error message is presented