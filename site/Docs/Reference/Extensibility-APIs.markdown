# Supported extensitiblity APIs

This page contains the comprehensive list of the supported extensibility API that are exported via MEF by the NuGet Visual Studio extension. Refer to [this tutorial](/site/docs/reference/invoking-nuget-services-from-inside-visual-studio "Invoke NuGEt Services from inside Visual Studio") to learn how to invoke them.

## IVsPackageInstaller interface

    public interface IVsPackageInstaller
    {
        /// <summary>
        /// Installs a single package from the specified package source.
        /// </summary>
        /// <param name="source">The package source to install the package from.</param>
        /// <param name="project">The target project for package installation.</param>
        /// <param name="packageId">The package id of the package to install.</param>
        /// <param name="version">The version of the package to install</param>
        /// <param name="ignoreDependencies">A boolean indicating whether or not to ignore the package's dependencies during installation.</param>
        void InstallPackage(string source, Project project, string packageId, string version, bool ignoreDependencies);

        /// <summary>
        /// Installs a single package from the specified package source.
        /// </summary>
        /// <param name="repository">The package repository to install the package from.</param>
        /// <param name="project">The target project for package installation.</param>
        /// <param name="packageId">The package id of the package to install.</param>
        /// <param name="version">The version of the package to install</param>
        /// <param name="ignoreDependencies">A boolean indicating whether or not to ignore the package's dependencies during installation.</param>
        /// <param name="skipAssemblyReferences">A boolean indicating if assembly references from the package should be skipped.</param>
        void InstallPackage(IPackageRepository repository, Project project, string packageId, string version, bool ignoreDependencies, bool skipAssemblyReferences);

        /// <summary>
        /// Installs one or more packages that exist on disk in a folder defined in the registry.
        /// </summary>
        /// <param name="keyName">The registry key name (under NuGet's repository key) that defines the folder on disk containing the packages.</param>
        /// <param name="isPreUnzipped">A boolean indicating whether the folder contains packages that are pre-unzipped.</param>
        /// <param name="skipAssemblyReferences">A boolean indicating whether the assembly references from the packages should be skipped.</param>
        /// <param name="project">The target project for package installation.</param>
        /// <param name="packageVersions">A dictionary of packages/versions to install where the key is the package id and the value is the version.</param>
        /// <remarks>
        /// If any version of the package is already installed, no action will be taken.
        /// <para>
        /// Dependencies are always ignored.
        /// </para>
        /// </remarks>
        void InstallPackagesFromRegistryRepository(string keyName, bool isPreUnzipped, bool skipAssemblyReferences, Project project, IDictionary<string, string> packageVersions);

        /// <summary>
        /// Installs one or more packages that are embedded in a Visual Studio Extension Package.
        /// </summary>
        /// <param name="extensionId">The Id of the Visual Studio Extension Package.</param>
        /// <param name="isPreUnzipped">A boolean indicating whether the folder contains packages that are pre-unzipped.</param>
        /// <param name="skipAssemblyReferences">A boolean indicating whether the assembly references from the packages should be skipped.</param>
        /// <param name="project">The target project for package installation</param>
        /// <param name="packageVersions">A dictionary of packages/versions to install where the key is the package id and the value is the version.</param>
        /// <remarks>
        /// If any version of the package is already installed, no action will be taken.
        /// <para>
        /// Dependencies are always ignored.
        /// </para>
        /// </remarks>
        void InstallPackagesFromVSExtensionRepository(string extensionId, bool isPreUnzipped, bool skipAssemblyReferences, Project project, IDictionary<string, string> packageVersions);
    }


## IVsPackageInstallerEvents interface

    /// <summary>
    /// Contains events which are raised when packages are installed or uninstalled from projects and the current solution.
    /// </summary>
    public interface IVsPackageInstallerEvents
    {
        /// <summary>
        /// Raised when a package is about to be installed into the current solution.
        /// </summary>
        event VsPackageEventHandler PackageInstalling;

        /// <summary>
        /// Raised after a package has been installed into the current solution.
        /// </summary>
        event VsPackageEventHandler PackageInstalled;

        /// <summary>
        /// Raised when a package is about to be uninstalled from the current solution.
        /// </summary>
        event VsPackageEventHandler PackageUninstalling;

        /// <summary>
        /// Raised after a package has been uninstalled from the current solution.
        /// </summary>
        event VsPackageEventHandler PackageUninstalled;

        /// <summary>
        /// Raised after a package has been installed into a project within the current solution.
        /// </summary>
        event VsPackageEventHandler PackageReferenceAdded;

        /// <summary>
        /// Raised after a package has been uninstalled from a project within the current solution.
        /// </summary>
        event VsPackageEventHandler PackageReferenceRemoved;
    }

## IVsPackageInstallerServices interface

    /// <summary>
    /// Contains methods to query for installed packages within the current solution.
    /// </summary>
    public interface IVsPackageInstallerServices
    {
        /// <summary>
        /// Get the list of NuGet packages installed in the current solution.
        /// </summary>
        IEnumerable<IVsPackageMetadata> GetInstalledPackages();

        /// <summary>
        /// Checks if a NuGet package with the specified Id is installed in the specified project.
        /// </summary>
        /// <param name="project">The project to check for NuGet package.</param>
        /// <param name="id">The id of the package to check.</param>
        /// <returns><c>true</c> if the package is install. <c>false</c> otherwise.</returns>
        bool IsPackageInstalled(Project project, string id);

        /// <summary>
        /// Checks if a NuGet package with the specified Id and version is installed in the specified project.
        /// </summary>
        /// <param name="project">The project to check for NuGet package.</param>
        /// <param name="id">The id of the package to check.</param>
        /// <param name="versionString">The version of the package to check.</param>
        /// <returns><c>true</c> if the package is install. <c>false</c> otherwise.</returns>
        /// <remarks>
        /// The reason this method is named IsPackageInstalledEx, instead of IsPackageInstalled, is that 
        /// when client project compiles against this assembly, the compiler would attempt to bind against 
        /// the other overload which accepts SemanticVersion and would require client project to reference NuGet.Core.
        /// </remarks>
        bool IsPackageInstalledEx(Project project, string id, string versionString);

        /// <summary>
        /// Get the list of NuGet packages installed in the specified project.
        /// </summary>
        /// <param name="project">The project to get NuGet packages from.</param>
        IEnumerable<IVsPackageMetadata> GetInstalledPackages(Project project);
    }

## IVsPackageUninstaller interface

    /// <summary>
    /// Contains methods to uninstall packages from a project within the current solution.
    /// </summary>
    public interface IVsPackageUninstaller
    {
        /// <summary>
        /// Uninstall the specified package from a project and specify whether to uninstall its dependency packages too.
        /// </summary>
        /// <param name="project">The project from which the package is uninstalled.</param>
        /// <param name="packageId">The package to be uninstalled</param>
        /// <param name="removeDependencies">A boolean to indicate whether the dependency packages should be uninstalled too.</param>
        void UninstallPackage(Project project, string packageId, bool removeDependencies);
    }

## IVsPackageMetadata interface

	/// <summary>
    /// Contains information about an installed package.
    /// </summary>
    public interface IVsPackageMetadata
    {
        /// <summary>
        /// Id of the package.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// The version of the package.
        /// </summary>
        string VersionString { get; }

        /// <summary>
        /// Title of the package.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Description of the package.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The authors of the package.
        /// </summary>
        IEnumerable<string> Authors { get; }

        /// <summary>
        /// The location where the package is installed on disk.
        /// </summary>
        string InstallPath { get; }
    }