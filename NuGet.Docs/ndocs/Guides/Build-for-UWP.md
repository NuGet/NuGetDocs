#Build for UWP

Windows 10 introduces the Universal Windows Platform (UWP), which further evolves the Windows Runtime model and brings it into the Windows 10 unified core. As part of the core, the UWP now provides a common app platform available on every device that runs Windows 10. With this evolution, apps that target the UWP can call not only the WinRT APIs that are common to all devices, but also APIs (including Win32 and .NET APIs) that are specific to the device family the app is running on. The UWP provides a guaranteed core API layer across devices. This means you can create a single app package that can be installed onto a wide range of devices. And, with that single app package, the Windows Store provides a unified distribution channel to reach all the device types your app can run on.

![One Windows Platform](https://i-msdn.sec.s-msft.com/en-us/windows/uwp/get-started/images/universalapps-overview.png)

[Learn more about the Universal Windows Platform](https://developer.microsoft.com/en-us/windows)

##What are we building
The scenario we are trying to address here is how to build, package and distribute a native UWP component that can be used in Managed and Native projects. In addition, we will also show you how to author and package XAML controls in NuGet packages.

##Create Project in Visual Studio

1. In Visual Studio, choose File, New, Project. In the New Project dialog, expand the Visual C++ node, expand the Windows node, and then choose Windows Runtime Component (Universal Windows). Change the name to ImageEnhancer. 

	![Create new Project](/images/BuildForUWP/01.PNG)

2. Choose the target and minimum platform versions that your Universal Windows application will support. You may accept the default values and click ok.

3. From the context menu of the project, select Add->New Item. In the Add New Item dialog, select XAML under the Visual C++ node and then select Templated Control. Change the name to AwesomeImageControl.cpp and click Add.
	
	![Add New Item](/images/BuildForUWP/02.PNG)

4. From the context menu of the project, select properties. In the Property Pages dialog, expand Configuration Properties, expand C/C++ and click on Output Files. In the pane on the right, change the value for Generate XML Documentation Files to Yes.

	![Generate XML Documentation Files](/images/BuildForUWP/03.PNG)

5. From the context menu of the solution, select Batch Build. In the Batch Build dialog, click on Select All, then click Build.

	![Batch Build](/images/BuildForUWP/04.PNG)

##Create the .nuspec file

Bring up the console and navigate to the project folder. This path will look something like this
	`C:\Users\username\Documents\Visual Studio 2015\Projects\ImageEnhancer\ImageEnhancer`

Then run the `spec` command

<code class="bash hljs">
	nuget spec
</code>

This will generate a new file `ImageEnhancer.nuspec`. Open this file. Update the contents to look something like

	<?xml version="1.0"?>
	<package >
	  <metadata>
		<id>ImageEnhancer</id>
		<version>1.0.0</version>
		<title>ImageEnhancer</title>
		<authors>karann</authors>
		<owners>karann</owners>
		<licenseUrl>http://LICENSE_URL_HERE_OR_DELETE_THIS_LINE</licenseUrl>
		<projectUrl>http://PROJECT_URL_HERE_OR_DELETE_THIS_LINE</projectUrl>
		<iconUrl>http://ICON_URL_HERE_OR_DELETE_THIS_LINE</iconUrl>
		<requireLicenseAcceptance>false</requireLicenseAcceptance>
		<description>Awesome Image Enhancer</description>
		<releaseNotes>First Release</releaseNotes>
		<copyright>Copyright 2016</copyright>
		<tags>image enhancer</tags>
	  </metadata>
	  <files>
		<file src="..\Release\ImageEnhancer\ImageEnhancer.winmd" target="lib\uap10.0"/>
		<file src="..\Debug\ImageEnhancer\ImageEnhancer.xml" target="lib\uap10.0"/>
		<file src="Themes\Generic.xaml" target="lib\uap10.0\Themes"/>
		<file src="..\Release\ImageEnhancer\Themes\Generic.xbf" target="lib\uap10.0\Themes"/>
		<file src="..\ARM\Release\ImageEnhancer\ImageEnhancer.dll" target="runtimes\win10-arm\native"/>
		<file src="..\ARM\Release\ImageEnhancer\ImageEnhancer.pri" target="runtimes\win10-arm\native"/>
		<file src="..\x64\Release\ImageEnhancer\ImageEnhancer.dll" target="runtimes\win10-x64\native"/>
		<file src="..\x64\Release\ImageEnhancer\ImageEnhancer.pri" target="runtimes\win10-x64\native"/>
		<file src="..\Release\ImageEnhancer\ImageEnhancer.dll" target="runtimes\win10-x86\native"/>
		<file src="..\Release\ImageEnhancer\ImageEnhancer.pri" target="runtimes\win10-x86\native"/>
	  </files>
	</package>

##Pack
Now run the `pack` command

<code class="bash hljs">
	nuget pack
</code>

This will generate a new file `ImageEnhancer.nupkg`. Open this file. The contents should look something like

![nupkg](/images/BuildForUWP/05.PNG)