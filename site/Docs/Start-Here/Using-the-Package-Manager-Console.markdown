# Finding and Installing a NuGet Package Using the Package Manager Console

This topic describes how to find, install, remove, and update NuGet packages using PowerShell commands. 
You can also work with packages using the **Manage NuGet Packages** dialog box. 
For more information, see [Using the Manage NuGet Packages dialog](Using-the Add-Library-Package-Reference-Dialog-Box).

Using PowerShell commands is required if you want to install a package without having a solution open. It's also required in some cases for packages that create commands that you can access only by using PowerShell.

## Finding a Package

From the **Tools** menu, select **Library Package Manager** and then click **Package Manager Console**.

![Package Manager Console in menu](images/package-manager-console-in-menu.png)

The **Package Manager Console** window is displayed.

![Package Manager Console](images/package-manager-console-empty-window.png)

The two drop-down lists set default values that let you omit parameters from the commands you enter in the window:

* In the **Package source** list, select the default source (NuGet package feed) that you want your commands to use. Typically you will leave this as its default value of **NuGet official package source**. For more information about alternative feeds, see [Hosting Your Own NuGet Feeds](../Creating-Packages/Hosting-Your-Own-NuGet-Feeds).
* In the **Default project** list, select the default project that you want your commands to work with. (The default value will be the first project in the solution, not necessarily the one you have selected in **Solution Explorer** when you open the window.)

When you enter commands, you can override these defaults.
In the **Package Manager Console** window, enter `Get-Package -ListAvailale` at the prompt to see a list of all packages 
that are available in the selected package source.

![Get-Package -ListAvailable command](images/package-manager-console-get-package-remote.png)

For the default package source, that command is going to list thousands of packages. It makes better sense to specify 
a filter.

For example, to find the logging package ELMAH, enter `Get-Package -ListAvailable -Filter elmah` (the name of the package) 
or `Get-Package -Filter Logging -ListAvailable` (a keyword in the package description).

![Get-Package command with filter](images/package-manager-console-Get-Package-with-filter.png)

For more options that you can specify with the `Get-Package` command, enter `Get-Help Get-Package`, or see [Package Manager Console Powershell Reference](../Reference/Package-Manager-Console-PowerShell-Reference).

## Installing a Package

After you have found a package that you want to install, use the `Install-Package` command with the name of the package.
For example, enter the command `Install-Package elmah` as shown in the following example:

![Install-Package command](images/package-manager-console-install-package.png)

For more options that you can specify with the `Install-Package` command, enter `get-help Install-Package` or see [Package Manager Console Powershell Reference](../Reference/Package-Manager-Console-PowerShell-Reference).

NuGet retrieves the package from the specified package source and installs it in the project 
that is selected in the **Default project** drop-down list 
(unless you specify a different project in the command). 
Files are copied to the solution, references might be added to the project, 
the project *app.config* or *web.config* file might be updated, etc. 

If the package you are installing is dependent on other packages, 
NuGet installs them also if they are not already installed.

If the package requires license acceptance, you will not be prompted in a dialog box. 
Instead, a message states that your use of the library constitutes license acceptance.

![License acceptance text in Package Manager Console](images/package-manager-console-license-acceptance.png)

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

## Extending The Package Manager Console With Packages

Some packages install new commands that you can use in the **Package Manager Console** window. 
One example of such a package is `MvcScaffolding`, which creates commands you can use to generate ASP.NET MVC 
controllers and views. The following illustration shows that installing MvcScaffolding creates a new command 
`Scaffold`, complete with tab expansion.

![Installing and using MvcScaffold](images/package-manager-console-install-mvcscaffold.png)

## Removing a Package

From the *Tools* menu, select *Library Package Manager* and then click *Package Manager Console*. 
If you do not already know the name of the package you want to remove, enter `Get-Package` at the prompt 
without any flags to see a list of all of the packages that are currently installed.

![Package Manager Console showing installed packages](images/package-manager-console-get-package-listing-installed-packages.png)

To remove a package, use the `Uninstall-Package` command with the name of the package. 
For example, use the `Uninstall-Package elmah` command as shown in the following example:

![uninstall package command](images/package-manager-console-uninstall-package.png)

For more options that you can specify with the `uninstall-package` command, enter `get-help uninstall-package` or see [Package Manager Console Powershell Reference](../Reference/Package-Manager-Console-PowerShell-Reference).

The following package elements are removed:

* References in the project. In **Solution Explorer**, you no longer see the library in the *References* folder or the *bin* folder. (You might have to build the project to see it removed from the *bin* folder.)
* Files in the solution folder. The folder for the package you removed is deleted from the *packages* folder. If it is the only package you had installed, the *packages* folder is also deleted.)
* Any changes that were made to your *app.config* or *web.config* file are undone.

If other packages were installed because they were dependencies of the package that you removed, and if no other packages remain that are dependent on the dependency packages, the dependency packages are also removed.

## Updating a Package

From the **Tools** menu, select **Library Package Manager** and then click **Package Manager Console**.
To check if there are newer versions available for any installed packages, enter `Get-Package -updates` at the prompt.

![Get-Package command](images/package-manager-console-get-package-showing-updates.png)

To update a package, enter `Update-Package` with the package ID. For example, enter the command `Update-Package jQuery`.
For more options that you can use with the `Update-Package` command, enter `get-help Update-Package` or see (../Reference/Package-manager-Console-Commands).

![update-package command](images/package-manager-console-update-package.png)

# Setting up a NuGet Powershell Profile
Powershell supports the concept of profiles which allow you to have commonly used PS commands available to you wherever you 
use PowerShell.

NuGet supports a NuGet specific profile typically located at:

    %UserProfile%\Documents\WindowsPowerShell\NuGet_profile.ps1

The easiest way to find the profile file is to type `$profile` within the NuGet Package Manager Console. 
For example, this is what I see on my machine.

    PM> $profile
    C:\Users\philha\Documents\WindowsPowerShell\NuGet_profile.ps1

This file doesn't necessarily exist by default. You can run the following set of commands to create it.

    PM> mkdir -force (split-path $profile)
    PM> notepad $profile

The first command creates the *WindowsPowershell* directory if it doesn&#8217;t already exist. 
The second command attempts to open the profile file in Notepad. If it doesn&#8217;t already exist, 
it prompts you to create the file. Within the profile file, you can change PowerShell settings or 
add new commands you might find useful.

Here is a simple example of adding a command that allows you to set the font.

    function Set-FontSize {
        param(
            [ValidateRange(6, 128)]
            [Parameter(position=0, mandatory=$true)]
            [int]$Size
        )
       $dte.Properties("FontsAndColors", "TextEditor").Item("FontSize").Value = $Size
    }

Save the profile file and then restart Visual Studio. The next time you open the Package Manager Console, 
you will be able to make use of the `Set-Font` command.

    PM> Set-Font 24

That makes for much more readable code!