#NuGet Tools

The following tools will help you build, publish and consume nuget packages.

##NuGet.exe Command-line Tool
This utility can be used to create, publish, and download packages.<br>
<a href="#nuget-compatibility">NuGet Compatibility</a>

###How do I get NuGet.exe?
<ol>
<li>1. Download the latest version from <a href="https://nuget.org/downloads">https://nuget.org/downloads</a> and save the file to a path of your choice.</li>
<li>2. Add this path to the PATH Environment Variable.</li>
</ol>

<div class="block-callout-warning">
	<strong>NuGet 2.x users</strong><br>
    Because there are a few breaking changes introduced in NuGet 3.2 <a href="https://nuget.org/nuget.exe">https://nuget.org/nuget.exe</a> points to the latest stable NuGet 2.x release to prevent CI systems from potentially breaking at this time.
</div>

Other options:

* Install the [NuGet.CommandLine](http://www.nuget.org/packages/NuGet.CommandLine/) package from the NuGet Visual Studio client and either move nuget.exe to a common location or execute it in the context of your project.
* Install the [NuGet.CommandLine](http://chocolatey.org/packages/NuGet.CommandLine) Chocolatey package using the Chocolatey client. More information on Chocolatey can be found at [http://chocolatey.org].


####Try out some scenarios
*  [Creating a package](https://docs.nuget.org/Create/Creating-and-Publishing-a-Package#creating-a-package)
*  [Publishing a Package](https://docs.nuget.org/Create/Creating-and-Publishing-a-Package#publishing-using-nuget-command-line)

####References
* [NuGet CLI commands](https://docs.nuget.org/consume/command-line-reference)

##NuGet Package Manager extension in Visual Studio
Starting with Visual Studio 2012, NuGet is included in every edition (except Team Foundation Server).. This extension includes the package manager UI and the package manager console.

If your copy of Visual Studio does not already have the NuGet Package Manager extension, you can install it using the Extension Manager.<br>
<ol>
<li>1. In Visual Studio, click Tools and then Extension and Updates.</li>
<li>2. Navigate to Online, search for "NuGet Package Manager for Visual Studio" and click Download.</li>
<li>3. In the Installer dialog box, click Install.</li>
<li>4. When installation is complete, close and re-open Visual Studio.</li>
</ol>


###Package Manager UI
The package manager UI allows you to find, install, remove, and update NuGet packages.

####Try out some scenarios
* [Finding and installing a package](http://docs.nuget.org/Consume/Package-Manager-Dialog#managing-nuget-packages-using-the-dialog)</li>
* [Removing a package](http://docs.nuget.org/Consume/Package-Manager-Dialog#removing-a-package)</li>
* [Updating a Package](http://docs.nuget.org/Consume/Package-Manager-Dialog#updating-a-package)</li>


###Package Manager Console
The package manager console allows you to find, install, remove, and update NuGet packages using PowerShell commands. Some packages sets up tools during install which can be accessed through the package manager console.

<div class="block-callout-warning">
	<strong>Note</strong><br>
    Package Manager Console commands do not work outside of visual studio since it is dependent on VS objects like DTE to work correctly.
</div>

The NuGet Package Manager Console requires that [PowerShell 2.0](http://support.microsoft.com/kb/968929) be installed. 
Powershell 2.0 is already installed if you have the following operating systems:

* Windows 7 (or newer)
* Windows Server 2008 R2 (or newer)

If you have the following operating systems, you must [manually install Powershell 2.0](http://support.microsoft.com/kb/968929/en-us).

* Windows XP SP3 /Windows Vista SP1
* Windows Server 2003 SP2/ Windows Server 2008



####Try out some scenarios
* [Removing a package](https://docs.nuget.org/Consume/Package-Manager-Console#removing-a-package)</li>
* [Updating a Package](https://docs.nuget.org/Consume/Package-Manager-Console#updating-a-package)</li>


####References
* [Package Manager Console Powershell Commands](https://docs.nuget.org/consume/package-manager-console-powershell-reference)
* [Setting up a NuGet Powershell Profile](https://docs.nuget.org/Consume/Setting-up-NuGet-PowerShell-Profile.md)</li>

###Updating the NuGet extension in Visual Studio
You can update NuGet using the Visual Studio Extension Manager. Navigate to the Extension Manager and click on the Updates tab to check for updates. If there is a new version of NuGet you will see it in the list of available updates. From VS 2015 Update 2, NuGet extension is auto updated by default in Visual Studio.

##NuGet Beta Channel
NuGet Beta Channel for the Visual Studio 2015 NuGet Package Manager gives you access to Beta bits. Even though it's called beta, we will only release near RTM quality builds into this channel. We want to use the extra runway on our end to make sure that we incorporate any feedback that we might get from the users of the channel and catch any blocking issues early on.

<div class="block-callout-info">
	Remember if you run into any issues while dogfooding the beta build or have an idea, <a href="https://github.com/Nuget/Home">open an issue on GitHub</a>.
</div>


###Who is this for?
The beta channel is recommended for the following users:
<ol>
<li>1. You like to stay on the latest and greatest.</li>
<li>2. You want to try out new features.</li>
<li>3. You are experiencing a blocking issue and want to get access to the build with the fix before it hits RTM.</li>
</ol>

###How do I get access to the Beta Feed?
You can get access to the Beta builds by the following the steps outlined below.

<ol>
<li>1. Add the Beta Feed: <b>https://dotnet.myget.org/F/nuget-beta/vsix/</b> to the Additional Extension Galleries list in<br> <b>Tools->Options->Environment->Extensions and Updates</b>.<br></li>
<li><img src="../../images/BetaChannel/01_ToolsSettings.png"</img></li>

<li>2. Navigate to <b>Tools->Extensions and Updates</b> and select <b>Online</b>. You should now be able to see the NuGet-Beta Feed there. Install the NuGet Package Manager Extension.<br></li>
<li><img src="../../images/BetaChannel/02_ExtensionUpdate.png"</img></li>
</ol>





##NuGet in .NET CLI
The .NET Core CLI is a new foundational cross-platform toolchain for developing .NET Core applications. It is "foundational" because it is the primary layer on which other, higher-level tools, such as Integrated Development Environments (IDEs), editors and build orchestrators can build on.<br>

<a href="https://docs.microsoft.com/en-us/dotnet/articles/core/tools/index#installation">.NET CLI Installation</a><br>

The only nuget command available at this time is restore which is executed though <a href="https://docs.microsoft.com/en-us/dotnet/articles/core/tools/dotnet-restore">dotnet restore</a>.


##Package Explorer
Package Explorer is a community driven tool which lets you visually explore and create nuget packages.
<a href="/Create/using-a-gui-to-build-packages" class="alert-link">Package Explorer GUI to create packages</a>.<br>
<div class="block-callout-info">
	<strong>Note</strong><br>
	This tool is OSS, not supported by the NuGet team, and is not signed</p>
</div>

Installing Package Explorer is easy, [click here and you are done](https://npe.codeplex.com/downloads/get/clickOnce/NuGetPackageExplorer.application)!

For Windows8 version of NuGet Package Explorer, please go [here](http://apps.microsoft.com/windows/en-us/app/nuget-package-explorer/3148c5ae-7307-454b-9eca-359fff93ea19)

Package Explorer is a click-once application which means every time you launch it, it will 
check for updates and allow you to keep the application up to date.

![Package Explorer Update Available](/images/create/package-explorer-update-available.png)



##How do I choose my tools?
Here is a quick reference to understand your options if you want to consume, create or publish NuGet packages:



##NuGet Compatibility
NuGet was originally designed to be run on Windows-based operating systems to support .NET development. With the advancements of .NET applications running on non-Windows operating systems, the demand for NuGet compatibility on those environments has risen.<br>

The NuGet command-line executable will run on Linux and Mac OSX when the Mono runtime is installed. NuGet does not yet provide support for non-Windows operating systems, but we have identified that the following features do work within Linux and Mac OS X:

###NuGet 3.2
With NuGet 3.2, the following commands have been tested to work:

* Config
* Delete
* Help
* Install
* List
* Push
* SetApiKey
* Sources
* Spec

The following commands are partially working:

* Pack - Pack will work with *.nuspec files but will not work with project files
* Restore - Restore works with packages.config and project.json files but will not yet work with *.sln solution files

The following commands do not work properly:

* Update