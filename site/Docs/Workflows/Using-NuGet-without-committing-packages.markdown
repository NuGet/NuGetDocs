# Using NuGet Without Committing Packages to Source Control

Using distributed version control systems such as Mercurial or Git provide great benefits, with the
caveat that commiting binaries into your source tree can grow the repository over time.  NuGet offers 
a workflow that goes a long way to solving this problem and is easy to set up.

The original NuGet workflow was to commit the Packages folder into source control. The 
reasoning is that it matches what developers typically do when they don't have NuGet: they create a 
`Lib` or `ExternalDependencies` folder, dump binaries into there and commit them to source control 
to allow others to build.  If you choose, this method is still fully workable and you can continue
to employ it in your environment. 

However, if you do want to take advantage of binary-free commits, here is how you do it:

## Enabling Package Restore During Build

Beginning with NuGet 2.0, [restoring packages during build requires explicit consent from the
user](http://blog.nuget.org/20120518/package-restore-and-consent.html). This must be done on
each machine that builds the project.

In Visual Studio, enable "Allow NuGet to download missing packages during build". This setting lives
under **Options -> Package Manager -> General**.

![Allow NuGet to download missing packages setting](images/allow-package-restore-configuration.png)

**To enable package restore for build servers without Visual Studio installed, you can also set the
environment variable `EnableNuGetPackageRestore` to "true".**

## Project Setup
Let’s assume that you have a solution that is either already using NuGet, or planning to use it, and that
you want to set up the no-commit workflow.

Right click on the _Solution_ node in Solution Explorer and select _Enable NuGet Package Restore_.

![Enable NuGet Package Restore Context Menu item](images/enable-package-restore.png)

**That's it!** You're all set.

## Details
So what exactly did that do? It added a solution folder called _.nuget_ with the following three files:

 1. NuGet.exe
 1. NuGet.targets 
 1. NuGet.config

More specifically, it downloaded and extracted two NuGet packages: [NuGet.Commandline](http://nuget.org/packages/nuget.commandline) 
for _NuGet.exe_ and [NuGet.Build](http://nuget.org/packages/nuget.build) for _NuGet.targets_. It also changed 
every project in the solution to import the _NuGet.targets_ MsBuild task, which you can see as a 
single-line entry near the end of your project file:

  <Import Project="$(SolutionDir)\.nuget\nuget.targets" />

![New Solution folder with package restore files](images/package-restore-solution.png)

The _NuGet.config_ file contains the following XML:

	<configuration>
	  <solution>
	    <add key="disableSourceControlIntegration" value="true" />
	  </solution>
	</configuration>

The `disableSourceControlIntegration` setting instructs version control systems like TFS to not 
add the NuGet packages folder to the pending check-ins list.

With this in place, any time a project is compiled, the build task will look at each project's 
_packages.config_ file and for each package listed, ensure that the corresponding package exists within 
the packages folder. For any missing package, the build task will download and unpack the package.

In this scenario, NuGet will grab the exact version when restoring a package. It will not perform any upgrades.

<p class="caution"><b>Be sure to check in your _packages.config_ file.</b> Some version control systems, 
such as SVN, may not allow you to exclude a path _and_ include a file, such as your _packages.config_ in 
the subdirectory of "Packages". You'll need to agree with your team to include the folder from the root 
of your solution, explicitly include the _packages.config_ file but _not_ check in any packages. Without 
the file you may experience problems loading or building a solution with package restore enabled.</p>

## Mono
On mono you can run `xbuild` on the project file or on your solution and it should successfully 
restore packages for any project that has package restore enabled.
