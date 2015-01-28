# Setting up a NuGet Powershell Profile
Powershell supports the concept of profiles which allow you to have commonly used PS commands available to you wherever you 
use PowerShell.

NuGet supports a NuGet specific profile typically located at:

    %UserProfile%\Documents\WindowsPowerShell\NuGet_profile.ps1

The easiest way to find the profile file is to type `$profile` within the NuGet Package Manager Console. 
For example, this is what I see on my machine.

    PM> $profile
    C:\Users\philha\Documents\WindowsPowerShell\NuGet_profile.ps1

This file doesn't necessarily exist by default. You can run the following set of commands to create it.

    PM> mkdir -force (split-path $profile)
    PM> notepad $profile

The first command creates the *WindowsPowershell* directory if it doesn&#8217;t already exist. 
The second command attempts to open the profile file in Notepad. If it doesn&#8217;t already exist, 
it prompts you to create the file. Within the profile file, you can change PowerShell settings or 
add new commands you might find useful.

Here is a simple example of adding a command that allows you to set the font.

    function Set-FontSize {
        param(
            [ValidateRange(6, 128)]
            [Parameter(position=0, mandatory=$true)]
            [int]$Size
        )
       $dte.Properties("FontsAndColors", "TextEditor").Item("FontSize").Value = $Size
    }

Save the profile file and then restart Visual Studio. The next time you open the Package Manager Console, 
you will be able to make use of the `Set-Font` command.

    PM> Set-FontSize 24

That makes for much more readable code!
