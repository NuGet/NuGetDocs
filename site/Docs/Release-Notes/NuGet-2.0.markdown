# NuGet 2.0 Release Notes

## Known Installation Issue
If you are running VS 2010 SP1, you might run into an installation error when attempting to upgrade 
NuGet if you have an older version installed.

The workaround is to simply uninstall NuGet and then install it from the VS Extension Gallery. See 
<a href="http://support.microsoft.com/kb/2581019">http://support.microsoft.com/kb/2581019</a> for more information, or <a href="http://bit.ly/vsixcertfix">to go directly to the VS hotfix</a>.

Note: If Visual Studio won't allow you to uninstall the extension (the Uninstall button is disabled),
then you likely need to restart Visual Studio using "Run as Administrator."

## Group dependencies by target frameworks

Starting from version 2.0, package dependencies can be specified to vary according to the framework profile of the target project. This is accomplished by using the new .nuspec schema. The `<dependencies>` element can now contain a set of `<group>` elements. Each group contains zero or more `<dependency>` element and a target framework attribute. All dependencies inside a group are installed together if the target framework is compatible with the project's framework profile. For example:

    <dependencies> 
       <group>
          <dependency id="RouteMagic" version="1.1.0" />
       </group>

       <group targetFramework="net40">
          <dependency id="jQuery" />
          <dependency id="WebActivator" />
       </group>
 
       <group targetFramework="sl30">
       </group>
    </dependencies>

Note that a group can contain **zero** dependencies. In the example above, if the project is a Silverlight 3.0 project, no dependencies will be installed. If the package is installed into a .NET 4.0 project, two dependencies, jQuery and WebActivator, will be installed.  For all other cases, RouteMagic 1.1.0 package will be installed.

A package can specify package dependencies in either of two formats: the old format of a flat list of `<dependency>`, or in groups. If the `<group>` format is used, the package cannot be installed into older versions of NuGet (below 2.0).

Note that mixing the two formats is not allowed. For example, the following snippet is **invalid** and will be rejected by NuGet.

    <dependencies> 
       <dependency id="jQuery" />
       <dependency id="WebActivator" />

       <group>
          <dependency id="RouteMagic" version="1.1.0" />
       </group>
    </dependencies>

## Grouping content files and PowerShell scripts by target frameworks

In addition to assembly references, in 2.0, content files and PowerShell scripts can be grouped by target frameworks too. The framework folder structure inside `lib` folder can now be applied exactly the same to `content` and `tools` folders. For example:

    \content
        \net11
            \MyContent.txt
        \net20
            \MyContent20.txt
        \net40
        \sl40
            \MySilverlightContent.html

    \tools
        \init.ps1
        \net40
            \install.ps1
            \uninstall.ps1
        \sl40
            \install.ps1
            \uninstall.ps1

**Note**: Because **`init.ps1`** is executed at the solution level and not dependent on projects, it must be placed directly under the `tools` folder. If placed under a framework folder, it will be ignored.

Also, a new feature in NuGet 2.0 is that a framework folder can be *empty*, in which case, NuGet will not add assembly references or content files or run the PowerShell scripts for the particular framework version. In the example above, the folder `content\net40` is empty.

## Improved tab completion performance
The tab completion feature in the NuGet Package Manager Console has been revamped to improve performance significantly. There will be much less delay from the time the tab key is pressed until the suggestion dropdown shows up.

## Bug Fixes
NuGet 2.0 includes many bug fixes with an emphasis on package restore consent and performance. 
For a full list of work items fixed in NuGet 2.0, please view the [NuGet Issue Tracker for this release](http://nuget.codeplex.com/workitem/list/advanced?keyword=&status=Closed&type=All&priority=All&release=NuGet%202.0&assignedTo=All&component=All&sortField=Votes&sortDirection=Descending&page=0).
