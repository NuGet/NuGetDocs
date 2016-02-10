# NuGet Overview

NuGet is the package manager for the Microsoft development platform including .NET. The NuGet client tools provide the ability to produce and consume packages. The [NuGet Gallery](http://nuget.org) is the central package repository used by all package authors and consumers.

When you install a package, NuGet copies files to your solution and automatically makes whatever changes are needed, such as adding references and changing your app.config or web.config file. If you decide to remove the library, NuGet removes files and reverses whatever changes it made in your project so that no clutter is left.

## NuGet Packages

Everything necessary to install a library or tool is bundled into a package (a `.nupkg` file). A package 
includes files to copy to your project and a manifest file that describes the contents of the package 
and what needs to be done to add or remove the library. Packages are bundled into feeds that Visual 
Studio accesses in order to present lists of available packages. There is an official feed that is the 
default source for NuGet, and you can contribute to that feed or create your own feeds.

## NuGet User Interface in Visual Studio

NuGet runs in all versions and SKUs of Visual Studio 2010, Visual Studio 2012 and Visual Studio 2013. 
For Visual Studio 2012 and Visual Studio 2013, NuGet is shipped in-the-box. For Visual Studio 2010, NuGet can be downloaded 
from the [Visual Studio Extension Gallery] (http://visualstudiogallery.msdn.microsoft.com/27077b70-9dad-4c64-adcf-c7cf6bc9970c).

You can find, install, remove, and update packages by using the [**Manage NuGet Packages**] (/Consume/Package-Manager-Dialog) dialog box 
or by using PowerShell command-line commands in the [**Package Manager Console**] (/Consume/Package-Manager-Console) dedicated Visual Studio window. 
Both options are accessible from the Visual Studio main menu. You can 
also open the dialog box from a Solution Explorer context menu. 

## Supported Operating Systems

The PowerShell cmdlets require PowerShell 
2.0. Therefore, NuGet requires one of the following operating systems:

* Windows 10
* Windows 8 or 8.1
* Windows 7
* Windows Vista SP1
* Windows Server 2012 R2
* Windows Server 2012
* Windows Server 2008
* Windows Server 2008 R2
* Windows Server 2003 SP2
* Windows XP SP3
