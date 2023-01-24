Oreilly
2022
Vlad Khononov
Aligning software architecture and business strategy

# Chapter 6 Tackling Complex Business Logic
The domain model pattern

The patterns that Evans introduced are often referred t oas tactical domain-driven design

## Domain Model
The domain model pattern is intended to cope with cases of complex business logic. Here, instead of CRUD interfaces, we deal with complicated state transitions, business rules, and invariants: rules that have to be
protected at all times.

A domain model is an object model of the domain that incorporates both behavior and data. DDD’s tactical patterns—aggregates, value objects, domain events, and domain services—are the building blocks of such an object model.

### Complexity
The domain’s business logic is already inherently complex, so the objects used for modeling it should not introduce any additional accidental complexities. The model should be devoid of any infrastructural or
technological concerns, such as implementing calls to databases or other external components of the system.

### Ubiquitous language
The emphasis on business logic instead of technical concerns makes it easier for the domain model’s objects to follow the terminology of the bounded context’s ubiquitous language. In other words, this pattern allows the code to “speak” the ubiquitous language and to follow the domain experts’ mental models.

### Building Blocks
The central domain model building blocks, or tactical patterns, offered by DDD: value objects, aggregates, and domain services.
#### Value object
- an object that can be identified by the composition of its values
- ubiquitous language: the primitive obsession code smell 
	- it presents multiple design risks
		- the validation logic tends to be duplicated
		- it's hard to enforce calling the validation logic before the values are used
		- it will become more challenging when the codebase will be evolved by other engineers
	- the opposite has advantages:
		- increased clarity
		- no need to validate the values before the assignment, as the validation logic resides in the value objects themselves
		- value object can implement cohesive logic, and because it is in one place it is easy to test
		- value objects express the business domain's concepts


#### Aggregates

#### Domain services
