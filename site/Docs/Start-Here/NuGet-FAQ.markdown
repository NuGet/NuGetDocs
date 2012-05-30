# NuGet Frequently Asked Questions

## What is required to run NuGet?

NuGet requires Visual Studio 2010 or Visual Web Developer Express 2010.
The NuGet Package Manager Console requires that [PowerShell 2.0](http://support.microsoft.com/kb/968929) be installed. 
Powershell 2.0 is already installed if you have the following operating system:

* Windows 7 
* Windows Server 2008 R2 

If you have the following operating systems, you must [manually install Powershell 2.0](http://support.microsoft.com/kb/968929/en-us).

* Windows XP SP3 
* Windows Server 2003 SP2 
* Windows Vista SP1 
* Windows Server 2008 

## Do I have to install ASP.NET MVC 3 to get NuGet?

**Not at all**. For information about how to install NuGet without MVC 3, see [Installing NuGet](Installing-NuGet).

## Why does the Package Manager Console or the Manage NuGet Packages dialog box crash or show an exception?

Check the [Known Issues](../Reference/Known-Issues) page. Typically, the issue is due to having an older version of the Reflector add-in installed or not having PowerShell 2.0 installed (as in the case of Windows XP).

## How do I get my package in the feed?

See the [Creating and publishing a package](../creating-packages/creating-and-publishing-a-package) page.

## What is the difference between a project-level package and a solution-level package?

A solution-level package has to be installed only once in a solution to be available for all projects in the solution. 
A project-level package must be installed separately in each project where you want to use it.
For solution-level packages, NuGet doesn't change anything in a project, whereas in a project-level package it does. 
Typically, a solution-level package installs new commands that can be called from within the **Package Manager Console** window.

## I have multiple versions of my library that target different versions of the .NET Framework. How do I build a single package that supports this?

See the section titled "Supporting Multiple .NET Framework Versions and Profiles" in [Creating a Package](http://nuget.codeplex.com/wikipage?title=Creating a Package#supporting-multiple-framework-versions).

## How do I check the exact version of NuGet installed?

In Visual Studio go to the _Help_ > _About Microsoft Visual Studio_ menu and look for NuGet Package Manager. The version is 
displayed next to that entry.

![NuGet Version in the Visual Studio Extension Manager](images/nuget-version.png)

Alternatively, you can launch the Package Manager Console and type in `$host` to output information about NuGet 
Powershell host including the version.

## How do I get access to the DTE object in the Package Manager console?

The console provides a variable named `$DTE` that returns the `DTE` object. See the `Get-Project` command in 
[Package Manager Console Powershell Reference](../Reference/Package-Manager-Console-PowerShell-Reference).

## Why do I get an "Unable to resolve dependency error" when installing a local package with remote dependencies?

**Select the *All* node when installing your local package.** The *all** node aggregates all the feeds. 
When you select a specific repository under the Online tab, that restricts installation to just that node. 
The reason for this behavior is that in many cases, users of a local repository don't want to accidentally 
install a remote package due to corporate polices.

## I try to cast the $DTE variable to the type DTE2, but I get an error: Cannot convert the "EnvDTE.DTEClass" value of type "EnvDTE.DTEClass" to type "EnvDTE80.DTE2". What's wrong?

This is a known issue with how PowerShell interacts with a COM object. Try the following:
`$dte2 = Get-Interface $dte ([EnvDTE80.DTE2])`
`Get-Interface` is a helper function added by the NuGet PowerShell host.

## How do I set up a local repository or feed?
See [Hosting Your Own NuGet Feeds](../Creating-Packages/Hosting-Your-Own-NuGet-Feeds).

## Does NuGet work with Nu Gems, or does NuGet supersede Nu Gems?

**Sorry, no. But keep reading.** NuGet does not work with Nu Gems directly, because NuGet uses its own package format 
(based on OPC) and cannot read *.gemspec* files directly. In essence, NuGet can be considered Nu Gems Version 2 and an 
evolution of package management for Visual Studio and the .NET Framework platform.
If you liked the Nu behavior of dealing with packages, 
note that NuGet.exe behaves very similarly for those who want to 
use NuGet outside of Visual Studio.

## Does NuGet support Mono?

The command-line application (*nuget.exe*) builds and runs under Mono and allows you to create packages in Mono.
This is especially true for Mono on Windows, but there are some known issues for Mono on Linux and OS X.  To review
the known issues, [search for Mono in our issue list](http://nuget.codeplex.com/workitem/list/basic?field=Votes&direction=Descending&issuesToDisplay=Open&keywords=mono&emailSubscribedItemsOnly=false).

## Is there a command-line tool for NuGet?

**Yes there is!** See David Ebbo's Blog post entitled [Installing NuGet Packages directly from the command line](http://blog.davidebbo.com/2011/01/installing-nuget-packages-directly-from.html).

Keep in mind that the focus of NuGet is to let you modify your projects and add references to Visual Studio projects. 
The command line tool, NuGet.exe, will download and unpack packages, but it won't automate Visual Studio and 
modify your project files.
Within Visual Studio, there are two clients for NuGet: 
the PowerShell-based **Package Manager Console** and the **Manage NuGet Packages** dialog box. 
Both are wrappers around the NuGet API, which is written in managed code.
NuGet.exe is also used to create and publish packages.

## What languages are supported by NuGet?

NuGet currently supports C#, F# and Visual Basic projects.

## Can I use NuGet outside of Visual Studio?

**You sure can!** As discussed in the question on command line tools for NuGet, the primary focus 
of NuGet is Visual Studio, but the core NuGet API has no dependencies on Visual Studio. 
There are multiple NuGet clients that work completely outside of Visual Studio:

* [SharpDevelop Alpha](http://community.sharpdevelop.net/blogs/mattward/archive/2011/01/23/NuGetSupportInSharpDevelop.aspx). (See a demo of this in [Phil Haack's MvcConf talk](http://bit.ly/fzrJDa).) 
* ASP.NET Web Pages in WebMatrix. (See a demo of this in [Phil Haack's MvcConf talk](http://bit.ly/fzrJDa).) 
* [NuGet.exe](http://blog.davidebbo.com/2011/01/installing-nuget-packages-directly-from.html) 