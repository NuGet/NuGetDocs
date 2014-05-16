# Managing NuGet Packages Using the Dialog

This topic describes how to find, install, remove, and update NuGet packages using the **Manage NuGet Packages** 
dialog box. To use this dialog box, you must have a solution open in Visual Studio.
As an alternative, you can install packages using PowerShell commands. 
For more information, see [Using the Package Manager Console](Using-the-Package-Manager-Console).

Note, for managing packages within multiple projects in the solution at the same time, skip to the section 
on [Managing Packages for the Solution](#Managing_Packages_for_the_Solution).

## Finding a Package

In **Solution Explorer**, right-click the **References** node and click **Manage NuGet Packages...**. 
(Note, in a Website project, right click on the **Bin** node.)

![Manage NuGet Packages menu option](images/manage-nuget-packages-menu-option.png)

Click the **Online** tab to display the list of available packages.

![Manage NuGet Packages Dialog Online tab](images/manage-nuget-packages-online-tab.png)

Browse through the list, or search for a package using the search box at the top right of the dialog box. 
For example, to find the logging package named ELMAH, enter "elmah" or "logging".

Long lists are divided into pages. Use the paging links at the bottom to move from page to page.

When you select a package, an **Install** button appears, and a description is shown in the right-hand pane.

## Package Sources
NuGet can display packages from multiple package sources. To add a package source, click on the **Settings** 
button in the dialog to launch the Options dialog. Make sure the **Package Sources** node is selected in the dialog.

![Package Sources Dialog](images/package-sources.png)

Type in the name of a source as well as its URL or folder path (a folder containing NuGet package 
files is a valid package source) and then click the **Add** button.

![Package Sources Dialog with a custom source](images/package-sources-with-custom-source.png)

The package source will be listed under the **All** node. Click on the package source to view 
packages from that source. The **All** node displays an aggregated view of packages from all 
package sources.

![Manage NuGet Packages Dialog with a custom package source](images/manage-nuget-packagse-with-custom-source.png)

If you want to temporarily disable a package source, just uncheck the package source in the 
dialog. This is useful if a package source is temporarily down for some reason and you need to 
keep it from being included in the aggregate feed.

![Package Sources Dialog with a disabled source](images/package-source-with-disabled-source.png)

## Installing a Package

To install a package, select it and then click **Install**. 
NuGet installs the selected package and any other packages it is dependent on. 
Files are copied to the solution, references might be added to the project, 
the project *app.config* or *web.config* file might be updated, etc.

You might be asked to accept license terms.

![License Acceptance dialog box](images/License-acceptance.png)

When the installation completes, the **Install** button turns into a green check mark to indicate 
that the package was installed correctly.

![Green check mark indicating elmah is installed](images/elmah-installed.png)

In **Solution Explorer**, you can see references that Visual Studio has added for the installed library or libraries.

![Elmah reference in Solution Explorer](images/elmah-reference-in-solution-explorer.png)

If your *app.config* or *web.config* file required changes, those have been applied. 
The following example shows some of the changes for ELMAH.

![Web.config changes for elmah](images/elmah-web.config-changes.png)

A new folder named *packages* is created in your solution folder. 
(If your project does not have a solution folder, the *packages* folder is created in the project folder.)

![packages folder](images/packages-folder.png)

The *packages* folder contains a subfolder for each installed package. 
This subfolder contains the files installed by the package. 
It also contains the package file itself (the *.nupkg* file, which is a *.zip* file 
that contains all of the files included in the package).

![elmah folder in packages folder](images/elmah-folder-in-packages-folder.png)

You can now use the library in your project. 
IntelliSense works when you enter code, and library features such as the ELMAH logging information page 
work when you run the project.

![elmah IntelliSense](images/elmah-intellisense.png)

![elmah Error Log page](images/elmah-errorr-log-page.png)

## Removing a Package

Open the **Manage NuGet Packages** dialog and make sure the **Installed Packages** tab is selected to display 
the list of installed packages.

![Manage NuGet Packages Dialog showing installed packages](images/manage-nuget-packages-installed.png)

Select the package you want to uninstall and then click **Uninstall** to remove the package.

The following package elements are removed:

* References in the project. In **Solution Explorer**, you no longer see the library in the *References* folder or the *bin* folder. (You might have to build the project to see it removed from the *bin* folder.)
* Files in the solution folder. The folder for the package you removed is deleted from the *packages* folder. If it is the only package you had installed, the *packages* folder is also deleted.)
* Any changes that were made to your *app.config* or *web.config* file are undone.

If other packages were installed because they were dependencies of the package that you removed, you might want to remove them also.

If a package has dependencies, NuGet prompts offering the choice to remove the package's 
dependencies.

![Removing dependent packages](../Start-Here/images/remove-dependent-packages.png)

## Updating a Package

Open the **Manage NuGet Packages** dialog and make sure the **Updates** tab is selected to display 
the list of packages that have newer versions available.

If any packages have updates available, they will be listed in the center pane. The following screenshot 
shows a newer version of jQuery available.

![Manage NuGet Packages Dialog showing updates available](images/manage-nuget-packages-showing-updates.png)

Select the package you want to update and click **Update** to update the package to the latest version. 

If a [package includes release notes](../reference/nuspec-reference), they will show up in place of the 
description in the right pane. 

# Managing Packages for the Solution

In the previous section, we looked at managing packages for a single project. In NuGet 1.4 and above, the 
**Manage NuGet Packages** dialog can also be launched at the solution level in order to install/uninstall 
packages in multiple projects at the same time.

Just right click on the Solution and select **Manage NuGet Packages**. You can also launch this dialog from 

![Manage NuGet Packages Solution level menu](images/manage-nuget-packages-solution-menu.png)

The dialog looks the same as it does when launched from a project, but notice the title bar indicates 
that the scope of the dialog is the solution.

![Manage NuGet Packages Dialog for the solution](images/manage-nuget-packages-solution-dialog.png)

The key difference is that each operation lets you select which projects it applies to.

## Installing Online Packages
When the **Online** tab is selected, clicking the **Install** button allows selecting the set of projects 
to install the package into.

![Manage NuGet Packages Project Selection](images/manage-nuget-packages-project-selection.png)

## Managing Installed Packages
When the **Installed** tab is selected, clicking the **Manage** button allows toggling whether or not the package 
is installed for each project.

![Manage NuGet Packages Project Selection](images/manage-nuget-packages-install-project-selection.png)

## Updating Packages
When the **Updates** tab is selected, clicking the **Update** button allows selecting the set of projects 
to install the update into.

![Manage NuGet Packages Project Selection](images/manage-nuget-packages-update-project-selection.png)