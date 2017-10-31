Infobip API C# client
======================

Prerequisites
--------------

.NET framework 4.5 or above is required to use this library.

Installation
-------------

It is recommended that you install the Infobip API C# client via NuGet Package Manager. Simply search the
Manager for "Infobip API C# client" and install it in your project to be able to access its features.
Additional instructions on how to access and use the NuGet Package Manager and install a package are available
on the [official Microsoft documentation page](https://docs.microsoft.com/en-us/nuget/tools/package-manager-ui).


Manual dependency management
-----------------------------

If you choose not to use the NuGet Package Manager, you can also clone this repository and reference the
InfobipClientLib project directly. Another way would be to build it in a .dll file, place it wherever you
like in your project and reference it that way.

Examples
---------

The Infobip API C# client solution also comes with the InfobipClientExamples project, where you can see, test,
change and run examples of some of the common uses of the Infobip API. For more details, please refer to the
[official documentation](https://dev.infobip.com/).

Running examples
-----------------

The examples can be run by uncommenting them in the ExampleRunner class and running it. Before that, make sure
to type in your credentials and desired phone number(s) destination(s) into the Example class.

License
--------

This library is licensed under the [Apache License, Version 2.0](http://www.apache.org/licenses/LICENSE-2.0)