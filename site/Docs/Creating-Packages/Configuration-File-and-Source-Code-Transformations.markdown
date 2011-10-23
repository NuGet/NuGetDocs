# Configuration File and Source Code Transformations

## Overview
In general, when you create a package, the files that you include in the package are not 
modified in any way and are simply copied to the appropriate location in the target solution. 
However, in some cases you might want a file to be modified or transformed during installation. 

### Configuration File Transformations
Some packages need to customize the configuration files (web.config or app.config) of the project 
that the package is installed in. For example, [ELMAH (Error Logging Modules and Handlers for ASP.NET)](http://code.google.com/p/elmah/) 
needs to add an entry in the `httpModules` section of a *web.config* file.

You can specify changes to make in the project's *app.config* or *web.config* file by including a file 
named *web.config.transform* or *app.config.transform*.

### Source Code Transformations

You can specify changes to make in source code that is copied to the project by appending *.pp* 
to a source code file name. You can then embed variables in the source code that are replaced 
with values appropriate to the project during installation. For example, if you put 
`namespace $rootnamespace$` in a source-code file and append *.pp* to the name, the code 
becomes `namespace TargetProject` when the file is installed in a target project whose 
root namespace is `TargetProject`. In the target project, the file no longer has the *.pp* 
extension. 

## Specifying Configuration File Transformations

To apply a configuration-file transformation, you add a file to your package's content and give it 
the same name as the file you want to transform, followed by a .transform extension. For example, 
to transform a web.config file, you create a web.config.transform file. The transformation file 
contains XML that looks like a web.config or app.config file, but it includes only the sections 
that need to be merged into the project's configuration file.

For example, suppose you want your package to add an item to the modules collection of the web.config 
file of the project that it's installed in. To do this, you add a file named web.config.transform to 
the package and put the following XML in it:

    <configuration>
        <system.webServer>
            <modules>
                <add name="MyNuModule" type="Sample.MyNuModule" />
            </modules>
        <system.webServer>
    </configuration>

Suppose the package is installed in a project that contains the following web.config file:

    <configuration>
        <system.webServer>
            <modules>
                <add name="MyModule" type="Sample.MyModule" />
            </modules>
        <system.webServer>
    </configuration>

After NuGet installs the package, the web.config file will look like the following example, in which the 
changed line is highlighted:

    <configuration>
        <system.webServer>
            <modules>
                <add name="MyModule" type="Sample.MyModule" />
                <add name="MyNuModule" type="Sample.MyNuModule" />
            </modules>
        <system.webServer>
    </configuration>

Notice that NuGet didn't replace the modules section, it just merged the new entry into it. When NuGet 
merges a transform file into a project's configuration file, it only adds elements or adds attributes 
to existing elements in the configuration file; it does not change existing elements or attributes in 
any other way.

As noted earlier, an example of a package that needs to change a project's web.config file during 
installation is ELMAH (Error Logging Modules and Handlers for ASP.NET). ELMAH requires that its 
HTTP modules and HTTP handlers be registered in the web.config file. The ELMAH package includes a 
file named web.config.transform that specifies how to register them.

![](images/web.config.transform.png)

Suppose the XML in the web.config.transform file looks like the following example:

    <configuration>
        <system.web>
            <httpModules>
                <add name="ErrorLog" type="Elmah.ErrorLogModule, Elmah" />
            </httpModules>
            <httpHandlers>
                <add verb="POST,GET,HEAD" path="elmah.axd"
                  type="Elmah.ErrorLogPageFactory, Elmah" />
            </httpHandlers>
        </system.web>
        <system.webServer>
            <validation validateIntegratedModeConfiguration="false" />
            <modules>
                <add name="ErrorLog" type="Elmah.ErrorLogModule, Elmah" />
            </modules>
            <handlers>
                <add name="Elmah" verb="POST,GET,HEAD" path="elmah.axd"
                  type="Elmah.ErrorLogPageFactory, Elmah" />
            </handlers>
        </system.webServer>
    </configuration>

Furthermore, suppose you install the ELMAH package in a project that has the following web.config file:

    <configuration> 
      <system.web> 
        <compilation debug="true" targetFramework="4.0"> 
          <assemblies> 
            <add assembly="System.Data.Entity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" /> 
            <add assembly="System.Web.Entity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" /> 
          </assemblies> 
        </compilation> 
      </system.web> 
      <system.webServer> 
          <modules runAllManagedModulesForAllRequests="true"> 
              <add name="ErrorLog" /> 
          </modules> 
          <handlers> 
              <add name="Elmah" verb="HEAD" path="myOwnElmah.axd" type="My.Elmah, Elmah"/> 
          </handlers> 
      </system.webServer> 
    </configuration>

After you install the package, the **web.config** file looks like the following example 
(the changes are highlighted):

    <configuration> 
      <system.web> 
        <compilation debug="true" targetFramework="4.0"> 
          <assemblies> 
            <add assembly="System.Data.Entity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" /> 
            <add assembly="System.Web.Entity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" /> 
          </assemblies> 
        </compilation> 
    <httpModules> 
          <add name="ErrorLog" type="Elmah.ErrorLogModule, Elmah" /> 
        </httpModules> 
        <httpHandlers> 
          <add verb="POST,GET,HEAD" path="elmah.axd" type="Elmah.ErrorLogPageFactory, Elmah" /> 
        </httpHandlers> 
      </system.web> 
      <system.webServer> 
        <modules runAllManagedModulesForAllRequests="true"> 
          <add name="ErrorLog" type="Elmah.ErrorLogModule, Elmah" /> 
        </modules> 
        <handlers> 
          <add name="Elmah" verb="HEAD" path="myOwnElmah.axd" type="My.Elmah, Elmah" /> 
          <add name="Elmah" verb="POST,GET,HEAD" path="elmah.axd" type="Elmah.ErrorLogPageFactory, Elmah" /> 
        </handlers> 
        <validation validateIntegratedModeConfiguration="false" /> 
      </system.webServer> 
    </configuration>

The following changes have been made:

* `<httpModules>` and `<httpHandlers>` elements have been added under the `<system.web>` element.
* A type attribute has been added to the ErrorLog item in the `<system.webserver/modules>` collection. 
NuGet found an element with one matching attribute and one new one in the transformation file, so it 
added the attribute to the existing element. Note that when the package is removed, it will appear to 
NuGet that this element was added, so the entire element will be removed from the project's web.config file.
* A new Elmah item has been added to the `<system.webserver/handlers>` collection. NuGet found an element 
with one matching element and other non-matching elements, so it added the new element rather than change 
the existing one.
* A validation element has been added under the `<system.webserver>` element.

## Specifying Source Code Transformations

NuGet also supports source-code transformations that work somewhat like Visual Studio project templates. 
These transformations are useful if your NuGet package includes source code to be added to the project it's 
installed in. For example, you might want to include source code that's used to initialize your library, 
but you want the code to exist in the target project’s namespace.

You specify a source code transformation by including Visual Studio project properties in the code. The 
properties are delimited using dollar signs ($). For example, suppose you want to specify that the target 
project’s root namespace should be inserted into the namespace statement. The source code that you include 
in the project might look like the following example (the rootnamespace project property is highlighted):

    namespace $rootnamespace$.Models {
        public struct CategoryInfo {
            public string categoryid;
            public string description;
            public string htmlUrl;
            public string rssUrl;
            public string title;
        }
    }

In order to enable the transformation process for a source-code file, you append the .pp file extension 
to the name of the file, as shown in the following example

![](images/pp.files.png)

When the source-code files illustrated in the figure are installed, NuGet transforms the files, removes 
the .pp extension, and adds them to the target project’s ~/Models directory.

The `$rootnamespace$` token is the most commonly used project property, but any project property that's 
available when a package is installed can be used. (Some project properties might be specific to the 
current project type.) For more information about project properties, see [MSDN documentation for project 
properties](http://msdn.microsoft.com/en-us/library/vslangproj.projectproperties_properties(VS.80).aspx).

An example of source code that you might need to customize in the target project for is code that you 
would normally put in the **global.asax** file because it needs to run when the application starts. 
For more information about how to achieve this effect without updating the **global.asax** file, see 
[WebActivator](https://bitbucket.org/davidebbo/webactivator/wiki/Home).