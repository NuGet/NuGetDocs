
# NuGet 3.2 Release Notes

[NuGet 3.1.1 Release Notes](nuget-3.1.1)

NuGet 3.2 was released September 2, 2015 as a collection of improvements and fixes for the 3.1 release.  Also, these are the first releases that are published first to the new dist.nuget.org repository.

## Command-line updates

There were a number of authenticated feed issues that were addressed in this release to improve interactions with the client.

* Install / restore interactions only submit credentials for the initial request to the authenticated feed - [1300](https://github.com/NuGet/Home/issues/1300), [456](https://github.com/NuGet/Home/issues/456)
* Push command does not resolve credentials from configuration - [1248](https://github.com/NuGet/Home/issues/1248)
* User agent and headers are now submitted to NuGet repositories to help with statistics tracking - [929](https://github.com/NuGet/Home/issues/929)

We made a number of improvements to better handle network failures while attempting to work with a remote NuGet repository:

* Improved error messages when unable to connect to remote feeds - (1238)[https://github.com/NuGet/Home/issues/1238]
* Corrected NuGet restore command to properly return a 1 when an error condition occurs - [1186](https://github.com/NuGet/Home/issues/1186)
* Now retrying network connections every 200ms for a maximum of 5 attempts in the case of HTTP 5xx failures - [1120](https://github.com/NuGet/Home/issues/1120) 
* Improved handling of server redirect responses during a push command - [1051](https://github.com/NuGet/Home/issues/1051)
* `nuget install -source` now supports either URL or repository name from nuget.config as an argument - [1046](https://github.com/NuGet/Home/issues/1046)
* Missing packages that were not located on a repository during a restore are now reported as errors instead of warnings [1038](https://github.com/NuGet/Home/issues/1038)
* Corrected multipartwebrequest handling of \r\n for Unix/Linux scenarios - [776](https://github.com/NuGet/Home/issues/776)

There are a number of fixes to issues with various commands:

* Push command no longer does a GET before a PUT against a package source - [1237](https://github.com/NuGet/Home/issues/1237)
* List command no longer repeats version numbers - [1185](https://github.com/NuGet/Home/issues/1185)
* Pack with the -build argument now properly supports C# 6.0 - [1107](https://github.com/NuGet/Home/issues/1107)
* Corrected issues attempting to pack an F# project built with Visual Studio 2015 - [1048](https://github.com/NuGet/Home/issues/1048)
* Restore now no-ops when packages already exist - [1040](https://github.com/NuGet/Home/issues/1040)
* Improved error messages when packages.config file is malformed - [1034](https://github.com/NuGet/Home/issues/1034)
* Corrected restore command with -SolutionDirectory switch to work with relative paths - [992](https://github.com/NuGet/Home/issues/992)
* Improved Updated command to support solution-wide update - [924](https://github.com/NuGet/Home/issues/924)

A complete list of issues addressed in this release can be found in the NuGet GitHub [Command-Line milestone](https://github.com/nuget/home/issues?utf8=%E2%9C%93&q=is%3Aissue+milestone%3A3.2.0-commandline+is%3Aclosed+-label%3AClosedAs%3ADuplicate).

## Visual Studio extension updates




