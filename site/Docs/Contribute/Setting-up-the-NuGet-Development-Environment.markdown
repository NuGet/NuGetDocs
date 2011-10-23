# Setting up the NuGet Development Environment
So you want to hack on NuGet? These notes will help you get your development environment 
set up correctly so you can work on NuGet using Visual Studio 2010.

## Get and Build the code
1. **[Install Tortoise HG](http://tortoisehg.bitbucket.org/download/index.html)** (this includes the Mercurial command line as well)
1. **Clone the repository.** From a command prompt, run the following command in a directory where you want the source code to be placed. 
This will create a folder named "nuget" with the source.

        hg clone https://hg01.codeplex.com/nuget

1. **Download and install the <a href="http://visualstudiogallery.msdn.microsoft.com/en-us/25622469-19d8-4959-8e5c-4025d1c9183d?SRC=VSIDE">Visual Studio 2010 SDK</a>** 
1. **Run build.cmd** from a Command Prompt running with Administrator privileges

## Setup Debugging
To debug the console and UI during development, following these steps:

1. Launch Visual Studio as Administrator 
1. Make sure that the NuGet Extension is UNINSTALLED from your primary instance of VS so your newly compiled one can load into the experimental instance.
1. Set the **VsExtension** project as the startup project 
1. Open the **Properties** page of the **VsExtension** project.
1. Click on the **Debug** tab.
1. Choose **Start external program** option. Type in **C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe** into the textbox (your path may be slightly different).
1. In the command line arguments textbox below, type: **/rootsuffix Exp**.
1. Ensure you rebuild the **VsExtension** project. 
1. Now you can run or debug the **VsExtension** project and this would launch a separate instance of VS2010 (called the Experimental instance) 
with a copy of the NuGet vsix installed. What you do in this instance don't affect the main VS instance. 

