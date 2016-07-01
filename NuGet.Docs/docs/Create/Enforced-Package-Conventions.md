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

### New in NuGet version 2.0 and above

Starting in NuGet 2.0, in addition to assembly references, content files as well as PowerShell scripts can be grouped by target frameworks too. The framework folder structure inside `lib` folder as described above  applies exactly the same to `content` and `tools` folders.

    \content
        \net11
            \MyContent.txt
        \net20
            \MyContent20.txt
        \net40
        \sl40
            \MySilverlightContent.html

    \tools
        init.ps1
        \net40
            install.ps1
            uninstall.ps1
        \sl40
            install.ps1
            uninstall.ps1


A new feature in NuGet 2.0 is that a framework folder can be *empty*, in which case, NuGet will not add assembly references or content files or run the PowerShell scripts for the particular framework version.

**Note**: Because **`init.ps1`** is executed at the solution level and not dependent on project, it must be placed directly under the `tools` folder. If placed under a framework folder, it will be ignored.

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
    <tr><td>Windows Store</td><td>win</td></tr>
    <tr><td>Windows Phone (Silverlight-based)</td><td>wp</td></tr>
    <tr><td>Windows Phone App (WinRT-based)</td><td>wpa</td></tr>
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
    <tr><td>.NET 3.5</td><td>net35</td><td>Just using '35' also works.</td></tr>
    <tr><td>.NET 4.0</td><td>net40</td><td>Just using '40' also works.</td></tr>
    <tr><td>.NET 4.0 Client Profile</td><td>net40-client</td><td></td></tr>
    <tr><td>.NET 4.0 Full Profile</td><td>net40-full</td><td>Requires full .NET profile</td></tr>
    <tr><td>.NET 4.0 Compact Framework</td><td>net40-cf</td><td>net40-compactframework also works.</td></tr>
    <tr><td>.NET Micro Framework</td><td>netmf</td><td></td></tr>
    <tr><td>Silverlight 3.0</td><td>sl3</td><td></td></tr>
    <tr><td>Silverlight 4.0</td><td>sl4</td><td></td></tr>
    <tr><td>Silverlight 5.0</td><td>sl5</td><td></td></tr>
    <tr><td>Windows Phone 7.0</td><td>sl3-wp</td><td></td></tr>
    <tr><td></td><td>wp7</td><td>Only in NuGet 2.1+</td></tr>
    <tr><td>Windows Phone 7.1 (Mango)</td><td>sl4-windowsphone71</td><td></td></tr>
    <tr><td></td><td>wp71</td><td>Only in NuGet 2.1+</td></tr>
    <tr><td>Windows Phone 8 (Silverlight-based)</td><td>windowsphone8</td><td>Only in NuGet 2.1+</td></tr>
    <tr>
        <td>Windows Phone App 8.1 (WinRT-based)</td>
        <td>wpa</td>
        <td>Only in NuGet 2.8.1+</td>
    </tr>
    <tr><td>Windows Store apps (Javascript, C#, VB.NET)</td><td>netcore45</td><td></td></tr>
    <tr><td></td><td>windows8</td><td>Only in NuGet 2.1+</td></tr>
    <tr><td>Portable class library for Windows Store apps and .NET 4.5</td><td>portable-windows8+net45</td><td>Only in NuGet 2.1+</td></tr>
    <tr><td>Portable class library for Windows Store apps, Silverlight 4.0 and Windows Phone 7.1</td><td>portable-sl4+wp71+windows8</td><td>Only in NuGet 2.1+</td></tr>
</table>

### Determining which NuGet Target to use

When packaging libraries targeting the Portable Class Library it can sometimes to be tricky to determine which NuGet Target you should use in your folder names and manifest files especially if targeting only a subset of the PCL.  Here are some links to useful external resources to help you with this:

* [Framework Profiles in .Net](http://blog.stephencleary.com/2012/05/framework-profiles-in-net.html)
* [Portable Class Library Profiles](http://embed.plnkr.co/03ck2dCtnJogBKHJ9EjY/preview) - Table enumerating PCL profiles and their equivalent NuGet targets
* [Portable Library Profiles Tool](https://github.com/StephenCleary/PortableLibraryProfiles) - Command line tool for determining PCL profiles available on your system
