# Project.json Usage

Project.json is the file replacing package.config as the file specifying the packages used by the project. 

This document is provided for a deeper dive into the content and shape of the file, as well as for some advanced features not available directly through the UI. 


The project.json used by NuGet 3 has the following basic shape 

    { 
    
      "dependencies": { "PackageId" : "1.0.0" }, 
      "frameworks" : { "TxM" : {} }, 
      "runtimes" : { "RID": {}, "RID": {} }, 
      "supports" : { "CompatabilityProfile" : {}, "CompatabilityProfile" : {} } 
    
    }
   
## Dependencies 

Lists the nuget package dependencies of your project in the form of: 

    “PackageId” : “Version Constraint”.  
    
For example: 

    "dependencies": { 
    
       "Microsoft.NETCore": "5.0.0", 
       "System.Runtime.Serialization.Primitives": "4.0.10" 
    
    } 

The dependencies section is where the NuGet Package Manager dialog will add package dependencies to your project. 

The Package id corresponds to the id of the package on nuget.org , the same as the id used in the package manager console: `Install-Package Microsoft.NETCore` 

The version constraint of **"5.0.0"** corresponds to the **>= 5.0.0** constraint. This means that if for some reason 5.0.0 is not available on the server in 5.0.1 is, the restore will pick 5.0.1 and warn you about the upgrade. Otherwise restore will pick the lowest possible version on the server matching the constraint which will be 5.0.0. 

See dependency resolution document for more details on resolution rules. 

## Frameworks


This lists the frameworks that your project will run on. E.g. net45, dnxcore50, net40. 


     "frameworks": { 
    
       "netcore50": {} 
    
     } 


Unlike the project.json used by DNX a project.json that is being used with other project types can only have a single entry in the frameworks section. This is because the build system, MSBuild, only ever builds for a single target in contrast to DNX where the build is run once for each of the targets. 

## Runtimes 

The Operating System and Architectures that your application will be running on. For example, win7-x64, win8-x64, win8-x86. 

If you are a portable class library that can run on any runtime, you don't need to specify a runtime. Of course any dependencies of your package have to run on any runtime as well. 


	"runtimes": { 

        "win10-arm": { }, 
	    "win10-arm-aot": { }, 
	    "win10-x86": { }, 
	    "win10-x86-aot": { }, 
	    "win10-x64": { }, 
	    "win10-x64-aot": { } 

	} 


## Supports 

Is for defining a set to checks for the package dependencies. 

Here you are defining the places you expect the portable library/application to run, it is not restrictive, you may be able to run elsewhere but specifying things here will make NuGet check that all dependencies are able to be satisfied on the listed TxMs. This is similar to PCL profiles, without being restrictive. Examples of the values for this are: net46.app, dnxcore50.app, uwp.10.0.app. 


This section should be populated automatically when you select an entry in the Portable Class Library targets dialog. 

	supports": { 

	    "net46.app": {}, 
	    "uwp.10.0.app": {} 

	} 


## Imports  ##


Imports are designed to allow packages that use the dotnet TxM to operate with packages that don’t declare a dotnet TxM. If your project is using the dotnet TxM then all the packages you depend on must also have a dotnet TxM, unless you add the following to your project.json in order to allow non dotnet platforms to be compatible with dotnet. If you are using the dotnet TxM then the PCL project system will add the appropriate imports statement based on the supported targets. 


	"frameworks": { 

    	"dotnet": { “imports” : “portable-net45+win81” } 

	} 


# Project.lock.json  #


The project.lock.json is a file that is generated in the process of restoring the NuGet packages. It is a snapshot of all the information that is generated as NuGet walks the graph of packages and includes the version, contents, and dependencies of all the packages your application depends on. 


## Why do I need a lock file?  ##


* In NuGet v3 all packages are downloaded only once to a user level packages directory. The project.lock.json provides the package information to the build system to allow it to only pick packages from the global location that are relevant for the project it is building.  


* It stores the list of files and relevant content for compilation and runtime so that the build system only has to read a single file instead of many nuspec files.  


* When you actually lock the lock file, the package restore process skips the dependency resolution step. It will just download the files listed in the lock file. So when your lock file is locked NuGet will no longer resolve floating dependencies or do any of the other work from the dependency resolution process. 

## When should I lock the lock file? 

The canonical example for when you want to lock your lock file is when you have floating dependencies on internal packages that are undergoing churn that breaks your particular branch/project. In this scenario you would lock your lock file on a known-good set of packages until the packages you depend on are stable again. 


## Should I check in the lock file?  ##


In general it is not necessary to check in the lock file unless you have locked it. An unlocked lock file will be auto generated whenever a restore happens, so you can safely leave it out of source control and avoid and accidental merge conflicts. On git source control system and newer versions of TFS a .gitignore/.tfignore can be used to prevent this file from being checked in accidentally. 


However, if you are locking the lock file then it is likely that you want to check it in so that anyone that clones your repository/branch will get the locked file and the same packages that you are working with. If you are on a feature branch that only you work on then it might not be necessary, however if multiple people are working on your branch then you might want to check it in to make sure everyone has a stable dev experience. 


Checking in a non locked lock file is possible, and the diff will show the changes in dependencies resolved overtime. 


## Differences from DNX/ASP.NET 5  ##


The project.json file used by NuGet is a subset of that found in DNX projects. In DNX the project.json file is used for project metadata, compilation information, and dependencies. When used in other project systems those three things are split into separate files so the project.json specifies less information. Notable differences include: 

* There can only be one framework in the frameworks section 


* The framework should be empty, as shown above. No dependencies, compilation options, etc that you can see in DNX project.json files. Given that there can only be a single framework it doesn’t make sense to enter framework specific dependencies. 


* Compilation is handled by MSBuild so compilation options, preprocessor defines, etc are all part of the MSBuild project file and not your project.json.  



 


In NuGet 3 unlike in DNX/ASPNET 5 projects (at least for now) the user is not expected to manually edit the file, the UI is responsible for manipulating the content. we're working on unifying the experiences across the project systems for project.json, its not unified yet for this release. 


Note that it is possible to edit the file, the user is responsible to build the project to kick off a package restore.  
