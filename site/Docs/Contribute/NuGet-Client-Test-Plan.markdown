# NuGet Client Test Plan
# 

## Visual Studio Versions
*    Visual Studio 2010
*    Visual Studio 2012
*    Visual Studio 2013
*    In-Development Visual Studio Release

## Visual Studio SKUs
*    Visual Studio Express For Web
*    Visual Studio Express for Desktop
*    Visual Studio Express for Phone
*    Visual Studio Express for Windows 8
*    Visual Studio Premium
*    Visual Studio Professional 
*    Visual Studio Ultimate

## Other
*    WebMatrix 3

## OS
*    Windows XP
*    Windows 7
*    Windows 8

## Pivots
*    Functional
*    Performance
*    Stress
*    UX
*    Accessibility
*    Localization
*    Globalization
*    Installation
*    End-to-end 

## Package Types

*    User is able to install/update various types of packages
    *    Solution level packages
    *    Portable class library packages
    *    Packages dependent on other packages
    *    Diamond dependency
    *    Packages that add binding redirects
    *    Packages from curated feed
    *    Templates with pre-installed packages like MVC
    *    Packages with readme.txt
    *    Packages at project-level with dependent packages at solution-level and vice-versa
    *    Packages with AllowedVersion specified in packages.config
    *    Packages with Framework Specific libraries, profile specific libraries and GAC references
    *    Pre-Release packages
    *    Packages with SemVer
*    &lt;references&gt; in nuspec
*    empty &lt;files /&gt; in nuspec
*    exclude file in nuspec
*    Satellite packages for localized resources
*    Group dependencies by Target Framework
*    Grouping content files and PS by Target Framework
*    Web config transform

## Project Types

*    Web Application Projects (MVC, Webforms)
*    Websites
*    Windows 8
*    Windows Phone 
*    F#
*    WiX
*    Class Libraries
*    Console Applications
*    Native Projects
*    Xamarin Projects
*    Universal Apps

## NuGet.Config

*    User is able to discover and apply various settings that are stored in nuget.config
*    User is able to store and retrieve data from solution level and root nuget.config
*    User is able to use hierarchy config
*    Can specify repositoryconfig path
*    Can specify relative path for repositorypath
*    Repository token and $ expand correctly
*    UNC path for repositorypath works fine
*    User is able to add/edit/remove/reorder/disable feeds from tool->options->package manage dialog
*    User is able specify packages folder location
*    User is able to use –Config switch with nuget.exe commands (except Spec and Pack) to point to a config file
*    Machine-wide NuGet Configuration defaults
    *    Enabled package sources
    *    Registered, but disabled package sources
    *    The default nuget.exe push source
*    DependencyVersion attribute 

## NuGet.exe

*    User is able to use nuget.exe in CI scenarios or as a CLI tool to perform various package operations
*    A mono user should be able to run nuget.exe (basic sanity validation)
*    install: user is able to install packages using following options of the command
    *    source (from multiple sources)
    *    outputdirectory
    *    Version
    *    ExcludeVersion
    *    PreRelease
    *    no cache
    *    RequireConsent
    *    Solutiondirectory
*    pack: user is able to create packages
    *    OutputDirectory
    *    BasePath
    *    Version
    *    Exclude
    *    Symbols
    *    Tool
    *    Build
    *    NoDefaultExcludes
    *    NoPackageAnalysis
    *    ExcludeEmptyDirectories
    *    Properties
    *    pack on project automatically includes dependencies
    *    nuspec tokens from nuspec file are replaced correctly in the package
    *    Specifying entire folder for package contents in nuspec
    *    minClientVersion
    *    developmentDependency 
*    config: user is able to set a config value
*    delete: user is able to delete package 
*    list command: user is able to list packages with following options
    *    Source
    *    AllVersions
    *    Prerelease
    *    user is able to list with user specific config file
*    spec command: user is able to generate a .nuspec file
*    update command: user is able to update packages
    *    source
    *    id
    *    repositorypath
    *    Safe
    *    Self
    *    Prerelease
*    User is able to use relative path (. Or ..) with nuget.exe commands
*    All the messages for nuget.exe are localized
*    Push
    *    Able to push to Official Source/ Private Sources with APIKey/ Credentials
    *    Able to push to UNC/ Local Sources

## NuGet.Server

*    Enable Windows Authentication, enable ASP.NET impersonation. Grant access to the packages folder to user A and deny access for user B
    *    When user A runs nuget push, the package is added to the packages folder.
    *    When user B runs nuget push, nuget will ask the user to provide another credential. If user A’s credential is provided, then package is pushed successfully.
*    Enable Basic Authentication. Grant access to the packages folder to user A; and deny access for user B 
    *    When running nuget push, nuget will ask the user to provide credential (no matter who’s running it). If user B’s credential is provided, nuget will ask credential again. If user A’s credential is provided, the package will be pushed successfully.
*    Test nuget delete / install / restore with the same setup in scenarios 1 & 2. 
*    Create redirect, test that nuget will follow the redirection.
*    Test that nuget push works on both .net 4.0 and .net 4.5, with or without –DisableBuffering switch
*    Verify new packages show up in search after a push, or after manually copying the nupkg into the packages folder.
*    Verify web.config switches are used

## Authentication

*    User is able to use feed sources while behind proxy/authentication
*    User is able to use nuget.exe with authentication
*    User is able to use nuget features behind a proxy requiring authentication
*    Proxies requiring authentication
*    Repositories requiring authentication

## Feed Sources

*    Official source
*    Private hosted galleries
*    Source requiring authentication
*    Local
*    UNC
*    Install/ UnInstall/ Update/Restore with different feed sources
*    Enable/ Disable different Sources
*    Machine-wide source
*    Curated Feeds
*    Add/ Remove/ Edit feed sources
    *    NuGet.Config
    *    Visual Studio ‘Package Manager Settings’ dialog


## Package Manager Dialog 

###Package Management/UI
*    User is able to effectively use UI to manage packages in a solution/project
*    User is able to launch the dialog on any supported project type and Solutions with supported project types
*    User is able to see list of installed packages and manage/uninstall/search them for project level and solution level"
*    User is able to see list of available updates and manage/search them for project level and solution level
*    Pagination of packages works fine
*    Package details in the right side pane of the dialog is shown correctly
*    Performance of the dialog for solutions containing large number of projects is acceptable
*    Shows correctly the packages installed for a project/solution
*    Filter projects for compatible packages in Solution Level dialog

###Search
*    User is able to search packages and use tags while searching 
*    User is able to filter packages with various options like pre-release, sort by download 
*    User is able to find relevant results for his search terms

###Project Operations
*    For large projects (project with large number of files/content) installing a package perf is acceptable
*    Pulls in dependencies correctly
*    Uninstall/Reinstall scenario works fine 
*    Shows errors correctly if there was an issue installing a package or its dependency and rolls back. Error message is understandable and has good details
*    Solution level and project level packages.config is updated correctly
*    Project references are added/ removed correctly
*    Content files are placed/ removed correctly
*    PS scripts are run correctly
*    Package uninstall is clean and brings the project back to its previous state
*    Update All packages at once
*    Install packages with minClientVersion
*    Packages with dependency constraints already satisfied don’t update dependencies
*    Development Dependency attribute in Packages.Config
*    Install packages with leading zeroes in Version

## NuGet PowerShell Console
(Most of the NuGet Package Manager Dialog tests apply here)

*    Test against PS V2 and V3
*    User is able to use various controls on the NuGet PowerShell console 
*    Powershell intellisense for packages & command options are shown correctly
*    User can switch between different package source from the source dropdown
*    User is able to switch between projects from project dropdown
*    Intellisense is shown for packages installing additional command(for example, EntityFramework, MVC scaffolding)
*    User is able to use PowerShell console to do various operations on the  project quickly in addition to install/ uninstall/ update/ reinstall
    *    add-bindingredirect
    *    get-project
*    User is able to install a particular version of a package using Version switch
*    User is able to fall back to Cache while installing a package if other sources are unreachable
*    User is able to downgrade a package by specifying a lower version using Version switch
*    User is able to install/ update/ uninstall a package and ignore its dependencies
*    User is able to overwrite content files using FileConflictAction switch
*    User is able to control the patch version using DependencyVersion switch
*    User is able to use WhatIf switch to review the operations that will be performed on PSC commands

## Package Restore
*    User is able to restore packages after a solution, withoug packages folder, is pulled down from TFS and is able to get the project to build
*    Package Manager shows package restore yellow bar when packages are missing
*    Package Manager Consoles shows package restore yellow bar when packages are missing
*    Package restore works fine with parallel builds
*    Package Manager downloads packages onlu when the consent from tools->options->package manager settings is on (It is on by default)
*    Package restore for a solution which contains packages that are now deprecated/ unlisted works
*    Package Restore Consent Scenarios
*    Projects under Solution folder
*    Projects in nested folder structure

## Miscellaneous

*    Visual studio shows an update of NuGet is available for download
*    User is able to set options for NuGet using Tools->Options dialog (Clear NuGet Cache, Enable Package Restore, Enable consent)
*    Project Templates with pre-installed packages (Single Repository, Multiple Repository)
*    .NET Micro Framework
*    Quick Launch Integration
*    User agents passed from Client to Server (Project GUIDs, Direct install, Dependency install)
*    Retarget project’s target framework and verify friendly warnings



