
# Allow multiple projects in the same directory


Here's the proposed feature for 2.8 to allow NuGet to work with the cases where people store multiple projects in the same directory.

**Problem:**

Some people like to store multiple projects in the same directory, which poses a problem with the current model because they can't have different **packages.config** files.


**Solution:**

1. If the project contains **packages.<project name>.config**, we will use it to load packages and store new packages.  

2. Otherwise, continue to use **packages.config**. 

3. Users are required to manually rename it to **packages.<project name>.config**. There’s no support from NuGet. 


**Project name normalization:**

To avoid potential bugs, NuGet will replace spaces in project name with underscores before looking up the config file.