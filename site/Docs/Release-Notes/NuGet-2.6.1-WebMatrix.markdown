# NuGet Package Manager for WebMatrix 2.6.1 Release Notes

The NuGet team released an updated NuGet Package Manager extension for WebMatrix on March 26, 2014.  This release addresses two of the most reported issues with NuGet in WebMatrix.  This update can be installed from the [WebMatrix Extension Gallery](http://extensions.webmatrix.com/packages/NuGetPackageManager/).

This latest release brings the NuGet Extension for WebMatrix up to version 2.6.1.

To Update NuGet Package Manager for WebMatrix, use the following steps:

1. Open WebMatrix
2. Click on the 'Extensions' icon in the Home ribbon
3. Select 'Updates' on the left and then 'NuGet Package Manager' on the right and click Update
4. Agree to install NuGet Package Manager 2.6.1
5. Review and accept the license terms to install
6. Restart WebMatrix

## Zero-Byte DLLs in bin Folder

Some users have reported that after installing NuGet packages in WebMatrix that include DLLs that get copied to bin, that the DLLs show up in the bin folder as 0-byte files.  This breaks the application at runtime.

[This issue](https://nuget.codeplex.com/workitem/4060) has now been fixed.

## NuGet Schema Version Error

Since WebMatrix 3 was released, new features have been introduced into NuGet that require a new schema version for the NuGet packages.  When trying to manage your NuGet packages in your web site, these new packages can lead to errors that you'll see in WebMatrix.

![An error occurred. The schema version is incompatible. Please upgrade NuGet to the latest version.](Images/NuGet-2.8/webmatrix-schema-version.png)

This latest release provides compatibility with the newest NuGet packages, preventing this error from occurring. New versions of packages including Microsoft.AspNet.WebPages can now be installed in WebMatrix.

