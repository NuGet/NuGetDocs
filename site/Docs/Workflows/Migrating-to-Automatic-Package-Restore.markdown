# Migrating MSBuild-Integrated solutions to use Automatic Package Restore

Solutions currently using MSBuild-Integrated package restore can be migrated to Automatic Package Restore. Prior to migrating, it can help to understand some of the differences between the two approaches.

Projects that use MSBuild-Integrated package restore typically contain a .nuget folder with three files:

1. NuGet.Config
1. NuGet.exe
1. NuGet.targets

Since the presence of a NuGet.targets file determines whether NuGet will continue to use the MSBuild-Integrated approach, this file must be removed. Also, as the .nuget\NuGet.exe file is not used by Automatic Package Restore, it likewise can be removed.

By default, the NuGet.Config file instructs NuGet to bypass adding package binaries to source control. Automatic Package Restore will honor this as long as you leave this file in place.

In addition to these files, NuGet modifies the project files in the solution to reference the NuGet.targets file so it can participate in the build process. When migrating to Automatic Package Restore, these references must also be removed.

With these details in mind, follow these steps to complete the migration:

1. Remove the NuGet.exe and NuGet.targets files from the solution's .nuget folder. Make sure the files themselves are also removed from the solution workspace.
1. Retain the NuGet.Config file to continue to bypass adding packages to source control.
1. Edit each project file (e.g., .csproj, .vbproj) in the solution and remove any references to the NuGet.targets file. To do so, search for Nuget.targets and remove the entire &lt;Import Project&gt; line where it is referenced.

To test the migration:

1. Save the solution and close Visual Studio.
1. Remove the packages folder located under the solution root.
1. Reopen the solution in Visual Studio.
1. Rebuild the solution. Automatic Package Restore should a) Download and unzip each package, and; b) Ignore adding the packages to source control.
