Feature: LanguageFeature

As i login to Mars-QA
I would like to add maximum of  lanuages i speak , edit those languages and edit those languages 
So i can manage my language details on Mars profile 



Scenario Outline: 01-As a Mars user i should be able to add maximum of 4 languages i can speak
	Given User has successfully logged in to Mars url
	When I add '<Language>' , '<Level>' to my user profile
	Then Should be able to successfully add '<Language>' , '<Level>'to my user profile

	Examples: 
	| Language	|Level|
	| Sinhalese	|Native/Bilingual|
	| English	|Fluent|
	| Hindi		|Conversational|
	| French	|Basic|

Scenario Outline: 02-As a Mars user i should be able to edit  languages details  i have already added to my user profile
	Given User has successfully logged in to Mars url
	When I edit exisitng '<Language>', '<Level>' listed on  my user profile
	Then Should be able to successfully edit '<Language>' ,'<Level>' listed on my user profile 

	Examples: 
	| Language| Level|
	| French	| Native/Bilingual|
	| Tamil	|Fluent	|
	| Hindi	|Fluent	|
	| sp#gh	|Basic	|


Scenario Outline: 03-As a Mars user i should be able to delete any language i have already added to my user profile
	Given User has successfully logged in to Mars url
	When I delete existing  '<Language>' , '<Level>'  on  my user profile 
	Then Should be able to successfully delete a selected '<Language>' , '<Level>'  from my user profile 

	Examples: 
	|Language	|Level|
	| sp#gh		|Basic|
