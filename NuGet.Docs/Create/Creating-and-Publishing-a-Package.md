# Creating and Publishing a Package

## Getting Started

1. [Download NuGet.exe](https://nuget.org/nuget.exe)
2. Make sure NuGet.exe is in your path

If you&#8217;re more __GUI inclined__, use the [Package Explorer GUI to create packages](/Create/using-a-gui-to-build-packages).

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
For example, `$version$` gets replaced by the version specified in the `AssemblyVersionAttribute` (or `AssemblyInformationalVersionAttribute` if present) applied to 
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
        <td>The assembly version as specified in the assembly&#8217;s <code>AssemblyVersionAttribute</code> (or <code>AssemblyInformationalVersionAttribute</code> if present).</td>
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
for some fields, you hard code them in the nuspec instead.

Also, if you want to pull additional files into the package, you can use a <files> node in the nuspec.
e.g. suppose you want to add all the files from some arbitrary other folder into the package, you'd have:

    <files>
        <file src="..\..\SomeRoot\**\*.*" target="" /> 
    </files>

Note that pack excludes by default any folder name starting with a . such as .git or .hg.

Once your nuspec is ready, you can run:

    nuget pack MyProject.csproj

Note that you need to run 'nuget pack' on the project file, not the nuspec itself. But the nuspec will in fact get picked up.

If the project references other projects, you can add the referenced projects as part of the package, or as dependencies 
with [-IncludeReferencedProjects option](/Consume/Command-Line-Reference#Pack-Command-Options). 
This is done recursively. For example, suppose you have project A.csproj, which references B.csproj and C.csproj, while B.csproj references D.csproj & E.csproj, 
C.csproj references F.csproj & G.csproj. Then, when you run 

	nuget pack A.csproj -IncludeReferencedProjects
	
the generated package will contain files from projects B, C, D, E, F & G, in addition to files from project A.

If a referenced project has a corresponding nuspec file with the same name, then that referenced project 
is added as a dependency instead. Using the same example, suppose now there is file C.nuspec in the same directory as project file C.csproj. When you run

	nuget pack A.csproj -IncludeReferencedProjects
	
the generated package will contain files from projects B, D, E, in addition to files from project A, and the package has dependency on C.

By default, NuGet will use the default build configuration set in the project file (typically Debug). To pack files from a different 
build configuration (e.g., Release), you can run:

    nuget pack MyProject.csproj -Prop Configuration=Release

To change the project default for future packaging calls, modify the project file directly; Visual Studio does not offer a 
convenient method of altering this setting in the project properties GUI. To edit this file in Visual Studio, first unload it by
right-clicking the project and choosing "Unload Project".

![Unloading a project in Visual Studio](/images/Create/Unloading-project.png)

To edit the project file, right-click the unloaded project and choose "Edit {your-project-name}.{cs|vb|etc.}proj".

![Editing unloaded project file in Visual Studio](/images/Create/Editing-unloaded-project-file.png)

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
3. [Configuration file and source code transformations](/Create/Configuration-File-and-Source-Code-Transformations).

To create a package in this way, you can layout a directory structure that follows 
the NuGet conventions.

* __tools__ - The *tools* folder of a package is for [powershell scripts](#powershell) and programs accessible from the Package Manager Console. 
After the folder is copied to the target project, it is added to the `$env:Path (PATH) environment variable. 
* __lib__ - Assemblies (*.dll* files) in the *lib* folder are added as assembly references when the package is installed.
* __content__ - Files in the *content* folder are copied to the root of your application when the package is installed. 
* __build__ - The *build* folder of a package is for MSBuild targets files that are automatically inserted into the *.csproj* file of the application.

__Think of the _Content_ folder as the root of your target application__. For example, if I want 
a package to add an image in the _/images_ directory of the target application, make 
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

To create your package. __Note__: token replacement is not supported in this scenario.

### Creating a solution-level package

A solution-level package is one that installs a tool or additional commands
for the Package Manager console, but does not add references, content, or
build customizations to any projects in your solution. For example, the
[psake](http://nuget.org/packages/psake) package installs Powershell scripts
you can use to automate your build process.

A package is considered a solution-level package if it does not contain
any files in its __lib__, __content__, or __build__ directories.  If the package
has dependencies, they also must not have files in their __lib__, __content__,
or __build__ directories.

When a solution-level package is installed, it is tracked in a packages.config
file in the .nuget directory, rather than in a packages.config file in a
specific project.


## Publishing in NuGet Gallery
### Create an account at NuGet.org

Head over to http://nuget.org/ and register for an account. Once you do that, use the Upload Package UI to 
upload your package to the NuGet Gallery

##Publishing using NuGet Command Line
### Create an account at NuGet.org

Head over to http://nuget.org/ and register for an account.
Once you do that, click on "My Account" to see an API Key that was generated for you.

In a command console, run the command:

    nuget setApiKey Your-API-Key

This will store your API key so that you never need to do this step again on 
this machine.

Push your package to NuGet Gallery using the command:
	
	nuget push YourPackage.nupkg

## Package Conventions

There are two types of conventions that apply when creating packages. 
The conventions listed in this page are *enforced conventions* which you have to follow 
when building packages. For information about enforced conventions, see the [Enforced Package Conventions] (/Create/Enforced-Package-Conventions) page.

There are also *community* (or *optional*) conventions, which have been formed by 
the community in order to make it easier for others to understand what your package is all about 
and make use of it immediately. For information about community conventions, see the 
[Package Conventions](Package-Conventions) page. This page will continue to be updated as new 
conventions are defined.

<a name="#powershell"></a>
## Automatically Running PowerShell Scripts During Package Installation and Removal

A package can include PowerShell scripts that automatically run when the package is installed or removed. 
NuGet automatically runs scripts based on their file names using the following conventions:

* ***Init.ps1*** runs the first time a package is installed in a solution. 
    * If the same package is installed into additional projects in the solution, the script is not 
    run during those installations. 
    * The script also runs every time the solution is opened (Package Manager Console window has to be open at the same for the script to run). For example, if you install a package, 
    close Visual Studio, and then start Visual Studio and open the solution with Package Manager Console window, the *Init.ps1* script runs again.
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

<a name="#importtargets"></a>
## Import MSBuild targets and props files into project 

Requires [NuGet 2.5] (/Release-Notes/NuGet-2.5) or above

A new convention has been added to the structure of NuGet packages. As a peer to \lib, \content, and \tools, you can now 
include a '\build' folder in your package. Under this folder, you can place two files with fixed names, **{packageid}.targets** or **{packageid}.props**. 
These two files can be either directly under \build or under framework-specific folders just like the other folders. The rule for picking the 
best-matched framework folder is exactly the same as in those.

When NuGet installs a package with \build files, it will add an MSBuild <Import> element in the project file pointing to the .targets and .props files. 
The .props file is added at the *top*, whereas the .targets file is added to the *bottom*.

    \build
        \Net40
            \MyPackage.props
            \MyPackage.targets
        \Silverlight40
            \MyPackage.props

If this package is installed into a .NET 4.0 project, for example, both the .props and .targets files are imported into the target project.

    <Project ToolsVersion="4.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
      <Import Project="..\packages\MyPackage.1.0.0\build\net40\MyPackage.props" Condition="Exists('..\packages\MyPackage.1.0.0\build\net40\MyPackage.props')" />
      ...
      ...
      <Import Project="..\packages\MyPackage.1.0.0\build\net40\MyPackage.targets" Condition="Exists('..\packages\MyPackage.1.0.0\build\net40\MyPackage.targets')" />
    </Project>

## Automatically Displaying a Readme.txt File During Package Installation

A package can include a *readme.txt* file in the root of the package. This file will be displayed in Visual Studio immediately after the package is installed. 

    <file src="readme.txt" target="" />

If the package is installed because it is a dependency of another package, the *readme.txt* file will not be opened. Only the *readme.txt* file of the package that the user is explicitly installing will be shown.

This feature was added in [NuGet 1.7] (/Release-Notes/NuGet-1.7). If the client is older than NuGet 1.7 the *readme.txt* file will be ignored.
