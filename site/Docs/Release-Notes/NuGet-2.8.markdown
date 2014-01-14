# NuGet 2.8 Release Notes

## Acknowledgements

1. [leppie](https://www.codeplex.com/site/users/view/leppie)
    - [#3466](https://nuget.codeplex.com/workitem/3466) - When packing packages, verifying Id of dependency packages.
1. [maartenba](https://www.codeplex.com/site/users/view/maartenba) ([@Maarten Balliauw](https://twitter.com/maartenballiauw))
    - [#2379](https://nuget.codeplex.com/workitem/2379) - Remove the $metadata suffix when persistening feed credentials.
1. [FilipDeVos](https://www.codeplex.com/site/users/view/FilipDeVos) ([@Filip De Vos](https://twitter.com/foxtricks))
    - [#3538](http://nuget.codeplex.com/workitem/3538) - Support specifying project file for the nuget.exe update command.
1. [jjgonzalez](https://www.codeplex.com/site/users/view/jjgonzalez)
    - [#3536](http://nuget.codeplex.com/workitem/3536) - Replacement tokens not passed with -IncludeReferencedProjects.
1. [Sarkie](https://www.codeplex.com/site/users/view/Sarkie)
    - [#3677](http://nuget.codeplex.com/workitem/3677) - Fix nuget.push throwing OutOfMemoryException when pushing large package.
1. [Despostes](https://www.codeplex.com/site/users/view/Despostes)
    - [#3666](http://nuget.codeplex.com/workitem/3666) - Fix incorrect target path when project references another CLI/C++ project.

## Notable features in the release

### Patch Resolution for Dependencies
When resolving package dependencies, NuGet has historically implemented a strategy of selecting the lowest major and minor package version which satisfies the dependencies on the package. Unlike the major and minor verison, however, the patch version was always resolved to the highest version. Though the behavior was well-intentioned, it created a lack of determinism for installing packages with dependencies. Consider the following example:

```
PackageA@1.0.0 -[ >=1.0.0 ]-> PackageB@1.0.0

Developer1 installs PackageA@1.0.0: installed PackageA@1.0.0 and PackageB@1.0.0

PackageB@1.0.1 is published 

Developer2 installs PackageA@1.0.0: installed PackageA@1.0.0 and PackageB@1.0.1
```

In this example, even though Developer1 and Developer2 installed PackageA@1.0.0, each ended up with a different version of PackageB. NuGet 2.8 changes this default behavior such that the dependency resolution behavior for patch versions is consistent with the behavior for major and minor versions. In the above example, then, PackageB@1.0.0 would be installed as a result of installing PackageA@1.0.0, regardless of the newer patch version.

### -DependencyVersion Switch
Though NuGet 2.8 changes the _default_ behavior for resolving dependencies, it also adds more precise control over dependency resolution process via the -DependencyVersion switch in the package manager console. The switch enables resolving dependencies to the lowest possible version (default behavior), the highest possible version, or the highest minor or patch version.

![DependencyVersion Switch](Images/NuGet-2.8/dependencyversion.png)

### Preview NuGet Operations With -whatif
Some NuGet packages can have deep dependency graphs, and as such, it can be helpful during an install, uninstall, or update operation to first see what will happen. NuGet 2.8 adds the standard PowerShell -what if switch to the install-package, uninstall-package, and update-package commands to enable visualizing the entire closure of packages to which the command will be applied. For example, running `install-package Microsoft.AspNet.WebApi -whatif` in an empty ASP.NET Web application yields the following.

```
PM> install-package Microsoft.AspNet.WebApi -whatif
Attempting to resolve dependency 'Microsoft.AspNet.WebApi.WebHost (≥ 5.0.0)'.
Attempting to resolve dependency 'Microsoft.AspNet.WebApi.Core (≥ 5.0.0)'.
Attempting to resolve dependency 'Microsoft.AspNet.WebApi.Client (≥ 5.0.0)'.
Attempting to resolve dependency 'Newtonsoft.Json (≥ 4.5.11)'.
Install Newtonsoft.Json 4.5.11
Install Microsoft.AspNet.WebApi.Client 5.0.0
Install Microsoft.AspNet.WebApi.Core 5.0.0
Install Microsoft.AspNet.WebApi.WebHost 5.0.0
Install Microsoft.AspNet.WebApi 5.0.0
```

### Downgrade Package
It is not uncommon to install a prerelease version of a package in order to investigate new features and then decide to roll back to the last stable version. Prior to NuGet 2.8, this was a multi-step process of uninstalling the prerelease package and its dependencies, and then installing the earlier version. With NuGet 2.8, however, the update-package will now roll back the entire package closure (e.g. the package's dependency tree) to the previous version.

### Development Dependencies
Many different types of capabilities can be delivered as NuGet packages - including tools that are used for optimizing the development process. These components, while they can be instrumental in developing a new package, should not be considered a dependency of the new package when it is later published. NuGet 2.8 enables a package to identify itself in the .nuspec file as a developmentDependency. When installed, this metadata will also be added to the packages.config file of the project into which the package was installed. When that packages.config file is later analyzed for NuGet dependencies during `nuget.exe pack`, it will exclude those dependences marked as development dependencies.

### Individual packages.config Files for Different Platforms
When developing applications for multiple target platforms, it is common to have different project files for each of the respective build environments. It is also common to consume different NuGet packages in different project files, as packages have varying levels of support for different platforms. NuGet 2.8 provides improved support for this scenario by creating different packages.config files for different platform-specific project files.

![Multiple package.config files](Images/NuGet-2.8/multiple-packageconfigs.png)

### Fallback to Local Cache
Though NuGet packages are typically consumed from a remote gallery such as [the NuGet gallery](http://www.nuget.org/) using a network connection, there are many scenarios where the client is not connected. Without a network connection, the NuGet client was not able to sucesfully install packages - even when those packages were already on the client's machine in the local NuGet cache. NuGet 2.8 adds automatic cache fallback to the package manager console. For example, when disconnecting the network adaptor and installing jQuery, the console shows the following:

```
PM> Install-Package jquery
The source at nuget.org [https://www.nuget.org/api/v2/] is unreachable. Falling back to NuGet Local Cache at C:\Users\me\AppData\Local\NuGet\Cache
Installing 'jQuery 2.0.3'.
Successfully installed 'jQuery 2.0.3'.
Adding 'jQuery 2.0.3' to WebApplication18.
Successfully added 'jQuery 2.0.3' to WebApplication18.
```

The cache fallback feature does not require any specific command arguments. Additionally, cache fallback currently works only in the package manager console - the behavior does not currently work in the package manager dialog.

### WebMatrix NuGet Client Updates
Along with NuGet 2.8, the NuGet extension for WebMatrix was also updated to include many of the major features delivered with [NuGet 2.5](http://docs.nuget.org/docs/release-notes/nuget-2.5). New capabilities include those such as 'Update All', 'Minimum NuGet Version', and allowing for overwriting of content files.

### Bug Fixes
In addition to these features, this release of NuGet also includes many other bug fixes. There were 97 total issues addressed in the release. For a full list of work items fixed in NuGet 2.7, please view the [NuGet Issue Tracker for this release](https://nuget.codeplex.com/workitem/list/advanced?release=NuGet%202.8&status=all).
