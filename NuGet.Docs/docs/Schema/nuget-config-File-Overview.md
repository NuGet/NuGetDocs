# NuGet Configuration File

NuGet's configuration file allows for persisting configuration settings and changing default configuration values.

## Default Location

The default location for NuGet's configuration file is `%APPDATA%\NuGet\NuGet.Config` (DOS) or `$ENV:APPDATA\NuGet\NuGet.Config` (PowerShell). APPDATA's value is OS, system drive, and current user dependent. 

For example: `D:\Users\username\AppData\Roaming\NuGet\NuGet.config`.

The default configuration file can be changed through -ConfigFile option when using NuGet CLI. For example, "-ConfigFile c:\my.config" means using file c:\my.config instead of %APPDATA%\NuGet\NuGet.Config as the default configuraion file.

## Config file reference

XML is used to store the configuration, and any text editor can be used to author it.

<p class="info">
<strong>Note</strong><br />NuGet will silently ignore the entire configuration file if it encounters any XML parsing issues (such as mismatched begin/end nodes, invalid quotation, etc.); therefore an editor that reports parsing issues is recommended.
</p>

<p class="info">
<strong>Note</strong><br />The keys are case sensitive.
</p>

Below an example of NuGet configuration file that specifies some of the available settings and is annotated with comments.  For the full list of configuration settings, see the [NuGet Configuration Settings page](NuGet-Config-Settings).

    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <config>
	    <!-- 
		Used to specify the default location to expand packages.
		See: NuGet.exe help install
		See: NuGet.exe help update
		-->
        <add key="repositoryPath" value="External\Packages" />
		<!-- 
		Used to specify default source for the push command.
		See: NuGet.exe help push
		-->
        <add key="DefaultPushSource" value="http://MyRepo/ES/api/v2/package" />
		<!-- 
		Proxy settings
		-->
		<add key="http_proxy" value="host" />
		<add key="http_proxy.user" value="username" />
		<add key="http_proxy.password" value="encrypted_password" />
      </config>
	  <packageRestore>
        <!-- Allow NuGet to download missing packages -->
        <add key="enabled" value="True" />

        <!-- Automatically check for missing packages during build in Visual Studio -->
        <add key="automatic" value="True" />
      </packageRestore>
	  <!--
	  Used to specify the default Sources for list, install and update.
	  See: NuGet.exe help list
	  See: NuGet.exe help install
	  See: NuGet.exe help update
	  -->
      <packageSources>
        <add key="NuGet official package source" value="https://nuget.org/api/v2/" />
        <add key="MyRepo - ES" value="http://MyRepo/ES/nuget" />
      </packageSources>
	  <!-- used to store credentials -->
	  <packageSourceCredentials />
	  <!-- Used to specify which one of the sources are active -->
      <activePackageSource>
	    <!-- this tells only one given source is active -->
        <add key="NuGet official package source" value="https://nuget.org/api/v2/" />
		<!-- this tells that all of them are active -->
		<add key="All" value="(Aggregate source)" />
      </activePackageSource>
	  <!-- Used to disable package sources  -->
      <disabledPackageSources />
	  <!-- 
	  Used to specify default API key associated with sources. 
	  See: NuGet.exe help setApiKey
	  See: NuGet.exe help push
	  See: NuGet.exe help mirror
	  -->
      <apikeys>
        <add key="http://MyRepo/ES/api/v2/package" value="encrypted_api_key" />
      </apikeys>
    </configuration>

## Chaining multiple configuration files

In general the NuGet.config file closest to the folder nuget.exe runs from wins, the section below walks through the details.

NuGet first loads NuGet.config from the default location, then loads any file named NuGet.config starting from the root of the current drive and ending in the current directory.

Current directory is defined as:

* Directory from which NuGet.exe is invoked (command line scenario).
* Directory in which the current solution was loaded from (Visual Studio scenario).


The following rules are used to determine the actual configuration values:

* When `<clear />` is present for a given node, previously defined configuration items for this node are ignored.
* For nodes used as collections (for example `<packageSources>`), new elements are added to the collection.
* For elements used as single items (for example elements under `<config>` or `<packageRestore>`), new elements replace previous elements with the same key.

For example, assuming this directory structure:

    C:\
    └───Users
    F:\
    ├───Project1
    │   └───Source
	├───Project2
    │   └───Source
	└───Tmp
       
With these four NuGet config files present on the filesystem: 

1) %APPDATA%\NuGet\Nuget.config with content:

    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <activePackageSource>
        <add key="NuGet official package source" value="https://nuget.org/api/v2/" />
      </activePackageSource>
    </configuration>

2) F:\NuGet.config with content:

    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
	  <config>
        <add key="repositoryPath" value="F:\tmp" />
      </config>
      <packageRestore>
        <add key="enabled" value="True" />
      </packageRestore>
    </configuration>

3) F:\Project1\NuGet.config with content:

    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <config>
        <add key="repositoryPath" value="External\Packages" />
        <add key="DefaultPushSource" value="http://MyPrivateRepo/ES/api/v2/package" />
      </config>
      <packageSources>
        <clear /> <!-- ensure only the sources defined below are used -->
        <add key="MyPrivateRepo - ES" value="http://MyPrivateRepo/ES/nuget" />
      </packageSources>
    </configuration>

4) F:\Project2\NuGet.config with content:

    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <packageSources>
	    <!-- Add this repository to the list of available repositories -->
        <add key="MyPrivateRepo - DQ" value="http://MyPrivateRepo/DQ/nuget" />
      </packageSources>
    </configuration>

NuGet will load:

* **When invoked from C:\Users**: Only 1. The default repository on NuGet.org is used.
* **When invoked from F:\ or F:\tmp**: 1 and 2. The default repository on NuGet.org is used, package restore is enabled and packages get expanded in F:\tmp.
* **When invoked from F:\Project1 or F:\Project1\Source**: 1, 2 and 3. The last config file that gets loaded overrides `repositoryPath` therefore packages get expanded in F:\Project1\External\Packages instead of F:\tmp. It also clears `<packageSources>` therefore nuget.org is no longer available as a source; instead only http://MyPrivateRepo/ES/nuget is available.
* **When invoked from F:\Project2 or F:\Project2\Source**: 1, 2 and 4. This time `packageSources` is not cleared, therefore both nuget.org and http://MyPrivateRepo/DQ/nuget are available as source repositories. Packages get expanded in F:\tmp

## NuGet config extensibility point
NuGet config files are treated in the following priority order (closest to the folder nuget.exe runs from wins), for example assuming the solution directory is c:\a\b\c:

* c:\a\b\c\\.nuget\nuget.config - This file is only used for solution level packages, and is not supported in nuget 3.0 - 3.4
* c:\a\b\c\nuget.config
* c:\a\b\nuget.config
* c:\a\nuget.config
* c:\nuget.config
* User specific config file, %AppData%\NuGet\nuget.config. 
* Or the user specified file thru option -ConfigFile.

Starting with NuGet 2.6, with the new config extensibility point, a new location for machine wide config files located under directory %ProgramData%\NuGet\Config are read after the user specific config file. So, the above list now becomes:

* c:\a\b\c\\.nuget\nuget.config
* c:\a\b\c\nuget.config
* c:\a\b\nuget.config
* c:\a\nuget.config
* c:\nuget.config
* User specific config file, %AppData%\NuGet\nuget.config
* Or the user specified file thru option -ConfigFile
* %ProgramData%\NuGet\Config\{IDE}\{Version}\{SKU}\*.config, e.g. %ProgramData%\NuGet\Config\VisualStudio\{VSVersion}\Pro\a.config
* %ProgramData%\NuGet\Config\{IDE}\{Version}\*.config
* %ProgramData%\NuGet\Config\{IDE}\*.config
* %ProgramData%\NuGet\Config\*.config

In the above path locations {IDE} can be VisualStudio and if you want to specify config for a particular SKU of Visual Studio {SKU} can be Pro, VWDExpress, VPDExpress, VSWinExpress or VSWinDesktopExpress.

With NuGet 2.6, the machine wide package sources are now shown in Package Manage Settings dialog. Machine wide package sources are readonly and you can enable or disable them using this dialog.

![NuGet Config File machine wide settings](/images/consume/NuGet-Config-File-Machine-Wide.png)


# NuGet Configuration Settings
Below is the summary of the NuGet configuration keys and values that can be set via the nuget.config files.

<h3> Repository Path </h3>
 Allows  you to install the NuGet packages in the specified folder, instead of the default "$(Solutiondir)\Packages" folder.
 This key can be added to the NuGet.config file manually or using the [NuGet Config Set](/Consume/Command-Line-Reference#Config-Command) command. 
 More details [here](/Release-Notes/NuGet-2.1#Specify-packages-Folder-Location)
 <add key="repositoryPath" value="C:\Temp" />
  
<h3>Package Restore </h3>
Allows you to restore missing packages from the NuGet source during build.

	<packageRestore>
		<!--Allow NuGet to download missing packages -->
		<add key="enabled" value="True" />
		<!-- Automatically check for missing packages during build in Visual Studio -->
		<add key="automatic" value="True" />
	</packageRestore>

<h3>Package Sources</h3>
Allows you to specify the list of sources to be used while looking for packages. 

* "PackageSources" section has the list of package sources 
* "DisabledPackageSources" has the list of sources which are currently disabled 
* "ActivePackageSource" points to the currently active source. Speciying "(Aggregate source)" as the source value would imply that all the current package sources except for the disabled ones are active

The values can be added to the config file directly or using the package manager settings UI (which would in turn update the NuGet.config file) or 
using the <a href="/Consume/command-line-reference#Sources-Command">NuGet.exe Sources command.</a>

	<packageSources>
		<add key="NuGet official package source" value="https://nuget.org/api/v2/" />
		<add key="TestSource" value="C:\Temp" />
	</packageSources>
	<disabledPackageSources />
	<activePackageSource>
		<add key="All" value="(Aggregate source)"  />
	</activePackageSource>

<h3>Source Control Integration </h3>
"disableSourceControlIntegration" under section "solution" allows you to disable source control integration for the "Packages" folder. 
This key works at the solution level and hence need to be added in a NuGet.config file in the "$(SolutionDir)\.nuget directory". 
The default value for this key is true.

	<solution>
		<add key="disableSourceControlIntegration" value="true" />
	</solution>

<h3>Proxy Settings</h3>
Allows you to set the proxy settings to be used while connecting to your NuGet feed.
This key can be added using <a href="command-line-reference#Set-Command">Nuget.exe Config -Set command</a>. 
It can also be set via environment variable "http_proxy". While setting environment variable, the value should be specified in the 
format 'http://[username]:[password]@proxy.com'. Note, the "http_proxy.password" key value is encrypted before storing in the nuget.config file. 
Hence it cannot be added manually by directly updating the config file.

<h3>Credentials for package source</h3>
Allows you to set the credentials to access the given package source
This key has to be set using the <a href="command-line-reference#Sources-Command">NuGet.exe Sources command.</a>
The default behavior is to store the password encrypted in the config file

	Nuget.exe Sources Add -Name feedName -UserName user -Password secret  
	Nuget.exe Sources Update -Name feedName -UserName user -Password secret 

This results in something similar to this:

	<packageSourceCredentials>
		<feedName>
			<add key="Username" value="user" />
			<add key="Password" value="...encrypted..." />
		</feedName>
	</packageSourceCredentials>

If you want to share the credentials with others then you might want to use the -StorePasswordInClearText option to disable password encryption. 
Using this option allows you to store the password in clear text, for instance in your solution-local nuget.config using the new 
<a href="/Consume/command-line-reference">-Config option</a>, and commit it to your source control.

	Nuget.exe Sources Add -Name feedName -UserName user -Password secret -StorePasswordInClearText -Config <path to nuget.config>
	Nuget.exe Sources Update -Name feedName -UserName user -Password secret -StorePasswordInClearText -Config <path to nuget.config>

This results in something more readable (or even manually configurable):

	<packageSourceCredentials>
		<feedName>
			<add key="Username" value="user" />
			<add key="ClearTextPassword" value="secret" />
		</feedName>
	</packageSourceCredentials>

<h3>API Key to access package source</h3>
Allows you to set the API Key corresponding to a specific package source.
This key  has to be set via <a href="/Consume/command-line-reference#Setapikey-Command">NuGet -SetApiKey</a>

### Environment variables in configuration

Starting with NuGet 3.4, NuGet evaluates environment variables in NuGet.config values.
NuGet does not evaluate environment variables in other locations.
This enables you to include NuGet.config in your source repository but still have environment specific configuration exposed. 

Consider an example NuGet.config file:

    <configuration>
        <config>
            <add key="repositoryPath" value="%HOME%\NuGetRepository" />
        </config>
    </configuration>

NuGet evaluates `%HOME%` when it attempts to access the `repositoryPath` key. 

    > nuget config repositoryPath
    C:\users\username\NuGetRepository

If your NuGet.config references an environment variable that is not set, it will left as is in the configuration value. 
