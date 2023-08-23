Feature: NegativeFeature

As I login Mars-QA application
I would like to add ,update and delete language details in languages and existing skills 
So that I can manage language details successfully 


Scenario Outline:01- Adding a invalidlanguage to user profile
	Given I have successfully logged into Mars-QA 
	When I Add invalid language '<Language>','<Level>' into user profile 
	Then Invalid language should not be added '<Language>','<Level>' 

	Examples: 
	| Language | Level                 |
	|          | Basic                 |
	| Sinhala   | Basic                 |
	|          | Choose Language Level |
	| Hindi    | Choose Language Level |
	
	Scenario Outline:02- Update the invalidlanguage to user profile
	  Given I have successfully logged into Mars-QA 
	  When I Update invalid language '<Language>','<Level>' into user profile
	  Then Invalid language should not be updated '<Language>','<Level>'
	  
	  Examples: 
	  | Language | Level                 |
	  |          | Basic                 |
	  | Sinhala  | Basic                 |
	  |          |Language Level         |
	  | Hindi    |Language Level         |

	