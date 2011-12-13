# Known Issues with NuGet

## Package Manager Console throws an exception when the Reflector Visual Studio Add-In is also installed.

When running the Package Manager console, you may run into the following exception message 
if you have the Reflector VS Add-in installed.

    The following error occurred while loading the extended type data file: 
    Microsoft.PowerShell.Core, C:\Windows\SysWOW64\WindowsPowerShell\v1.0\types.ps1xml(2950) : 
    Error in type "System.Security.AccessControl.ObjectSecurity": 
    Exception: Cannot convert the "Microsoft.PowerShell.Commands.SecurityDescriptorCommandsBase" 
    value of type "System.String" to type "System.Type".
    System.Management.Automation.ActionPreferenceStopException: 
    Command execution stopped because the preference variable "ErrorActionPreference" or common parameter 
    is set to Stop: Unable to find type

or

    System.Management.Automation.CmdletInvocationException: Could not load file or assembly 'Scripts\nuget.psm1' or one of its dependencies. <br />The parameter is incorrect. (Exception from HRESULT: 0x80070057 (E_INVALIDARG)) ---&gt; System.IO.FileLoadException: Could not load file or <br />assembly 'Scripts\nuget.psm1' or one of its dependencies. The parameter is incorrect. (Exception from HRESULT: 0x80070057 (E_INVALIDARG)) <br />---&gt; System.ArgumentException: Illegal characters in path.
       at System.IO.Path.CheckInvalidPathChars(String path)
       at System.IO.Path.Combine(String path1, String path2)
       at Microsoft.VisualStudio.Platform.VsAppDomainManager.&lt;AssemblyPaths&gt;d__1.MoveNext()
       at Microsoft.VisualStudio.Platform.VsAppDomainManager.InnerResolveHandler(String name)
       at Microsoft.VisualStudio.Platform.VsAppDomainManager.ResolveHandler(Object sender, ResolveEventArgs args)
       at System.AppDomain.OnAssemblyResolveEvent(RuntimeAssembly assembly, String assemblyFullName)
       --- End of inner exception stack trace ---
       at Microsoft.PowerShell.Commands.ModuleCmdletBase.LoadBinaryModule(Boolean trySnapInName, String moduleName, String fileName, <br />Assembly assemblyToLoad, String moduleBase, SessionState ss, String prefix, Boolean loadTypes, Boolean loadFormats, Boolean&amp; found)
       at Microsoft.PowerShell.Commands.ModuleCmdletBase.LoadModuleNamedInManifest(String moduleName, String moduleBase, <br />Boolean searchModulePath, <br />String prefix, SessionState ss, Boolean loadTypesFiles, Boolean loadFormatFiles, Boolean&amp; found)
       at Microsoft.PowerShell.Commands.ModuleCmdletBase.LoadModuleManifest(ExternalScriptInfo scriptInfo, ManifestProcessingFlags <br />manifestProcessingFlags, Version version)
       at Microsoft.PowerShell.Commands.ModuleCmdletBase.LoadModule(String fileName, String moduleBase, String prefix, SessionState ss, <br />Boolean&amp; found)
       at Microsoft.PowerShell.Commands.ImportModuleCommand.ProcessRecord()
       at System.Management.Automation.Cmdlet.DoProcessRecord()
       at System.Management.Automation.CommandProcessor.ProcessRecord()
       --- End of inner exception stack trace ---
       at System.Management.Automation.Runspaces.PipelineBase.Invoke(IEnumerable input)
       at System.Management.Automation.Runspaces.Pipeline.Invoke()
       at NuGetConsole.Host.PowerShell.Implementation.PowerShellHost.Invoke(String command, Object input, Boolean outputResults)
       at NuGetConsole.Host.PowerShell.Implementation.PowerShellHostExtensions.ImportModule(PowerShellHost host, String modulePath)
       at NuGetConsole.Host.PowerShell.Implementation.PowerShellHost.LoadStartupScripts()
       at NuGetConsole.Host.PowerShell.Implementation.PowerShellHost.Initialize()
       at NuGetConsole.Implementation.Console.ConsoleDispatcher.Start()
       at NuGetConsole.Implementation.PowerConsoleToolWindow.MoveFocus(FrameworkElement consolePane)

We've contacted the author of the add-in in the hopes of working out a resolution.

<p class="info">Update: We have verified that the latest version of Reflector, 6.5, no longer causes this exception in the console.</p>

## The Add Package Library Reference dialog throws an exception if the solution contains InstallShield Limited Edition Project.

We have identified that if your solution contains one or more InstallShield Limited Edition project, the **Add Package Library 
Reference** dialog will throw an exception when opened. There is currently no workaround yet except either removing 
InstallShield projects or unloading them.

## Upgrading to latest NuGet from an older version causes a signature verification error.

If you are running VS 2010 SP1, you might run into the following error message when attempting to upgrade 
NuGet if you have an older version installed.

![Visual Studio Extension Installer](images/Visual-Studio-Extension-Installer.png)

When viewing the logs, you might see a mention of a `SignatureMismatchException`.

The workaround is to simply uninstall NuGet and then install it from the VS Extension Gallery.  See
<a href="http://support.microsoft.com/kb/2581019">http://support.microsoft.com/kb/2581019</a> for more information.

## Uninstall Button Greyed out? NuGet Requires Admin Privileges to Install/Uninstall

If you try to uninstall NuGet via the Visual Studio Extension Manager, you may notice that the Uninstall button is disabled. 
NuGet requires admin access to install and uninstall. Relaunch Visual Studio as an administrator to uninstall the extension. 
NuGet does not require admin access to use it.

## The Package Manager Console crashes when I open it in Windows XP. What's wrong?

NuGet requires Powershell 2.0 runtime. Windows XP, by default, doesn't have Powershell 2.0. 
You can download the Powershell 2.0 runtime from this link 
<a href="http://support.microsoft.com/kb/968929">http://support.microsoft.com/kb/968929</a>. 
After you install it, restart Visual Studio and you should be able to open Package Manager Console.

## Visual Studio 2010 SP1 Beta crashes on exit if the Package Manager Console is open.

If you have installed Visual Studio 2010 SP1 Beta, you may notice that if you leave the Package Manager Console open 
and close Visual Studio, it will crash. This is a known issue of Visual Studio and will be fixed in SP1 RTM release. 
For now, just ignore the crash or uninstall SP1 Beta if you can.

## The element 'metadata' in namespace 'schemas.microsoft.com/packaging/2010/07/nuspec.xsd' has invalid child element exception occurs

If you installed packages built with a pre-release version of NuGet, you might encounter this error message when 
running the RTM version of NuGet with that project. You'll need to uninstall and then re-install each package 
using the RTM version of NuGet.

## Attempting to install or uninstall results in the error "Cannot create a file when that file already exists.&rdquo;

For some reason, Visual Studio extensions can get in a weird state where you've uninstalled the VSIX extension, 
but some files were left behind. To work around this issue:

1. Exit Visual Studio 
2. Open the following folder (it might be on a different drive on your machine) 

    <pre>C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\Extensions\Microsoft Corporation\NuGet Package Manager\&lt;version&gt;\</pre>

3. Delete all the files with the *.deleteme* extensions. 
4. Re-open Visual Studio 

After following these steps, you should be able to continue.

## In rare cases, compiling with Code Analysis turned on causes error.

You might get the following error if you installs FluentNHibernate with the Package Manager console and then compile your project 
with "Code Analysis" turned on.

    Error 3 CA0058 : The referenced assembly 
    'NHibernate, Version=3.0.0.2001, Culture=neutral, PublicKeyToken=aa95f207798dfdb4' 
    could not be found. This assembly is required for analysis and was referenced by: 
    C:\temp\Scratch\src\MyProject.UnitTests\bin\Debug\MyProject.UnitTests.dll. 
    MyProject.UnitTests

<a href="http://davesbox.com/archive/2008/06/14/reference-resolutions-changes-in-code-analysis-and-fxcop-part-2.aspx">David Kean</a> 
has an Excellent BLog post that explains this issue. 
By default, FluentNHibernate requires NHibernate 3.0.0.2001. However, by design NuGet will install NHibernate 3.0.0.4000 
in your project and add the appropriate binding redirects so that it will work.
You project will compile just fine if code analysis is not turned on. In contrast to the compiler, 
code analysis tool doesn't properly follow the binding redirects to use 3.0.0.4000 instead of 3.0.0.2001. 
You can work around the issue by either installing NHibernate 3.0.0.2001 or tell the code analysis tool to 
behave the same as the compiler by doing the following:

1. Go to *%PROGRAMFILES%\Microsoft Visual Studio 10.0\Team Tools\Static Analysis Tools\FxCop* 
2. Open FxCopCmd.exe.config and change <code>AssemblyReferenceResolveMode</code> from <code>StrongName</code> to <code>StrongNameIgnoringVersion</code>. 
3. Save the change and rebuild your project. 

## Write-Error command doesn't work inside install.ps1/uninstall.ps1/init.ps1

This is a known issue. Instead of calling Write-Error, try calling throw.

    throw "My error message"

## Installing NuGet with restricted access on Windows 2003 can crash Visual Studio
When attempting to install NuGet using the Visual Studio Extension Manager and not running 
as an administrator, the &#8220;Run As&#8221; dialog is displayed with the checkbox labeled 
&#8220;Run this program with restricted access&#8221; checked by default.

![Run As Restricted Dialog](images/RunAsRestricted.png)

Clicking OK with that checked crashes Visual Studio. Make sure to uncheck that option before 
installing NuGet.

## Cannot uninstall NuGet for Windows Phone Tools
Windows Phone Tools does not have support for the Visual Studio Extension Manager. In order to 
uninstall NuGet, run the following command.

     vsixinstaller.exe /uninstall:NuPackToolsVsix.Microsoft.67e54e40-0ae3-42c5-a949-fddf5739e7a5