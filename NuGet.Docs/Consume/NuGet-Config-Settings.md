# NuGet Configuration Settings

There are a bunch of NuGet configuration values which can be set via the nuget.config file.
Below is the summary of the NuGet config keys and their usage, note the keys are case sensitive.

## Repository path

**section**: config  
**key**: repositoryPath

Allows  you to install the NuGet packages in the specified folder, instead of the default `"$(Solutiondir)\Packages"` folder.
This key can be added to the NuGet.config file manually or using the [NuGet.exe Config -Set command](Command-Line-Reference#config-command).
More details [here](../Release-Notes/NuGet-2.1#specify-%E2%80%98packages%E2%80%99-folder-location).

    <config>
      <add key="repositoryPath" value="C:\Temp" />
    </config>

You can also provide a relative path (note the forward slashes for relative path).

<p class="info">
<strong>Note</strong><br/>Relative path is only relative to NuGet.config file location.
</p>

    <config>
      <add key="repositoryPath" value="../relativepath" />
    </config>

## Dependency version

**section**: config  
**key**: dependencyVersion

Defines what the default DependencyVersion value is, if the `-DependencyVersion` switch is not specified in an invocation of `install-package`.
This value will also be respected by the NuGet Package Manager Dialog for any install package operations in projects with a packages.config file.
To set this value, add the attribute below to your nuget.config file:

    <config>
      <add key="dependencyVersion" value="Highest" />
    </config>

Allowed values for dependencyVersion are: Lowest, HighestPatch, HighestMinor, Highest

Information about semantic versioning and what these values apply to can be found in [Versioning](../Create/Versioning#really-brief-introduction-to-semver).

## Package Restore

**section**: packageRestore  
**keys**: enabled and automatic

**Used for Pre-2.7 Nuget Package Restore only.**

Allows you to restore missing packages from the NuGet source during build.
The environment variable `EnableNuGetPackageRestore` with a value of `true` can be used in place of the `enabled` key in the config file.
More details [here](Package-Restore).

    <packageRestore>
      <!-- Allow NuGet to download missing packages -->
      <add key="enabled" value="True" />
      <!-- Automatically check for missing packages during build in Visual Studio -->
      <add key="automatic" value="True" />
    </packageRestore>

## Package sources

**sections**: packageSources, disabledPackageSources and activePackageSource  

Allows you to specify the list of sources to be used while looking for packages.

* `packageSources` section has the list of package sources.
* `disabledPackageSources` has the list of sources which are currently disabled.
* `activePackageSource` points to the currently active source. Specifying `(Aggregate source)` as the source value would imply that all the current package sources except for the disabled ones are active.

The values can be added to the config file directly or using the package manager settings UI (which would in turn update the NuGet.config file) or using the [NuGet.exe Sources command](Command-Line-Reference#sources-command).

    <packageSources>
      <add key="NuGet official package source" value="https://nuget.org/api/v2/" />
      <add key="TestSource" value="C:\Temp" />
    </packageSources>
    <disabledPackageSources />
    <activePackageSource>
      <add key="All" value="(Aggregate source)" />
    </activePackageSource>

## Source control integration

**section**: solution  
**key**: disableSourceControlIntegration

Allows you to disable source control integration for the "Packages" folder.
This key works at the solution level and hence need to be added to the NuGet.config file present in the `$(SolutionDir)\.nuget` directory.
Enabling package restore from VS would add the `.nuget\nuget.config` file automatically.
More details [here](../Docs/Workflows/Using-NuGet-without-committing-packages).

The default value for this key is true.

    <solution>
      <add key="disableSourceControlIntegration" value="true" />
    </solution>

## Proxy settings

**section**: config  
**keys**: http_proxy, http_proxy.user, http_proxy.password and no_proxy.

Allows you to set the proxy settings to be used while connecting to your NuGet feed.
More details [here](http://skolima.blogspot.com/2012/07/nuget-proxy-settings.html).

This key can be added using [NuGet.exe Config -Set command](Command-Line-Reference#config-command).

It can also be set via environment variables `http_proxy` and `no_proxy`. `http_proxy` should be specified in the format `http://[username]:[password]@proxy.com` whereas `no_proxy` should be a comma-separated list of domains to bypass the proxy server.

<p class="info">
<strong>Note</strong><br />The "http_proxy.password" key value is encrypted before storing in the nuget.config file.
Hence it can not be added manually by directly updating the config file.
</p>

## Credentials for package source

**section**: packageSourceCredentials  
**keys**: Username, Password and ClearTextPassword

Allows you to set the credentials to access the given package source.

This key has to be set using the [NuGet.exe Sources command](Command-Line-Reference#sources-command).
The default behavior is to store the password encrypted in the config file.

    NuGet.exe Sources Add -Name <feedName> -Source <pathToPackageSource> -UserName xxx -Password <secret>
    NuGet.exe Sources Update -Name <feedName> -Source <pathToPackageSource> -UserName xxx -Password <secret> 

This results in something similar to this:

    <packageSourceCredentials>
      <feedName>
        <add key="Username" value="xxx" />
        <add key="Password" value="...encrypted..." />
      </feedName>
    </packageSourceCredentials>

If you want to share the credentials with others then you might want to use the -StorePasswordInClearText option to disable password encryption.
Using this option allows you to store the password in clear text, for instance in your solution-local nuget.config using the new [-Config option](Command-Line-Reference#config-command), and commit it to your VCS.

    NuGet.exe Sources Add -Name <feedName> -Source <pathToPackageSource> -UserName xxx -Password <secret> -StorePasswordInClearText -Config <path to nuget.config>
    NuGet.exe Sources Update -Name <feedName> -Source <pathToPackageSource> -UserName xxx -Password <secret> -StorePasswordInClearText -Config <path to nuget.config>

This results in something more readable (or even manually configurable):

    <packageSourceCredentials>
      <feedName>
        <add key="Username" value="xxx" />
        <add key="ClearTextPassword" value="secret" />
      </feedName>
    </packageSourceCredentials>

## API Key to access package source

Allows you to set the API Key corresponding to a specific package source.

This key has to be set via [NuGet -SetApiKey](Command-Line-Reference#setapikey-command).
