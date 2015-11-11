# Credential Providers

NuGet 3.3 now supports Credential Providers, which enable NuGet to work seamlessly with authenticated feeds. 
After you install a Credential Provider, NuGet will automatically acquire and refresh credentials for authenticated feeds as necessary.

NuGet Credential Providers can be used in 3 ways:
1. [Globally](#installing-a-credential-provider-globally)
2. [Environment Variable](#using-a-credential-provider-from-an-environment-variable)
3. [Alongside NuGet.exe](#using-a-credential-provider-alongside-nuget-exe)

## Installing a Credential Provider Globally

To make a Credential Provider available to all instances of NuGet.exe run under the current user's profile, 
add it to `%LocalAppData%\NuGet\CredentialProviders`. You may need to create the `CredentialProviders` folder.

Credential Providers can be installed at the root of the `CredentialProviders` folder or within a subfolder. If a Credential Provider has 
multiple files/assemblies, using subfolders can help keep the Providers organized.

## Using a Credential Provider from an Environment Variable

Credential Providers can also be stored anywhere and then made accessible to NuGet.exe via an environment variable. To use a Credential Provider
this way, set the `%NUGET_CREDENTIALPROVIDERS_PATH%` to the location of your Provider. The variable can be a semicolon-separated list &mdash; e.g. 
`path1;path2` &mdash; if you have have multiple Credential Providers in different locations.

## Using a credential provider alongside NuGet.exe

Credential Providers can also be placed in the same folder as NuGet.exe.