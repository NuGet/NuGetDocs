# NuGet Configuration Settings
There are a bunch of NuGet configuration values which can be set via the nuget.config file.
Below is the summary of the NuGet config keys and their usage.

<table class="reference" border="1">
<tbody>
    <tr>
        <th>Settings  </th> <th>Key Name</th> <th>Description</th>
    </tr>
    <tr>
    <td> Repository path </td>
    <td>"repositoryPath" </td>
    <td>
       Allows  you to install the NuGet packages in the specified folder, instead of the default "$(Solutiondir)\Packages" folder. <br/>
       This key can be added to the NuGet.config file manually or using the <a href="Command-Line-Reference#Config Command"> NuGet.exe Config -Set command.  </a>  <br/>
       More details <a href="../Release-Notes/NuGet-2.1#Specify-%e2%80%98packages%e2%80%99-Folder-Location">here.</a>

	<pre><code>
    &lt;config&gt;
     &lt;add key="repositorypath" value="C:\Temp" /&gt;
    &lt;/config&gt;
	</pre></code>
	

   
    </td>
    </tr>
	<tr>
	<td> Package Restore
	</td>
	<td> "enabled" and "automatic" under the section "packageRestore"

	</td>
	<td>
	Allows you to restore missing packages from the NuGet source during build.<br/>
	The environment variable "EnableNuGetPackageRestore" with a value of "true" can be used in place of the "enabled" key in the config file.<br/>
	More details <a href="Package-Restore"> here.</a>

	<pre><code>
	&lt;packageRestore&gt;
		&lt;!-- Allow NuGet to download missing packages --&gt;
		&lt;add key="enabled" value="True" /&gt;

		&lt;!-- Automatically check for missing packages during build in Visual Studio --&gt;
		&lt;add key="automatic" value="True" /&gt;
	&lt;/packageRestore&gt;
	</pre></code>

	</td>	  
	</tr>
	<tr>
	<td> Package sources
	</td> 
	<td> "activePackageSource" , "packageSources" , "disabledPackageSources"
	</td>
	<td>
	   Allows you to specify the list of sources to be used while looking for packages. <br/>
	   
	- "PackageSources" section has the list of package sources. <br/> 
	- "DisabledPackageSources" has the list of sources which are currently disabled.  <br/>
	- "ActivePackageSource" points to the currently active source. Speciying "(Aggregate source)" as the source value would imply that all the current package sources except for the disabled ones are active.<br/></br> </br>

		The values can be added to the config file directly or using the package manager settings UI ( which would in turn update the NuGet.config file) or using the <a href="Command-Line-Reference#Sources-Command">NuGet.exe Sources command.</a>

	<pre><code>
	&lt;packageSources&gt;
		&lt;add key="NuGet official package source" value="https://nuget.org/api/v2/" /&gt;
		&lt;add key="TestSource" value="C:\Temp" /&gt;
	&lt;/packageSources&gt;
	&lt;disabledPackageSources /&gt;
	&lt;activePackageSource&gt;
		&lt;add key="All" value="(Aggregate source)"  /&gt;
	&lt;/activePackageSource&gt;
	</pre></code>

	</td>
	</tr>
	<tr>
	<td> Source control integration

	</td>
	<td> "disableSourceControlIntegration" under section "solution"
	</td>
    <td>
	Allows you to disable source control integration for the "Packages" folder. This key works at the solution level and hence need to be added to the NuGet.config file present in the "$(SolutionDir)\.nuget directory". Enabling package restore from VS would add the .nuget\nuget.config file automatically. More details <a href="..\Workflows\Using-NuGet-without-committing-packages"> here.</a>
    <br/>

	The default value for this key is true.
	<pre><code>
	&lt;solution&gt;
		&lt;add key="disableSourceControlIntegration" value="true" /&gt;
	&lt;/solution&gt;
	</code></pre>

	</td>
	</tr>
	<tr>
	<td>  Proxy settings
	</td>
	<td> "http_proxy" ,  "http_proxy.user", "http_proxy.password" 

	</td>
	<td>
	Allows you to set the proxy settings to be used while connecting to your NuGet feed.
	More details <a href="http://skolima.blogspot.com/2012/07/nuget-proxy-settings.html">here.</a>
	<br/>

	This key can be added using <a href="Command-Line-Reference#Config Command">NuGet.exe Config -Set command.</a> <br/><br/>It can also be set via environment variable "http_proxy". While setting env variable, the value should  be specified in the format 'http://[username]:[password]@proxy.com'.
	Note, the "http_proxy.password" key value is encrypted before storing in the nuget.config file. Hence it can not be added manually by directly updating the config file.

	</td>
	</tr>
	<tr>
	<td> Credentials for package source
	</td>
	<td> "Username",  "Password" and "ClearTextPassword" under section "packageSourceCredentials" 
	</td>
	<td>
	Allows you to set the credentials to access the given package source. <br/>
	This key has to be set using the <a href="Command-Line-Reference#Sources-Command">NuGet.exe Sources command.</a> <br/>
	The default behavior is to store the password encrypted in the config file. <br/> <br/>

		<i>NuGet.exe  Sources  Add  -Name  &lt;feedName&gt; -Source &lt;pathToPackageSource&gt; -UserName  xxx   -Password &lt;secret&gt;  </i><br/>
		<i>NuGet.exe  Sources  Update  -Name  &lt;feedName&gt; -Source &lt;pathToPackageSource&gt; -UserName  xxx   -Password &lt;secret&gt; </i><br/><br/>

	This results in something similar to this:<br/>
	<pre><code>
		&lt;packageSourceCredentials&gt;
			&lt;feedName&gt;
				&lt;add key="Username" value="xxx" /&gt;
				&lt;add key="Password" value="...encrypted..." /&gt;
			&lt;/feedName&gt;
		&lt;/packageSourceCredentials&gt;
	</code></pre>

	If you want to share the credentials with others then you might want to use the -StorePasswordInClearText option to disable password encryption.<br/>
	Using this option allows you to store the password in clear text, for instance in your solution-local nuget.config using the new <a href="Command-Line-Reference">-Config option</a>, and commit it to your VCS.<br/><br/>

		<i>NuGet.exe  Sources  Add  -Name  &lt;feedName&gt; -Source &lt;pathToPackageSource&gt; -UserName  xxx  -Password  &lt;secret&gt;  -StorePasswordInClearText -Config &lt;path to nuget.config&gt;</i><br/>
		<i>NuGet.exe  Sources  Update  -Name  &lt;feedName&gt; -Source &lt;pathToPackageSource&gt; -UserName  xxx  -Password &lt;secret&gt; <i>-StorePasswordInClearText</i> -Config &lt;path to nuget.config&gt;</i><br/><br/>

	This results in something more readable (or even manually configurable):<br/>
	<pre><code>
		&lt;packageSourceCredentials&gt;
			&lt;feedName&gt;
				&lt;add key="Username" value="xxx" /&gt;
				&lt;add key="ClearTextPassword" value="secret" /&gt;
			&lt;/feedName&gt;
		&lt;/packageSourceCredentials&gt;
	</code></pre>
	</td>
	</tr>
	<tr>
	<td> API Key to access package source

	</td>
	<td>
	</td>
	<td>
	Allows you to set the API Key corresponding to a specific package source.<br/>

	This key  has to be set via <a href=".\Command-Line-Reference#Setapikey-Command">NuGet -SetApiKey. </a>
	</td>
	</tr>

   </tbody>
   </table>
