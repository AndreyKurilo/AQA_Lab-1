﻿Feature: GherkinDatabaseEmployeesTest
	Verify possibility getting, adding, deleting employees

Scenario: Employees operations
	Given Setting up Connection
	And Count of employees equal 4
	When Add employee to list
	Then Count of employees increases on 1
