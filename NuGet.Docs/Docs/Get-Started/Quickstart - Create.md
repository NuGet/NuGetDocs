#Quickstart - Create a NuGet package

There are a few ways to create a NuGet package. This tutorial walks you through creating a NuGet package from a project using the nuget CLI.

<div class="block-callout-info">
	<strong>Note:</strong><br>
	You need nuget CLI installed to follow this tutoial. If you don't already, take a look at <a href="/docs/get-started/install-nuget#nuget-exe-cli">The NuGet Install guide</a>.
</div>

##Create a new Class library project

<div class="block-callout-info">
	<strong>Note:</strong><br>
	You can create any project that builds to a DLL.
</div>

In Visual Studio, choose **File**, **New**, **Project**. In the **New Project** dialog, expand the **Visual C#** node and choose the **Windows** node, and then choose **Class Library**.

![Create new Project](/images/ConsumeNugetSample/01.PNG)

Our sample DLL just has one public method that outputs a message describing the version of the package. Copy the following lines of code to the class doc.

On the **Build** menu, choose **Build Solution**.


##Create a .nuspec file
Bring up the console and navigate to the folder containing the .csproj file for the project that you just created. This path will look something like this
	C:\Users\karann\Documents\Visual Studio 2015\Projects\Awesomeness\Awesomeness

Then run the following command

	nuget spec

This will generate a new file Awesomeness.nuspec

Open this file

Edit the contents

##Pack
Now run the pack command

	nuget pack Awesomeness.csproj

This will generate a new file Awesomeness.1.0.0.0.nupkg




##Publish the package
Got to nuget.org


That's it!
You have just created and published your first NuGet package.



