# NuGet 2.8.6 Release Notes

[NuGet 2.8.5 Release Notes](nuget-2.8.5) | [NuGet 3.0 Preview Release Notes](nuget-3.0-preview)

NuGet 2.8.6 was released July 22, 2015. It is a minor update to our 2.8.5 VSIX with some targeted fixes and improvements to support the Windows 10 UWP development model. 

In this release, the NuGet Package Manager dialog had support added for:

* Introduced the UAP Target Framework Moniker to support Windows 10 Application Development.
* NuGet protocol version 3 endpoints
* Support for [nuget.config](http://docs.nuget.org/consume/NuGet-Config-Settings) protocolVersion attribute on repository sources.  Default value is "2"
* Falling back to remote repository if a required package version is not available in the local cache 

  
