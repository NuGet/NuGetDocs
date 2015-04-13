# Setting up the NuGet Development Environment
So you want to hack on NuGet? These notes will help you get your development environment 
set up correctly so you can work on NuGet using Visual Studio. The lowest supported 
version is Visual Studio 2012.

## Get and Build the code
1. **Install Git.** Install [Git for Windows](http://code.google.com/p/msysgit/downloads/list?can=3) and then optionally install [TortoiseGit](http://code.google.com/p/tortoisegit/downloads/list)
1. **Clone the repository.** From a command prompt, run the following commands in a directory where you want the source code to be placed. 
This will create a folder named "NuGet.VisualStudioExtension" with the source and switch to the branch where active development happens.

        git clone -b dev https://github.com/NuGet/NuGet.VisualStudioExtension.git

1. If you are using VS2012 then,
    1. Uninstall the existing NuGet Extension from Visual Studio.
    1. **Download and install the <a href="http://www.microsoft.com/en-us/download/details.aspx?id=30668">Visual Studio 2012 SDK</a>**
    1. **Run build.cmd** from a Command Prompt
1. If you are using VS2013 then,
    1. Uninstall the existing NuGet Extension from Visual Studio.
    1. **Download and install the <a href="http://www.microsoft.com/en-us/download/details.aspx?id=40758">Visual Studio 2013 SDK</a>**
    1. **Run build.cmd** from a Command Prompt
1. For more information on using GIT, you may refer to <a href="http://think-like-a-git.net/">http://think-like-a-git.net/</a>

## Setup Debugging for VS2012/VS2013
To debug the console and UI during development, following these steps:

1. Launch Visual Studio as Administrator 
1. Make sure that the NuGet Extension is UNINSTALLED from your primary instance of VS so your newly compiled one can load into the experimental instance.
1. Set the **VsExtension** project as the startup project 
1. Ensure that you rebuild the **VsExtension** project. 
1. Now you can run or debug the **VsExtension** project and this would launch a separate instance of VS2012/VS2013 (called the Experimental instance) 
with a copy of the NuGet vsix installed. What you do in this instance don't affect the main VS instance. 

## Developing NuGet on Linux
The easiest distribution to use is OpenSUSE. Install OpenSUSE 13.2, then follow these steps:

1. **Install Git**

        sudo zypper install git
1. **Install Mono**

        sudo zypper install mono-complete
1. **Import Trusted Root Certificates**. By default, Mono trusts no one. 
The NuGet build needs to install some packages from https://www.nuget.org, 
and without neccessary root certificates this will fail. Run
this command to import trusted root certificates from Mozilla's LXR into 
Mono's certificate store:

        mozroots --sync --import
1. **Clone the repository** 

        git clone https://git01.codeplex.com/nuget

1. **Build NuGet**
Cd to the nuget source code direcotry, run

        ./build.sh
This will build NuGet.exe in directory src/CommandLine/bin/Release successfully.
