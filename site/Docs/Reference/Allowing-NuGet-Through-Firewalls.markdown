# Allowing Access to NuGet.org Through Firewalls

We occasionally get questions from companies whose developers need to gain access to nuget.org, but the company firewalls are pretty locked down. They ask us what all they need to open up to give their developers access and sometimes they ask whether it's safe to grant the access.

## Domains Used

In order to give complete access to NuGet.org, developers' machines will need to be able to connect via HTTP to the following domains:

1. *.nuget.org
1. az320820.vo.msecnd.net (our current CDN domain)

We suggest using *.nuget.org so that the following properties can be consumed:

1. **www.nuget.org** - The website and the root of the package sources configured by default
1. **docs.nuget.org** - This documentation website
1. **blog.nuget.org** - Where we blog about the project
1. **status.nuget.org** - Our system monitoring status page
1. **preview.nuget.org** - This is where we're currently exposing our preview API v3 feed protocol
1. **api.nuget.org** - This is where we expect to put our production API v3 feed

## Is NuGet.org Safe?

The repository of packages at nuget.org is community curated. There’s no guarantee of the cleanliness of the software found in the repository—it’s an open repository. We take reports of malicious packages very seriously and we act upon them right away.

## What Is In a Package?

The packages are served as .nupkg files, which are themselves ZIP files ([OPC](http://en.wikipedia.org/wiki/Open_Packaging_Conventions#File_formats_using_the_OPC) to be specific). These .nupkg files will contain .js files, .dll files, .exe files, and other forms of executable code. If your firewall is performing scanning of the contents of the .nupkg, you should expect these (and other) forms of files to be included.
