# Showing Package Dependents

## Scenario

The NuGet Gallery has to show the list of "Dependents" for a package similar to "Dependencies". This will help package authors and consumers in the following ways:

1. While making breaking changes and updates to their packages, package authors would know whom to contact.
1. Also for package consumers, showing the dependents would give a sense of the various scenarios in which the parent package is being used and an idea of "users who installing this package might also install" the dependent package.

Reference implementation from NPM:

* [https://npmjs.org/package/commander](https://npmjs.org/package/commander)

### Tracking issues

1. [https://github.com/NuGet/NuGetGallery/issues/445](https://github.com/NuGet/NuGetGallery/issues/445)
1. [https://github.com/NuGet/NuGetGallery/issues/922](https://github.com/NuGet/NuGetGallery/issues/922)
1. [https://github.com/NuGet/NuGetGallery/issues/1029](https://github.com/NuGet/NuGetGallery/issues/1029)

## Basic flow

1. The individual package page should show "Dependents" similar to "Dependencies".
"Dependents" might be quite huge in number unlike "Dependencies", especially for popular packages. To simplify the view, we can show the top 10 dependents (based on download count) and a "see more" hyperlink.
1. Fetching the "Dependents" for a package should be straight forward as we have the dependencies listed in "Package Dependencies" table in our DB.
1. For each "Dependent" we should show the Id and the Version spec by which it is bound to the current package.

### Example

> Package A is dependent on package B with a version spec >=1.0.0 and <= 2.0.0

An entry like "A, depends on B >=1.0.0 && <= 2.0.0" would be shown as a "Dependent" on all versions of package B from 1.0.0 to 2.0.0 inclusive.

## Extended features

1. Grouping the "Dependents" based on target framework can be added similar to the way we group "Dependencies". It is however low priority and can be added in phase 2 after the first cut of the feature goes out. Also currently the "Target Framework" is not being populated in the "Package Dependencies" table.
1. We can have a link "Contact Dependents" similar to "Contact support" which would let the package author to send e-mail notification to all his dependents (who has turned on email notifications) in one go.
1. [Ron Cain](https://github.com/NuGet/NuGetGallery/issues/922) has some interesting points in [#922](https://github.com/NuGet/NuGetGallery/issues/922). One suggestion is to be able to find "incompatible dependencies".  While it is an interesting data point, it would be hard to show the list of all incompatible dependents for each single dependents. What can probably highlight is the incompatibilities within noticed in the top 10 dependents? It need not be shown the package page. When the user clicks on "See more" hyperlink, the incompatibility can be shown along with the package id and dependency version spec.

### Example

* Package A depends on C with spec > 2.0.0
* Package B depends on C with spec < 2.0.0
* Package X depends on C with spec >= 1.0.0

For C’s package version > 2.0.0, "Dependents" will show something like:

> A depends on C > 2.0.0, incompatible with dependent B.

For C’s package version < 2.0.0, "Dependents" will show something like:

> B depends on C < 2.0.0, incompatible with dependent A.

## Non-goals

1. Showing multiple levels of dependents or a dependency graph is not required for the below reasons :
    1. A dependency graph can grow big too easily for popular packages with lots of nodes and edges and it would be difficult to interpret any data out of it.
    1. We need to deal with cases like "Circular dependency" and it might be a performance hit while loading package page.
    1. As a package author, I would be only interested in the packages that are directly dependent on me and not on in-direct dependencies.
    1. In any case, if it is required to find the in-direct dependents, users can do it by an extra click – go to the dependent package’s page and view its dependents.
1. This will be just a Gallery feature and we will not be integrating it with the client side (to be able to view all the dependents of a package from all the feeds). Such feature can be added as an extension to NuGet.exe or NPE by the community, but it will not be a first class feature in VS.

## Open questions

1. We might want to avoid showing the "Dependents" that are being unlisted. Are we doing that for "Dependencies" today?
