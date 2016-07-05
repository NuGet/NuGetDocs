# OS Compatibility

NuGet was originally designed to be run on Windows-based operating systems to support .NET development.  With the advancements of .NET applications running on non-Windows operating systems, the demand for NuGet compatibility on those environments has risen.

The NuGet command-line executable will run on Linux and Mac OSX when the Mono runtime is installed.  NuGet does not yet provide support for non-Windows operating systems, but we have identified that the following features do work within Linux and Mac OS X:

## NuGet 3.2

With NuGet 3.2, the following commands have been tested to work:

* Config
* Delete
* Help
* Install
* List
* Push
* SetApiKey
* Sources
* Spec

The following commands are partially working:

* Pack - Pack will work with *.nuspec files but will not work with project files
* Restore - Restore works with packages.config and project.json files but will not yet work with *.sln solution files

The following commands do not work properly:

* Update

