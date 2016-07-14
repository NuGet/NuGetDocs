#Quickstart - Consume a NuGet package

Installing a NuGet package is fairly straightforward. This tutorial walks you through installing a popular Json framework ([Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)) for a Universal Windows Platform (UWP) project. 

<div class="block-callout-info">
	<strong>Note:</strong><br>
	You need Visual Studio 2015 Update 3 with Windows developer tools installed to follow this tutoial. If you don't have Visual Studio already, you can download <a href="https://developer.microsoft.com/en-us/windows/downloads">Visual Studio Community 2015</a> for free. 
</div>

##Create a new UWP project
In Visual Studio, choose **File**, **New**, **Project**. In the **New Project** dialog, expand the **Visual C#** node, then expand the **Windows** node and choose the **Universal** node, and then choose **Blank App (Universal Windows)**.

![Create new Project](/images/ConsumeNugetSample/01.PNG)


Accept the default values for Target and Minimum versions and click ok.

![Target and Minimum versions](/images/ConsumeNugetSample/02.PNG)


##Add a NuGet package
In Solution Explorer, open the context menu for the **References** node and choose **Manage NuGet Packages**.

![References context](/images/ConsumeNugetSample/03.PNG)


Choose "nuget.org" as the **Package source**, and choose the **Browse** tab. Check the **Include prerelease** checkbox, and then browse for **Newtonsoft.Json**. Click **Install**. 

![Browse nuget packages](/images/ConsumeNugetSample/04.PNG)


Review changes and click ok

![Browse nuget packages](/images/ConsumeNugetSample/05.PNG)



##Build the solution
On the **Build** menu, choose **Build Solution**. Building the solution also restores packages.



##Reference the package
Now that we have added the Newtonsoft.json nuget Package, we will use JsonConvert.SerializeObject to convert an object to JSON string and display it.


From Solution Explorer, open MainPage.xaml and copy the following lines of code

	<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
		<StackPanel VerticalAlignment="Center">
			<Button Click="Button_Click" Content="Click Me" />
			<TextBlock Name="TextBlock" Text="TextBlock" />
		</StackPanel>
	</Grid>


Expand MainPage.xaml, open MainPage.xaml.cs and copy the following line of code

	public class Account
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Account account = new Account
        {
            Name = "John Doe",
            Email = "john@microsoft.com",
            DOB = new DateTime(1980, 2, 20, 0, 0, 0, DateTimeKind.Utc),
        };
        string json = JsonConvert.SerializeObject(account, Formatting.Indented);
        TextBlock.Text = json;
    }
 
   
You will see a squiggle for **JsonConvert**. Although we added the Newtonsoft.json nuget package, we need to add a using statement to this doc. Click the Lightbulb and then click show potential fixes.

![Lightbulb fix](/images/ConsumeNugetSample/06.PNG)


Select the first suggested fix i.e. <b>using Newtonsoft.Json;</b>

![Lightbulb fix](/images/ConsumeNugetSample/07.PNG)



##Run the app
Hit debug local machine. The app opens up.

![Output](/images/ConsumeNugetSample/08.PNG)


Click on the button and the contents of the TextBlock are replaced with the json string.

![Output](/images/ConsumeNugetSample/09.PNG)


That's it!
You can repeat these steps to install any NuGet package for any project type.



