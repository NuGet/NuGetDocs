# Functional Testing

## For NuGet Visual Studio Extension

We have a functional test framework written in powershell that we use to verify the NuGet's behavior in Visual Studio.

After [setting up your environment and running the experimental instance of VS](/Setting-up-the-NuGet-Development-Environment.md ), you can run the tests by running the cmdlet *Run-Test*. You can run a specific test by specifying the name of the test as a 
parameter to *Run-Test* (we also show IntelliSense for test names).

### Writing Tests

All tests are located in *test\EndtoEnd\tests*. Tests are grouped by functionality (it's purely convention based) 
so all tests that test NuGet's install functionality resides in the install.ps1 file. 
Tests are regular powershell functions that start with the name "test":

	function Test-Foo {
		"Hello World"
	}

After writing the above test in any file under the test folder, you can run it in the console by typing 
*Run-Test Foo* (notice how we exclude the *Test-* prefix from the name of the test while running it). 
The test runner loads all scripts under the tests folder, imports all the functions with the Test- prefix into the 
environment for execution.

#### Test Context

Since this framework is mostly for testing NuGet within visual studio, each test is passed a context object that has 2 paths:

* *RepositoryRoot* - Path to the test package repository (*test\EndToEnd\Packages*).
* *RepositoryPath* - Path to the repository for this specific test (for example, for a test called *MyTest* the path is *test\EndToEnd\Packages\MyTest\Packages*).

### Package Creation Tool

To avoid checking in binaries into the source tree, the functional test framework allows two ways of generating packages on the fly.  Under **Tools\NuGet\GenerateTestPackages** there is a tool that takes one of the two forms of inputs
and creates binaries from it. Specific tests can specify these input files in their *RepositoryPath*

1) [DGML](http://blogs.msdn.com/b/camerons/archive/2009/01/26/directed-graph-markup-language-dgml.aspx)
DGML is a dsl for generated directed graphs. In our case, this specifies the dependency chain of packages and builds a set of packages from it with default set of package content.
This comes in handy when trying to test complex package graph behavior.

2) NuSpec files
If you need more fine grained control over what each package's content and metadata is, you can check in multiple nuspec files of the format *Id*.*Version*.nuspec. If the package specifies a files node,
the generator tool would look for it under *RepositoryPath*\files\*full path to file* path. If no file exists at this location, the generator would create an appropriate file and include that in the resulting package.

### Test API

Tests aren't useful unless you're actually testing interesting behavior. Just like anything else in the console, 
tests have full access to $dte, but we also have some useful helper functions that aid you when trying to interact with VS.

#### Assert-AreEqual

	Assert-AreEqual $Expected $Actual

#### Assert-True

	Assert-True $Value

#### Assert-False

	Assert-False $Value

#### Assert-Fail

	Assert-Fail "Failed :("

#### Assert-Throws

	# Assert that the exception message matches the expected exception message.
	Assert-Throws { throw "foo" } "foo"

#### Assert-PathExists

	Assert-PathExists "c:\foo"

### Assert-Reference

	$project = Get-Project MvcApplication1
	Assert-Reference $project System.Web

#### Assert-Build

	# Assert that there are no errors.
	$project = Get-Project SilverlightApplication
	Assert-Build $project

#### Assert-Package


	$project = Get-Project MyProject
	# Assert that this project has any version of package A.
	Assert-Package $project A

	# Assert that this project has package A 2.0.
	Assert-Package $project A 2.0

#### Assert-SolutionPackage

	# Assert that the solution has package A.
	Assert-SolutionPackage A

	# Assert that the solution has package A 1.0.
	Assert-SolutionPackage A 1.0

### VS Helper API

When building tests it's useful to create new projects in each test for better isolation 
(each test is run in a new solution). We have helpers for project creation and helpers that make common 
DTE operations easier.

We store project templates locally so we don't have 
to depend on the ones installed in VS. Project templates are stored in 
*test\EndToEnd\ProjectTemplates*.

#### New-Project

	# The project name is the name of a folder under the project templates folder (without the .zip)
	New-Project ClassLibrary

There are also a number of shortcuts so that we don't have to use New-Project to create projects:

	$project = New-ClassLibrary

The above will create a new class library and return the project instance.

You might have realized that New-Project doesn't take any parameters that 
have to do with where the project is physically created on disk, this is 
because we create a solutions and projects in *test\EndToEnd\bin*. 
This makes it easy to create new projects without having to think about 
where things need to go. The other benefit of putting then in the bin folder 
is that it means they are ignored in source control. 
**You can however pass a name if you like.**

Each project and solution end up with a random name, e.g. *Solution_06c6*.

You can also create Solution folders and create projects within solution folders:

#### New-SolutionFolder

	# Create a solution folder called foo
	$solutionFolder = New-SolutionFolder foo

	# Create a project within that folder
	$project = $solutionFolder | New-ClassLibrary

#### Build-Project

	# Build debug configuration
	Build-Project $project Debug

	# Build release configuration
	Build-Project $project Release

#### Remove-ProjectItem

	# Removes item from the project and disk
	Remove-ProjectItem $project Default.aspx

#### Get-ProjectItem

	# Gets the project item for jquery
	$projectItem = Get-ProjectItem $project Scripts/jquery.js

#### Get-ProjectItemPath

	# Get the physical path for web.config in the views folder
	$fullPath = Get-ProjectItemPath $project Views/web.config

#### Get-OutputPath

	# Get the output path of the project (based on current configuration)
	$outputPath = Get-OutputPath $project

#### Get-ProjectDir

	# Get the path to the project root
	$projectPath = Get-ProjectDir $project

#### Get-PropertyValue

	# Get-PropertyValue $project AssemblyName

#### Get-AssemblyReference

	# Get the assembly reference for System.Web
	$assemblyReference = Get-AssemblyReference $project System.Web

#### Get-Errors

	# Returns a list of errors in the current error list.
	
## For NuGet Gallery

The automated functional tests for NuGet Gallery live under %RepositoryRoot%\Gallery\test folder. Within that folder, there is a NuGetGallery.FunctionalTests.sln file, which can be opened in Visual Studio. The functional test solution consists of gallery functional tests written on top of the [Microsoft Unit Test Framework](http://msdn.microsoft.com/en-us/library/ms182532.aspx). Many of the tests issue Http Web requests to the Gallery in testing and then verify the web responses that are received back. The Fluent tests are authored using the [Fluent Automation framework](https://www.nuget.org/packages/FluentAutomation.SeleniumWebDriver/), which belongs to the category of UI Automation and will start web browsers to run. 

### Test By Kinds

In order to test different layers of the gallery such as OData query, API, UI and client integration, the functional tests have been written in different ways, which include:
	1. OData tests
	2. Web UI tests
	3. Client integration tests
	4. Fluent tests

### Tests by Scenarios

Within each kind of the tests above, there are tests that cover one or more of the following gallery scenarios:
	1. AccountManagement
	2. BasicPages
	3. EditableMetadata
	4. PackageManagement
	5. UploadAndDownload
	6. Search(UI and syntax)
	7. Statistics
	8. ReadOnlyMode
	9. Feed

### How to Run functional Tests Locally using Scripts

Under %RepositoryRoot%\Gallery\tests\scripts folder, there are 4 .cmd files that can be used for running functional tests, while each of them may server a different purpose. 

1. TestRunSetupScript.cmd - as of now the functional tests requires the following environmental variables to be set for tests to run properly: RunFunctionalTests, TestAccountName, TestAccountPassword, TestEmailServerHost. This script set these variables and also the target URL to run tests against, as well as the APIKey for uploading packages. Note that this script should be run before the other scripts.
2. RunEverythingy.cmd - this script runs all of the tests inside NuGetGallery.FunctionalTests.sln, including Fluent tests.
3. RunByTestList.cmd - this script runs functional tests by test lists, by specifying P0Tests, P1Tests, P2Tests or ReadOnlyModeTests as the 1st parameter. 
4. RunSpecificTests.cmd - this scripts runs specific tests filtered by 1st parameter of criteria and 2nd parameter of test kind. For example, to run fluent test of EditAndSearch, type "runspecifictests.cmd editandsearch fluent" on a command prompt.

### Known Issues/Tips about Running the Gallery Functional Tests 
1. The 4 environmental variables above needs to be defined before running the tests.
2. The fluent tests will start browser and take control of the screen while running. It's recommended to not use the mouse and keyboard during the run and wait for the tests to complete.


