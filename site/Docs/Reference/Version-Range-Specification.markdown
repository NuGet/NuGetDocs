# Version Range Specification
When you create a NuGet package, you can specify dependencies for the package in the .nuspec file. You 
also specify which versions of a dependency package are required. For information about creating NuGet 
packages and the .nuspec file format, see [Creating a Package](../creating-packages/creating-and-publishing-a-package) 
and [.nuspec File Format Specification](nuspec-reference).

Dependency versions are specified in the version attribute of the dependency element. For example, the 
following dependency element specifies a dependency on version 1.3.2 or higher of the package named 
ExamplePackage.

## Specifying Version Ranges in .nuspec Files

    <dependency id="ExamplePackage" version="1.3.2" />

NuGet supports using interval notation for specifying version ranges. The NuGet specification was 
inspired by the Maven Version Range Specification but is not identical to it. The following summarizes 
how to specify version ranges.

    1.0	 = 1.0 ≤ x
    (,1.0]	= x ≤ 1.0
    (,1.0)	= x < 1.0
    [1.0] = x == 1.0
    (1.0) = invalid
    (1.0,) = 1.0 < x
    (1.0,2.0) = 1.0 < x < 2.0
    [1.0,2.0] = 1.0 ≤ x ≤ 2.0
    empty = latest version.

## Examples
The following example specifies a dependency on any version of ExamplePackage that begins with a 1 or a 2. 
The square bracket indicates that the 1 is included, while the parenthesis indicates that 3 is excluded.

    <dependency id="ExamplePackage" version="[1,3)" />

In the example, version 1 and version 2.9 would be acceptable, but not 0.9 or 3.0.

The following example specifies a dependency on ExamplePackage 1.3.2 through any version number that 
begins with 1.4. The square bracket indicates that the 1.3.2 is included, while the parenthesis 
indicates that 1.5 is excluded.

    <dependency id="ExamplePackage" version="[1.3.2,1.5)" />

In the example, version 1.3.2.1 and version 1.4.999 would be acceptable, but not version 1.5.

## Guidance
Generally, the guidance in most cases is to only specify a lower bound, and leave the upper bound open. e.g.

    <dependency id="ExamplePackage" version="1.3.2" />