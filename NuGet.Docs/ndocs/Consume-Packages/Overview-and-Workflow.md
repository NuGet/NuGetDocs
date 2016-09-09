# Package Consumption Overview and Workflow

Between nuget.org and private package galleries that your organization might establish, you can find tens of thousands of highly useful packages to use in your apps and services (including packages that support native C++ projects; see [Native C++ Packages](/ndocs/consume-packages/finding-and-choosing-packages#native-c---packages)). But regardless of the source, consuming a package follows the same general workflow:

![Flow of going to a package source, finding a package, installing it in a project, then adding a using statement and calls to the package API](/images/Consume/Overview-01-GeneralFlow.png)

For details, see [Finding and Choosing Packages](/ndocs/consume-packages/finding-and-choosing-packages) and the [Use a Package quickstart](/ndocs/quickstart/use-a-package).

<div class="block-callout-info">
	<strong>Note</strong><br>
	NuGet maintains a local package cache from which it installs requested packages if they're available. If you encounter errors related to the cache, see <a href="/ndocs/consume-packages/troubleshooting-nuget-cache-issues">Troubleshooting NuGet Cache Issues</a>.
</div>

When adding project code to a source repository, you typically don't include NuGet packages. Those who later clone the repository, which includes build agents on systems like Visual Studio Team Services, must restore the necessary packages prior to running a build:

![Flow of restoring NuGet packages by cloning a repository and using either a restore command](/images/Consume/Overview-02-RestoreFlow.png)

For additional details, see [Package Restore](/ndocs/consume-packages/package-restore).

Occasionally it's necessary to reinstall packages that are already included in a project. This is easy to do using the `reinstall` command via the NuGet command line or the NuGet Package Manager Console. For details, see [Reinstalling Packages](/ndocs/consume-packages/reinstalling-packages).

Finally, what drives NuGet for a particular project is either the `packages.config` file or a `project.json` file (NuGet 3.0 and later). If you want to change the configuration manually, you can edit these files directly as described in the [NuGet config file overview](/ndocs/consume-packages/nuget-config-file-overview) and  [project.json overview](/ndocs/consume-packages/projectjson-intro).

Enjoy improving your coding productivity with NuGet packages!
  