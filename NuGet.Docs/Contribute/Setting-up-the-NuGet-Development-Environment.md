# Setting up the NuGet Development Environment
So you want to hack on NuGet? These notes will help you get your development environment 
set up correctly so you can work on NuGet using Visual Studio. The lowest supported 
version is Visual Studio 2015. 

## Get and Build the code
After VS2015 has been installed, you would need to:

1. Uninstall the existing NuGet Extension from Visual Studio.
1. **Download and install the <a href="https://www.visualstudio.com/downloads/download-visual-studio-vs">Visual Studio 2015 SDK</a>**
    
To build NuGet.VisualStudioExtension, execute the following steps:

1. Add the directory of msbuild 14, e.g. C:\Program Files (x86)\MSBuild\14.0\Bin, to PATH
1. Download the latest version of [NuGet.exe](https://www.nuget.org/nuget.exe), and add its directory to PATH
1. Start powershell. Create a directory, cd into that directory
1. Run  git clone https://github.com/NuGet/Home.git 
1. Run  Home\clone-repos.ps1 
1. Run  Home\build-nuget.ps1 -configuration debug -clean . The generated vsix will be                 NuGet.VisualStudioExtension\src\VsExtension\bin\Debug\NuGet.Tools.vsix.

For more details, please visit the [NuGet/Home repository](https://github.com/NuGet/Home/blob/master/README.md)


## Setup Debugging for VS2015
To debug the console and UI during development, following these steps:

1. Launch Visual Studio as Administrator 
1. Make sure that the NuGet Extension is UNINSTALLED from your primary instance of VS so your newly compiled one can load into the experimental instance.
1. Set the **VsExtension** project as the startup project 
1. Ensure that you rebuild the **VsExtension** project. 
1. Now you can run or debug the **VsExtension** project and this would launch a separate instance of VS2015 (called the Experimental instance) 
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

        git clone https://github.com/NuGet/NuGet2.git

1. **Build NuGet**
Cd to the nuget source code direcotry, run

        ./build.sh
This will build NuGet.exe in directory src/CommandLine/bin/Release successfully.
