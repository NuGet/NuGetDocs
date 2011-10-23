# NuGet Overview

NuGet is a Visual Studio extension that makes it easy to add, remove, and update libraries and tools in 
Visual Studio projects that use the .NET Framework. If you develop a library or tool that you want to share
with other developers, you create a NuGet package and store the package in a NuGet repository. If you want to 
use a library or tool that someone else has developed, you retrieve the package from the repository and install
it in your Visual Studio project or solution.  

When you install the package, NuGet copies files 
to your solution and automatically makes whatever changes are needed, such as adding 
references and changing your app.config or web.config file. If you decide to remove the library, NuGet removes 
files and reverses whatever changes it made in your project so that no clutter is left.

## NuGet Packages

Everything necessary to install a library or tool is bundled into a package (a .nupkg file). A package 
includes files to copy to your project and a manifest file that describes the contents of the package 
and what needs to be done to add or remove the library. Packages are bundled into feeds that Visual 
Studio accesses in order to present lists of available packages. There is an official feed that is the 
default source for NuGet, and you can contribute to that feed or create your own feeds.

## NuGet User Interface in Visual Studio

NuGet runs in Visual Studio 2010, Visual Web Developer 2010, and Windows Phone Developer Tools 7.1. 
You can find, install, remove, and update packages by using the **Manage NuGet Packages** dialog box 
or by using PowerShell command-line commands in the **Package Manager Console** dedicated Visual Studio window. 
Both options are accessible from the Visual Studio main menu; you can 
also open the dialog box from a Solution Explorer context menu. 

### The Manage NuGet Packages Dialog Box

The following 
illustration shows the **Manage NuGet Packages** dialog box. Click on the **Online** tab to see 
packages available in the official feed.

![Manage NuGet Packages dialog](images/Manage-NuGet-Packages-Dialog.png)

For information about how to use the **Manage NuGet Packages** dialog box, see
[Using the Manage NuGet Packages Dialog Box](Managing-NuGet-Packages-Using-The-Dialog)

## The Package Manager Console Window

The following illustration shows the **Package Manager Console** window.

![Package Manager Console](images/package-console.png)

For information about how to use the Package Manager Console, see 
[Using the Package Manager Console](Using-the-Package-Manager-Console)

## Supported Operating Systems

The PowerShell cmdlets require PowerShell 
2.0. Therefore, NuGet requires one of the following operating systems:

* Windows 7
* Windows Vista SP1
* Windows Server 2008
* Windows Server 2008 R2
* Windows Server 2003 SP2
* Windows XP SP3

## Videos

<iframe width="640" height="390" src="http://www.youtube.com/embed/PboPfoptU2c?hd=1" frameborder="0" allowfullscreen></iframe>
