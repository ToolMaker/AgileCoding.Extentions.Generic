AgileCoding.Extensions.Generic
==============================

Overview
--------

AgileCoding.Extensions.Generic is a .NET library that provides enhanced functionality for handling generic objects in your .NET applications. This package offers a collection of extension methods that facilitate better management and manipulation of generic types.

Installation
------------

This library is available as a NuGet package. You can install it using the NuGet package manager console:

bashCopy code

`Install-Package AgileCoding.Extensions.Generic -Version 2.0.5`

Features
--------

The library introduces the following extension methods for generic types:

1.  ThrowIfNull: Throws an exception if the object is null.
2.  ThrowIfNullOrEmpty: Throws an exception if the array or list is null or empty.
3.  SplitYield and Split: Splits a list into blocks of a given size.
4.  ThrowIfTrue: Throws an exception if the boolean is true.
5.  InitIfNull: Initializes a null object.

Usage
-----

Here's a brief example of how to use these features in your code:

csharp
```
using AgileCoding.Extentions.Generics;
using System;
using System.Collections.Generic;

try
{
    // Your code here...
    List<int> list = new List<int>();
    list.ThrowIfNullOrEmpty<int, Exception>("List is empty or null");
    var blocks = list.Split<int>(5);
}
catch (Exception ex)
{
    // Handle or log the exception...
}
```

Documentation
-------------

For more detailed information about the usage of this library, please refer to the [official documentation](https://github.com/ToolMaker/AgileCoding.Extentions.Generic/wiki).

License
-------

This project is licensed under the terms of the MIT license. For more information, see the [LICENSE](https://github.com/ToolMaker/AgileCoding.Extentions.Generic/blob/main/LICENSE) file.

Contributing
------------

Contributions are welcome! Please see our [contributing guidelines](https://github.com/ToolMaker/AgileCoding.Extentions.Generic/blob/main/CONTRIBUTING.md) for more details.