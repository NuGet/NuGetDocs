# NuGet Configuration File

NuGet's configuration file allows for persisting configuration settings and changing default configuration values.

## Default Location

The default location for NuGet's configuration file is %APPDATA%\NuGet\NuGet.Config (DOS) or $ENV:APPDATA\NuGet\NuGet.Config (PowerShell).
APPDATA's value is OS, system drive, and current user dependent. For example: D:\Users\username\AppData\Roaming\NuGet\NuGet.config.

The default configuration file can be changed through -ConfigFile option. For example, 
"-ConfigFile c:\my.config" means using file c:\my.config instead of %APPDATA%\NuGet\NuGet.Config as the default configuraion file.

## Config file reference

XML is used to store the configuration, and any text editor can be used to author it.
Note: NuGet will silently ignore the entire configuration file is it encounters any XML parsing issues (such as mismatched begin/end nodes, invalid quotation, etc.); therefore an editor that reports parsing issues is recommended.

Below an example of NuGet configuration file that specifies some of the available settings and is annotated with comments.  For the full list of configuration settings, see the [NuGet Configuration Settings page](nuget-config-settings).

    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <config>
	    <!-- 
		Used to specify the default location to expand packages.
		See: NuGet.exe help install
		See: NuGet.exe help update
		If value starts with "$\" then location is relative to this conf file.
		-->
        <add key="repositorypath" value="$\External\Packages" />
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
	  <!-- If specified, package restore is enabled -->
	  <packageRestore>
        <add key="enabled" value="True" />
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
        <add key="repositorypath" value="F:\tmp" />
      </config>
      <packageRestore>
        <add key="enabled" value="True" />
      </packageRestore>
    </configuration>

3) F:\Project1\NuGet.config with content:

    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <config>
        <add key="repositorypath" value="$\External\Packages" />
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
* **When invoked from F:\Project1 or F:\Project1\Source**: 1, 2 and 3. The last config file that gets loaded overrides `repositorypath` therefore packages get expanded in F:\Project1\External\Packages instead of F:\tmp. It also clears `<packageSources>` therefore nuget.org is no longer available as a source; instead only http://MyPrivateRepo/ES/nuget is available.
* **When invoked from F:\Project2 or F:\Project2\Source**: 1, 2 and 4. This time `packageSources` is not cleared, therefore both nuget.org and http://MyPrivateRepo/DQ/nuget are available as source repositories. Packages get expanded in F:\tmp
