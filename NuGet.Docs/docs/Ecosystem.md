# An Overview of the NuGet Ecosystem
First introduced in 2010, NuGet has been around for a few years now and many people and organizations are starting to realize that NuGet presents a great opportunity to improve and automate different aspects of the development processes. Because the NuGet project is open source under a permissive [Apache v2 license](http://choosealicense.com/licenses/apache/), other projects can leverage NuGet and companies can build support for it in their products. Whether for open source projects or enterprise application development, NuGet plus the ever-growing set of applications built on and around NuGet, provide a broad selection of tools for improving your software development process.

All of these projects are able to innovate for the same reason that has allowed NuGet to innovate - You. As such, please contribute to these projects just as you contribute to NuGet by reporting defects and new feature ideas, providing feedback, writing documentation, and contributing code where possible. 

## .NET Foundation Projects
The NuGet project provides a free, open source package management system for the Microsoft development platform and consists out of a few client tools ([NuGet Command Line](/Consume/Command-Line-Reference) and (NuGet Visual Studio Extension)[http://visualstudiogallery.msdn.microsoft.com/27077b70-9dad-4c64-adcf-c7cf6bc9970c?SRC=Home]), as well as the set of services that comprise the [official NuGet Gallery](http://www.nuget.org). Combined, these form the NuGet project which is governed by the [.NET Foundation](http://www.dotnetfoundation.org/).

The sources for the NuGet clients can be found on [Codeplex](http://nuget.codeplex.com/), while sources for NuGet Gallery  services are available on [GitHub](https://github.com/NuGet/).

### NuGet Core project
* License: Apache v2
* Sources: [https://nuget.codeplex.com](https://nuget.codeplex.com/)

Most NuGet client tools are based on the cross-platform `NuGet.Core` project. If you are building a NuGet client, the fastest way to get started is by either fetching and building the NuGet.Core project's [sources from Codeplex](https://nuget.codeplex.com/), or using the NuGet.Core binaries directly by installing the [NuGet.Core package](http://www.nuget.org/packages/Nuget.Core/) into your project. The following command installs the NuGet.Core package using the Visual Studio Package Manager Console.

    Install-Package NuGet.Core

### NuGet Command Line tool
* License: Apache v2
* Sources: [https://nuget.codeplex.com](https://nuget.codeplex.com/)

This is a command line wrapper around NuGet.Core.

More info: [NuGet Command Line Reference](/Consume/Command-Line-Reference)

### NuGet Server project
* License: Apache v2
* Sources: [https://nuget.codeplex.com](https://nuget.codeplex.com/)

To create a basic NuGet server and point it to a local folder or network share, create a new ASP.NET application and run the following command in the Package Manager Console to install the [NuGet.Server package](http://www.nuget.org/packages/NuGet.Server):

    Install-Package NuGet.Server

More info: [Install the NuGet.Server package](../Create/Hosting-Your-Own-NuGet-Feeds#Step-2%3a-Install-the-NuGet.Server-Package)

Benefits:

* requires minimal infrastructure (IIS and some diskspace)
* requires .NET Framework 4.0

Drawbacks:

* non-indexed storage (slower as repository-size increases)
* single API key for entire server
* no fine-grained security
* single NuGet feed per NuGet.Server application

### Official NuGet Gallery Services
* License: Apache v2
* Sources: [https://github.com/NuGet/NuGetGallery](https://github.com/NuGet/)

The official NuGet Gallery Web site is hosted at [http://www.nuget.org](http://www.nuget.org).
Availability info: [http://status.nuget.org/](http://status.nuget.org/)
Statistics: [http://www.nuget.org/stats](http://www.nuget.org/stats)

To set up your own NuGet Gallery, fetch the sources from GitHub and follow the instructions at [https://github.com/NuGet/NuGetGallery](https://github.com/NuGet/NuGetGallery).

Benefits:

* micro-service architecture enables fine-grained control over the desired NuGet gallery services
* indexed storage (faster querying)
* simple user system (authentication, API-key per user, manage own packages, emails)
* supports SSL

Drawbacks:

* gallery is comprised of several independent, loosely-coupled services, requiring fetching, building, and deploying code from multiple repositories
* requires proper infrastructure (IIS, SqlServer)
* requires .NET Framework 4.5 (.NET 4.5 is an in-place upgrade)
* requires you to fetch the sources, compile everything and configure quite a lot in source code and configuration files
* upgrading to new versions of the gallery requires repeating the fetch/update/build/deploy loop

### NuGet Concierge
* License: Apache v2
* Sources: https://github.com/NuGet/Concierge

[NuGet Concierge](http://concierge.nuget.org/) is a package recommendation service: upload a packages.config file and NuGet Concierge will recommend you packages you may find useful.

More info: [http://blog.nuget.org/20130816/introducung-nuget-concierge.html](http://blog.nuget.org/20130816/introducung-nuget-concierge.html)

## Microsoft Projects
Microsoft has extensively contributed to the development of the NuGet project. All contributions made by Microsoft employees are also open source and are donated (including copyrights) to the .NET Foundation.

### NuGet-based Microsoft Package Manager for Visual Studio 2013
* License: [Microsoft Software License (custom)](http://visualstudiogallery.msdn.microsoft.com/site/4ec1526c-4a8c-4a84-b702-b21a8f5293ca/eula?licenseType=None)
* Sources: [https://nuget.codeplex.com](https://nuget.codeplex.com/)

You can download this Visual Studio extension using the Visual Studio Extension Manager or directly from the Visual Studio Gallery at [http://visualstudiogallery.msdn.microsoft.com/4ec1526c-4a8c-4a84-b702-b21a8f5293ca](http://visualstudiogallery.msdn.microsoft.com/4ec1526c-4a8c-4a84-b702-b21a8f5293ca).

More info:

* Using the [Manage NuGet Packages Dialog](../Start-Here/managing-nuget-packages-using-the-dialog)
* Using the [Package Manager Console](../Start-Here/using-the-package-manager-console)

### NuGet-based Microsoft Package Manager for Visual Studio 2012/2010
* License: [Microsoft Software License (custom)](http://visualstudiogallery.msdn.microsoft.com/site/27077b70-9dad-4c64-adcf-c7cf6bc9970c/eula?licenseType=None)
* Sources: [https://nuget.codeplex.com](https://nuget.codeplex.com/)

You can download this Visual Studio extension using the Visual Studio Extension Manager or directly from the Visual Studio Gallery at [http://visualstudiogallery.msdn.microsoft.com/27077b70-9dad-4c64-adcf-c7cf6bc9970c](http://visualstudiogallery.msdn.microsoft.com/27077b70-9dad-4c64-adcf-c7cf6bc9970c).

More info:

* Using the [Manage NuGet Packages Dialog](../Start-Here/managing-nuget-packages-using-the-dialog)
* Using the [Package Manager Console](../Start-Here/using-the-package-manager-console)

### Visual Studio Team Services Package Management
In fall 2015, [Visual Studio Team Services](https://www.visualstudio.com/products/what-is-visual-studio-online-vs) launched a public preview of NuGet package hosting. VSTS's solution provides
* Private package hosting for your team or entire organization,
* Enterprise-grade security and authentication,
* Seamless integration with other VSTS components such as Team Build, and
* Easy integration with third-party dev tools like Jenkins.
Package management will also be added to the on-premises TFS product in 2016.

More info:

* [Announcing package management support for VSTS](http://blogs.msdn.com/b/visualstudioalm/archive/2015/08/27/announcing-package-management-for-vso-tfs.aspx)

## Non-Microsoft Projects
In addition to Microsoft, many other individuals and companies have made significant contributions to the NuGet ecosystem. Each project listed here may have a different license than the core NuGet components so please confirm that the license terms are acceptable prior to use. 

### NuGet Package Explorer
One of the developers of the core NuGet team at Microsoft, [Luan Nguyen](https://twitter.com/dotnetjunky "dotnetjunky"), created a great graphical tool to work with NuGet packages. The GUI allows you to very easily [create, publish](/Create/Using-a-GUI-to-build-packages), download and inspect NuGet packages and their metadata.

* Click-Once (desktop) application: [http://npe.codeplex.com](http://npe.codeplex.com)
* Windows 8 app: [http://apps.microsoft.com/windows/en-us/app/nuget-package-explorer/3148c5ae-7307-454b-9eca-359fff93ea19/m/ROW](http://apps.microsoft.com/windows/en-us/app/nuget-package-explorer/3148c5ae-7307-454b-9eca-359fff93ea19/m/ROW)
* Windows Phone 8 app: [http://www.windowsphone.com/en-us/store/app/nuget-package-explorer/3cb19574-1565-4f1c-aa42-f5cccc385053](http://www.windowsphone.com/en-us/store/app/nuget-package-explorer/3cb19574-1565-4f1c-aa42-f5cccc385053)
* Silverlight: [http://dotnetjunky.info/slnpe.html](http://dotnetjunky.info/slnpe.html)

### MyGet (or NuGet-as-a-Service)
MyGet is a NuGet server that allows you to create and host your own NuGet, NPM, Bower and VSIX feeds. It is hosted on Azure and has a freemium offering, meaning you can use it for free (within the constrains of [the free plan](https://www.myget.org/plans)) or subscribe to one of the paying plans if you require more resources or features. More info at [https://www.myget.org](https://www.myget.org).

* Availability and history: [http://status.myget.org](http://status.myget.org).
* Documentation: [http://docs.myget.org](http://docs.myget.org).
* Twitter: [https://twitter.com/mygetteam](https://twitter.com/mygetteam)
* JabbR: [https://jabbr.net/#/rooms/myget](https://jabbr.net/#/rooms/myget)

Provides:

* requires no infrastructure
* allows you to get started in a few clicks and focus on the packages instead of the server
* fully compatible with all NuGet client tools
* free software updates (including support for to the latest NuGet version)
* free for open source projects (meeting criteria and within allowed quota)
* publish and promote your feed in the public gallery
* supports NuGet Feed Discovery and Package Source Discovery
* extended feed functionality
  * SSL-by-default
  * feed visibility (public, readonly or private)
  * activity streams
  * strict SemVer validation for packages being pushed
  * upload packages directly in the browser
  * add packages from another feed (upstream package source)
  * upstream package source presets for nuget.org, chocolatey, teamcity, etc
  * filter upstream package sources
  * mirror upstream package sources
  * package promotion to an upstream package source
  * (automatic or manual) package mirroring
  * RSS
  * package retention rules
  * download entire feeds as ZIP archives for backup purposes
  * download packages from the web (without the need for nuget client tools)
  * integration with symbolsource (shared credentials and feed/repository security settings)
  * multiple endpoints, including the v1-compatible endpoint (e.g. you can use the feed as a custom Orchard Gallery feed)
* granular security: 
  * API key per user
  * user-roles on feeds (owner, co-owner, contributor, reader)
  * user management
  * quota management
  * web site authentication using on-premise ADFS, web site authentication using prefered identity providers: Live ID, Google, GitHub, StackOverflow, etc
* build services
  * creates the NuGet and symbols packages for you
  * customizable automatic-versioning and assembly version patching
  * auto-trigger builds for CodePlex, BitBucket or GitHub commits
  * support for many unit testing frameworks
  * support for many SDKs (including windows phone)
  * build failure notifications through email and downloadable build logs
* custom logo and domain name

### Chocolatey
* License: Apache v2
* Sources: [https://github.com/chocolatey](https://github.com/chocolatey)

[Chocolatey.org](http://www.chocolatey.org/) is a system-level package manager for Windows based on NuGet, allowing you to search and install software components on your system, even unattended. Looks very promising and definitely something to keep an eye on!

* Documentation: [https://github.com/chocolatey/chocolatey/wiki](https://github.com/chocolatey/chocolatey/wiki)
* Reference: [https://github.com/chocolatey/chocolatey/wiki/CommandsReference](https://github.com/chocolatey/chocolatey/wiki/CommandsReference)
* Twitter: [http://twitter.com/chocolateynuget](http://twitter.com/chocolateynuget)
* Forums: [http://groups.google.com/group/chocolatey](http://groups.google.com/group/chocolatey)

Provides:

* Unattended software installations
* Installation of multiple packages with a single command
* Easy to use command line tool
* Supports any NuGet package source (feeds and file shares)
* Has a GUI as well: http://chocolatey.org/packages/ChocolateyGUI
* Integration with:
  * Web Platform Installer
  * Windows Features
  * Ruby Gems
  * CygWin
  * Python

### OctopusDeploy
[OctopusDeploy](http://octopusdeploy.com/) is a convention-based automated deployment solution using NuGet as a protocol. You can use the Community edition for free (limited to 5 projects, up to 10 tentacles and limited to 5 users) or [buy](http://octopusdeploy.com/purchase) one of the paying editions.

* Documentation: [http://octopusdeploy.com/documentation](http://octopusdeploy.com/documentation)
* Blog: [http://octopusdeploy.com/blog](http://octopusdeploy.com/blog)
* Twitter: [https://twitter.com/OctopusDeploy](https://twitter.com/OctopusDeploy)

Provides:

* Deployment dashboard
* Scalability through lightweight service agents (tentacles)
* Deployment promotion between environments
* Support for PowerShell scripts
* Support for manual interventions
* Support for XML configuration transforms and variables
* Support for Windows Azure web and worker roles
* Support for (S)FTP
* Has a TeamCity plug-in
* Has a Command Line (octo.exe)
* Has a REST API
* Fine-grained user permissions
* Retention policies
* Automation of common tasks for ASP.NET deployments (IIS configuration) and Windows Services

### RedGate Deployment Manager
[RedGate's Deployment Manager](http://www.red-gate.com/delivery/deployment-manager/) is a custom fork of the OctopusDeploy project. History separates shortly after v1.0 of OctopusDeploy, as explained in this post: [http://octopusdeploy.com/support/red-gate](http://octopusdeploy.com/support/red-gate)

More info: [http://www.red-gate.com/delivery/deployment-manager/](http://www.red-gate.com/delivery/deployment-manager/)

### SymbolSource
[SymbolSource](http://www.symbolsource.org/) is a hosted symbolserver that integrates with NuGet and is configurable in Visual Studio, allowing you to debug NuGet packages by downloading the symbols and sources on-demand.

* Documentation: [http://www.symbolsource.org/Public/Wiki/Index](http://www.symbolsource.org/Public/Wiki/Index)
* Blog: [http://www.symbolsource.org/Public/Blog](http://www.symbolsource.org/Public/Blog)
* Forums: [http://groups.google.com/group/symbolsource](http://groups.google.com/group/symbolsource)

Provides:

* Consumes and provides NuGet symbols packages
* Consumes and provides OpenWrap packages
* Hosts symbols (PDB files) and sources (C#, VB.NET, C++)
* Symbol server and source server compatible with Visual Studio
* Flexible security for public and private content
* Integration with MyGet.org (shared credentials and feed/repository security settings)
* Integration with NuGet.org (default symbols repository)

### CoApp
* License: Apache v2
* Sources: [https://github.com/coapp/](https://github.com/coapp/)

The [CoApp](http://coapp.org/) project originally aimed to create a vibrant Open Source ecosystem on Windows by providing the technologies needed to build a complete community-driven Package Management System, along with tools to enable developers to take advantage of features of the Windows platform. 

The project has [pivoted](http://coapp.org/news/2013-03-27-The-Long-Awaited-post.html) to mesh with the NuGet project and the collaborative result is visible in NuGet 2.5 where [support for native packages](../Release-Notes/NuGet-2.5#Support-for-Native-projects) was first introduced. The CoApp project is still building [additional tools](http://coapp.org/pages/releases.html) to enhance C/C++ support in NuGet. 

* Documentation: [http://coapp.org/pages/reference.html](http://coapp.org/pages/reference.html)
* Twitter: [@CoApp](https://twitter.com/#!/coapp)

### ProGet (Inedo)
[ProGet](http://inedo.com/proget/overview) is an on-premise NuGet server with a freemium model that also provides integration with the Inedo BuildMaster product.

* Documentation: [http://inedo.com/support/documentation/table-of-contents](http://inedo.com/support/documentation/table-of-contents)
* Twitter: [@Inedo](http://twitter.com/inedo)

Provides:

* Compatibility with all NuGet client tools
* Custom proget.exe client tool
* Connectors to other NuGet feeds
* Connector filters
* Support for multiple feeds
* Support for private feeds
* License filtering
* Download feeds and packages
* LDAP authentication to the ProGet web application
* Upload packages to the ProGet web application
* integrated symbols and source server
* SDK and API
* Supports OData
* Supports NuGet Feed Discovery and NuSpec Extensions

## BoxStarter
* License: Apache v2
* Sources: [http://boxstarter.codeplex.com/](http://boxstarter.codeplex.com/)

[BoxStarter](http://boxstarter.codeplex.com/) is another cool project leveraging NuGet and Chocolatey to quickly set up development environments.

More info: [http://boxstarter.codeplex.com/documentation](http://boxstarter.codeplex.com/documentation)

### SharpDevelop
SharpDevelop was amongst the first IDEs other than Visual Studio to support NuGet.

More info: [http://community.sharpdevelop.net/blogs/mattward/archive/2011/01/23/NuGetSupportInSharpDevelop.aspx](http://community.sharpdevelop.net/blogs/mattward/archive/2011/01/23/NuGetSupportInSharpDevelop.aspx)

### Xamarin and MonoDevelop
Xamarin Studio and MonoDevelop also have a NuGet extension, built on top of a custom build of the NuGet.Core.dll and a custom build of Microsoft's XML Document Transformation (XDT) library.

More info: [https://github.com/mrward/monodevelop-nuget-addin](https://github.com/mrward/monodevelop-nuget-addin)

### JetBrains ReSharper
As of v8.0 of [ReSharper](http://www.jetbrains.com/resharper/),  the built-in extension manager allows you to fetch ReSharper plug-in packages from a custom NuGet Gallery hosted at [https://resharper-plugins.jetbrains.com](https://resharper-plugins.jetbrains.com/). 

### JetBrains TeamCity
[TeamCity](http://www.jetbrains.com/teamcity/) has a few build steps specifically designed to deal with NuGet package consumption, creation and publication. In addition, it also comes with a built-in NuGet feed collecting all packages produced in your build artifacts.

More info: [http://blogs.jetbrains.com/dotnet/2011/08/native-nuget-support-in-teamcity/](http://blogs.jetbrains.com/dotnet/2011/08/native-nuget-support-in-teamcity/)

### AppVeyor CI

[AppVeyor](http://www.appveyor.com) is Continuous Integration service for Windows developers to securely build and test code in parallel and deploy successful bits to on-premise or cloud environments. Every AppVeyor account comes with a private NuGet feed aggregating packages from all build artifacts and supporting publishing of your own packages.

More info: [http://blog.appveyor.com/2014/02/21/nuget-support-in-appveyor-ci/](http://blog.appveyor.com/2014/02/21/nuget-support-in-appveyor-ci/)

### Artifactory
Artifactory is the first and only Binary Repository Manager with 1st class support for .NET development in general and NuGet packages in particular, including proxying remote feeds, hosting in-house packages, security and user management, promotion, browsing the content of packages, custom metadata and full search for packages.

More info: [Article](http://www.jfrog.com/article/nuget-repositories/), [White Paper](http://bit.ly/ZS5IrA), [Reference Documentation](http://www.jfrog.com/confluence/display/RTF/NuGet+Repositories), [number of blog posts](http://www.jfrog.com/tag/nuget/)

### Sonatype Nexus
Nexus is another repository manager with built-in support for NuGet and they even provide a "[What is NuGet for Java Developers](http://blog.sonatype.com/people/2012/02/what-is-nuget-for-java-developers/)" on their blog.

More info: [http://books.sonatype.com/nexus-book/reference/nuget.html](http://books.sonatype.com/nexus-book/reference/nuget.html)

## NuGet Server

[NuGet Server](http://nugetserver.net/) is a fully functional NuGet server you install as a Windows service. Purchase for $5 US, download and double click the installer. NuGet Server is basically a wrapper of the [NuGet.Server](http://www.nuget.org/packages/NuGet.Server/) package, but installed through a wizard. NuGet Server is distributed with its own web server, so you don't need IIS.

More info: [http://nugetserver.net/](http://nugetserver.net/)

## Klondike

[Klondike](https://github.com/themotleyfool/Klondike) is a fully functional NuGet server that can be installed
as an IIS site or as a Windows Service (using OWIN self-hosting). Klondike aims to be an alternative to
[NuGet.Server](http://www.nuget.org/packages/NuGet.Server/) that offers much faster performance by indexing
all package metadata with Lucene.Net.

Klondike is an open source alternative that's faster than NuGet.Server and easier to deploy than NuGet Gallery.

Provides:

* Windows Authentication
* API Key Authentication
* Automatic mirroring of packages from a public feed
* Symbol Package and symbol server support

More info: [https://github.com/themotleyfool/Klondike](https://github.com/themotleyfool/Klondike)

## scriptcs
[scriptcs](http://scriptcs.net/) offers a cross-platform scripting environment for authoring C#. Scripts can be created via a text editor and executed or code can be executed interactively in the scriptcs [REPL] (https://github.com/scriptcs/scriptcs/wiki/REPL). scriptcs allows script authors to install NuGet packages and use them in their scripts. scriptcs also leverages NuGet for extensibility as [script packs] (https://github.com/scriptcs/scriptcs/wiki/Script-Packs) and [modules] (https://github.com/scriptcs/scriptcs/wiki/Modules) are installed as NuGet packages.

## Other NuGet-based utilities
There are quite a few other tools and utilities building further on top of NuGet. Here's a list of what I've found interesting:

* [Glimpse Extensions](http://getglimpse.com/Packages) (plug-ins are packages)
* [NuGetMustHaves.com](http://nugetmusthaves.com/)
* [NuGetFeed](http://nugetfeed.org/) (build a list of favorite packages)
* [Orchard](http://www.orchardproject.net/) (CMS modules are fetched from a v1 NuGet feed hosted in the Orchard Gallery)
* [Java implementation of NuGet Server](http://blog.jonnyzzz.name/2012/03/nuget-server-in-pure-java.html)
* [NuGetLatest](https://twitter.com/NuGetLatest) (Twitter bot tweeting new package publications)
* [HotNuget](http://hotnuget.com) (Compare package usage)
* [DefinitelyTyped](http://definitelytyped.org/) ([Automatic](https://github.com/DefinitelyTyped/NugetAutomation/) TypeScript Type [Definitions published to NuGet](http://www.nuget.org/packages?q=DefinitelyTyped))

## Training Materials and References
Using a new tool or technology usually comes with a learning curve. Luckily for you, NuGet has no steep learning curve it all! In fact, anyone can [get started consuming packages in no time](http://www.youtube.com/watch?feature=player_embedded&v=PboPfoptU2c). Authoring packages however, and especially authoring good packages, as well as embracing NuGet in your automated build and deployment processes requires some research in order to get things right.

The following pointers should help you get the maximum out of NuGet:

* Official NuGet Documentation site: you are here :-)
* NuGet Blog: [http://blog.nuget.org/](http://blog.nuget.org/)
* NuGet team on Twitter: [@nuget](http://twitter.com/nuget)
* JabbR chat: [https://jabbr.net/#rooms/nuget](https://jabbr.net/#rooms/nuget)
* MSDN article: [Top 10 NuGet (anti-)patterns](http://msdn.microsoft.com/en-us/magazine/jj851071.aspx)
* Books
  * [Apress Pro NuGet](http://bit.ly/ProNuGet)
  * [NuGet 2 Essentials](http://www.amazon.com/NuGet-2-Essentials-Damir-Arh-ebook/dp/B00GTQD5M4)
* Xavier Decoster's blog: [http://www.xavierdecoster.com/tagged/NuGet](http://www.xavierdecoster.com/tagged/NuGet)

## Documentation for Individual Packages

[NuDoq](http://nudoq.org) provides the missing link between straightforward access and updates to NuGet packages, and their corresponding API documentation.

NuDoq regularly polls the NuGet.org gallery server for the latest package updates, unpacks and processes the library documentation files, and update the site accordingly.

## Adding Your Project
If you have a NuGet ecosystem project that would be a valuable addition to this page, please  submit a pull request with an edit to [this page](https://github.com/NuGet/NuGetDocs/tree/master/NuGet.Docs/Contribute/Ecosystem.md).
