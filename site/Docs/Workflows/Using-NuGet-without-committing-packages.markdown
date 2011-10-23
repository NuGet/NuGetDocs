# Using NuGet without committing packages to source control

The original NuGet workflow has been to commit the Packages folder into source control. The 
reasoning is that it matches what developers typically do when they don't have NuGet: they create a 
‘Lib' or ‘ExternalDependencies' folder, dump binaries into there and commit them to source control 
to allow others to build.

While this has worked fine for some users, we have also heard from many that committing packages 
into source control is not what they want to do. When using a DVCS like Mercurial or Git, committing 
binaries can grow the repository size like crazy over time, making cloning more and more painful. In 
fact, this has been one of the top requests on NuGet our issue tracker.

The good news is that NuGet now offers a workflow which goes a long way to solving this problem, and is
really easy to set up. Here is the way to do it:

Let’s assume that you have a solution that is either already using NuGet, or planning to use it, and that
you want to set up the no-commit workflow.

Now, you just need to go to the Package Manager Console and run a couple commands:

    PM> Install-Package NuGetPowerTools
    Successfully installed 'NuGetPowerTools 0.28'.

## Constraining Upgrades To Allowed Versions
By default, when running the `Update-Package` command on a package (or updating the package using dialog), 
it will be updated to the latest version in the feed. With the new support for updating all packages, there 
may be cases in which you want to lock a package to a specific version range. For example, you may know in 
advance that your application will only work with version 2.* of a package, but not 3.0 and above. In order 
to prevent accidentally updating the package to 3, NuGet supports constraining the range of versions that 
packages can be upgraded to by hand editing the `packages.config` file using the `allowedVersions` attribute.

For example, the following example shows how to lock the `SomePackage` package the version range 2.0 - 3.0 
(exclusive). The `allowedVersions` attribute accepts values using the</code> [version range format](../Reference/Version-Range-Specification).

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
