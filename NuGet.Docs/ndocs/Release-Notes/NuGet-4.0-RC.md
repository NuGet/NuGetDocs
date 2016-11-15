# 4.0 RC Release Notes

[NuGet 3.5 RTM Release Notes](nuget-3.5-RTM)

## New Features

### Improved Package Management in your project file with PackageReference

NuGet 2 enabled package management through a `packages.config` file, with synchronized edits of the project file to coordinate references.

NuGet 3 enabled package management through a `project.json` file, with references for the desired package (and all of its dependencies) just-in-time created during build, so the project file synchronization is no longer necessary.

NuGet 4 takes the benefits of NuGet 3’s model and enables integrated package management in your project file. References (&lt;References&gt;), project references (&ltProjectReferences&gt;), and package references (&lt;PackageReference&gt;) are all managed and controlled by MSBuild. This provides a unifed and consistent way to manage NuGet dependencies across all project types.

New .NET Core project types use PackageReference. In these projects, NuGet 4 enables multi-targeting (building for more than one TargetFramework with the same project) and the ability to use MSBuild conditions on PackageReference. PackageReference was built to be first class for .NET Core and beyond.

<div class="callout-block-info">
    <strong>Note:</strong><br>
    NuGet 4 RC supports PackageReference .NET Core projects only. NuGet 4.0 RTM aims to fully support PackageReference for other project types like WPF,UWP, Win Forms, class libraries, and project types that support project.json.
</div>

For additional details, see [PackageReference](/ndocs/consume-packages/packagereference).

### DotNetCliToolsReference

To use .NET Core CLI tools, you must list the DotNetCliToolsReference in the project file.

### Better Performance

NuGet 4 improves performance across several key scenarios such as update, install, and restore, which are significantly faster.

### Making NuGet a first-class citizen of MSBuild

NuGet 4 has invested in improving the NuGet experience with MSBuild. Restore and Pack are first-class MSBuild targets, which allows you to take advantage of MSBuild capabilities as part of your workflow. That is, you can work with NuGet as you would with any task or target in MSBuild and enable customization along with other parts of your build pipeline:

- Build packages directly from a project without the need of downloading and updating a separate nuget.exe. For example, you can do `msbuild /t:pack` in a project directory, which generates a NuGet package using the properties and metadata declared in the csproj file of the project.
- In CI systems, you don’t need to download and update a separate nuget.exe to run `nuget restore`. You can  use `msbuild /t:restore` instead.

### Background Package Restore

In the past, you had to perform a build or an explicit restore to restore NuGet packages. NuGet 4's background package restore automatically downloads and adds or removes NuGet packages as you edit PackageReferences and save your project files.

<div class="callout-block-info">
    <strong>Note:</strong><br>
    Background package restore is currently supported for .NET Core projects and in the future, we will extend it to all project types that support PackageReference.
</div>

### UI Improvements

You can now clear the all Nuget caches through Visual Studio from Tools/Options/Nuget Package Manager/General instead of needing to use NuGet.exe CLI.

### New .NET CLI commands

Some commands that were available only in nuget.exe on Windows now run with the DotNet CLI which on Windows, Mac OS X, and Linux, such as `dotnet nuget locals`, `dotnet nuget push`, `dotnet nuget delete`, `dotnet pack`, and `dotnet restore`. See [dotnet Commands](/ndocs/tools/dotnet-commands).

## Breaking Changes

### Default Location for the machine-wide NuGet.config

In Visual Studio 2017 and above, the machine-wide `NuGet.config` is now located at `%ProgramFiles(x86)%\NuGet\Config\`. Going forward, nuget.exe v4.0.0+ will also treat this as the new location for the machine-wide configuration. `NuGet.config` in `%ProgramData%\NuGet\Config\` will no longer be implicitly referenced or considered for hierarchical merging of `nuget.config`.

The primary driver for the change is to improve security in a multi-user scenarios. Previously NuGet would write to the `ProgramData` folders which don't require admin privileges to modify. Program Files folders are protected and only users with admin privileges, or those granted permissions by an administrator, can change their contents.

<div class="callout-block-info">
    <strong>Note:</strong><br>
    You must manually migrate existing config files from <code>%ProgramData%</code> to <code>%ProgramFiles(x86)%</code>.
</div>