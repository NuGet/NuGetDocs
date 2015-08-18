##Analyzer Nuget Format##
The proposed format should be identical to the format described [here](https://docs.nuget.org/Create/Enforced-Package-Conventions), except the specifiers in the path describe development host dependencies instead of build-time.

$/analyzers/{**Framework Name**}{**Version**}/{**Supported Architecture**}/**{Supported Programming Language**}/{**Analyzer**}.dll

**Framework Name and Version** the *optional* API surface area of the .NET framework that the contained dlls need to run. If no target is specified, dlls are assumed to apply to *all* targets

example:

- dotnet
- net45
- wp10
- win10
- win8

**Supported Programming Language** the language specific dlls that should be loaded only when the project language and the dll language match. If no language is specified then dll is assumed to apply to *all* languages that support analyzers.

valid values:

- cs -> represents C#
- vb -> represents Visual Basic
- fs -> represents F#


**Analyzer** The analyzer or analyzer dependency dll.  If the analyzer requires additional files beyond dlls their inclusion will need to be explained in a targets or properties files.


##Example Analyzer Packages##

### System.Runtime.Analyzers ###
Because System.Runtime.Analyzers has no platform specific requirements the platform folder is omitted. Properties files are included to disable legacy FxCop rules in favor of the analyzer implementation. 

- analyzers\dotnet\System.Runtime.Analyzers.dll 
- analyzers\dotnet\cs\System.Runtime.CSharp.Analyzers.dll 
- analyzers\dotnet\vb\System.Runtime.VisualBasic.Analyzers.dll
- build\System.Runtime.Analyzers.Common.props
- build\System.Runtime.Analyzers.props
- build\System.Runtime.CSharp.Analyzers.props
- build\System.Runtime.VisualBasic.Analyzers.props

##Notes on Using Target Framework Other Than 'dotnet'##

At this time there is no host other than Roslyn compiler that can run analyzers.  Therefore, **Framework Name and Version** should always be specified as 'dotnet' until another host is implemented that has runtime restrictions.