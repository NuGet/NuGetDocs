# Command Line Reference

You can download the command line tool from [here](http://nuget.codeplex.com/releases/view/58939)

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
        <td>Help</td>
        <td>help</td>
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
</table>

### Examples

    nuget list
    
    nuget list -verbose -allversions





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
        <td>Properties</td>
        <td>Provides the ability to specify a semicolon ";" delimited list of properties when creating a package.</td>
    </tr>
    <tr>
        <td>Help</td>
        <td>help</td>
    </tr>
</table>

### Examples

    nuget pack
    
    nuget pack foo.nuspec
    
    nuget pack foo.csproj
    
    nuget pack foo.csproj -Build -Symbols -Properties Configuration=Release
    
    nuget pack foo.nuspec -Version 2.1.0





##  Publish Command

Publishes a package that was uploaded to the server but not added to the feed.

### Usage
    nuget publish <package id> <package version> <API Key> [options]

Specify the id and version of the package that will be published to the feed.
### Options
<table>
    <tr>
        <td>Source</td>
        <td>Specifies the server URL.</td>
    </tr>
    <tr>
        <td>Help</td>
        <td>help</td>
    </tr>
</table>

### Examples

    nuget push foo.nupkg 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a
    
    nuget push foo.nupkg 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a -s http://example.com/nuget-publish-endpoint
    
    nuget push foo.nupkg
    
    nuget push foo.nupkg.symbols





##  Push Command

Pushes a package to the server and optionally publishes it.

### Usage
    nuget push <package path> [API key] [options]

Specify the path to the package and your API key to push the package to the server.
### Options
<table>
    <tr>
        <td>CreateOnly</td>
        <td>Specifies if the package should be created and uploaded to the server but not published to the server. False by default.</td>
    </tr>
    <tr>
        <td>Source</td>
        <td>Specifies the server URL.</td>
    </tr>
    <tr>
        <td>ApiKey</td>
        <td>The API key for the server.</td>
    </tr>
    <tr>
        <td>Help</td>
        <td>help</td>
    </tr>
</table>

### Examples

    nuget push foo.nupkg 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a
    
    nuget push foo.nupkg 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a -s http://customsource/
    
    nuget push foo.nupkg
    
    nuget push foo.nupkg.symbols





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
</table>

### Examples

    nuget setapikey 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a
    
    nuget setapikey 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a -Source http://example.com/nugetfeed





##  Sources Command

Provides the ability to manage list of sources located in  %AppData%\NuGet\NuGet.config

### Usage
    nuget sources <List|Add|Remove|Enable|Disable> -Name [name] -Source [source]

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
        <td>Help</td>
        <td>help</td>
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
</table>

### Examples

    nuget update
        
    nuget update -Safe
    
    nuget update -Self


