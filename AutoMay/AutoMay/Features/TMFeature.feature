Feature: TMFeature

As a TurnUp Portal admin
I would like to create, edit and delete time and material records 
So i can manage employee time and material successfully

@tag1
Scenario: Create time and material records with valid details 
	Given I logged in to Turn Up portal successfully 
	When Navigate to Time & material page
	And Create a new Time & Material record 
	Then New time and material record should be created successfully 
