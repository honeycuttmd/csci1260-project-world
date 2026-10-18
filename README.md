
# CSCI 1260 Project 1: Happy Tails Rescue Center

**Name:** Madison Honeycutt  
**Section:** 002  
**World:** Happy Tails Animal Rescue Center  
**Language:** C#

## About This Project

HappyTails is a console application that models an animal rescue center. It manages animal intake records, treatment histories, adoption information, and condition updates. The project demonstrates object-oriented programming concepts including classes, encapsulation, inheritance, abstraction, polymorphism, interfaces, aggregation, composition, equality, sorting, exception handling, and file logging.

## How to Run

Open the HappyTails project in Visual Studio and run the program. The application automatically reads animal information from `data.txt` and prints the five required demonstration groups to the console. It handles invalid records without stopping, displays animal reports and sorting results, and creates a `rescue_log.txt` file in the application's output directory.

## UML Diagram

The UML class diagram is located in `docs/uml.pdf`. It shows the class hierarchy, interfaces, properties, methods, and aggregation and composition relationships.

## Aggregation and Composition Design Question

The aggregation relationship is between `RescueCenter` and `RescueAnimal`. Animals are created in `Program.cs` and passed into the rescue center through `Add()`. Because the rescue center does not create or own the lifetime of these animals, they can still exist independently if the rescue center is removed. To change this relationship to composition, `RescueCenter` would need to create and manage the animals internally instead of receiving existing animal objects.

The composition relationship is between `RescueAnimal` and `CareNote`. The animal creates and stores its own care notes through `AddCareNote()`, so the notes belong to that animal's treatment history. When the animal is removed and no references to its notes remain, the notes are no longer accessible through the system. To change this relationship to aggregation, `CareNote` objects could be created outside the animal and passed into `AddCareNote()` instead of being constructed inside the animal.

## Interface Design Question

The custom `IAdoptable` interface defines `AdoptionFee` and `GetAdoptionProfile()` for animals that can be adopted. It is implemented by `Dog`, `Cat`, `Rabbit`, and `Turtle`, which do not all share the same immediate parent class. This behavior does not belong in `RescueAnimal` because not every rescue animal is adoptable, such as `Owl`, which is being rehabilitated for release. Using an interface allows the rescue center to work with different adoptable animal types without requiring adoption behavior from every animal.

## Adding a New Animal Type Design Question

To add a new animal type, I would create a new `.cs` file containing a class that inherits from `RescueAnimal` or `CompanionMammal`, depending on the animal. The new class would implement the required abstract methods, including `CreateTreatmentSummary()` and `GetDailyCareInstructions()`, and override `Describe()` while calling `base.Describe()`. If the animal is adoptable, it would also implement `IAdoptable`.

I would then update `Program.cs` to recognize the new animal type when reading `data.txt`, add the appropriate constructor call, and update the UML diagram. **The manager class, `RescueCenter`, would not change.** It already accepts any `RescueAnimal` through `Add()` and uses `IAdoptable` for adoption-related behavior, so adding another animal type does not require changing the manager.

## Unfinished Work

None.