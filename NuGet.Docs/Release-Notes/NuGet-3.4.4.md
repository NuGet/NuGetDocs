# NuGet 3.4.4 Release Notes

The primary focus of this release was improvements to the quality of 3.4.3 version of nuget.exe with a few fixes to the Visual Studio extension as well.

You can download both the VSIX and NuGet.exe [here](https://dist.nuget.org/index.html).

## [3.4.4-rtm](https://github.com/NuGet/NuGet.Client/tree/3.4.4-rtm) (2016-05-19)

[Full Changelog](https://github.com/NuGet/NuGet.Client/compare/3.5.0-beta-final...3.4.4-rtm)

[List of Issues](https://github.com/NuGet/Home/issues?q=is%3Aissue+milestone%3A3.4.4+is%3Aclosed)

**Changes:**

- Fixes for pack [\#606](https://github.com/NuGet/NuGet.Client/pull/606)
- Display exception when there is a failure finding projects in update command [\#605](https://github.com/NuGet/NuGet.Client/pull/605) 
- Fixed E2E tests [\#604](https://github.com/NuGet/NuGet.Client/pull/604)
- Read package type from input .nuspec and project.json when packing [\#603](https://github.com/NuGet/NuGet.Client/pull/603) 
- Make NuGet.Shared not a project. [\#602](https://github.com/NuGet/NuGet.Client/pull/602) 
- Fix PackageManagement tests. [\#601](https://github.com/NuGet/NuGet.Client/pull/601) 
- Use the push timeout as the HTTP response timeout [\#599](https://github.com/NuGet/NuGet.Client/pull/599)
- Add serviceable attribute. [\#598](https://github.com/NuGet/NuGet.Client/pull/598) 
- Package files with future times will not have their times used [\#597](https://github.com/NuGet/NuGet.Client/pull/597)
- Make NuGet.Frameworks conditionally internal and C\# 5 compatible [\#595](https://github.com/NuGet/NuGet.Client/pull/595)
- Updating NuGet.Core.dll version to 2.12.0 to fix XML issue [\#594](https://github.com/NuGet/NuGet.Client/pull/594)
- Support ./NuGet.CommandLine.XPlat -v \<verbosity\> \<mode\> [\#593](https://github.com/NuGet/NuGet.Client/pull/593)
- Display error restoring without project.json or packages.config [\#590](https://github.com/NuGet/NuGet.Client/pull/590)
- Fixing dependency versions when required versions differ [\#559](https://github.com/NuGet/NuGet.Client/pull/559)