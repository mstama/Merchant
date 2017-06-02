# Merchant

### How to build

* [Install](https://www.microsoft.com/net/download/core#/current) .NET Core 1.1 
* In the project folder, where the **Merchant.csproj** is type: 

```
dotnet build -c release
```
### How to run

* Running using the project file. In the project folder, where the **Merchant.csproj** is type: 

```
dotnet run input.txt
```

* Running using the binary:

```
dotnet Merchant.dll input.txt
```

### Architecture

The solution is composed of:

* Converters : Responsible to convert the different number formats.
* Parser
* Command
* Calculators


