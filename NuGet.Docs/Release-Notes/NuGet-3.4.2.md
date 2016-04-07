# NuGet 3.4.1 Release Notes

[NuGet 3.4 Release Notes](nuget-3.4) 

NuGet 3.4.2 was released on April 8, 2016 to address several issues that were identified in the 3.4 and 3.4.1 release.

## Updates and Improvements

* While we continue to invest heavily in performance improvements to package update, we have significantly improved the performance of updates in a specific
scenario where updates on packages with deep dependency graphs took a really long time and hung Visual Studio. 
* Added support for no_proxy setting

##Fixes

* Fixed an issue where NuGet.org source was missing in NuGet settings or config after updating to 3.4.1.
* Fixed an issue where a casing change to FindPackagesById in 3.4.1 breaks Artifactory.
* Corrected an issue with FIPS that caused failures with NuGet restore with nuget.exe.
* Fixed a crash when browsing sources with invalid icon URL.
* Fixed issues with merging versions and entries from 'All Sources'.


For the complete list of fixes and improvements in this release, check out the list of issues [here] (https://github.com/NuGet/Home/issues?utf8=%E2%9C%93&q=is%3Aissue+milestone%3A3.4.2++is%3Aclosed+).
