# SemVer Support

NuGet supports the creation of prerelease packages by specifying a prerelease string in 
the version number according to the [Semantic Versioning (SemVer) specification v1.0.0](http://semver.org/spec/v1.0.0.html).

## Really brief introduction to SemVer
The [SemVer spec](http://semver.org/spec/v1.0.0.html) is the best place to get a detailed understanding of SemVer. For 
those in a hurry, this is a brief rundown of SemVer.

SemVer is a convention for versioning your public APIs in which the version number has meaning attached to it. 
Each version has three parts, _Major.Minor.Patch_.

In brief, these correspond to:
* __Major__: Breaking changes.
* __Minor__: New features, but backwards compatible.
* __Patch__: Backwards compatible bug fixes only.

Additionally, prerelease versions of your API can be denoted by appending an arbitrary string to the 
_Patch_ number separated by a dash. For example:

    1.0.1-alpha
    1.0.1-beta
    1.0.1-Fizzleshnizzle

<div class="block-callout-info">
    <strong>Note:</strong><br>
    The actual string applied doesn't matter. If there's a string there, it's a prerelease version.
</div>

When you’re ready to release, just remove the dash and the string and that version is considered “higher” 
than all the prerelease versions. For example, the stable version `1.0.1` is larger than `1.0.1-rc`

The prerelease versions are given precedence in alphabetical order (well technically lexicographic 
ASCII sort order).Therefore, the following is an example from lowest to highest versions of a package.

    1.0.1-alpha
    1.0.1-alpha2
    1.0.1-beta
    1.0.1-rc
    1.0.1-zeeistalmostdone
    1.0.1

SemVer also introduces the concept of a build number for those creating daily or continuous builds. This is not 
supported in the public NuGet.org gallery, so while this is allowed:

    1.0.1-build23

including the SemVer-compatible build number with dot notation is not allowed:
    
    1.0.1-build.23


