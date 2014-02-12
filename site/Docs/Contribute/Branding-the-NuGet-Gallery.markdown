#Branding the NuGet Gallery
This doc covers the general instructions for re-branding the NuGet Gallery (based on API v2) so that a separate gallery with new branding (and content, style, etc.) can be quickly and easily set up.  Additionally, it will be possible to continue taking pulls from the main git repository as the files will not conflict with the existing gallery.

##What You Need to Do

At a high level re-branding the gallery is as simple as these three steps.

1. Clone the gallery
2. Modify the web.config
3. Add any new files/content to the Branding folder

###Clone the Gallery

Follow the instructions on setting up a local version of the NuGet Gallery [here](https://github.com/NuGet/NuGetGallery/blob/master/README.markdown), with the following changes:

1. First fork the gallery from the main fork to your own version.  This can be accomplished be clicking the fork button at the top of the github page for the NuGet Gallery Repository.
2. When you clone down, you will use the url of your own fork of the gallery, not the main NuGetGallery fork.
3. After cloning add a reference to the main NuGetGallery repository by typing `git add remote nuget https://gitub.com/NuGet/NuGetGallery.git` in your GitBash/Powershell terminal.

###Modify the web.config

In addition to any modifications made as part of the process to get your gallery running locally in the instructions above, find the `Gallery.Brand` and the `Gallery.GalleryOwner` references and modify them with the new values for your re-branded Gallery.

	<add key="Gallery.Brand" value="Rebranded Gallery" />
    <add key="Gallery.GalleryOwner" value="Rebranded NuGet Gallery &lt;your_email@youremailhoster.com&gt;" />

###New Files and Styles

For adding any new Views to the re-branded Gallery use the following instructions:

1. Copy the directory structure under the `Views` folder of the view you are overwriting exactly under the `Branding` folder.

		/Views/Packages/UploadPackage.cshtml
		maps to
		/Branding/Packages/UploadPackage.cshtml

2. Create the new Razor file there.
3. Build and Run the Project.
4. Navigate to the page you are overwriting and verify that the page has the content from the `Branding` folder.

For adding any new Content files to the re-branded Gallery use the following instructions:

1. In the `Branding` folder create a `Content` folder.
2. Add the Content file of your choice (Styles, Layout, PageStylings)
3. Note that these files will be appended to the matched Content file, with normal css rules being used (later overwrites of the same rule will win).
4. This means that it is possible that pulling down the latest gallery version from git can change your styling as more specific rules can be added in the pull request.

Note: there is a current [bug](https://github.com/NuGet/NuGetGallery/issues/1888) related to content re-branding getting served.  Workaround steps are provided there

##Pulling the Latest NuGet Gallery into the Re-Branded Gallery

The goal of re-branding the gallery in the steps outlined above is that you can continue to pull updated versions of the gallery code without worrying about your views and content being overwritten.  Additionally, you can use the existing git infrastructure of the gallery to do your own source control within your team.  When you are ready to pull the latest changes from the main fork of the gallery just do a `git pull nuget master` and you will get the latest gallery bits.  

**Note**: the web.config can cause a merge conflict (if it has been modified in master), and when resolving the merge conflict you should make sure to preserve any updates you have made, while being aware of any new settings added in master.

##Examples of Re-Branding the Gallery

This section has in depth walkthroughs and examples of the different processes involved in re-branding the gallery detailed above.

###Modifying the web.config

Open the web.config file of the NuGetGallery project.  Then search for the Brand and GalleryOwner attributes in the file.

![screenshot of the web.config file (with line numbers) with the Brand and GalleryOwner attributes highlighted](./images/webconfig1.jpg)

Modify these two attributes to the new values for your re-branded Gallery.

![screenshot of the web.config file with the Brand and GalleryOwner modified from above](./images/webconfig2.jpg)

###Creating/Overriding a New View

In this example, the Upload Package page will be re-branded to contain unique language for the re-branded site.

First note the folder structure of the original Upload Package page.

![picture of the folder structure under views of Packages/uploadPackage](./images/uploadPackage1.jpg)

Also notice that on F5, if you navigate to `http://nuget.localtest.me/packages/upload` you see the content from the uploadPackage page.

![screenshot of http://nuget.localtest.me/packages/upload](./images/uploadPackage2.jpg)

Create a matching folder structure (including the Views folder, under branding)

![picture showing the new folders (Views and Packages) created under the Branding folder](./images/uploadPackage3.jpg)

Create a new .cshtml file named `uploadPackage.cshtml` under the new `Branding/Views/Packages` Area path.  Then modify the file to the new desired values.

![screenshot showing both the editor and the solution explorer with the new Branding/Views/Packages/uploadPackage.cshtml page](./images/uploadPackage4.jpg)

When we now refresh the `http://nuget.localtest.me/packages/upload` page in the browser, the new content from the `Branding/Views/Packages/uploadPackage.cshtml` is displayed.

![screenshot of the browser displaying the new http://nuget.localtest.me/packages/upload page, with the re-branding override](./images/uploadPackage5.jpg)

That's all.

###Adding Custom CSS

Identify which content file the styling you are overriding comes from (Layout, Site, or PageStylings). Create a new css file with the same name in the `Branding/Content` folder.  In this example some styling from the Layout page is being overridden, so that file is created.

![Screenshot of a new Layout.css file in the Branding/Content folder](./images/customcontent1.jpg)

Now add your css rule as normal (either for overriding or for creating new styling rules).  In this example, the footer background color is modified from a peaceful teal to a blinding yellow.

![Screenshot of the new rule on the left and the nuget homepage with the new footer styling on the right](./images/customcontent2.jpg)

##Tips for how to Re-Brand

###Using BrowserLink with WebEssentials to identify the origin file of content to change

Using BrowserLink (with WebEssentials) it's easy to identify which files you need to override in the Branding folder.

Pre-reqs:

- Visual Studio 2013 Pro, Premium or Ultimate
- [WebEssentials](http://visualstudiogallery.msdn.microsoft.com/56633663-6799-41d7-9df7-0f2a504ca361)

Go into Visual Studio, and run the NuGetGallery (F5).  In the browser navigate to the page you want to alter.  In this example we will use the Upload Package page. Notice at the bottom left of the browser window there is a semi-transparent overlay.

![Screenshot of the browser on the nuget.localtest.me/packages/upload page](./images/browserlink1.jpg)

Either click the inspect element or use the keyboard shortcut (`Ctrl+Alt+I`).  Make sure that you can see both Visual Studio and the browser.  Now hover over the page to see which file generated which parts of the page.

![Screenshot of hovering over an element in the browser in inspectmode (1), with the VS also visible and having that element in the IDE highlighted(2)](./images/browserlink2.jpg)

You now know which file you need to create a override of in the Branding folder.