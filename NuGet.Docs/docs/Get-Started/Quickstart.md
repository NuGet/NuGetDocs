#Install a NuGet package

Installing a NuGet package is fairly straightforward. This tutorial walks you through installing a popular Json framework (Newtonsoft.Json) for a .NET core project. 

## Prerequisites

* [Visual Studio 2015 Update 3](https://www.visualstudio.com/news/releasenotes/vs2015-update3-vs). If you don't have Visual Studio already, you can download [Visual Studio Community 2015](https://www.visualstudio.com/downloads/download-visual-studio-vs) for free. 

* [NuGet Manager extension for Visual Studio](install-nuget#nuget-package-manager-extension-in-visual-studio). NuGet is the package manager for the Microsoft development platform including .NET Core. When you use NuGet to install a package, it copies the library files to your solution and automatically updates your project (add references, change config files, etc.).

* [.NET Core Tooling Preview 2 for Visual Studio 2015](https://go.microsoft.com/fwlink/?LinkId=817245). This installs templates and other tools for Visual Studio 2015, as well as .NET Core 1.0 itself.

##Consume NuGet within a .NET Core Solution

1. In Visual Studio, choose **File**, **New**, **Project**. In the **New Project** dialog, expand the **Visual C#** node and choose the **.NET Core** node, and then choose **Console Application (.NET Core)**. 
![Create new Project](/images/ConsumeNugetSample/01_New_Proj.JPG)

2. In Solution Explorer, open the context menu for the **References** node and choose **Manage NuGet Packages**.
![References context](/images/ConsumeNugetSample/02_Right_click_ref.JPG)

3. Choose "nuget.org" as the **Package source**, and choose the **Browse** tab. Check the **Include prerelease** checkbox, and then browse for **Newtonsoft.Json**. Click **Install**. 
![Browse nuget packages](/images/ConsumeNugetSample/03_newtonsoft.JPG)<br>
Review changes and click ok
![Browse nuget packages](/images/ConsumeNugetSample/04_click_ok.JPG)

4. Open the context menu for the **References** node and choose  **Restore packages**.

5. On the **Build** menu, choose **Build Solution**.

6. In Solution Explorer, open the context menu for the **NETCoreConsoleApp** node and choose **Add**, **Class**. 
![Add class](/images/ConsumeNugetSample/05_add_class.JPG)<br>
Name the class "Account".
![Add class](/images/ConsumeNugetSample/06_create_class.JPG)

7. Paste the following code to the Account class.

			public class Account
			{
				public string Email { get; set; }
				public bool Active { get; set; }
				public DateTime CreatedDate { get; set; }
				public IList<string> Roles { get; set; }
			}
   
8. Click on the tab for Program.cs and copy the following lines of code

			namespace NETCoreConsoleApp
			{
				public class Program
				{
					public static void Main(string[] args)
					{
						Account account = new Account
						{
							Email = "john@microsoft.com",
							Active = true,
							CreatedDate = new DateTime(2015, 2, 20, 0, 0, 0, DateTimeKind.Utc),
							Roles = new List<string>
							{
								"PowerUser",
								"Admin"
						   }
						};

						string json = JsonConvert.SerializeObject(account, Formatting.Indented);

						Console.WriteLine(json);
						Console.ReadLine();
					}
			   }
			}


9. You will see a squiggle for **JsonConvert**. Although we added the Newtonsoft nuget package but we need to add a reference to it as well. CLick the Lightbulb and click show potential fixes. Select the first suggested fix i.e. Using Newtonsoft.Json;
![Lightbulb fix](/images/ConsumeNugetSample/07_potential_fix.JPG) <br>
![Lightbulb fix](/images/ConsumeNugetSample/08_potential_fix.JPG)

10. Hit debug and you should see the following output
![Output](/images/ConsumeNugetSample/09_output.JPG)<br>
<br>

That's it!
You can repeat these steps to install any NuGet package for any project type.



