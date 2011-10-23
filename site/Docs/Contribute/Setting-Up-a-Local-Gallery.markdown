# Setting Up a Local NuGet Gallery

**Note: the instructions below are for the older gallery. The newer one is available from [here](https://github.com/NuGet/NuGetGallery)**

You might want to set up a local NuGet Gallery (like the one hosted at [nuget.org](http://nuget.org)) either to host your own custon packages or just for testing. The following steps will walk you through the process of setting it up.

## Assumptions
1. You know how to use Mercurial
1. You know how to set up websites in IIS
1. You know how to manage SQL Server databases
1. You have some experience managing an Orchard website

## Get the Source Code
1. Clone the NuGet Gallery super-repo: [https://hg01.codeplex.com/nugetgallery](https://hg01.codeplex.com/nugetgallery); for the rest of this document, {clone-dir} will refer to the directory into which you cloned
   * **NOTE**: You should consider doing this at your root directory (e.g., C:\\) so you don't have to fight with IIS about permissions)

## Configure IIS and Permissions
1. Create a new IIS website for the NuGet Gallery services, pointing to {clone-dir}\Services\GalleryServer\src\Gallery.Server; for the rest of this document, {services-url} will refer to this site's URL
1. Create a new IIS website for the NuGet Gallery website, pointing to {clone-dir}\Website\src\Orchard.Web; for the rest of this document, {website-url} will refer to this site's URL
1. Ensure that the application pool for each of these IIS websites is running .NET 4.0 in Integrated Mode
1. Create an App_Data directory at {clone-dir}\Services\GalleryServer\src\Gallery.Server
1. Grant write permission to the App_Data directory created above for the NuGet Gallery services' app pool's identity
1. Create an App_Data directory at {clone-dir}\Website\src\Orchard.Web
1. Grant write permission to the App_Data directory created above for the NuGet Gallery website's app pool's identity
1. Grant write permission to {clone-dir}\Website\src\Orchard.Web\Media  for the NuGet Gallery website's app pool's identity

## Create SQL Databases and Logins
1. Create a database for the NuGet Gallery services; for the rest of this document, this database's name will be referred to as {services-db}
1. Create a SQL Server login for the NuGet Gallery services' app pool's identity, and grant it dbowner permission to {services-db}
1. Create a database for the NuGet Gallery website; for the rest of this document, this database's name will be referred to as {website-db}
1. Create a SQL Server login for the NuGet Gallery website's app pool's identity, and grant it dbowner permission to {website-db}

## Configure and build the NuGet Gallery Services
1. Edit {clone-dir}\Services\GalleryServer\src\Gallery.Server\Config\AppSettings.config.default, setting the following app settings:
   * FrontEndWebSiteRoot = {website-url} (*NOTE* ensure there is a trailing slash)
   * MigratorProvider = SqlServer
1. Edit ConnectionStrings.config.default under {clone-dir}\Services\GalleryServer\src\Gallery.Server\Config to 
   * Data Source=(local);Initial Catalog={services-db};
1. In a console, change to the {clone-dir}\Services directory, then run ClickToBuildRelease.bat
   * **NOTE**: MSBuild.exe must be in %PATH%
1. Test by navigating to {services-url}/FeedService.svc/Packages
   * **NOTE**: The first time you request the NuGet Gallery Services feed, the database will be populated, which might take some time

## Build and Configure the NuGet Gallery Website
1. In a console, change to the {clone-dir}\Website directory, then run ClickToBuild.cmd
   * **NOTE**: MSBuild.exe must be in %PATH%
1. Navigate to {website-url}
1. You should now see the Orchard setup page
   * Specify an admin username and password
   * Select SQL Server for the database option, and a connection string to {website-db}
   * Click "Finish Setup"
1. After the setup page, you will be redirected to the main Orchard page; click the Dashboard link at the bottom of the page
1. Open the Users page and then edit the admin user created above to provide an email address
1. Open the Modules page and then enable the Orchard.Gallery module on the Features tab
1. Open the Themes page and then set the NuGetGallery theme to current
1. From within the settings menu:
   * On the General page, configure Gallery Server by entering {services-url} as the Gallery Server Service Root, and {services-url}/FeedService.svc as the Gallery Feed URL
   * On the General page, configure Package Expiration
   * On the Email page, configure SMTP Settings
   * On the Users page, configure User Registration
