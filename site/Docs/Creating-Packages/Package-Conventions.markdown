# Package Conventions

The purpose of this page is to start hashing out package conventions. These conventions are different from 
the “enforced” conventions that are required by NuGet when creating a package such as the package folder 
structure and supporting multiple .NET Framework versions. For those conventions, view the docs on Creating 
a Package.

## Package Id Conventions

**Namespace-like names**: Package IDs should follow a pattern similar to namespaces in .NET. For example, 
Ninject.Mvc3 instead of Ninject-Mvc3.

**Sample Packages**: Use the ".Sample" suffix for a package that provides sample code for your package. 
This is useful for helping others get started. For example, if your package name is Clay, then a sample 
of how to use clay would be Clay.Sample. Also, within the content folder, arrange your samples within a 
root /Samples/PackageID folder structure. For example, the Clay.Sample package would have a folder 
/Samples/Clay. See this blog post for more details.

## Package Contents Conventions

**App\_Start Folder**: When using the [WebActivator](http://nuget.org/List/Packages/WebActivator) package, 
put all the application startup code in a root **App\_Start** folder within the package's Content folder. 
See this blog post for more details.

**Assemblies**: In general, it makes sense to have one package per assembly. In some cases, if your library 
has assemblies that don’t make sense in any other context except within your library, then it’s fine to 
package those assemblies within your package. For example, if you have a Foo.dll that depends on Bar.dll and 
both you think others may depend on Bar.dll, then make two packages. But if you have Foo.dll and Foo.resources.dll, 
then there’s no point in making two packages. Just put both in a single package.

## Package Versioning Conventions
**Versioning Guidelines**: To understand NuGet versioning, the following three part series is a very important 
(and quick!) read: NuGet Versioning [Part 1: Taking on DLL Hell](http://blog.davidebbo.com/2011/01/nuget-versioning-part-1-taking-on-dll.html), 
[Part 2: The core algorithm](http://blog.davidebbo.com/2011/01/nuget-versioning-part-2-core-algorithm.html), 
[Part 3: Unification via Binding Redirects](http://blog.davidebbo.com/2011/01/nuget-versioning-part-3-unification-via.html).

**Choosing a Version**: In general, it makes sense to name the package version according to the library version. 
But do not the versioning rules that NuGet uses just in case your library has a very non-standard versioning 
scheme. While we generally recommend that the version of the package matches the library, this is not required.