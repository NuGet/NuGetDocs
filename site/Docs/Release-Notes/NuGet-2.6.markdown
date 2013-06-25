# NuGet 2.6 Release Notes

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

While the directory structure makes it straightforward for programs like software installers to add machine-wide package sources to NuGet's configuration, the NuGet configuration dialog has also been updated to allow for the registration of package sources as either user-specific (e.g. registered in %AppData%/NuGet/NuGet.config) or machine-wide.

![Machine-wide Package Source Configuration Dialog](Images/NuGet-2.6/MachineLevelConfigDlg.png)

### Contextualizing Search

As the number of packages served by the NuGet gallery continues to grow at an exponential pace, improving search remains ever at the top of the NuGet  priority list. One of the planned features for a forthcoming version of the NuGet client is contextual search, meaning that NuGet will use information about the version of Visual Studio that you are using and the type of project that you are building as criteria for determining the relevance of potential search results. The goal is that NuGet search will be able to move beyond search results based on query term analysis and in addition deliver tailored search results.

In order to set the stage for a contextual search experience, NuGet 2.6 sends the following additional bits of data to the NuGet gallery when a package is installed.
* Visual Studio Version, SKU, and project type GUID(s)
* Whether the package is being installed as a part of an explicit install command or whether it is being installed as a dependency

## Bug Fixes
NuGet 2.6 includes many bug fixes. For a full list of work items fixed in NuGet 2.6, please view the [NuGet Issue Tracker for this release](https://nuget.codeplex.com/workitem/list/advanced?keyword=&status=Closed&type=All&priority=All&release=NuGet%202.6&assignedTo=All&component=All&sortField=LastUpdatedDate&sortDirection=Descending&page=0&reasonClosed=All).