Feature: SkillsFeature

As i log in to Mars-QA i would like to add details of skills i possess as well as update and delete those skills 


Scenario Outline: 01-As a Mars-QA user i would like to add skills i possess 
	Given I have successfully logged in to Mars url
	And I have navigated to Skills page
	When I  add '<Skill>', '<Level>' to my Skills section on my profile page 
	Then Should be able to successfully add '<Skill>', '<Level>' to Skills section on my profile page 
	
	Examples: 
	| Skill      | Level        |
	| Swimming   | Intermediate |
	| Dancing    | Expert       |
	| Chesscoach | Intermediate |

Scenario Outline: 02-As a Mars-QA user i would like to update exisiting skills on my Skills section
	Given I have successfully logged in to Mars url
	And I have navigated to Skills page
	When I update exisitng '<Skill>', '<Level>' on  Skills section on my profile page
	Then Should be able to successfully update existing '<Skill>', '<Level>' to Skills section

	Examples: 
	| Skill      | Level        |
	| Swimming   | Expert       |
	| Chesscoach | Intermediate |

Scenario Outline: 03-As a Mars-QA user i would like to delete existing skills on my Skills section
	Given I have successfully logged in to Mars url
	And I have navigated to Skills page
	When I delete existing '<Skill>', '<Level>' on my Skills section
	Then Should be able to successfully delete existing '<Skill>', '<Level>' on Skills section of my profile page 

	Examples: 
	| Skill    | Level  |
	| Swimming | Expert |