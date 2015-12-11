# Package Manager User Interface Options

This topic describes the options available to install and uninstall NuGet packages using the **Manage NuGet Packages** 
dialog box. To begin using this dialog box, you must have a solution open in Visual Studio.
For more information, see [Managing NuGet Packages Using the Dialog](Package-Manager-Dialog).

## Installation Options
<a name="install-options"></a>

Whether you are attempting to install, update, or downgrade a package you will have the same collection of options available to you:

![Installation Options](/images/consume/installation-options.png)

There are currently three options available:

1. **Show Preview Window** - if enabled, a modal window will be displayed that details which dependent packages will be loaded with the package you have chosen.

	![Example Preview Dialog](/images/consume/install-preview-dialog.png)

2. **Dependency Behavior** - this allows you to configure how NuGet will decide which versions of dependent packages will be installed.  There are five options:

	a. **Ignore** - This is usually a bad idea, as a package has dictated that it dependends on other packages and will require their contents to operate.  You may choose to skip installing those packages.

    b. **Lowest** - Install the package version with the minimal version number that meets the requirements of my chosen package.

    c. **Highest Patch** - Install the version with the same first and second version numbers (typically called major and minor version numbers), but the highest patch number.  For example, if version 1.2.2 is specified then the highest version that starts with 1.2 will be installed

    d. **Highest Minor** - Install the version with the same first (or major) version number, but the highest minor number and patch number.  If version 1.2.2 is specified, then the highest version that starts with 1 will be installed

    e. **Highest** - Install the highest version of the package available

3. **File Conflict Options** - If the package or any of its dependent packages being installed match a file already on disk, how should NuGet handle it?

    a. **Prompt** - NuGet will ask if you would like to keep or override the files
    
  	b. **Ignore All** - NuGet will skip writing any files into your project with matching file names

	c. **Overwrite All** - NuGet will overwrite any matching files in your project with those from the package 

## Uninstall Options
<a name="uninstall-options"></a>

The following options are available when you are attempting to uninstall and remove a package from your project:

![Uninstallation Options](/images/consume/uninstall-options.png)

These three options are available:

1. **Show Preview Window** - if enabled, a modal window will be displayed that details what packages and dependent packages will be removed from your project.
2. **Remove Dependencies** - Remove any dependent packages if they are not referenced by any other package in the project
3. **Force Uninstall** - Typically used in combination with **Remove Dependencies** to remove a package and its dependencies whether there are other packages that depend on the current package or its dependencies.  This may lead to a breaking reference scenario in your project.
