# Hosting Your Own NuGet Feeds

Some companies restrict which third-party libraries their developers may use.
Therefore, they might not want developers to have access to everything in the official
NuGet feed, or they might have a set of proprietary libraries they want to make available
in addition to the official feed.

In these scenarios, you can set up a custom NuGet feed, and you can configure
Visual Studio to offer that feed instead of or in addition to the official feed.
A feed can be local (a folder on the local machine or a network folder) or remote
(an internet URL).

## Creating Local Feeds

Begin by creating or getting the packages you want to include in the custom feed
and then putting them all into a folder. In the following example, a folder has
been created in the local *c:* drive.
The folder contains a single package (.nupkg file).

![LocalNuGetFeed-folder.png](images/LocalNuGetFeed-folder.png)

Next, specify that folder as the location of a NuGet feed. In Visual Studio,
from the **Tools** menu select **Library Package Manager** and then click
**Package Manager Settings**.

![Package Manager Settings in menu](images/Package-Manager-Settings-in-menu.png)

The **Options** dialog box is displayed.

![Options dialog box](images/Options-dialog-box.png)

In the **Name** box, enter a name for your feed.
In the **Source** box enter the path of your packages folder.

![Available Package Sources dialog box without new feed](images/Available-Package-Sources-without-new-feed.png)

Click **Add**. Your local folder is now another NuGet feed source.

![Available Package Sources dialog box with new feed](images/Available-Package-Sources-with-new-feed.png)

To install a package using the new feed, in the **Package Manager Console** window,
select the new feed in the **Package source** list.

![Selecting local feed in Package Manager Console](images/Selecting-local-feed-in-Package-Manager-Console.png)

You can also select the new feed in the **Online** tab of the
**Manage NuGet Packages** dialog box.

![Selecting local feed in the Manage NuGet Packages dialog](images/Selecting-local-feed-in-Add-Library-Package-Reference.png)

## Creating Remote Feeds

You can also host a remote (or internal) feed on a server that runs IIS.

<p class="caution">Make sure you're running NuGet 1.4 or higher!</p>

### Step 1: Create a new Empty Web Application in Visual Studio

Go to the **File** | **New** | **Project** menu option (or just hit CTRL + SHIFT + N)
which will bring up the new project dialog and
select **ASP.NET Empty Web Application** as in the following screenshot.

![New Project dialog box](images/New-Project-dialog-box.png)

This results in a very empty project template.

![New project in Solution Explorer](images/New-project-in-Solution-Explorer.png)

### Step 2: Install the NuGet.Server Package

Now right click on the **References** node and select **Manage NuGet Packages** to launch
the NuGet dialog (alternatively, you can use the Package Manager Console instead and
type `Install-Package NuGet.Server`).

Click the **Online** tab and then type **NuGet.Server** in the top right search box.
Click **Install** on the **NuGet.Server** package as shown in the following image.

![NuGet.Server package](images/NuGet.Server-package.png)

### Step 3: Configure the Packages folder

Starting with `NuGet.Server` 1.5, you can configure the folder which contains your packages. The web.config file contains a new `appSetting`, named `packagesPath`. When the key is omitted or left blank, the packages folder is the default ~/Packages. You can specify an **absolute path**, or a **virtual path**.

    <appSettings>
        <!-- Set the value here to specify your custom packages folder. -->
        <add key="packagesPath" value="C:\MyPackages" />
    </appSettings>


### Step 4: Add Packages to the Packages folder

That's it! The **NuGet.Server** package just converted your empty website into a site
that's ready to serve up the OData package feed.
Just add packages into the Packages folder and they'll show up.

In the following screenshot, you can see that I've manually added a few packages to the default **Packages**
folder.  

![Adding packages to the packages folder](images/Adding-packages-to-the-packages-folder.png)

<p class="info">If you want these packages to be published (such as when selecting Build -> Publish from
the application menu) you'll also need to select the .nupkg files in Solution Explorer
and change the Build Action property to "Content".</p>

Starting with `NuGet.Server` 1.4, you can also add and delete packages to the lightweight feed using 
NuGet.exe. After installing the package, the web.config file will contain a new `appSetting`, named 
`apiKey`. When the key is omitted or left blank, pushing packages to the feed is disabled. Setting the 
apiKey to a value (ideally a strong password) enables pushing packages using NuGet.exe.

    <appSettings>
        <!-- Set the value here to allow people to push/delete packages from the server.
             NOTE: This is a shared key (password) for all users. -->
        <add key="apiKey" value="" />
    </appSettings>


### Step 5: Deploy and run your brand new Package Feed!

I can hit CTRL + F5 to run the site and it'll provide some instructions on what to do next.

![Package feed home page](images/Package-feed-home-page.png)

Clicking on "here" shows the OData over ATOM feed of packages.

![OData over ATOM package feed](images/OData-over-ATOM-package-feed.png)

Now all I need to do is deploy this website as I would any other site and then
I can click the Settings button and add this feed to my set of package sources
as in the following screenshot.



![Adding new feed to package sources](images/Adding-new-feed-to-package-sources.png)

Note that the URL you need to put in is <a href="http://yourdomain/nuget/">http://yourdomain/nuget/</a> depending on how you deploy the site.

Yes, it's that easy! Note that this feed is "read-only" in the sense that it doesn't support 
publishing to it via the NuGet.exe command line tool. Instead, you need to add packages 
to the **Packages** folder and they are automatically syndicated.