# Installing NuGet
NuGet can be installed and updated using the Visual Studio **Extension Manager**. To check if your copy 
of Visual Studio already has the NuGet extension, look for **Library Package Manager** in the Tools menu 
of your copy of Visual Studio.

![Menu](images/Menu.png)

If your copy of Visual Studio does not already have the Library Package Manager (NuGet) extension, you 
can install it using the Extension Manager.

## Using the Extension Manager

In Visual Studio, click **Tools** and then **Extension Manager**.

In the **Extension Manager** dialog box, select the **Online Gallery** tab, and enter "nuget" in the search box to find the **NuGet Package Manager** extension.

Select **NuGet Package Manager** and then click **Download**.

![Extension Manager showing NuGet](images/extension-manager-with-nuget.png)

In the **Installer** dialog box, click **Install**.

![Visual Studio Extension Installer](images/visual-studio-extension-installer.png)

When installation is complete, close and re-open Visual Studio.

![Visual Studio Extension Installer Complete](images/visual-studio-extension-installer-complete.png)

NuGet is now ready to use.

## Using the Visual Studio Gallery

[vsg]:http://visualstudiogallery.msdn.microsoft.com/27077b70-9dad-4c64-adcf-c7cf6bc9970c

You can also install NuGet from the [Visual Studio Gallery][vsg] by downloading and executing the extension installer.  

![Screen shot of NuGet on the Visual Studio Gallery on MSDN](images/Visual-Studio-Gallery-Download.PNG)

Download and run the VSIX file.  You'll need to agree to the terms, wait for the install to complete and then exit.  Close all open instances of Visual Studio and restart.

NuGet is now ready to use.

# Updating NuGet
You can update NuGet using the Visual Studio **Extension Manager**.  Navigate to the Extension Manager and click on the Updates tab to check for updates.

If there is a new version of NuGet you will see it in the list of available updates.

![Extension Manager showing a new version of NuGet available](images/visual-studio-extension-update-check.png)

Select NuGet in the list and click **Update**.  When the update is complete, close and re-open all open instances of Visual Studio.

# Installing a CI build

If you want to run the very latest unreleased build of NuGet, you can
[install it from the CI (Continuous Integration) machine](http://ci.nuget.org:8080/guestAuth/repository/download/bt4/.lastSuccessful/VisualStudioAddIn/NuGet.Tools.vsix).

**Important note**: the official NuGet build is signed, while the one from the CI machine is not. For that reason, Visual Studio will not let you
install a CI build if you already have an official build installed. If you do, you'll get an error that looks like:

*The installed version of 'NuGet Package Manager' is signed, but the update version is not signed. Therefore, Extension Manager cannot install the update.*

To avoid this issue, you need to uninstall the official build (from the VS extension manager) before installing the CI build. Likewise, please uninstall the CI build
before going back to an official build. However, you don't need to do this from going to a CI build to a newer CI build. If Visual Studio won't allow you to uninstall the extension (the Uninstall button is disabled), then you likely need to restart Visual Studio using "Run as Administrator."