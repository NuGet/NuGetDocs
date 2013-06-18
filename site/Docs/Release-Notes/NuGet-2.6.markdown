# NuGet 2.6 Release Notes

## Acknowledgements
1. [Mike Roth](http://www.codeplex.com/site/users/view/mxrss) ([@mxrss](https://twitter.com/mxrss))
    - Show License url when listing packages and verbosity is detailed. 
1. [Adam Ralph](http://www.codeplex.com/site/users/view/adamralph) ([@adamralph](https://twitter.com/adamralph))
    - [#1956](http://nuget.codeplex.com/workitem/1956) - Add developmentDependency attribute to packages.config and use it in pack command to only include runtime packages
1. [tkrafael](http://www.codeplex.com/site/users/view/tkrafael)
    - Avoid duplicate Properties key in nuget.exe pack command.
1. [Ben Phegan](http://www.codeplex.com/site/users/view/benphegan) ([@BenPhegan](https://twitter.com/benphegan))
    - [#2610](http://nuget.codeplex.com/workitem/2610) - Increase machine cache size to 200.
1. [derigel](http://www.codeplex.com/site/users/view/derigel) ([@derigel](https://twitter.com/derigel))
    - [#3217](http://nuget.codeplex.com/workitem/3217) - Fix NuGet dialog showing updates in the wrong tab
    - Fix Project.TargetFramework can be null in ProjectManager
    - [#3248](http://nuget.codeplex.com/workitem/3248) - Fix SharedPackageRepository FindPackage/FindPackagesById will fail on non-existent packageId
1. [Kevin Boyle](http://www.codeplex.com/site/users/view/KevinBoyleRG) ([@kevfromireland](https://twitter.com/kevfromireland))
    - [#3234](http://nuget.codeplex.com/workitem/3234) - Enable support for Nomad project
1. [Corin Blaikie](http://www.codeplex.com/site/users/view/corinblaikie) ([@corinblaikie](https://twitter.com/corinblaikie))
    - [#3252](http://nuget.codeplex.com/workitem/3252) - Fix push command fails with exit code 0 when file doesn't exist.
1. [veselkamartin](http://www.codeplex.com/site/users/view/veselkamartin)
    - [#3226](http://nuget.codeplex.com/workitem/3226) - Fix bug with Add-BindingRedirect command when a project references a database project.
1. [Miroslav Bajtos](http://www.codeplex.com/site/users/view/miroslavbajtos) ([@bajtos](https://twitter.com/bajtos))
    - [#2891](http://nuget.codeplex.com/workitem/2891) - Fix bug of nuget.pack parsing wildcard in the 'exclude' attribute incorrectly.
1. [Justin Dearing](http://www.codeplex.com/site/users/view/zippy1981) ([@zippy1981](https://twitter.com/zippy1981))
    - [#3307](http://nuget.codeplex.com/workitem/3307) - Fix bug NuGet.targets does not pass $(Platform) to nuget.exe when restoring packages.
1. [Brian Federici](http://www.codeplex.com/site/users/view/benerdin) ([@benerdin](https://twitter.com/benerdin))
    - [#3294](http://nuget.codeplex.com/workitem/3294) - Fix bug in nuget.exe package command which would allow adding files with the same name but different casing, eventually causing "Item already exists" exception.
1. [Daniel Cazzulino](http://www.codeplex.com/site/users/view/dcazzulino) ([@kzu](https://twitter.com/kzu))
    - [#2990](http://nuget.codeplex.com/workitem/2990) - Add Version property to NetPortableProfile class.

## Notable features in the release

### XDT Support
One of the most highly requested features for the NuGet client has been to support more powerful XML transformations using the XDT transformation engine which is used in Visual Studio [build configuration transformations](http://msdn.microsoft.com/en-us/library/dd465318(v=vs.100).aspx). In April, 2013, we made two big announcements regarding NuGet support for XDT. The first was that the XDT library itself was being itself [released as a NuGet package](https://nuget.org/packages/Microsoft.Web.Xdt) and [open sourced on CodePlex](http://xdt.codeplex.com/). This step enabled the XDT engine to be used freely by other open-source software, including the NuGet client. The second announcement was the plan to support use of the XDT engine for transformations in the NuGet client. NuGet 2.6 includes this integration.

#### How it works
To take advantage of NuGet’s XDT support, the mechanics look similar to those of the [current config transformation feature](http://docs.nuget.org/docs/creating-packages/configuration-file-and-source-code-transformations). Transformation files are added to the package’s content folder. However, while config transformations use a single file for both installation and uninstallation, XDT transformations enable fine-grained control over both of these processes using the following files:

* Web.config.install.xdt
* Web.config.uninstall.xdt

Additionally, NuGet uses the file suffix to determine which engine to run for transformations, so packages using the existing web.config.transforms will continue to work. XDT transformations can also be applied to any XML file (not just web.config), so you can leverage this for other applications in your project.

#### What you can do with XDT

One of XDT’s greatest strengths is its [simple but powerful syntax](http://msdn.microsoft.com/en-us/library/dd465326.aspx) for manipulating the structure of an XML DOM. Rather than simply overlaying one fixed document structure onto another structure, XDT provides controls for matching elements in a variety of ways, from simple attribute name matching to full XPath support. Once a matching element or set of elements is found, XDT provides a rich set of functions for manipulating the elements, whether that means adding, updating, or removing attributes, placing a new element at a specific location, or replacing or removing the entire element and its children.

### Machine-wide Configuration
One of the great strengths of NuGet is that it breaks down an otherwise large executable or library into a set of modular components which can be integrated, and most importantly maintained and versioned independently. One side effect of this, however, is that the conventional idea of a product or product family becomes potentially more fragmented. NuGet’s custom package source feature provides one way of organizing packages; however, custom package sources are not discoverable on their own.
NuGet 2.6 extends the logic for configuring NuGet by searching the directory hierarchy under the path %ProgramData%/NuGet/Config. Product installers can add custom NuGet configuration files under this directory to register a custom package source for their products. Additionally, the directory structure supports semantics for product, version, and even SKU. Settings from these directories are applied in the following order with a “last in wins” precedence strategy.

1. %ProgramData%\NuGet\Config\*.config 
2. %ProgramData%\NuGet\Config\{IDE}\*.config 
3. %ProgramData%\NuGet\Config\{IDE}\{Version}\*.config 
4. %ProgramData%\NuGet\Config\{IDE}\{Version}\{SKU}\*.config

In this list, the {IDE} placeholder is specific to the IDE in which NuGet is running, so in the case of Visual Studio, it will be “VisualStudio”. The {Version} and {SKU} placeholders are provided by the IDE (e.g. “11.0” and “WDExpress”, “VWDExpress” and “Pro”, respectively). The directory can then contain many different *.config files. Therefore, the ACME component company can, as a part of their product installer, add a custom package source which will be visible only in the Professional and Ultimate versions of Visual Studio 2012 by creating the following file path: 

%ProgramData%\NuGet\Config\VisualStudio\11.0\Pro\acme.config

## Bug Fixes
NuGet 2.6 includes many bug fixes. For a full list of work items fixed in NuGet 2.6, please view the [NuGet Issue Tracker for this release](https://nuget.codeplex.com/workitem/list/advanced?keyword=&status=Closed&type=All&priority=All&release=NuGet%202.6&assignedTo=All&component=All&sortField=LastUpdatedDate&sortDirection=Descending&page=0&reasonClosed=All).