# TNCS Powered by SuperSistem (https://www.supersistem.com )
A C# library for interacting with the Turtle Network blockchain

Supports node interaction, offline transaction signing, Matcher orders, and creating addresses and keys.

## Getting Started

You can install TNCS [NuGet package](https://www.nuget.org/packages/TNCS_SSYS/1.0.0.4) and add it to your project's References and in your code as:
```
using TNCS;
```

For installation NuGet package from VS Package Manager Console you should use:
```
PM> Install-Package TNCS_SSYS -Version 1.0.0.4
```

For installation via UI Package Manager use this [instruction](https://docs.microsoft.com/en-us/nuget/tools/package-manager-ui).

Target framework .NET Framework 4.5.1
## Documentation

The library utilizes classes to represent various TN data structures and encoding and serialization methods:

- TNCS.Node
- TNCS.Order
- TNCS.OrderBook
- TNCS.PrivateKeyAccount
- TNCS.Transaction
- TNCS.AddressEncoding
- TNCS.Base58
- TNCS.Utils


#### Code Example
Code examples are in [TNCSTests](https://github.com/bulentustbas/TNCS/tree/master/TNCSTests) project.

### Source code
[TNCS Github repository](https://github.com/bulentustbas/TNCS)
