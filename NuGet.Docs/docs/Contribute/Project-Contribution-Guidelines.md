# How to contribute

One of the easiest ways to contribute is to participate in discussions and discuss issues. You can also contribute by submitting pull requests with code changes.

## General feedback and questions?

Please start a discussion on the [Home repo issue tracker](https://github.com/NuGet/Home/issues).

## Bugs and feature requests?

Please log a new issue in the appropriate GitHub repo.

If you're having trouble with the NuGet.org Website, file a bug on the [NuGet Gallery Issue Tracker](https://github.com/nuget/NuGetGallery/issues).

If you're having trouble with the NuGet client tools (the Visual Studio extension, NuGet.exe command line tool, etc.), file a bug on [NuGet Home](https://github.com/nuget/home/issues).

## Other discussions

Our team members also monitor several other discussion forums:

* [StackOverflow](http://stackoverflow.com/questions/tagged/nuget) with the `nuget` tag
* [JabbR chat room](https://jabbr.net/#/rooms/nuget) for real-time discussions with the community and the people who work on the project

## Filing issues

The best way to get your bug fixed is to be as detailed as you can be about the problem. Providing a minimal project with steps to reproduce the problem is ideal. Here are questions you can answer before you file a bug to make sure you're not missing any important information.

1. Did you read the [documentation](http://docs.nuget.org)?
2. Did you include the command you executed in the issue?
3. What are the EXACT steps to reproduce this problem?
4. What package versions are you using (you can see these in the `project.json` or `packages.config` file)?
5. What operating system are you using?
6. What NuGet version are you using?
7. What version of Visual Studio are you using?

GitHub supports markdown, so when filing bugs make sure you check the formatting before clicking submit.

## Contributing code and content

You will need to sign a [Contributor License Agreement](https://cla2.dotnetfoundation.org/) before submitting your pull request. To complete the Contributor License Agreement (CLA), you will need to submit a request via the form and then electronically sign the Contributor License Agreement when you receive the email containing the link to the document. This needs to only be done once for any .NET Foundation OSS project.

Make sure you can build the code. Familiarize yourself with the project workflow and our coding conventions. If you don't know what a pull request is [read this article](https://help.github.com/articles/using-pull-requests).

Before submitting a feature or substantial code contribution please discuss it with the team and ensure it follows the product roadmap. You might also read these two blogs posts on contributing code: [Open Source Contribution Etiquette](http://tirania.org/blog/archive/2010/Dec-31.html) by Miguel de Icaza and [Don't "Push" Your Pull Requests](http://www.igvita.com/2011/12/19/dont-push-your-pull-requests/) by Ilya Grigorik. Note that all code submissions will be rigorously reviewed and tested by the NuGet team, and only those that meet an extremely high bar for both quality and design/roadmap appropriateness will be merged into the source.

Here's a few things you should always do when making changes to the code base:

**Engineering guidelines**

The coding, style, and general engineering guidelines are published on the [Engineering guidelines](/contribute/coding-guidelines) page.

**Commit/Pull Request Format**

```
Summary of the changes (Less than 80 chars)
 - Detail 1
 - Detail 2

#bugnumber (in this specific format)
```

**Tests**

* Tests need to be provided for every bug/feature that is completed.
* Tests only need to be present for issues that need to be verified by QA (e.g. not tasks)
* If there is a scenario that is far too hard to test there does not need to be a test for it.
  * "Too hard" is determined by the team as a whole.

## Builds

The NuGet Continuous Integration (CI) server has builds directly from the source tree. This allows you to try out the latest successful unstable builds.

Our TeamCity build server is at [http://build.nuget.org](http://build.nuget.org).