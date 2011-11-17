# Nuspec Reference

A .nuspec file is a manifest that uses XML to describe a package. The manifest is used to build a package 
and is also stored in the package after the package is built. For information about how to build a package, 
see Creating a Package.

In a .nuspec file, the top-level package element contains a **metadata** element that describes the package and 
its dependencies. Optionally, the **package** element can include a files element that specifies files to be 
included in the package. If the files element is omitted, all files and folders that are in the same folder 
as the .nuspec file are included in the package. The .nuspec file is included in the package after the 
package is built (but without the element that lists files if that element was included).

## Metadata Section

<table class="reference">
<tbody>
    <tr>
        <th>Element</th> <th>Description</th>
    </tr>
    <tr>
        <td><strong>id</strong></td>
        <td>
            The unique identifier for the package. This is the package name that is shown 
            when packages are listed using the Package Manager Console. These are also used 
            when installing a package using the Install-Package command within the Package 
            Manager Console. Package IDs may not contain any spaces or characters that are 
            invalid in an URL. In  general, they follow the same rules as .NET namespaces do. 
            So <code>Foo.Bar</code> is a valid ID, <code>Foo!</code> and <code>Foo Bar</code> are not.
        </td>
    </tr>
    <tr>
        <td><strong>version</strong></td>
        <td>The version of the package, in a format like <code>1.2.3</code>.</td>
    </tr>
    <tr>
        <td>title</td>
        <td>
            The human-friendly title of the package displayed in the Manage NuGet Packages
            dialog. If none is specified, the ID is used instead.        
        </td>
    </tr>
    <tr>
        <td><strong>authors</strong></td>
        <td>A comma-separated list of authors of the package code.</td>
    </tr>
    <tr>
        <td>owners</td>
        <td>
            A comma-separated list of the package creators. This is often the 
            same list as in authors. This is ignored when uploading the package 
            to the NuGet.org Gallery.
        </td>
    </tr>
    <tr>
        <td><strong>description</strong></td>
        <td>
            A long description of the package. This shows up in the right pane of the 
            Add Package Dialog as well as in the Package Manager Console when listing 
            packages using the <code>Get-Package</code> command.
        </td>
    </tr>
    <tr>
        <td>releaseNotes</td>
        <td>
            A description of the changes made in each release of the package. This field 
            only shows up when the _Updates_ tab is selected and the package is an update 
            to a previously installed package. It is displayed where the Description would 
            normally be displayed.
        </td>
    </tr>
    <tr>
        <td>summary</td>
        <td>
            A short description of the package. If specified, this shows up in the middle pane 
            of the Add Package Dialog. If not specified, a truncated version of the description 
            is used instead.
        </td>
    </tr>
    <tr>
        <td>language</td>
        <td>The locale ID for the package, such as en-us.</td>
    </tr>
    <tr>
        <td>projectUrl</td>
        <td>A URL for the home page of the package.</td>
    </tr>
    <tr>
        <td>iconUrl</td>
        <td>A URL for the image to use as the icon for the package in the <strong>Manage NuGet Packages</strong> dialog box. This should be a 32x32-pixel <em>.png</em> file that has a transparent background.</td>
    </tr>
    <tr>
        <td>licenseUrl</td>
        <td>A link to the license that the package is under.</td>
    </tr>
    <tr>
        <td>copyright</td>
        <td>(v<em>1.5</em>) Copyright details for the package.</td>
    </tr>
    <tr>
        <td>requireLicenseAcceptance</td>
        <td>A Boolean value that specifies whether the client needs to ensure that the package license (described by licenseUrl) is accepted before the package is installed.</td>
    </tr>
    <tr>
        <td>dependencies</td>
        <td>The list of dependencies for the package. For more information, see <a href="#Specifying_Dependencies">Specifying Dependencies</a> later in this document.</td>
    </tr>
    <tr>
        <td>references</td>
        <td>(v<em>1.5</em>) Names of assemblies under lib that are added as project references. If unspecified, all references in lib are added as project references. When specifying a reference, only specify the name and not the path inside the package.</td>
    </tr>
    <tr>
        <td>frameworkAssemblies</td>
        <td>(v<em>1.2+</em>) The list of .NET Framework assembly references that this package requires. These are references to assemblies that exist in the .NET Framework and thus should already be in the GAC for any machine. Specifying framework assembly references  ensures these references are added when installing the package.</td>
    </tr>
    <tr>
        <td>tags</td>
        <td>A space-delimited list of tags and keywords that describe the package. This information is used to help make sure users can find the package using searches in the <strong>Add Package Reference</strong> dialog box or filtering in the <strong>Package Manager Console</strong> window.</td>
    </tr>
</tbody>
</table>

### Replacement Tokens
Replacement tokens can be used in place of values within the Metadata section of 
the NuSpec file [when creating a package from a project file](../creating-packages/creating-and-publishing-a-package#From_a_project)

For example, when using the command:

    nuget pack MyProject.csproj

The `MyProject.nuspec` file adjacent to the `MyProject.csproj` file may contain the following replacement tokens which 
are populated by the values within the project.

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
        <td>references</td>
        <td>
            This element contains a set of <code>&lt;reference&gt;</code> elements, each of which 
            specifies an assembly that will be referenced by the project. The existence of 
            this element overrides the convention of pulling everything in the <code>lib</code> 
            folder. More info below.
        </td> 
    </tr>
</table>

## Specifying Dependencies

The dependencies element is a child element of the metadata element and contains a set of dependency 
elements. Each dependency element is a reference to another package that this package depends on. The 
following table lists attributes of the dependency element.

    <dependencies>
      <dependency id="RouteMagic" version="1.1.0" />
      <dependency id="RouteDebugger" version="1.0.0" />
    </dependencies>

## Specifying Explicit Assembly References
Use the `<references />` element to explicitly specify assemblies that the target project should 
reference.

For example, if you add the following:

    <references>
      <reference file="xunit.dll" />
      <reference file="xunit.extensions.dll" />
    </references>

Then only the _xunit.dll_ and _xunit.extensions.dll_ will be referenced from the appropriate 
[framework/profile subdirectory](../creating-packages/creating-and-publishing-a-package#Grouping_Assemblies_by_Framework_Version) 
of the `lib` folder even if there are other assemblies in the folder.

If this element is omitted, then the usual behavior applies, which is to reference every assembly 
in the lib folder.

__What is this feature used for?__

This feature supports design-time only assemblies. For example, when using Code Contracts, the 
contract assemblies need to be next to the runtime assemblies that they augment so that Visual 
Studio can find them, but the contract assemblies should not actually be referenced by the project 
and should not be copied into the bin folder.

Likewise, the feature can be used to for unit test frameworks such as XUnit which need its tools 
assemblies to be located next to the runtime assemblies, but excluded from project references.

## Specifying Framework Assembly References (GAC)

In some cases, a package may depend on an assembly that’s in the .NET Framework. Strictly speaking, it’s 
not always necessary that the consumer of your package reference the framework assembly. But in some cases, 
it is important, such as when the developer needs to code against types in that assembly in order to use 
your package. The `<frameworkAssemblies>` element, a child element of the metadata element, allows you to 
specify a set of frameworkAssembly elements pointing to a Framework assembly in the GAC. Note the emphasis 
on Framework assembly. These assemblies are not included in your package as they are assumed to be on every 
machine  as part of the .NET Framework.

    <frameworkAssemblies>
      <frameworkAssembly assemblyName="System.ServiceModel" targetFramework="net40" />
      <frameworkAssembly assemblyName="System.SomethingElse"  />
    </frameworkAssemblies>

The following table lists attributes of the frameworkAssembly element.

<table class="reference">
    <tr>
        <th>Attribute</th>
        <th>Description</th>
    </tr>
    <tr>
        <td>assemblyName</td>
        <td>
            <em>Required.</em> The fully qualified assembly name.
        </td>
    </tr>
    <tr>
        <td>targetFramework</td>
        <td>
           <em>Optional.</em> If specified, the specific target framework that this reference applies to. 
            For example, if reference only applies to .NET 4, then the value should be "net40". If 
            the reference applies to *all* frameworks, then omit this attribute.
        </td>
    </tr>
</table>


## Specifying Files to Include in the Package

If you follow the conventions described in Creating a Package, you do not have to explicitly specify a list 
of files in the .nuspec file. Note that if you specify any files, the conventions are ignored and only the 
files listed in the .nuspec file are included in the package.

The files element is an optional child element of the package element and contains a set of file elements. 
Each file element specifies the source and destination of a file to include in the package via the `src` 
attribute and `target` attribute respectively.

<table class="reference">
    <tr>
        <th>Element</th>
        <th>Description</th>
    </tr>
    <tr>
        <td>src</td>
        <td>
            The location of the file or files to include. The path is relative to the NuSpec file 
            unless an absolute path is specified. The wildcard character, *,  is allowed. Using a double 
            wildcard, **, implies a recursive directory search.
        </td>
    </tr>
    <tr>
        <td>target</td>
        <td>
            This is a relative path to the directory within the package 
            where the source files will be placed.
        </td>
    </tr>
    <tr>
        <td>exclude</td>
        <td>
            The file or files to exclude. This is usually combined with a wildcard value in the `src` 
            attribute. The `exclude` attribute can contain a semi-colon delimited list of files or 
            a file pattern. Using a double wildcard, **, implies a recursive exclude pattern.
        </td>
    </tr>
</table> 

The following is an example of a `files` element.

    <files>
      <file src="bin\Debug\*.dll" target="lib" /> 
      <file src="bin\Debug\*.pdb" target="lib" /> 
      <file src="tools\**\*.*" exclude="**\*.log" />
    </files>

### File Element Examples
Let&#8217;s look at some example usages of this element to gain a better understanding of how it&#8217;s used.

#### Single Assembly
Copies a single assembly in the same folder as the NuSpec file into the package&#8217;s `lib` folder.

Source Contains: `foo.dll`

    <file src="foo.dll" target="lib" />
    
Packaged Result: `lib\foo.dll`

#### Single Assembly In a deep path
Copies a single assembly  into the package&#8217;s `lib\net40` folder so that it only applies to projects 
targeting the .NET 4 framework.

Source Contains: `foo.dll`

    <file src="assemblies\net40\foo.dll" target="lib\net40" />

Packaged Result: `lib\net40\foo.dll`


#### Set Of DLLs
Copies a set of assemblies within the `bin\release` folder into the package&#8217;s `lib` folder.

Source contains: 

* `bin\releases\MyLib.dll`
* `bin\releases\CoolLib.dll`

NuSpec File Element

    <file src="bin\release\*.dll" target="lib" />

Packaged Result
* `lib\MyLib.dll`
* `lib\CoolLib.dll`

#### DLLs for different frameworks
Source contains:

* `lib\net40\foo.dll`
* `lib\net20\foo.dll`

NuSpec File Element:

    <file src="lib\**" target="lib" />

Packaged Result: 

* `lib\net40\foo.dll` 
* `lib\net20\foo.dll`

Note: The double wildcard implies a recursive search in the source for matching files.

#### Content Files
Source Contains: 

* `css\mobile\style1.css`
* `css\mobile\style2.css`

NuSpec File Element:

    <file src="css\mobile\*.css" target="content\css\mobile" />

Packaged Result: 

* `Content\css\mobile\style1.css`
* `Content\css\mobile\style2.css`

#### Content files with directory structure
Source Contains:
 
* `css\mobile\style.css`
* `css\mobile\wp7\style.css`
* `css\browser\style.css`

NuSpec file element

    <file src="css\**\*.css" target="content\css" />

Packaged Result:

* `content\css\mobile\style.css` 
* `content\css\mobile\wp7\style.css`
* `content\css\browser\style.css`

#### Content File with deep path
Source Contains: `css\cool\style.css`

    <file src="css\cool\style.css" target="Content" />

Packaged Result: `Content\style.css`

#### Content File copied to Folder with dot in name

    <file src="images\Neatpic.png" target="Content\images\foo.bar" />

Packaged Result: `Content\images\foo.bar\Neatpick.png`

Note: Because the target "extension" doesn't match the src extension, NuGet treats it as a directory.

#### Content file with deep path and deep target

    <file src="css\cool\style.css" target="Content\css\cool" />

Packaged Result: `Content\css\cool\style.css`

Note: This also works:

    <file src="css\cool\style.css" target="Content\css\cool\style.css" />

In this case, because the file extensions of the source and target match, it's assumed that the target 
is not a directory but is the file name.

#### Content file copy and rename

    <file src="ie\css\style.css" target="Content\css\ie.css" />

Packaged Result: `Content\css\ie.css`

### Excluding files in the NuSpec
The `<file>` element within a NuSpec file can be used to include a specific file or a set of files 
using a wildcard. When using a wildcard, there's no way to exclude a specific subset of the included 
files. For example, suppose you want all text files within a directory except a specific one.

    <files>
        <file src="docs\*.txt" target="content\docs" exclude="docs\admin.txt" />
    </files>

Use semicolons to specify multiple files.

    <files>
        <file src="*.txt" target="content\docs" exclude="admin.txt;log.txt" />
    </files>

Use a wildcard to exclude a set of files such as all backup files.

    <files>
        <file src="tools\*.*" target="tools" exclude="tools\*.bak" />
    </files>

Or use a double wildcard to exclude a set of files recursively across directories.

    <files>
        <file src="tools\**\*.*" target="tools" exclude="**\*.log" />
    </files>

## Examples of .nuspec Files

The following example shows a simple .nuspec file that does not specify dependencies or files.

    <?xml version="1.0" encoding="utf-8"?>
    <package xmlns="http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd">
      <metadata>
        <id>sample</id>
        <version>1.2.3</version>
        <authors>Kim Abercrombie, Franck Halmaert</authors>
        <description>Sample exists only to show a sample .nuspec file.</description>
        <language>en-US</language>
        <projectUrl>http://xunit.codeplex.com/</projectUrl>
        <licenseUrl>http://xunit.codeplex.com/license</licenseUrl>
      </metadata>
    </package>

The following example shows a .nuspec file that specifies dependencies.

    <?xml version="1.0" encoding="utf-8"?>
    <package xmlns="http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd">>
      <metadata>
        <id>sample</id>
        <version>1.0.0</version>
        <authors>Microsoft</authors>
        <dependencies>
          <dependency id="another-package" version="3.0.0" />
          <dependency id="yet-another-package"/>
        </dependencies> 
      </metadata>
    </package>

The following example shows a .nuspec file that specifies files.

    <?xml version="1.0"?>
    <package xmlns="http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd">
      <metadata>
        <id>routedebugger</id>
        <version>1.0.0</version>
        <authors>Jay Hamlin</authors>
        <requireLicenseAcceptance>false</requireLicenseAcceptance>
        <description>Route Debugger is a little utility I wrote...</description>
      </metadata>
      <files>
        <file src="bin\Debug\*.dll" target="lib" />
      </files>
    </package>

The following example shows a .nuspec file that specifies framework assemblies.

    <?xml version="1.0"?>
    <package xmlns="http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd">>
      <metadata>
        <id>PackageWithGacReferences</id>
        <version>1.0</version>
        <authors>Author here</authors>
        <requireLicenseAcceptance>false</requireLicenseAcceptance>
        <description>
            A package that has framework assemblyReferences depending 
            on the target framework.
        </description>
        <frameworkAssemblies>
          <frameworkAssembly assemblyName="System.Web" targetFramework="net40" />
          <frameworkAssembly assemblyName="System.Net" targetFramework="net40-client, net40" />
          <frameworkAssembly assemblyName="Microsoft.Devices.Sensors" targetFramework="sl4-wp" />
          <frameworkAssembly assemblyName="System.Json" targetFramework="sl3" />
        </frameworkAssemblies>
      </metadata>
    </package>

Given the above package as an example, here is what will get installed for specific project targets:

* Project targeting .NET4 -> System.Web, System.Net  
* Project targeting .NET4 Client Profile -> System.Net  
* Project targeting Silverlight 3 -> System.Json  
* Project targeting Silverlight 4 -> System.Windows.Controls.DomainServices  
* Project targeting WindowsPhone -> Microsoft.Devices.Sensors  
