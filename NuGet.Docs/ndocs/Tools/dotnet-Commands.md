# dotNet Commands

The DotNet command-line interface, which runs on Windows, Mac OS X, and Linux, provides a number of essential nuget.exe commands as listed below. Where dotnet provides the desired commands, it is not necessary to download nuget.exe.

- [**dotnet pack**](https://docs.microsoft.com/dotnet/articles/core/tools/dotnet-pack): Packs the code into a NuGet package. As of NuGet 4.0, this runs the same code as `nuget pack`.
- [**dotnet restore**](https://docs.microsoft.com/dotnet/articles/core/tools/dotnet-restore): Restores the dependencies and tools of a project. As of NuGet 4.0, this runs the same code as `nuget restore`.
- [**dotnet nuget locals**](https://docs.microsoft.com/en-us/dotnet/articles/cli-preview3/tools/dotnet-nuget-locals): Clears or lists local NuGet resources such as http the -request cache, temporary cache, or machine-wide global packages folder.
- [**dotnet nuget push**](https://docs.microsoft.com/en-us/dotnet/articles/cli-preview3/tools/dotnet-nuget-push): Pushes a package to a server and publishes it, applicable to nuget.org, Visual Studio Team Services, or any third-party NuGet servers.
- [**dotnet nuget delete**](https://docs.microsoft.com/en-us/dotnet/articles/cli-preview3/tools/dotnet-nuget-delete): Deletes or unlists a package from a  server, applicable to nuget.org, Visual Studio Team Services, or any third-party NuGet servers.