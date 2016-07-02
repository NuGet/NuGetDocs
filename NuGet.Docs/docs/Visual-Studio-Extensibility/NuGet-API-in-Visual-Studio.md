# NuGet API in Visual Studio

Besides the UI that everyone has become familiar with, the NuGet extension also exports some useful services, via [MEF](http://msdn.microsoft.com/en-us/library/dd460648.aspx "MEF"), which allow other components in VS to interact with NuGet. These include installing packages, uninstalling packages and querying for installed packages.

As of NuGet 2.0, NuGet exports six interfaces/services via MEF, all of which reside in the `NuGet.VisualStudio` namespace in the `NuGet.VisualStudio.dll` assembly:

## Available Services

**IVsPackageInstaller**: Contains methods to install NuGet packages into projects.

**IVsPackageInstallerEvents**: Offers events which raise when packages are installed and uninstalled in the current solution.

**IVsPackageInstallerServices**: Contains a method to retrieve installed packages in the current solution, as well as methods to check if a specified package Id is installed in a project.

**IVsPackageUninstaller**: Contains methods to uninstall NuGet packages from projects.

**IConsoleInitializer**: Trigger eager initialization of the NuGet Package Manager Console.

**IVsTemplateWizard**: This interface is designed for project/item templates to include pre-installed packages, and is *not* meant to be invoked from code.

Detailed API references is available [here](Extensibility-APIs "Extensibility API references").

## Using NuGet Services

**Step 1**

Install the **NuGet.VisualStudio** nuget package into your project. The [NuGet.VisualStudio](https://nuget.org/packages/NuGet.VisualStudio) package contains the NuGet.VisualStudio.dll assembly which includes all the above interfaces.

<div class="block-callout-info">
    <strong>Note:</strong><br>
    When installed, the package will automatically set the **Embed Interop Types** property of the assembly reference to **True**. The reason it does so is to make your code  resilient against version changes when users update to newer versions of NuGet.
</div>

<div class="block-callout-warning">
    <strong>Note:</strong><br>
    You must NOT use any other types besides the above interfaces in your code. You must NOT reference any other NuGet assemblies either, including NuGet.Core.dll.
</div>


**Step 2**

With the package installed, you are ready to obtain those services from your code. Because they are exported as MEF contracts, you can import them either via MEF's Import attribute, or through the [IComponentModel service](http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.componentmodelhost.icomponentmodel.aspx "IComponentModel interface") in code. 

Sample code snippet:

    var componentModel = (IComponentModel)GetService(typeof(SComponentModel));
    IVsPackageInstallerServices installerServices = componentModel.GetService<IVsPackageInstallerServices>();
    var installedPackages = installerServices.GetInstalledPackages();