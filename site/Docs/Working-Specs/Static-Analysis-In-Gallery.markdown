# Scenario Overview #
Run static analysis rules before pushing a package and notify the user about the errors and warnings.

# Problem #

Package authors would like to make sure that a package meets certain basic validation checks before publishing it. Similarly package consumers would like to know before intalling it.

We have few basic static analysis rules around package authoring convention as part of NuGet.exe and these warnings get displayed during "pack" command.

The errors/warnings given by pack command (client side) gets ignored by authors most of times. Some times they are ignored intentionally as the default built-in rules are more of warnings than errors and some times accidentally as packages are created in bulk as part of build process.

The proposal is to provide an extended set of static analysis rules which will be run on the server side when a package is submitted for publishing.

# Few rules to begin with#


1. Making sure all the assemblies and powershell script files in the package are strong name signed.
2. Making sure all the mandatory attributes are being set in the package.
3. Making sure the package is compatible with a given template (say MVC 4).

  Example:
 We had a support request once for [jQuery.UI.Widgets.Datepicker](http://nuget.org/packages/jQuery.UI.Widgets.Datepicker/) package that it doesn't get installed on MCV template.
This is because the package has a dependency on jQuery which conflicts with the jQuery version that comes with MVC template. Such issues can be caught before hand with a static analysis rule.

4. Making sure the dependencies of the package are compatible with each other.
5. Making sure that the LOC package versions are also uploaded with new ENU package version.

 Example:
  We once had a support request where the zh-Hans locale version of 'Microsoft.AspNet.Providers.Core' package was missing for it's latest stable version and we had to pushed the LOC packages latter.

Note : We already have most of the rules implemented and they are being used for our internal packages.


# Work flow #

1. User uploads a package in nuget.org.
2. In the upload wizard, have a checkboxes for the below option

           "Run static analysis rules on my package and notify me".

3. Have a worker task which would run every 5 minutes and executes the analysis rules on newly submitted packages. The task should send mail notification to the owner about the errors and warnings.

              
#### Open questions ####

1. Running the analysis rules requires unzipping the nupkg file and we don't want to do it in the web role. If we can do it in web role, we can have 'static analysis' as step in the upload process and users can check out the results right before pushing the package.
Any thoughts around this ?
2. Should we have an option like "Upload my package only when static analysis rule suceeds". That way an user can chose not to push the package if it has errors (probably skip warnings) and get it fixed.

# Extended scenarios : #

1. Store the results of static analysis in Gallery and make it available in the package page (if package consumers would like to look at it ? )

2. Provide an equivalent switch for it in "Push" command as well, say "-RunStaticAnalysis". 

3. Ship the assembly containing extended rules as a NuGet package (say NuGet.AnalysisRules) so that it can be used as part of pack command as well during package development.


