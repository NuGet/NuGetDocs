# Reinstalling Packages and its Pitfalls #

Reinstalling a package is a simple act of uninstalling a package and installing back the same version of the package that was uninstalled. The 2 steps involved are nicely bundled up in the –reinstall switch of the Update-Package command as shown below. But, it is ESSENTIAL that one understands the changes this single command can bring to a project before using it. Please note that this doc will be updated in the near future to cover more scenarios

	Update-Package –reinstall <packageName>

## Prior Knowledge required and Reference ##

1.	[Package can support multiple .NET Framework Versions and Profiles](http://docs.nuget.org/docs/creating-packages/creating-and-publishing-a-package#Supporting_Multiple_.NET_Framework_Versions_and_Profiles)
2.	[Original Codeplex discussion on –reinstall switch](https://nuget.codeplex.com/discussions/256212)
3.	[Codeplex Issue with info on various cases involved with -reinstall switch](http://nuget.codeplex.com/workitem/1779)

## Why do you need it? ##

1.	Project Retargeting or Upgrade: This can be useful when a project has been retargeted or upgraded and if the package REQUIRES reinstallation due to the recent change in target framework. In NuGet 2.7, when this happens, we should a build error right after project retargeting and subsequently, build warnings to let you know that the package may need to be reinstalled. For project upgrade, we show an error in the Project Upgrade Log
2.	You Broke the Project: Simply because you modified contents installed from a package and this broke your project. You just want to go back to a state where the package contents present in your project match the actual contents of the package
3.	Package Update Broke the Project: You updated a package. And, this broke your project. The failure is generally caused by a dependency package which may have gotten updated by you or by an update-package. All you want is to go back to a state where the older version of the troubling dependency package where things were fine
4.	Improved NuGet Package Development cycle. Package authors often need to reinstall the same version of package they are developing to test the behavior. The command Install-Package does not provide ‘-force’ option, that could forcefully reinstall a package. So, `Update-Package -reinstall` is added to meet that requirement

## When to and when NOT to use it? ##

Reinstalling packages seem pretty straightforward. But, it can get very tricky since the following may affect or be affected by it

1. Project Retargeting or Project Upgrade where the target framework of the project gets changed
2. Package Dependencies and their versions
3. Dependent Packages and their versions

The cases above are covered in detail below

1.	Reinstalling packages according to project target framework retargeting
	1. USE IT: In a simple case, just reinstalling a package using `Update-Package –reinstall <packageName>` will do the trick. Package installed against old target framework gets uninstalled and the same package gets installed against the current target framework of the project
	2.	DON’T USE IT: In a slightly more complex but not uncommon case, there may be a dependent package that still consumes the contents pertaining to the old target framework of the package needing one to not reinstall the package
		- For example: Package A was installed against .NET 4.0. Package B depends on Package A. Package B does not multi-target, however, Package A does. Now, retargeting the project to .NET 4.5 has no issues. Project builds and runs fine. If, however, Package A was reinstalled, project may not build properly or worse yet fail at run-time. This is because the latest Package B may be created to depend on Package A targeting .NET 4.0; the different contents brought in by Package A targeting .NET 4.5 might cause issues. So, in this case, do not reinstall package
2.	Reinstalling packages when package dependency versions are involved
	1. It is known that when a package is reinstalled using ‘Update-Package –reinstall’, the same version of the package is installed. However, this is not true for package dependencies. The version of the package dependency that is installed is determined by package dependency version constraints if provided (or the latest if none is provided). Since the version of the package dependency that worked best is determined by you, use one of the following
		-	`Update-Package –reinstall <packageName>` when updating the package dependencies is required for fixing an issue
		-	`Update-Package –reinstall <packageName> -ignoreDependencies` when updating package dependencies might result in a broken state 
3.	Reinstalling packages when dependent versions are involved
	-	Not surprisingly, Update-Package –reinstall does not change versions of the dependent packages. While this is expected, as explained in the example of 1.2 above, versions of dependent versions need to be taken into account to determine if a package should be reinstalled or not
