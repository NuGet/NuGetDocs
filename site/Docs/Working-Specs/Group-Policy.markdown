# Group Policy #

## Overview ##
Enable NuGet to be centrally controlled by an administrator using group policy.

## Problem ##
As we have talked to more customers using NuGet within a large enterprise, the issue has come up repeatedly that it is too easy for developers to install non-sanctioned packages in their projects. This can introduce the enterprise to a range of potential problems from licensing issues to security concerns. Moreover, the public NuGet gallery is enabled for NuGet by default and there is no way for an administrator to disable it for all developer environments.

Additionally, we have observed on a few occasions where an enterprise developer has accidentally pushed what was intended to be an internal NuGet package to the public NuGet gallery. This is a very easy mistake for a developer to make, since – after registering her API key – could be made by simply running the command nuget push <package>

##Solution##

We want to enable core NuGet configuration, including control over available package sources, to be centrally managed using technologies like Windows group policy. This will enable administrators within an enterprise to implement policy around approved packages for development projects. By giving administrators the ability to centrally disable the public NuGet gallery, it can also mitigate the risk of an enterprise developer accidentally publishing an internal package to the public gallery.

##Goals##
1.	Enable administrators to centrally control package sources
2.	All the NuGet Clients must honor the administrator policies in a user friendly way

##Non-Goals##
1. Provide custom authorization features, such as role-based security
2. Block all possible ways to connect to nuget.org such as using a Web Browser
3. Support all platforms including non-windows platforms
4. Enabling Group Policy for old clients of NuGet

##Customer asks##


- “A group policy rule to help prevent access to nuget.org”
- “The ability to disable NuGet.org might be useful, yes”
- “I’d hate to see someone accidentally pushing internal packages to nuget.org”
- “having the ability to create groups – one for vendors and one for internal developers would be huge.  I’d like to be able to create libraries and publish like I have been, but not expose all of the packages to the vendors”
- “ability to set permission levels to publish new packages or deleting packages as opposed to the apiKey which allows both if supplied”
- “The ability to lock down who can publish packages would be good. This could manifest as the intersection of AD account & package ID”

##Problems and Solutions##

Administrators can use the Windows Group Policy to set the aforementioned collection of settings or policies

1.	There are 2 aspects to using an AD account for this purpose
	2.	Enforcing a group policy
		3.	This needs to come from the Group Administrator
		2.	Whatever it is, a file like NuGet.Config, a Windows registry to restrict access to nuget.org; Group Admin needs to put it on the user’s machine
	2.	Honoring the group policy
		1.	This will be taken care of by the NuGet Client(s) like VS Client, NuGet.exe and the WebMatrix client
2.	Using a file to maintain the collection of settings (PREFERRED)
	1.	GOOD: Having a human readable file format is generally easy to author. Note that this needs to come from the administrator. It is also easy to support and parse if a standard format such as XML is used
	2.	BAD: Need to use a folder that only has read permissions for the user. NuGet Client only needs to read the global settings file. Ensuring that the file is the same as what the administrator put in place is always hard is out of the scope of this feature
	3.	Group Policy can be used to set the permissions on files and folders on the machines of a user in a domain
		1.	http://technet.microsoft.com/en-us/library/cc782533(WS.10).aspx
		2.	http://www.techrepublic.com/blog/datacenter/use-group-policy-to-have-a-local-file-resource/2837
3.	Using Windows Registry to maintain the collection of settings
	1.	GOOD: Using the windows registry can help maintain machine wide setting with desired read/write permissions
	2.	BAD: Though it is a non-goal to extend to non-windows platforms, using Windows Registry will prevent us from supporting non-windows platforms
	3.	BAD: We already use XML files in NuGet.Config and it has worked well so far. Using Windows Registry for settings similar to what is supported in NuGet.Config is not a good idea

So, a file will be used to maintain the collection of settings or policies to be honored by all the NuGet Clients. This will be the NuGet Global Policy File. NuGet Global Policy File overrides all the other settings at all times
NuGet Global Policy File

##NuGet Global Policy File##

NuGet Global Policy File, to begin with, will capture the default or mandatory package source(s) that the company likes to set on the developer machines. These mandatory package sources cannot be deleted, modified but may be disabled
Today, if someone deletes the NuGet Official Package Feed from %appdata%, it is rehydrated as disabled if another package source exists or as enabled if no package source exists. In the same way, now, there will be a set of defaults or mandatory packages instead of the just 1 feed. Now, the NuGet Official Feed may very well be part of the default mandatory package sources list

###Sample###

	<?xml version="1.0" encoding="UTF-8"?>
	<configuration>
	<!-- Mandatory Package Sources -->
	<!-- They cannot be deleted or modified but can be disabled/enabled by user -->
	<MandatoryPackageSources>
		<add key="Contoso Package Source" value="http://contoso.com/packages/" />
	</MandatoryPackageSources>

	<!-- Mandatory Package Sources that are Disabled by Default -->
	<!-- They cannot be modified or deleted either but can be enabled/disabled by user -->
	<DisabledByDefaultMandatoryPackageSources>
		<add key="NuGet Official Feed" value="http://nuget.org/api/v2/" />
	</DisabledByDefaultMandatoryPackageSources>
	</configuration>


##Open Issues and Scenarios##

Following are the list of issues and scenarios that are not planned for 2.7. Based on customer feedback, we might include it in 2.7 or might do add this in the future

1. Supporting ‘Disabling of Package Sources’ via AllowedUriSchemes
1. Supporting an Allowed List of package sources
1. Supporting Publishable package sources

##Discussion
For comments, suggestions, or any other feedback on this working spec, please use the corresponding CodePlex discussion page here:
https://nuget.codeplex.com/discussions/445625
