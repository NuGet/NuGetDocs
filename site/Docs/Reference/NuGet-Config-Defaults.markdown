# NuGet Configuration Defaults

## Overview

Many companies are using NuGet internally, but have had a hard time guiding their developers to use internal package sources instead of nuget.org. NuGet 2.7 introduces a Configuration Defaults feature that allows machine-wide defaults to be specified for:

1. Enabled package sources
1. Registered, but disabled package sources
1. The default nuget.exe push source

Each of these can now be configured within a file located at %ProgramData%\NuGet\NuGetDefaults.config. If this config file specifies package sources, then the default nuget.org package source will not be registered automatically, and the ones in NuGetDefaults.config will be registered instead.

While not required to use this feature, we expect companies to deploy NuGetDefaults.config files using Group Policy.

*Note that this feature will never cause a package source to be removed from a developer's NuGet settings. That means if the developer has already used NuGet and therefore has the nuget.org package source registered, it won't be removed after the creation of a NuGetDefaults.config file.*

## NuGet Config Defaults File

NuGet Config Defaults file, NuGetDefaults.config, is located under %ProgramData%\NuGet folder, which is machine-wide and requires Administrator permissions. Administrators are expected to set the correct permissions on this file based on the user and/or machine information.

### Default Package Sources

NuGet Config Defaults File will capture the default package source(s) that the should be used by all users on the machine. These default package sources cannot be deleted or modified but may be disabled. When the NuGet Config Defaults file is absent, if someone deletes the nuget.org package source from %AppData%, it is rehydrated as disabled if another package source exists or as enabled if no package source exists. In the same way, with a NuGet Config Defaults file present, there will be a set of default package sources instead of just the 1 feed. Note that we still fallback to default nuget.org package source if there are no default package sources. However, if there are any default package sources specified in the NuGet Config Defaults file and the nuget.org package source is *not* one of them, it *will not be rehydrated*.

This approach essentially allows administrators to replace the default nuget.org package source with their own package sources.

### Default Push Source

The NuGet Config Defaults file also allows specification of the Default Push Source. This will be the defaultPushSource if one is NOT provided in the command line argument of NuGet.exe. Note that today, by default, Push Source is the nuget.org package source. Using the new configuration though, administrators can change the Push Source used by default. This will help prevent accidental publishing of packages to nuget.org. Unless the user explicitly uses the source parameter for publishing, the Default Push Source set by administrator will get used.

NuGetDefaults.config will support the following cases

1. Configure a DefaultPushSource that will get used over the NuGet Official Feed when using the commandline tool
2. Configure the default package sources that the enterprise wants their developers to be using.
   Some of these default package sources may be disabled by default too

###Sample###

	<?xml version="1.0" encoding="UTF-8"?>
	<configuration>
		<!-- DefaultPushSource key is similar to the 'DefaultPushSource' key of NuGet.config schema-->
		<!-- This can be used by administrators to prevent accidental publishing of packages to 
		     NuGet Official Feed which is a public feed -->
		<config>
			<add key="DefaultPushSource" value="http://contoso.com/packages/" />
		</config>
	
		<!-- Default Package Sources -->
		<!-- They cannot be deleted or modified but can be disabled/enabled by user -->
		<!-- The following section is similar to 'packageSources' section of NuGet.config schema -->
		<packageSources>
			<add key="Contoso Package Source" value="http://contoso.com/packages/" />
			<add key="nuget.org" value="https://www.nuget.org/api/v2/" />
		</packageSources>

		<!-- Default Package Sources that are Disabled by Default -->
		<!-- They cannot be modified or deleted either but can be enabled/disabled by user -->
		<!-- The following section is similar to 'disabledPackageSources' section of NuGet.config schema-->
		<disabledPackageSources>
			<add key="nuget.org" value="true" />
		</disabledPackageSources>
	</configuration>


##Open Issues and Scenarios##

Following are the list of issues and scenarios that are not planned for 2.7. Based on customer feedback, we might add this in the future

1. Supporting ‘Disabling of Package Sources’ via AllowedUriSchemes
1. Supporting an Allowed List of package sources
1. Supporting Publishable package sources
