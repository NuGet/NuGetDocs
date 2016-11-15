# Package References in Project Files

Package references, using the `PackageReference` node, allow you to manage NuGet dependencies directly in .NET Core project files, without needing a separate `packages.config` or `project.json` file. This approach also allows you to use MSBuild conditions to choose package references per target framework, configuration, platform, or other groupings. It also allows for fine-grained control over dependencies and content flow. In terms of behavior and dependency resolution, it is the same as using `project.json`

<div class="block-callout-info>
    <strong>Note</strong><br>
    Package references are currently supported for only .NET Core projects in Visual Studio 2017.
</div>

## Adding a PackageReference

You can add a dependency in your project file using the following syntax:

    <ItemGroup>
        <!-- ... -->
        <PackageReference Include="Contoso.Utility.UsefulStuff">
            <Version>3.6.0</Version>
        </PackageReference>
        <!-- ... -->
    </ItemGroup>

or, alternately:

    <ItemGroup>
        <!-- ... -->
        <PackageReference Include="Contoso.Utility.UsefulStuff" Version="3.6.0" />
        <!-- ... -->
    </ItemGroup>


## Controlling dependency version

The convention for specifying version remains unchanged:

    <ItemGroup>
        <!-- ... -->
        <PackageReference Include="Contoso.Utility.UsefulStuff">
            <Version>3.6.0</Version>
        </PackageReference>
        <!-- ... -->
    </ItemGroup>

In the example above, 3.6.0 means any version that is >=3.6.0 with preference for the lowest version, as described on [version ranges](/ndocs/create-packages/dependency-versions#version-ranges).

## Floating Versions

[Floating versions](/ndocs/consume-packages/dependency-resolution#floating-versions) are supported with `PackageReference`:

    <ItemGroup>
        <!-- ... -->
        <PackageReference Include="Contoso.Utility.UsefulStuff">
            <Version>3.6.*</Version>
        </PackageReference>

        <PackageReference Include="Contoso.Utility.UsefulStuff">
            <Version>3.6.0-beta*</Version>
        </PackageReference>
        <!-- ... -->
    </ItemGroup>

## Controlling dependency assets

You might be using a dependency purely as a development harness and might not want to expose that to projects that will consume your package. In this scenario, you can use the `PrivateAssets` metadata to control this behavior.

    <ItemGroup>
        <!-- ... -->

        <PackageReference Include="Contoso.Utility.UsefulStuff" Version="3.6.0">
            <PrivateAssets>All</PrivateAssets>
        </PackageReference>

        <!-- ... -->
    </ItemGroup>

The following metadata tags control dependency assets:

<table>
    <thead>
        <tr>
            <td>Tag</td>
            <td>Description</td>
            <td>Default value</td>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>IncludeAssets</td>
            <td>These assets will be consumed</td>
            <td>all</td>
        </tr>
        <tr>
            <td>ExcludeAssetsTag</td>
            <td>These assets will not be consumed</td>
            <td>none</td>
        </tr>
        <tr>
            <td>PrivateAssets</td>
            <td>These assets will be consumed but won't flow to the parent project</td>
            <td>contentfiles;analyzers;build</td>
        </tr>
    </tbody>
</table>


Allowable values for these tags are as follows, with multiple values separated by a semicolon except with `all` and `none` which must appear by themselves:

<table>
    <thead>
        <tr>
            <td>Value</td>
            <td>Description</td>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>compile</td>
            <td>Contents of the <code>lib</code> folder</td>
        </tr>
        <tr>
            <td>runtime</td>
            <td>Contents of the <code>runtime</code> folder</td>
        </tr>
        <tr>
            <td>contentFiles</td>
            <td>Contents of the <code>contentfiles</code> folder</td>
        </tr>
        <tr>
            <td>build</td>
            <td>Props and targets in the <code>build</code> folder</td>
        </tr>
        <tr>
            <td>anaylzers</td>
            <td>.NET analyzers</td>
        </tr>
        <tr>
            <td>native</td>
            <td>Contents of the <code>native</code> folder</td>
        </tr>
        <tr>
            <td>none</td>
            <td>None of the above are used.</td>
        </tr>
        <tr>
            <td>all</td>
            <td>All of the above (except <code>none</code>)</td>
        </tr>
    </tbody>
</table>


In the following example, everything except the content files from the package would be consumed by the project and everything except content files and analyzers would flow to the parent project.

    <ItemGroup>
        <!-- ... -->

        <PackageReference Include="Contoso.Utility.UsefulStuff" Version="3.6.0">
            <IncludeAssets>All</IncludeAssets>
            <ExcludeAssets>contentFiles</ExcludeAssets>
            <PrivateAssets>contentFiles;analyzers</PrivateAssets>
        </PackageReference>

        <!-- ... -->
    </ItemGroup>

## Adding a PackageReference condition

You can use a condition to control whether a package is included, where conditions can use any MSBuild variable or a variable defined in the targets or props file.

For example, say you're targeting `netstandard1.4` as well as `net452` but have a dependency that is applicable only for `net452`. In this case you don't want a `nestandard1.4` project that's consuming your package to add that unnecessary dependency. To prevent this, you specify a condition on the `PackageReference` as follows:  

    <ItemGroup>
        <!-- ... -->

        <PackageReference Include="Newtonsoft.json" Condition="'$(TargetFramework)' == 'net452'>
            <Version>9.0.1</Version>
        </PackageReference>

        <!-- ... -->
    </ItemGroup>

A package build using this project will show that Newtonsoft.json is included as a dependency only for a `net452` target:

![The result of applying a Condition on PackageReference](/images/Consume/PackageReference-Condition.png)

Conditions can also be applied at the `ItemGroup` level and will apply to all children `PackageReference` elements:

    <ItemGroup Condition = "'$(TargetFramework)' == 'net452'>
        <!-- ... -->

        <PackageReference Include="Newtonsoft.json">
            <Version>9.0.1</Version>
        </PackageReference>

        <PackageReference Include="Contoso.Utility.UsefulStuff" Version="3.6.0">

        <!-- ... -->
    </ItemGroup>