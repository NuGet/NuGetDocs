# NuGet Package Explorer - GUI tool for building packages

Not everyone is a command line junkie. Some folks actually prefer the comfort of a 
Windows GUI application for performing tasks such as package creation. The NuGet Package 
Explorer click-once application makes creating packages very easy. It's also a great way 
to examine packages and learn how packages are structured.

If you&#8217;re integrating building packages into a build system, then [using NuGet.exe to create 
and publish packages](Creating-and-Publishing-a-Package) is a better choice.

## Installation
Installing Package Explorer is easy, [click here and you&#8217;re done](https://npe.codeplex.com/downloads/get/clickOnce/NuGetPackageExplorer.application)!
For Windows8 version of NuGet Package Explorer, please go [here] (http://apps.microsoft.com/windows/en-us/app/nuget-package-explorer/3148c5ae-7307-454b-9eca-359fff93ea19)

Package Explorer is a click-once application which means every time you launch it, it will 
check for updates and allow you to keep the application up to date.

![Package Explorer Update Available](/images/create/package-explorer-update-available.png)

## Creating a Package
To create a package, launch Package Explorer and select **File** > **New** menu option 
(or hit CTRL + N).

![Creating a new package](/images/create/package-explorer-file-new.png)

Then select the **Edit** > **Edit Package Metadata** menu option (or CTRL + K) to edit the package metadata.

![Editing Metadata with the Package Explorer](/images/create/package-explorer-metadata.png)

The metadata editor provides a GUI editor for editing the underlying nuspec file. For more 
details about these fields, read the [NuSpec reference](Nuspec-Reference).

The final step is to drag in the contents of your package into the **Package contents** pane. 
Package Explorer will attempt to infer where the content belongs and prompt you to place it in 
the correct directory within the package.

For example, if you drag an assembly into the Package contents window, it will prompt you to place 
the assembly in the **lib** folder.

![Package Explorer Infers content location](/images/create/package-explorer-content-inference.png)

And clicking **OK** places the file in the appropriate folder.

![Package Explorer Lib Folder](/images/create/package-explorer-lib-folder.png)

You can also explicitly add the special folders via the **Content** menu.

![Package Explorer Content](/images/create/package-explorer-content.png)

Don&#8217;t forget to save your package via the **File** > **Save** menu option (or CTRL + S).

## Publishing a Package

Once you've created and saved your package, navigate to the **File** > **Publish** menu option 
(CTRL + P) to publish your package.

This brings up the **Publish Package** dialog.

![Publish Package Dialog](/images/create/package-explorer-publish.png)

Enter your API Key and click **Publish** to publish your package to the NuGet package feed. 
If you don&#8217;t have an account yet, visit [the NuGet Gallery](http://nuget.org/) and register 
for an account.

After you register and login, click on the **[My Account](http://nuget.org/Contribute/MyAccount)** link to see your API access key.
