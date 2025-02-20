Feature: Increment Counter

Simple counter incremental by clicking a button

Rule: The counter can be incremented by pressing a button


Scenario: Default counter value
	Given a counter object is initialized
	When the counter button is clicked 0 times
	Then the current counter should be 0


Scenario: Increment counter 3 times
	Given a counter object is initialized
	When the counter button is clicked 3 times
	Then the current counter should be 3