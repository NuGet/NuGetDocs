# Creating and Publishing a Package

## Getting Started

1. [Download NuGet.exe](http://nuget.codeplex.com/releases/view/58939)
2. Make sure NuGet.exe is in your path

If you&#8217;re more __GUI inclined__, use the [Package Explorer GUI to create packages](/docs/creating-packages/using-a-gui-to-build-packages).

## Share your Package
Upgrade to the latest version of NuGet.exe (_[or download it here](http://nuget.codeplex.com/releases/view/58939)_)

    NuGet Update

Store your [API Key](#api-key)

    NuGet SetApiKey Your-API-Key

Build your NuGet Package

    NuGet Pack YourPackage.nuspec

Publish your package

    NuGet Push YourPackage.nupkg

## Installing NuGet.exe
1. [Download NuGet.exe](http://nuget.codeplex.com/releases/view/58939)
2. Place NuGet in a well known location such as c:\utils on your machine
3. Make sure that NuGet.exe is in your path

To learn about the nuget commands, run <code>nuget help</code> or refer to 
the [NuGet.exe Command Line Reference](~/docs/reference/command-line-reference).

## Creating a Package
There are a few approaches to creating a package. Most packages are very simple and contain 
a single assembly. In those cases, there are some very easy ways to create packages. 
We&#8217;ll cover more interesting cases later.

### From an assembly
If you have an assembly, you can easily generate a nuspec file from metadata within the assembly 
and create a package.

    nuget spec MyAssembly.dll

This creates a Nuspec file. Edit the NuSpec file as needed and then

    nuget pack MyAssembly.nuspec

### From a project
For simple packages, creating a package from a csproj or vbproj file is a convenient way 
to create packages. For example, other packages that have been installed into your project 
will be referenced as dependencies when you create a package this way.

In the folder where the csproj file is, run:

    nuget spec

This creates a special nuspec file with tokens meant to be replaced at pack time based on the project metadata.
For example, `$version$` gets replaced by the version specified in the `AssemblyVersionAttribute` applied to 
your assembly (typically within the `AssemblyInfo.cs` file).

The following is a list of the supported replacement tokens.

<table class="reference">
    <tr><th>Token</th><th>Source</th></tr>
    <tr>
        <td>$id$</td>
        <td>The Assembly name</td>
    </tr>
    <tr>
        <td>$version$</td>
        <td>The assembly version as specified in the assembly&#8217;s <code>AssemblyVersionAttribute</code>.</td>
    </tr>
    <tr>
        <td>$author$</td>
        <td>The company as specified in the <code>AssemblyCompanyAttribute</code>.</td>
    </tr>
        <tr>
        <td>$description$</td>
        <td>The description as specified in the <code>AssemblyDescriptionAttribute</code>.</td>
    </tr>
</table>

You can then edit this nuspec file if you need to customize it. e.g. if you don't want token replacement
for some fields, you hard code then in the nuspec instead.

Also, if you want to pull additional files into the package, you can use a <files> node in the nuspec.
e.g. suppose you want to add all the files from some arbitrary other folder into the package, you'd have:

    <files>
        <file src="..\..\SomeRoot\**\*.*" target="" /> 
    </files>

Once your nuspec is ready, you can run:

    nuget pack MyProject.csproj

Note that you need to run 'nuget pack' on the project file, not the nuspec itself. But the nuspec will in fact get picked up.

By default, NuGet will use the default build configuration set in the project file (typically Debug). To pack files from a different 
build configuration (e.g., Release), you can run:

    nuget pack MyProject.csproj -Prop Configuration=Release

To change the project default for future packaging calls, modify the project file directly; Visual Studio does not offer a 
convenient method of altering this setting in the project properties GUI. To edit this file in Visual Studio, first unload it by
right-clicking the project and choosing "Unload Project".

![Unloading a project in Visual Studio](images/Unloading-project.png)

To edit the project file, right-click the unloaded project and choose "Edit {your-project-name}.{cs|vb|etc.}proj".

![Editing unloaded project file in Visual Studio](images/Editing-unloaded-project-file.png)

In typical project files, the first `<Project><PropertyGroup>` will contain a 
`<Configuration>` element that can be modified to choose your preferred build configuration (typically Release).

    <Configuration Condition=" '$(Configuration)' == '' ">Release</Configuration>

You can also use the <code>-Symbols</code> flag to include a symbols package as well. A symbols 
package allows others to step into your package&#8217;s code in the debugger.

For a detailed walkthrough showing how to create and publish NuGet packages from a project, 
see [The easy way to publish NuGet packages with sources](http://blog.davidebbo.com/2011/04/easy-way-to-publish-nuget-packages-with.html) 
on David Ebbo&#8217;s blog.

### From a convention based working directory
Some packages contain more than just assemblies. They may contain 

1. Content and source code that should be injected into the target project.
2. [PowerShell scripts](#powershell) and executables.
3. [Configuration file and source code transformations](~/docs/creating-packages/Configuration-File-and-Source-Code-Transformations).

To create a package in this way, you can layout a directory structure that follows 
the NuGet conventions.

* __tools__ - The *tools* folder of a package is for [powershell scripts](#powershell) and programs accessible from the Package Manager Console. 
After the folder is copied to the target project, it is added to the `$env:Path (PATH) environment variable. 
* __lib__ - Assemblies (*.dll* files) in the *lib* folder are added as assembly references when the package is installed.
* __content__ - Files in the *content* folder are copied to the root of your application when the package is installed. 

__Think of the _Content_ folder as the root of your target application__. For example, if I want 
to a package to add an image in the _/images_ directory of the target application, make 
sure to place the image in the _Content/images_ folder of the package.

#### Create the manifest
To create a spec file from scratch, run the following command.

    nuget spec

This will create an XML file with the .nuspec extension. 

    <?xml version="1.0"?>
    <package xmlns="http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd">
      <metadata>
        <id>MyPackageId</id>
        <version>1.0</version>
        <authors>philha</authors>
        <owners>philha</owners>
        <licenseUrl>http://LICENSE_URL_HERE_OR_DELETE_THIS_LINE</licenseUrl>
        <projectUrl>http://PROJECT_URL_HERE_OR_DELETE_THIS_LINE</projectUrl>
        <iconUrl>http://ICON_URL_HERE_OR_DELETE_THIS_LINE</iconUrl>
        <requireLicenseAcceptance>false</requireLicenseAcceptance>
        <description>Package description</description>
        <tags>Tag1 Tag2</tags>
        <dependencies>
          <dependency id="SampleDependency" version="1.0" />
        </dependencies>
      </metadata>
    </package>

Edit this file to fill in the values appropriate for your package. 
Then create the folders needed by your package and copy the correct 
content in each folder.

    mkdir lib
    mkdir tools
    mkdir content
    mkdir content\controllers

    copy ..\src\SomeController.cs content
    copy ..\src\MyLibrary lib
    copy ..\src\SomePowershellScript.ps1 tools

With the working directory in place with content, run the following command:

    nuget pack YourPackage.nuspec

To create your package.


## Publishing
### Create an account at NuGet.org
<a name="api-key"></a>
Head over to http://nuget.org/ and register for an account. Once you do that, 
click on "My Account" to see an API Key that was generated for you.

In a command console, run the command:

    nuget setApiKey Your-API-Key

This will store your API key so that you never need to do this step again on 
this machine.

## Package Conventions

There are two types of conventions that apply when creating packages. 
The conventions listed in this page are *enforced conventions* which have to follow 
when building packages. 
There are also *community* (or *optional*) conventions, which have been formed by 
the community in order to make it easier for others to understand what your package is all about 
and make use of it immediately. For information about community conventions, see the 
[Package Conventions](Package-Conventions) page. This page will continue to be updated as new 
conventions are defined.


## Supporting Multiple .NET Framework Versions and Profiles

Many libraries target a specific version of the .NET Framework. For example, you might have one version of your library that's 
specific to Silverlight, and another version of the same library that takes advantage of .NET Framework 4 features. 
You do not need to create separate packages for each of these versions. NuGet supports putting multiple versions of the 
same library in a single package keeping them in separate folders within the package.

### Framework Version Folder Structure

When NuGet installs an assembly from a package, it checks the target .NET Framework version of the project 
you are adding the package to. NuGet then selects the correct version of the assembly in the package by selecting 
the correct subfolder within the *lib* folder. 

To enable NuGet to do this, you use the following naming convention to indicate which assemblies go 
with which framework versions:

    lib\{framework name}{version}

The following example shows a folder structure that supports four versions of a library:

    \lib
        \net11
            \MyAssembly.dll
        \net20
            \MyAssembly.dll
        \net40
            \MyAssembly.dll
        \sl40
            \MyAssembly.dll

### Framework Names

NuGet attempts to parse the folder name into a <a href="http://msdn.microsoft.com/en-us/library/dd414023.aspx">FrameworkName</a> 
object. Names are case insensitive, and you can use abbreviations for both framework name and version number.
 
If you omit the framework name, the .NET Framework is assumed. For example, the following folder structure 
is equivalent to the previous one:

    \lib
        \11
            \MyAssembly.dll
        \20
            \MyAssembly.dll
        \40
            \MyAssembly.dll
        \sl4
            \MyAssembly.dll

The following is a list of valid framework names and abbreviation:

<table class="reference">
    <tr><th>Framework Name</th><th>Abbreviations</th></tr>
    <tr><td>.NET Framework</td><td>net</td></tr>
    <tr><td>Silverlight</td><td>sl</td></tr>
    <tr><td>.NETMicroFramework</td><td>netmf</td></tr>
</table>

### Assemblies that are not Specific to a Framework Version

Assemblies that have no associated framework name or version are stored directly in the *lib* folder.

### Matching Assembly Version to the Target Framework of a Project

When NuGet installs a package that has multiple assembly versions, it tries to match the framework name of the 
assembly with the target framework of the project. 
If a match is not found, NuGet copies the assembly that's for the highest version that is less than or 
equal to the project's target framework. 
For example, if you install a package that has the *lib* folder structure shown in the previous example 
in a project that targets the .NET Framework 3.5, 
the assembly in the *2* folder (for .NET Framework 2.0) is selected.

### Grouping Assemblies by Framework Version

NuGet copies assemblies from only a single library folder. For example, suppose a package has the following folder structure:

    \lib
        \Net20
            \MyAssembly.dll (v1.0)
            \MyAssembly.Core.dll (v1.0)
        \Net40
            \MyAssembly.dll (v2.0)

When the package is installed in a project that targets the .NET Framework 4, *MyAssembly.dll (v2.0)* is the only 
assembly installed. *MyAssembly.Core.dll (v1.0)* is not installed. 
(One reason why NuGet behaves this way is that *MyAssembly.Core* might have been merged 
into version 2.0 of *MyAssembly*.) 

In this example, 
if you want *MyAssembly.Core.dll* to be installed in a project that targets the .NET Framework 4, 
you must include it in the *Net40* folder as well as in the *Net20* folder.

The rule about copying assemblies from only one folder also applies to the root *lib* folder. 
Suppose a package has the following folder structure:

    \lib
        \MyAssembly.dll (v1.0)
        \MyAssembly.Core.dll (v1.0)
        \Net40
            \MyAssembly.dll (v2.0)

In projects that target the .NET Framework 2.0 and the .NET Framework 3.5, NuGet copies 
both *MyAssembly.dll* and *MyAssembly.Core.dll*. But as was true of the previous example, 
in projects that target the .NET Framework 4, only *MyAssembly.dll *from the *Net40* folder will be copied. 

As in the previous example, if you want *MyAssembly.Core.dll* to be installed in a project that targets 
the .NET Framework 4, you must include it in the *Net40* folder.

### Grouping Assemblies by Framework Profile

NuGet also supports targeting a specific framework profile by appending a dash and the profile name to the end of the folder.

    lib\{framework name}-{profile}

For example, to target the Windows Phone profile, place your assembly in a folder named *sl3-wp*.

Profiles supported by NuGet include:

* Client - Client Profile
* Full - Full Profile
* WP - Windows Phone

At the time of this writing, to target the Windows Phone profile, the Silverlight 3 framework must be specified. 
It is anticipated that in the future, later versions of Silverlight will be supported on the phone.

<table class="reference">
    <tr><th>Profile Name</th><th>Abbreviations</th></tr>
    <tr><td>Client</td><td>client</td></tr>
    <tr><td>WindowsPhone</td><td>wp</td></tr>
    <tr><td>CompactFramework</td><td>cf</td></tr>
    <tr><td>Full</td><td>full</td></tr>
</table>

### Common Framework and Profile Targeting Examples
The following provides examples of common targets.

<table class="reference">
    <tr><th>Tool</th><th>Target</th><th>Notes</th></tr>
    <tr><td>.NET 4.0</td><td>net40</td><td>Just using '40' also works.</td></tr>
    <tr><td>.NET 4.0 Client Profile</td><td>net40-client</td><td></td></tr>
    <tr><td>.NET 4.0 Full Profile</td><td>net40-full</td><td>Requires full .NET profile</td></tr>
    <tr><td>.NET 4.0 Compact Framework</td><td>net40-cf</td><td>net40-compactframework also works.</td></tr>
    <tr><td>Silverlight 4.0</td><td>sl4</td><td></td></tr>
    <tr><td>Windows Phone 7.0</td><td>sl3-wp</td><td></td></tr>
    <tr><td>Windows Phone 7.1 (Mango)</td><td>sl4-windowsphone71</td><td></td></tr>
</table>


<a name="#powershell"></a>
## Automatically Running PowerShell Scripts During Package Installation and Removal

A package can include PowerShell scripts that automatically run when the package is installed or removed. 
NuGet automatically runs scripts based on their file names using the following conventions:

* ***Init.ps1*** runs the first time a package is installed in a solution. 
    * If the same package is installed into additional projects in the solution, the script is not 
    run during those installations. 
    * The script also runs every time the solution is opened. For example, if you install a package, 
    close Visual Studio, and then start Visual Studio and open the solution, the *Init.ps1* script runs again.
* ***Install.ps1*** runs when a package is installed in a project. 
    * If the same package is installed in multiple projects in a solution, the script runs each time the 
    package is installed. 
    * The package must have files in the *content* or *lib* folder for *Install.ps1* to run. Just having 
    something in the tools folder will not kick this off.
    * If your package also has an *init.ps1*, *install.ps1* runs **after** *init.ps1*.
* ***Uninstall.ps1*** runs every time a package is uninstalled. 
* These files should be located in the tools directory of your package. 
* At the top of your file, add this line: **`param($installPath, $toolsPath, $package, $project)`**
    * **`$installPath`** is the path to the folder where the package is installed
    * **`$toolsPath`** is the path to the tools directory in the folder where the package is installed
    * **`$package`** is a reference to the package object. 
    * **`$project`** is a reference to the EnvDTE project object and represents the project the package is 
    installed into. *Note:* This will be null in *Init.ps1*. In that case doesn't have a reference to a particular 
    project because it runs at the solution level. The properties of this object are defined in [the MSDN documentation](http://msdn.microsoft.com/en-us/library/51h9a6ew(v=VS.80).aspx).
* When you are testing **`$project`** in the console while creating your scripts, you can set it to *$project = Get-Project* 

If you want to learn about your actual output, <a href="http://nuget.org/List/Packages/NuGetPSVariables">NuGetPSVariables</a> 
is a helper package that writes information out to a series of log files. You can make use of the package with the following call:

    Install-Package NuGetPSVariables

NuGetPSVariables displays the log files and uninstalls itself.