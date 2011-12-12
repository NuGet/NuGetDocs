# Versioning
When you create a NuGet package, you can specify dependencies for the package in the .nuspec file. You 
also specify which versions of a dependency package are required. For information about creating NuGet 
packages and the .nuspec file format, see [Creating a Package](../creating-packages/creating-and-publishing-a-package) 
and [.nuspec File Format Specification](nuspec-reference).

Dependency versions are specified in the version attribute of the dependency element. For example, the 
following dependency element specifies a dependency on version 1.3.2 or higher of the package named 
ExamplePackage.

## Specifying Version Ranges in .nuspec Files

    <dependency id="ExamplePackage" version="1.3.2" />

NuGet supports using interval notation for specifying version ranges. The NuGet specification was 
inspired by the Maven Version Range Specification but is not identical to it. The following summarizes 
how to specify version ranges.

    1.0	 = 1.0 ≤ x
    (,1.0]	= x ≤ 1.0
    (,1.0)	= x < 1.0
    [1.0] = x == 1.0
    (1.0) = invalid
    (1.0,) = 1.0 < x
    (1.0,2.0) = 1.0 < x < 2.0
    [1.0,2.0] = 1.0 ≤ x ≤ 2.0
    empty = latest version.

## Examples
The following example specifies a dependency on any version of ExamplePackage that begins with a 1 or a 2. 
The square bracket indicates that the 1 is included, while the parenthesis indicates that 3 is excluded.

    <dependency id="ExamplePackage" version="[1,3)" />

In the example, version 1 and version 2.9 would be acceptable, but not 0.9 or 3.0.

The following example specifies a dependency on ExamplePackage 1.3.2 through any version number that 
begins with 1.4. The square bracket indicates that the 1.3.2 is included, while the parenthesis 
indicates that 1.5 is excluded.

    <dependency id="ExamplePackage" version="[1.3.2,1.5)" />

In the example, version 1.3.2.1 and version 1.4.999 would be acceptable, but not version 1.5.

## Guidance
Generally, the guidance in most cases is to only specify a lower bound, and leave the upper bound open. e.g.

    <dependency id="ExamplePackage" version="1.3.2" />

## Prerelease Versions
When most people install packages from NuGet, they want the latest “stable” release of that package. 
Other developers like to live life on the edge and want to grab the latest prerelease version of a package. 

As of NuGet 1.6, NuGet supports the creation of prerelease packages by specifying a prerelease string in 
the version number according to the [Semantic Versioning (SemVer) specification](http://semver.org/).

### Really brief introduction to SemVer
The [SemVer spec](http://semver.org/) is the best place to get a detailed understanding of SemVer. For 
those in a hurry, this is a brief rundown of SemVer.

SemVer is a convention for versioning your public APIs in which the version number has meaning attached to it. 
Each version has three parts, _Major.Minor.Patch_.

In brief, these correspond to:
* __Major__: Breaking changes.
* __Minor__: New features, but backwards compatible.
* __Patch__: Backwards compatible bug fixes only.

Additionally, prerelease versions of your API can be denoted by appending an arbitrary string to the 
_Patch_ number separated by a dash. For example:

* `1.0.1-alpha`
* `1.0.1-beta`
* `1.0.1-Fizzleshnizzle`

Note that the actual string applied doesn't matter. If there's a string there, it's a prerelease version.

When you’re ready to release, just remove the dash and the string and that version is considered “higher” 
than all the prerelease versions. For example, the stable version `1.0.1` is larger than `1.0.1-rc`

The prerelease versions are given precedence in alphabetical order (well technically lexicographic 
ASCII sort order).

Therefore, the following is an example from lowest to highest versions of a package.

* `1.0.1-alpha`
* `1.0.1-alpha2`
* `1.0.1-beta`
* `1.0.1-rc`
* `1.0.1-zeeistalmostdone`
* `1.0.1`

SemVer also introduces the concept of a build number for those creating daily or continous builds. This is not 
supported in the public NuGet.org gallery.

### Creating Prerelease Packages
As mentioned before, to create a prerelease package, simply give it a version that has a prerelease string. 
There are two ways this can be accomplished.

1. Within the NuSpec file, specify the version in the &lt;version /> element

        <version>1.0.1-alpha</version>

2. If building a package from a project (.csproj or .vbproj), use the 
`AssemblyInformationalVersionAttribute` to specify the version.

        [assembly: AssemblyInformationalVersion("1.0.1-alpha")]

NuGet will pick up this value instead of the one specified in the `AssemblyVersion` attribute (this 
attribute does not support SemVer which is why a different attribute was needed).

### Installing Prerelease Packages
By default, NuGet does not display prerelease packages in the dialog or in the console. As of NuGet 1.6, 
there is no way to install prerelease packages using the _Manage NuGet Packages_ dialog. This may change 
in the future.

To allow installation of a prerelease package, use the _Package Manager Console_ and specify the 
`-IncludePrelease` flag.

    Install-Package CoolStuff -IncludePrelease

This command includes prerelease packages in the set of packages considered. If a prerelease package is 
the latest version, then it is installed. If a stable package is the latest, it is installed. This flag 
does not force a prerelease package to be installed.

You are also free to use the `-Pre` alias for installing prerelease packages.

    Install-Package CoolStuff -Pre

NuGet does not allow a stable package to reference a prerelease package. This avoids accidentally installing 
a prerelease package when you're only interested in stable packages.

### Upgrading Prerelease Packages
The `Update-Package` command will update all packages to the latest stable version. As before, use the 
`-IncludePrelesase` flag to upgrade to the latest stable or prelease package, whichever is latest.

## Constraining Upgrades To Allowed Versions
By default, when running the `Update-Package` command on a package (or updating the package using dialog), 
it will be updated to the latest version in the feed. With the new support for updating all packages, there 
may be cases in which you want to lock a package to a specific version range. For example, you may know in 
advance that your application will only work with version 2.* of a package, but not 3.0 and above. In order 
to prevent accidentally updating the package to 3, NuGet supports constraining the range of versions that 
packages can be upgraded to by hand editing the `packages.config` file using the `allowedVersions` attribute.

For example, the following example shows how to lock the `SomePackage` package the version range 2.0 - 3.0 
(exclusive). The `allowedVersions` attribute accepts values using the</code> version range format described 
earlier.

    <?xml version="1.0" encoding="utf-8"?>
    <packages>
        <package id="SomePackage" version="2.1.0" allowedVersions="[2,3)" />
    </packages>

Currently, locking a package to a specific version range requires hand-edited the packages.config file.

    PM> Enable-PackageRestore
    Attempting to resolve dependency 'NuGet.CommandLine (≥ 1.4)'.
    Successfully installed 'NuGet.CommandLine 1.4.20615.182'.
    Successfully installed 'NuGet.Build 0.16'.
 
    Copying nuget.exe and msbuild scripts to D:\Code\StarterApps\Mvc3Application\.nuget
    Successfully uninstalled 'NuGet.Build 0.16'.
    Successfully uninstalled 'NuGet.CommandLine 1.4.20615.182'.
 
    Don't forget to commit the .nuget folder
    Updated 'Mvc3Application' to use 'NuGet.targets'
    Enabled package restore for Mvc3Application

And you’re done! So basically, the first command installs a NuGet package which brings
in some helpful commands, and the second one runs one of those commands.

After doing this, you’ll notice a new .nuget folder under your solution, containing
nuget.exe plus a couple msbuild target files. Make sure you commit that folder to
source control! You’ll also find a few changes in your csproj files to trigger the restore functionality when you build.
