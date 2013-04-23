##  Config Command

Gets or sets NuGet config values.

### Usage
    nuget config -Set name=value

### Options
<table>
    <tr>
        <td>Set</td>
        <td>One on more key-value pairs to be set in config.</td>
    </tr>
    <tr>
        <td>Help</td>
        <td>help</td>
    </tr>
    <tr>
        <td>Verbosity</td>
        <td>Display this amount of details in the output: normal, quiet, detailed.</td>
    </tr>
    <tr>
        <td>NonInteractive</td>
        <td>Do not prompt for user input or confirmations.</td>
    </tr>
</table>

### Examples

    nuget config -Set HTTP_PROXY=http://127.0.0.1 -Set HTTP_PROXY.USER=domain\user
    nuget.config HTTP_PROXY





##  Delete Command

Deletes a package from the server.

### Usage
    nuget delete <package Id> <package version> [API Key] [options]

Specify the Id and version of the package to delete from the server.
### Options
<table>
    <tr>
        <td>Source</td>
        <td>Specifies the server URL.</td>
    </tr>
    <tr>
        <td>NoPrompt</td>
        <td>Do not prompt when deleting.</td>
    </tr>
    <tr>
        <td>ApiKey</td>
        <td>The API key for the server.</td>
    </tr>
    <tr>
        <td>Help</td>
        <td>help</td>
    </tr>
    <tr>
        <td>Verbosity</td>
        <td>Display this amount of details in the output: normal, quiet, detailed.</td>
    </tr>
    <tr>
        <td>NonInteractive</td>
        <td>Do not prompt for user input or confirmations.</td>
    </tr>
</table>

### Examples

    nuget delete MyPackage 1.0
        
    nuget delete MyPackage 1.0 -NoPrompt





##  Help Command

Displays general help information and help information about other commands.

### Usage
    nuget help [command]

Pass a command name to display help information for that command.
### Options
<table>
    <tr>
        <td>All</td>
        <td>Print detailed help for all available commands.</td>
    </tr>
    <tr>
        <td>Markdown</td>
        <td>Print detailed all help in markdown format.</td>
    </tr>
    <tr>
        <td>Help</td>
        <td>help</td>
    </tr>
    <tr>
        <td>Verbosity</td>
        <td>Display this amount of details in the output: normal, quiet, detailed.</td>
    </tr>
    <tr>
        <td>NonInteractive</td>
        <td>Do not prompt for user input or confirmations.</td>
    </tr>
</table>

### Examples

    nuget help
    
    nuget help push
    
    nuget ?
    
    nuget push -?





##  Install Command

Installs a package using the specified sources. If no sources are specified, all sources defined in %AppData%\NuGet\NuGet.config are used.  If NuGet.config specifies no sources, uses the default NuGet feed.

### Usage
    nuget install packageId|pathToPackagesConfig [options]

Specify the id and optionally the version of the package to install. If a path to a packages.config file is used instead of an id, all the packages it contains are installed.
### Options
<table>
    <tr>
        <td>Source</td>
        <td>A list of packages sources to use for the install.</td>
    </tr>
    <tr>
        <td>OutputDirectory</td>
        <td>Specifies the directory in which packages will be installed. If none specified, uses the current directory.</td>
    </tr>
    <tr>
        <td>Version</td>
        <td>The version of the package to install.</td>
    </tr>
    <tr>
        <td>ExcludeVersion</td>
        <td>If set, the destination folder will contain only the package name, not the version number</td>
    </tr>
    <tr>
        <td>Prerelease</td>
        <td>Allows prerelease packages to be installed. This flag is not required when restoring packages by installing from packages.config.</td>
    </tr>
    <tr>
        <td>NoCache</td>
        <td>Disable looking up packages from local machine cache.</td>
    </tr>
    <tr>
        <td>RequireConsent</td>
        <td>Checks if package restore consent is granted before installing a package.</td>
    </tr>
    <tr>
        <td>SolutionDirectory</td>
        <td>Solution root for package restore.</td>
    </tr>
    <tr>
        <td>Help</td>
        <td>help</td>
    </tr>
    <tr>
        <td>Verbosity</td>
        <td>Display this amount of details in the output: normal, quiet, detailed.</td>
    </tr>
    <tr>
        <td>NonInteractive</td>
        <td>Do not prompt for user input or confirmations.</td>
    </tr>
    <tr>
        <td>FileConflictAction</td>
        <td>The action to take, when asked to overwrite or ignore existing files referenced by the project: Overwrite, Ignore, None.</td>
    </tr>
</table>

### Examples

    nuget install elmah
    
    nuget install packages.config
    
    nuget install ninject -o c:\foo





##  List Command

Displays a list of packages from a given source. If no sources are specified, all sources defined in %AppData%\NuGet\NuGet.config are used. If NuGet.config specifies no sources, uses the default NuGet feed.

### Usage
    nuget list [search terms] [options]

Specify optional search terms.
### Options
<table>
    <tr>
        <td>Source</td>
        <td>A list of packages sources to search.</td>
    </tr>
    <tr>
        <td>Verbose</td>
        <td>Displays a detailed list of information for each package.</td>
    </tr>
    <tr>
        <td>AllVersions</td>
        <td>List all versions of a package. By default, only the latest package version is displayed.</td>
    </tr>
    <tr>
        <td>Prerelease</td>
        <td>Allow prerelease packages to be shown.</td>
    </tr>
    <tr>
        <td>Help</td>
        <td>help</td>
    </tr>
    <tr>
        <td>Verbosity</td>
        <td>Display this amount of details in the output: normal, quiet, detailed.</td>
    </tr>
    <tr>
        <td>NonInteractive</td>
        <td>Do not prompt for user input or confirmations.</td>
    </tr>
</table>

### Examples

    nuget list
    
    nuget list -verbose -allversions


##  Mirror Command

Mirrors a package and its dependencies from the specified source repositories to the target repository.

Note: to enable this command, navigate to [http://ci.nuget.org/](http://ci.nuget.org/) (there's a Guest log in option),
copy NuGet.ServerExtensions.dll from Artifacts,CommandLine.ServerExtensions to your local disk in the same folder than NuGet.exe.

### Usage
    nuget mirror packageId|pathToPackagesConfig listUrlTarget publishUrlTarget [options]

Specify the id of the package to mirror, the url to query the target repository (list command) and the url to push packages to the target repository.
If a path to a packages.config file is used instead of a package id, all the packages it contains are mirrored to the given version (if specified) or latest otherwise.
Assuming you're targeting a private repository under [http://machine/repo](http://machine/repo) installed using NuGet.Server, the list and push urls will be 
[http://machine/repo/nuget](http://machine/repo/nuget) and [http://machine/repo/api/v2/package](http://machine/repo/api/v2/package) respectively.

### Options
<table>
    <tr>
        <td>Source</td>
        <td>A list of packages sources to use for the finding packages to mirror. 
        If no sources are specified, the ones defined in the default NuGet config file are used. 
        If the default NuGet config file specifies no sources, uses the default NuGet feed.</td>
    </tr>
    <tr>
        <td>Version</td>
        <td>The version of the package to install. If not specified, latest version is mirrored.</td>
    </tr>
    <tr>
        <td>ApiKey</td>
        <td>The API key for pushing to the target repository. If not specified, the one specified in the default NuGet config file is used.</td>
    </tr>
    <tr>
        <td>Prerelease</td>
        <td>When set, "latest" when specifying no version for a package id (as command argument or in packages.config) includes pre-release packages.</td>
    </tr>
    <tr>
        <td>Timeout</td>
        <td>Specifies the timeout for pushing to a server in seconds. Defaults to 300 seconds (5 minutes).</td>
    </tr>
    <tr>
        <td>NoCache</td>
        <td>By default a local cache is used as a fallback when a package or a package dependency is not found in the specified source(s). 
        If you want to ensure only packages from the specified sources are used, set the NoCache option. 
        If you want instead to maximize chances of finding packages, do not set this option.</td>
    </tr>
    <tr>
        <td>NoOp</td>
        <td>Log what would be done without actually doing it. Assumes success for push operations.</td>
    </tr>
    <tr>
        <td>Help</td>
        <td>help</td>
    </tr>
</table>

### Examples

    nuget mirror packages.config  http://MyRepo/ES/nuget http://MyRepo/ES/api/v2/package -source https://nuget.org/api/v2 -apikey myApiKey -NoCache
    
    nuget mirror Microsoft.AspNet.Mvc http://MyRepo/ES/nuget http://MyRepo/ES/api/v2/package -version 4.0.20505.0

    nuget mirror Microsoft.Net.Http http://MyRepo/ES/nuget http://MyRepo/ES/api/v2/package -prerelease



##  Pack Command

Creates a NuGet package based on the specified nuspec or project file.

### Usage
    nuget pack <nuspec | project> [options]

Specify the location of the nuspec or project file to create a package.
### Options
<table>
    <tr>
        <td>OutputDirectory</td>
        <td>Specifies the directory for the created NuGet package file. If not specified, uses the current directory.</td>
    </tr>
    <tr>
        <td>BasePath</td>
        <td>The base path of the files defined in the nuspec file.</td>
    </tr>
    <tr>
        <td>Verbose</td>
        <td>Shows verbose output for package building.</td>
    </tr>
    <tr>
        <td>Version</td>
        <td>Overrides the version number from the nuspec file.</td>
    </tr>
    <tr>
        <td>Exclude</td>
        <td>Specifies one or more wildcard patterns to exclude when creating a package.</td>
    </tr>
    <tr>
        <td>Symbols</td>
        <td>Determines if a package containing sources and symbols should be created. When specified with a nuspec, creates a regular NuGet package file and the corresponding symbols package.</td>
    </tr>
    <tr>
        <td>Tool</td>
        <td>Determines if the output files of the project should be in the tool folder. </td>
    </tr>
    <tr>
        <td>Build</td>
        <td>Determines if the project should be built before building the package.</td>
    </tr>
    <tr>
        <td>NoDefaultExcludes</td>
        <td>Prevent default exclusion of NuGet package files and files and folders starting with a dot e.g. .svn.</td>
    </tr>
    <tr>
        <td>NoPackageAnalysis</td>
        <td>Specify if the command should not run package analysis after building the package.</td>
    </tr>
    <tr>
        <td>ExcludeEmptyDirectories</td>
        <td>Prevent inclusion of empty directories when building the package.</td>
    </tr>
    <tr>
        <td>Properties</td>
        <td>Provides the ability to specify a semicolon ";" delimited list of properties when creating a package.</td>
    </tr>
    <tr>
        <td>Help</td>
        <td>help</td>
    </tr>
    <tr>
        <td>Verbosity</td>
        <td>Display this amount of details in the output: normal, quiet, detailed.</td>
    </tr>
    <tr>
        <td>NonInteractive</td>
        <td>Do not prompt for user input or confirmations.</td>
    </tr>
    <tr>
        <td>MinClientVersion</td>
        <td>Set the <strong>minClientVersion</strong> attribute for the created package. This value will override the value of the existing minClientVersion attribute (if any) in the .nuspec file.</td>
    </tr>
</table>

### Examples

    nuget pack
    
    nuget pack foo.nuspec
    
    nuget pack foo.csproj
    
    nuget pack foo.csproj -Build -Symbols -Properties Configuration=Release
    
    nuget pack foo.nuspec -Version 2.1.0

    nuget pack foo.nuspec -Version 1.0.0 -MinClientVersion 2.5





##  Push Command

Pushes a package to the server and optionally publishes it.
NuGet's default configuration is obtained by loading %AppData%\NuGet\NuGet.config, then loading any nuget.config or .nuget\nuget.config starting from root of drive and ending in current directory.


### Usage
    nuget push <package path> [API key] [options]

Specify the path to the package and your API key to push the package to the server.
### Options
<table>
    <tr>
        <td>Source</td>
        <td>Specifies the server URL. If not specified, nuget.org is used unless DefaultPushSource config value is set in the NuGet config file.
        <br/>
        Starting with NuGet 2.5, if NuGet.exe identifies a UNC/folder source, it will perform the file copy to the source.
        </td>
    </tr>
    <tr>
        <td>ApiKey</td>
        <td>The API key for the server.</td>
    </tr>
    <tr>
        <td>Timeout</td>
        <td>Specifies the timeout for pushing to a server in seconds. Defaults to 300 seconds (5 minutes).</td>
    </tr>
    <tr>
        <td>Help</td>
        <td>help</td>
    </tr>
    <tr>
        <td>Verbosity</td>
        <td>Display this amount of details in the output: normal, quiet, detailed.</td>
    </tr>
    <tr>
        <td>NonInteractive</td>
        <td>Do not prompt for user input or confirmations.</td>
    </tr>
</table>

### Examples

    nuget push foo.nupkg 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a
    
    nuget push foo.nupkg 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a -s http://customsource/
    
    nuget push foo.nupkg
    
    nuget push foo.nupkg.symbols
    
    nuget push foo.nupkg -Timeout 360
    
    nuget push *.nupkg

    Starting with NuGet 2.5 you can now push to a UNC/Folder source
    nuget.exe push -source \\mycompany\repo\ mypackage.1.0.0.nupkg 


##  Setapikey Command

Saves an API key for a given server URL. When no URL is provided API key is saved for the NuGet gallery.

### Usage
    nuget setapikey <API key> [options]

Specify the API key to save and an optional URL to the server that provided the API key.
### Options
<table>
    <tr>
        <td>Source</td>
        <td>Server URL where the API key is valid.</td>
    </tr>
    <tr>
        <td>Help</td>
        <td>help</td>
    </tr>
    <tr>
        <td>Verbosity</td>
        <td>Display this amount of details in the output: normal, quiet, detailed.</td>
    </tr>
    <tr>
        <td>NonInteractive</td>
        <td>Do not prompt for user input or confirmations.</td>
    </tr>
</table>

### Examples

    nuget setapikey 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a
    
    nuget setapikey 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a -Source http://example.com/nugetfeed





##  Sources Command

Provides the ability to manage list of sources located in  %AppData%\NuGet\NuGet.config

### Usage
    nuget sources <List|Add|Remove|Enable|Disable|Update> -Name [name] -Source [source]

### Options
<table>
    <tr>
        <td>Name</td>
        <td>Name of the source.</td>
    </tr>
    <tr>
        <td>Source</td>
        <td>Path to the package(s) source.</td>
    </tr>
    <tr>
        <td>UserName</td>
        <td>UserName to be used when connecting to an authenticated source.</td>
    </tr>
    <tr>
        <td>Password</td>
        <td>Password to be used when connecting to an authenticated source.</td>
    </tr>
    <tr>
        <td>Help</td>
        <td>help</td>
    </tr>
    <tr>
        <td>Verbosity</td>
        <td>Display this amount of details in the output: normal, quiet, detailed.</td>
    </tr>
    <tr>
        <td>NonInteractive</td>
        <td>Do not prompt for user input or confirmations.</td>
    </tr>
</table>




##  Spec Command

Generates a nuspec for a new package. If this command is run in the same folder as a project file (.csproj, .vbproj, .fsproj), it will create a tokenized nuspec file.

### Usage
    nuget spec [package id]

### Options
<table>
    <tr>
        <td>AssemblyPath</td>
        <td>Assembly to use for metadata.</td>
    </tr>
    <tr>
        <td>Force</td>
        <td>Overwrite nuspec file if it exists.</td>
    </tr>
    <tr>
        <td>Help</td>
        <td>help</td>
    </tr>
    <tr>
        <td>Verbosity</td>
        <td>Display this amount of details in the output: normal, quiet, detailed.</td>
    </tr>
    <tr>
        <td>NonInteractive</td>
        <td>Do not prompt for user input or confirmations.</td>
    </tr>
</table>

### Examples

    nuget spec
    
    nuget spec MyPackage
    
    nuget spec -a MyAssembly.dll





##  Update Command

Update packages to latest available versions. This command also updates NuGet.exe itself.

### Usage
    nuget update <packages.config|solution>

### Options
<table>
    <tr>
        <td>Source</td>
        <td>A list of package sources to search for updates.</td>
    </tr>
    <tr>
        <td>Id</td>
        <td>Package ids to update.</td>
    </tr>
    <tr>
        <td>RepositoryPath</td>
        <td>Path to the local packages folder (location where packages are installed).</td>
    </tr>
    <tr>
        <td>Safe</td>
        <td>Looks for updates with the highest version available within the same major and minor version as the installed package.</td>
    </tr>
    <tr>
        <td>Self</td>
        <td>Update the running NuGet.exe to the newest version available from the server.</td>
    </tr>
    <tr>
        <td>Verbose</td>
        <td>Show verbose output while updating.</td>
    </tr>
    <tr>
        <td>Prerelease</td>
        <td>Allows updating to prerelease versions. This flag is not required when updating prerelease packages that are already installed.</td>
    </tr>
    <tr>
        <td>Help</td>
        <td>help</td>
    </tr>
    <tr>
        <td>Verbosity</td>
        <td>Display this amount of details in the output: normal, quiet, detailed.</td>
    </tr>
    <tr>
        <td>NonInteractive</td>
        <td>Do not prompt for user input or confirmations.</td>
    </tr>
    <tr>
        <td>FileConflictAction</td>
        <td>The action to take, when asked to overwrite or ignore existing files referenced by the project: Overwrite, Ignore, None.
    </tr>
</table>

### Examples

    nuget update
        
    nuget update -Safe
    
    nuget update -Self


