# Adding nuget pack as an MSBuild target

*NuGet 4.0+*

NuGet 4.0+ can work directly with the information in a `.csproj` file without requring a separate `packages.config` or `project.json` file. All the metadata that was previously stored in those configuration files can be instead stores in the `.csproj` file directly, as described here.

## MSBuild Properties

The table below describes the MSBuild properties that can be added to a `.csproj` file within the first &lt;PropertyGroup&gt; node. You can make these edits easily in Visual Studio 2017 and later by right-clicking the project and selecting **Edit {project_name}** on the context menu. For convenience the table is organized by the equivalent property in a [`.nuspec` file](/ndocs/schema/nuspec); note that the `Title` and `Summary` properties of a `.nuspec` file have no MSBuild equivalents.

<table>
    <thead>
        <tr>
            <th>Attribute/NuSpec Value</th>
            <th>MSBuild Property</th>
            <th>Default</th>
            <th>Notes</th>
            </tr>
    </thead>
    <tbody>
        <tr>
            <td>Id</td>
            <td>PackageId</td>
            <td>AssemblyName</td>
            <td>$(AssemblyName) from msbuild</td>
        </tr>
        <tr>
            <td>Version</td>
            <td>PackageVersion</td>
            <td>Version</td>
            <td>New $(Version) property from msbuild, is semver compatible. Could be “1.0.0”, “1.0.0-beta”, or “1.0.0-beta-00345”.</td>
        </tr>
        <tr>
            <td>Authors</td>
            <td>Authors</td>
            <td>username of the current user will be the default value</td>
            <td></td>
        </tr>
        <tr>
            <td>Owners</td>
            <td>N/A</td>
            <td>Not present in NuSpec</td>
            <td></td>
        </tr>
        <tr>
            <td>Description</td>
            <td>Description</td>
            <td>"Package Description"</td>
            <td></td>
        </tr>
        <tr>
            <td>Copyright</td>
            <td>Copyright</td>
            <td>empty</td>
            <td></td>
        </tr>
        <tr>
            <td>RequireLicenseAcceptance</td>
            <td>PackageRequireLicenseAcceptance</td>
            <td>false</td>
            <td></td>
        </tr>
        <tr>
            <td>LicenseUrl</td>
            <td>PackageLicenseUrl</td>
            <td>empty</td>
            <td></td>
        </tr>
        <tr>
            <td>ProjectUrl</td>
            <td>PackageProjectUrl</td>
            <td>empty</td>
            <td></td>
        </tr>
        <tr>
            <td>IconUrl</td>
            <td>PackageIconUrl</td>
            <td>empty</td>
            <td></td>
        </tr>
        <tr>
            <td>Tags</td>
            <td>PackageTags</td>
            <td>empty</td>
            <td></td>
        </tr>
        <tr>
            <td>ReleaseNotes</td>
            <td>PackageReleaseNotes</td>
            <td>empty</td>
            <td></td>
        </tr>
        <tr>
            <td>RepositoryUrl</td>
            <td>RepositoryUrl</td>
            <td>empty</td>
            <td></td>
        </tr>
        <tr>
            <td>RepositoryType</td>
            <td>RepositoryType</td>
            <td>empty</td>
            <td></td>
        </tr>
        <tr>
            <td>PackageType</td>
            <td><code>&lt;PackageType&gt;DotNetCliTool, 1.0.0.0;Dependency, 2.0.0.0&lt;/PackageType&gt;</code></td>
            <td></td>
            <td></td>
        </tr>
    </tbody>
</table>


## Inputs for Pack Target

The following properties and items in the `.csproj` file are applied when MSBuild is used to create a NuGet package:

Properties:

- `PackageVersion`
- `PackageId`
- `Authors`
- `Description`
- `Copyright`
- `PackageRequireLicenseAcceptance`
- `PackageLicenseUrl`
- `PackageProjectUrl`
- `PackageIconUrl`
- `PackageReleaseNotes`
- `PackageTags`
- `PackageOutputPath`
- `Configuration`
- `AssemblyName`
- `IncludeSymbols`
- `IncludeSource`
- `PackageTypes`
- `IsTool`
- `RepositoryUrl`
- `RepositoryType`
- `NoPackageAnalysis`
- `MinClientVersion`

Items:

- `SourceFiles` (if IncludeSymbols = true)
- `PackageFiles` (needs design, but basically means the list of content files to be included)
- `TargetPath` (cross-targeting scenarios; see below)
- `TargetFrameworks` (cross-targeting scenarios; see below)
- `ProjectReferences` (has a custom serialization format, see below)


## Scenarios

### PackageIconUrl

As part of addressing [Issue 2582](https://github.com/NuGet/Home/issues/2582), `PackageIconUrl` will eventually be changed to `PackageIconUri` and can be a relative path to a icon file which will included at the root of the resulting package.

### Output Assemblies

The `nuget pack` command will copy the output files, that is, those with extensions `.exe`, `.dll`, `.xml`, and `.winmd`. The output files that are copied depend on what MSBuild provides from the `BuiltOutputProjectGroup` target.

There are two MSBuild  properties that you can use in your project file or command line to control where output assemblies go:

- `IncludeBuildOutput`: A boolean that determines whether the build output assemblies should be included in the package.
- `BuildOutputTargetFolder`: Specifies the folder in which the output assemblies should be placed. The output assemblies (and other output files) are copied into their respective framework folders.

### Package References

See the [Package References specification](https://github.com/NuGet/Home/wiki/PackageReference-Specification).

### Project to Project References

Project to Project references are considered by default as NyGet package references. However, this behavior can be overridden in the following manner:

    <ProjectReference Include="..\UwpLibrary2\UwpLibrary2.csproj">
        <Project>{25dcfe98-02b7-403a-b73d-6282d9801aa1}</Project>
        <Name>UwpLibrary2</Name>
         <TreatAsPackageReference>false</TreatAsPackageReference>
     </ProjectReference>

If a referenced project's output DLL is to be copied over to the NuGet package, then `ReferenceOutputAssembly` should not be set to `false`. This is because the output DLL of the referenced project is copied from the output directory of the project being packed. For more details on `ReferenceOutputAssembly`, see [How to have a Project Reference without referencing the actual binary](https://blogs.msdn.microsoft.com/kirillosenkov/2015/04/04/how-to-have-a-project-reference-without-referencing-the-actual-binary/).

If `TreatAsPackageReference` is not specified, or is set to `true`, then the `ProjectReference` will actually be added as a `PackageReference` in the output nuspec file, and no DLLs will be copied.

Note that this behavior is recursive. If a `ProjectReference` has `TreatAsPackageReference` set to `false`, it's project to project references will also be treated in the same manner.

If a `ProjectReference` is treated as a `PackageReference`, then you can also add the following metadata to your project reference:

    <IncludeAssets>

    <ExcludeAssets>

    <PrivateAssets>

### Including Content in package

To include content, add extra metadata to the existing &lt;Content&gt; item . By default everything of type "Content" gets included in the package unless you override with entries like the following:

     <Content Include="..\win7-x64\libuv.txt">
         <Pack>false</Pack>
     </Content>

Everything gets added to the root of the `content` and `contentFiles` folder within a package and preserves the relative directory structure, unless you specify a package path:

    <Content Include="..\win7-x64\libuv.txt">
        <Pack>true</Pack>
        <PackagePath>content\myfiles</PackagePath>
     </Content>

`PackagePath` can be a semicolon-delimited set of target paths. Specifying an empty package path would add the file to the root of the package. For example, the following adds libuv.txt to content\myfiles, content\samples, and the package root:

    <Content Include="..\win7-x64\libuv.txt">
        <Pack>true</Pack>
        <PackagePath>content\myfiles;content\sample;;</PackagePath>
     </Content>

Packing of content files is also recursive. Content files from any project to project reference, which has `TreatAsPackageReference` set to `false`, are also copied in the similar manner and the same rules apply.

If you wish to prevent copying of a content from another project into your nuget package, use the following form:

    <Content Include="..\..\project2\readme.txt">
        <Pack>false</Pack>
     </Content>

Similarly, you can override the behavior in the referenced project and include a file to be packed which would have otherwise been excluded:

    <Content Include="..\..\project2\readme.txt">
        <Pack>true</Pack>
        <PackagePath>content\myfiles</PackagePath>
        <Visible>false</Visible>
    </Content>

Setting `Visible` to `false` prevents Visual Studio from showing the file in the Solution Explorer.

There is also an MSBuild property `$(IncludeContentInPack)`, which defaults to `true`. If this is set to `false` on any project, then the content from that project or it's project to project dependencies are not included in the nuget package.

<div class="block-callout-info">
    <strong>Notes</strong><br>
    Apart from Content items, the Pack and PackagePath metadata can also be set on files with a build action of Compile or None.
    <br>
    For pack to append the filename to your package path, your package path must end with the directory separator character, otherwise the package path is treated as the full path including the file name.
</div>

### Cross-Targeting

At present, target frameworks are defined in the `.csproj` file in an item list called `TargetFrameworks`  where the identity maps to `$(TargetFrameworkIdentity),$(TargetFrameworkVersion)` (not using NuGet short names).

The `@(TargetPath)` will be a list of all the output paths (path to the output assembly) with their associated TargetFramework metadata. `nuget pack` will convert these full target framework names to short folder names in the resulting package.

Details on cross-targeting are still being finalized, and is subject to change.

## IncludeSymbols

When using `msbuild /t:pack /p:IncludeSymbols=true`, the corresponding pdb files are copied along with other output files (`.dll`, `.exe`, `.winmd`, `.xml`). Note that setting `IncludeSymbols=true` creates a regular package *and* a symbols package.

### IncludeSource

This is the same as `IncludeSymbols`, except that it copies source files along with pdbs as well. All files of type Compile are copied over to `src\&lt;ProjectName&gt;\` preserving the relative path directory structure in the resulting package. The same also happens for source files of any `ProjectReference` which has `TreatAsPackageReference` set to `false`.

If a file of type Compile, is outside the project folder, then it is just added to `src\&lt;ProjectName&gt;\`.

### IsTool

When using `msbuild /t:pack /p:IsTool=true`, all output files, as specified in the [Output Assemblies](#output-assemblies) scenario, are copied to the `tools` folder instead of the `lib` folder. Note that this is different from a `DotNetCliTool` which is specified by setting the `PackageType` in `.csproj` file.

### Framework Assembly References or Reference to DLL on disk

1. Reference to an existing DLL on disk: In this case there will be a hint path–the source path from where the DLL will be picked up. If metadata is set on this reference, it will be copied to the `lib` folder. If `PackagePath` metadata is set too, it will be copied to the path denoted by `PackagePath`.

1. Reference to an assembly in GAC: If there is no hint path to a `Reference`, these will be by default ignored by pack since these are assemblies from the GAC. This can be changed by setting `Pack` metadata to `true`, in which case, this would be added to `frameworkAssemblies` in nuspec along with `targetFramework` based on any conditions provided.

1. Reference to a DLL that comes from a package: These by default have custom metadata like `NuGetSourceType` set to `package`, the package should be added as a dependency.