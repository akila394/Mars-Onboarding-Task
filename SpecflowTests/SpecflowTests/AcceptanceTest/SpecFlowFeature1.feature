Feature: SpecFlowFeature1
	In order to update my profile 
	As a skill trader
	I want to add the languages that I know

@mytag
Scenario: Check if user could able to add a language 
	Given I clicked on the Language tab under Profile page
	When I add a new language
	Then that language should be displayed on my listings

Scenario: Check if user could able to delete a language
	Given I added a Language under profile page
	When I click on delete button on that language
	Then Message should be displayed and language should be removed from the profile

Scenario: Check if user could able to add a skill 
	Given I clicked on the Skills tab under Profile page
	When I add a new skill
	Then that skill should be displayed on my listings
	
Scenario: Check if user could able to delete a skill
	Given I added a skill under profile page
	When I click on delete button on that skill
	Then Message should be displayed and skill should be removed from my listings

Scenario: Check if user could able to add a Education 
	Given I clicked on the Education tab under Profile page
	When I add a new Education
	Then that Education should be displayed on my listings

Scenario: Check if user could able to delete a Education
	Given I added a Education under profile page
	When I click on delete button on that Education
	Then Message should be displayed and Education should be removed from the profile

Scenario: Check if user could able to add a Certification 
	Given I clicked on the Certification tab under Profile page
	When I add a new Certification
	Then that Certification should be displayed on my listings

Scenario: Check if user could able to delete a Certification
	Given I added a Certification under profile page
	When I click on delete button on that Certification
	Then Message should be displayed and Certification should be removed from the profile

Scenario: Check if user could able to add a Description 
	Given I clicked on the Description tab under Profile page
	When I add a new description and click save button
	Then that description should be displayed in profile

Scenario: Check if user could able to add a Availability 
	Given I clicked on the availability tab under Profile page
	When I select availability from drop down list
	Then that availability should be displayed in profile

Scenario: Check if user could able to add number of hours available 
	Given I clicked on the hours tab under Profile page
	When I select hours from drop down list
	Then that hours should be displayed in profile

Scenario: Check if user could able to add Earn Target 
	Given I clicked on the earn target tab under Profile page
	When I select target from drop down list
	Then that target should be displayed in profile