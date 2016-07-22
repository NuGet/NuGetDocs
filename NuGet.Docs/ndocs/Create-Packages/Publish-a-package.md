#Publish a Package

Before you publish your package, you must decide whether you want your package to be public or private.

* If it's for public consumption, use [NuGet.org](https://www.nuget.org/packages/upload).
* If it's within an organization or a team, use one of the following methods:
    * NuGet.Server or file shares (for more information, see Hosting your own NuGet Feeds)
	* Visual Studio Team Services Package Management
	* Other third-party package repository managers, such as myget, ProGet, Nexus Repository, Artifactory, etc.

##Create an account
To publish to [NuGet.org](https://www.nuget.org/packages/upload) you must have an account.

Go to [nuget.org](http://nuget.org/) and register for an account. Then, log in to your NuGet.org account.

![NuGet SignIn](/images/Create/publish_NuGetSignIn.PNG)

##Publish through NuGet.Org
Use the Upload Package UI to upload your package to the NuGet Gallery

![Upload your package](/images/Create/publish_UploadYourPackage.PNG)

##Publish to NuGet.org by using the NuGet CLI

###Get your API Key

Go [nuget.org](http://nuget.org/) and register for an account. Then, click "My Account" to see an API Key that was generated for you.

![Get your API Key](/images/Create/publish_NuGet-API-Key.PNG)

###Using the push command

In a command console, run the following command:

	nuget setApiKey Your-API-Key

This will store your API key so that you never need to do this step again on this machine.

Push your package to NuGet Gallery using the command:

	nuget push YourPackage.nupkp

**Recommended Reading:** [NuGet CLI reference](/ndocs/tools/nuget-cli-reference), [setApiKey](/ndocs/tools/nuget-cli-reference#setapikey), [Push](/ndocs/tools/nuget-cli-reference#push)