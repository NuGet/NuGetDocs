# NuGet Gallery Test Plan

## Browser Types/ Versions
Latest and Latest - 1 versions of these browsers are used for NuGet Gallery Testing

*    Internet Explorer
*    Chrome
*    Firefox

## Pivots
*    Functional
*    Performance
*    Stress
*    UX
*    Accessibility
*    End-to-end 
*    Client Compatibility
*    Security
*    Availability

## Client

*    Latest Released Client
*    In-Development Client

## Account Management

*    Register a new user
*    Proper error message if an existing user ID is specified during registration
*    Login as an existing user
*    Lost password management
*    Upload package requires login
*    Lands on current page after login
*    Resend confirmation email
*    Logout
 

## Administration

*    Clicking on user name at top right should take you to  https://www.nuget.org/account
*    Logged in  user should be able to upload package via gallery
*    Logged in user should be able to "Download" the packages that he owns from the package home page
*    "Manage my packages" should list the details of listed and unlisted packages
*    Administration page should show the user API key and user should be able to generate a new key
*    Administration page should let the user to update his profile info at any point of time
	* Email address.
	* Receive Email notification option
	* Password
*   User should be able to Unlist and relist his package at any point of time
*   Admin page should let user to "Add owners" to a package
*   Package Management
	*   Editing Package Details
	*   Unlising Packages

## Search

*    Search using field identifiers like author , tags, ID, title and description fields is intuitive for end user and returns expected results
*    Search for exact match by enclosing search terms within quotes
*    Check that a newly added package gets indexed and returned as part of search results
*    Check for case insensitivity of the keywords and the column identifiers
*    Search for ID and partial ID returns expected results
*    When no field identifier is specified, the keyword it is matched with ID first and then other fields
*    Multi-string search term  with/ without quotes
*    Search for the value of fields other than - Id, Title, Author, Description, and Tags
*    Clicking on a tag/author would open search page  with word as the search term
*    Localized strings like "Author:"Jörn Zaefferer"
*    Multiple field query search 
*    Add leading and trailing space in the keywords  and make sure it works
*    Search using title
*    Search with "." and "-"
	
## Package Upload

*    User is able to use feed sources while behind proxy/authentication
*    User is able to use nuget.exe with authentication
*    User is able to use nuget features behind a proxy requiring authentication
*    Proxies requiring authentication
*    Repositories requiring authentication

## Package Download
*    Using VS, Browser and NuGet commandline
	*    Official source
	*    Private hosted galleries
	*    Source requiring authentication
	*    Local
	*    UNC
	*    Install/ UnInstall/ Update/Restore with different feed sources
	*    Enable/ Disable different Sources
	*    Machine-wide source
	*    Curated Feeds
	*    Add/ Remove/ Edit feed sources
	    *    NuGet.Config
	    *    Visual Studio ‘Package Manager Settings’ dialog


## Package Restore
* Using VS and NuGet.exe, try package restore
	* From official source
	* From privately hosted galleries
	* Sources requiring authentication
	* Local 
	* UNC

## UI
*    Rendering of UI elements
*    Accessibility
*    UX
*    Intuitiveness of UI workflows

## Curated Feeds
* Nuget gallery curated feed and package inclusion/exclusion
	* Create the curated feed via nuget.org\dbadmin
		* Automatic package inclusion based on rules
		* Manual inclusing of packages to a feed
		* Remove packages from curated feeds, verify they no longer show in the Included Packages list
			* Remove one or multiple
			* Remove all
	* Exclude automatically-curated packages, verify they show up in the Excluded Packages list
		* Exclude one or multiple
		* Exclude all

	### Use of Nuget VS UI, package management console and Nuget.exe with curated feeds
	* Addition of the curated feed service URL to package settings as a feed
	* Verify if feed is displayed and can be selected from Package source (Console and UI)
	* Multiple curated feed in the setting
		* List of available packages for the curated feed
		* Verify that the list match what’s been curated in the “Included Package” list, minus the ones that are unlisted (Console and UI, Get-Package –ListAvailable)
		* Try Install-Package, Uninstall-Package, Update-Package (Console and UI equivalent), and add-bindingredirect, new-package 
		* Try Nuget.exe install

## E2E Scenarios
* Account Registration, Package Upload, Package Management, Search and Download
* Package Upload, Download and Statistics
* Account Registration, Password Management and Login

## Load
* Use the peak loads to stress the download, restore and upload scenarios

## Availability
* [Monitoring NuGet](http://blog.nuget.org/20140626/monitoring-nuget.html)

## Client Compatibility
* For every gallery deployment, client tests are run to make sure client scenarios work as expected
	* Install
	* Uninstall
	* Update
	* Restore
	* Search

## Support Request

* Report Abuse
* Contact Owners
	

