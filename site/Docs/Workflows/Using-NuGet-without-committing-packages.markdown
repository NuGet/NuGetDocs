# Using NuGet without committing packages to source control

The original NuGet workflow has been to commit the Packages folder into source control. The 
reasoning is that it matches what developers typically do when they don't have NuGet: they create a 
`Lib` or `ExternalDependencies` folder, dump binaries into there and commit them to source control 
to allow others to build.

While this has worked fine for some users, we have also heard from many that committing packages 
into source control is not what they want to do. When using a DVCS like Mercurial or Git, committing 
binaries can grow the repository size like crazy over time, making cloning more and more painful. In 
fact, this has been one of the top requests on NuGet our issue tracker.

The good news is that NuGet now offers a workflow which goes a long way to solving this problem, and is
really easy to set up. Here is the way to do it:

## Setup
Let’s assume that you have a solution that is either already using NuGet, or planning to use it, and that
you want to set up the no-commit workflow.

Right click on the _Solution_ node in Solution Explorer and select _Enable NuGet Package Restore_.

![Enable NuGet Package Restore Context Menu item](images/enable-package-restore.png)

**That's it!** You're all set.

## Details
So what exactly did that do? It added a solution folder named `.nuget` containing `NuGet.exe` and a 
`NuGet.targets` MsBuild file. It also changed every project in the solution to import the `NuGet.targets` 
MsBuild task.

![New Solution folder with package restore files](images/package-restore-solution.png)

With this in place, any time a project is compiled, the build task will look at each project's 
`packages.config` file and for each package in that file, ensure that the corresponding package 
exists within the `packages` folder. For any missing package, the build task will download and 
unpack the package.

In the restore scenario, NuGet will grab the exact version when restoring a package. It will not 
perform any upgrades.