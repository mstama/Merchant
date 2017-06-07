# Merchant

### How to build

* [Install](https://www.microsoft.com/net/download/core#/current) .NET Core 1.1 
* In the project folder, where the **Merchant.csproj** is, execute the following command: 

```
dotnet build -c release
```
### How to run

* Running using the project file. In the project folder, where the **Merchant.csproj** is, execute the following command: 

```
dotnet run input.txt
```

* Running using the binary. Execute the following command with the binary file:

```
dotnet Merchant.dll input.txt
```
### How to test

* Executing unit tests. In the unit tests project folder, where the **UnitTests.csproj** is, execute the following

```
dotnet test
```

### Architecture

The solution is composed of:

* Models
    * Command    : Meaningful information used to perform actions.
    * RomanNumber: Representation and meta-data of roman numbers.
* Services
    * Converters : Responsible for converting the different number formats.
    * Parser     : Responsible for creating commands from the user input.
    * Calculators: Responsible for calculating value of commodity.
    * Visitor    : Responsible for performing a specific action for a given command.
* Interfaces     : Services are implemented using interfaces to be extensible.

The main program is composed of:

* Composition Root: where all modules are put together.
* Execution of the command parser.
* Execution of the visitor of the command.

Highlights:
* Extensibility: main modules are provided with an interface so it can be replaced in the composition root for evolution.
* Separation of concerns.

[GitHub Project Repository](https://github.com/mstama/Merchant)