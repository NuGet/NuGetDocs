# Project Guidelines

## Developer Workflow

Developers should follow the following workflow when working on items.

* Bug/work item is assigned to the developer via the *Triage Process* (see the next section) or developer assigns buck to him/herself and marks it as active. 
* Developer creates a fork for this change (or reuses one of his existing forks) 
* Developer clones the fork to his or her local machine and makes the changes, committing to their local repository and pushing to the fork on their server as needed. This can continue until all work is finished (The purpose of pushing to the fork is to keep changes on the server). 
* Developer pulls and rebases (using the <a title="Rebase Extension" href="http://hgtip.com/tips/advanced/2010-02-11-merging-mq-patches-with-rebase/">rebase extension</a>) his or her fork until it&rsquo;s up to date with Main. 
* Developer [requests a code review](Code-Reviews). 
* Once code review is finished, developer sends a pull request for Main. 
* One of the members of the integration team commits the changes to Main. 
* Once the change is committed, integration team sends the developer an email notifying that the change has been committed to main. 
Only then should the developer mark the item as *fixed* and assign it to Drew Miller per the triage process. 
* If you are creating a fork per change (and not reusing the fork), please delete the fork once it's been accepted. Thanks! 

Notes:

* Only members of the *integration team* may commit to main. Note that for members of the *Developers* group in this 
CodePlex project this is enforced by the process and trust as CodePlex will allow you to commit to main. We are not going to 
enforce this through the use of CodePlex groups for the time being. 
* We'll use rebase instead of merge as a default option of getting in sync with changes in Main. This keeps the history 
cleaner and simplifies code reviews. Make sure to 
<a title="Enable the rebase extension" href="http://hgtip.com/tips/advanced/2010-02-11-merging-mq-patches-with-rebase/">enable 
the rebase extension</a>. 

## Triage Process

We'll be using the following process to triage bugs in the issue tracker. This process may change as we refine our development workflow, but let's use this for now.

1. New bugs are opened with the "Proposed" status. 
2. During triage, we'll assign triaged bugs to a specific release (Or the hidden *Triage* release if we don't yet have a release in mind). In some cases, we'll also assign a developer. 
3. When developers pick a bug to work on, they should
    4. Assign it to themselves if it isn't already assigned to them. 
    5. Change the status to *Active* when you start working on it. 
1. When the bug is fixed, send a pull request. 
2. Once the pull request is accepted, change the status to *Fixed* and assign it to *aldion*. Please associate a changeset for the fix (This feature is not yet available, but will be in the next release).&nbsp; 
3. Once the bug is verified by someone else (typically the opener of the bug if it's a different person 
or a member of the QA team or both), only then will it get marked as *Closed*.

We will try to run a weekly triage process to manage the extensive list of bugs. 
However, given the distributed nature of open source development, we'll have to be flexible here. 
If there's a bug you feel strongly about and want to work on, but it hasn't been triaged yet, 
just send an email to the rest of the group for an ad-hoc triage.

Ideally, we should only work on issues that have been approved in triage (aka assigned to one of the releases). 
However, you can always feel free to work on an untriaged issue in a private fork as long as you are ok with the risk 
that the issue will be rejected when you submit the pull request. Ideally, 
just send an email to the team to let us know you're working on it.

## Source Tree Organization

* *LICENSE.txt* file at the root of the project trunk containing the copyright for the collective distribution and complete text for the license terms. 
* *CREDITS.txt* file wherever the LICENSE.txt file is located. Sample:

        NuGet Project
        ASP.NET Open Source Gallery at Outercurve Foundation
        Copyright 2010 Outercurve Foundation

        This product includes software developed at
        The Outercurve Foundation (http://www.outercurve.org/).

        NuGet includes or is derivative of works distributed under the licenses listed below. 
        The full text for most of the licenses listed below can be found in the LICENSE.txt file 
        accompanying each work. The original copyright notices have been preserved within 
        the respective files and or packages. Please refer to the specific files and/or packages 
        for more detailed information about the authors, copyright notices, and licenses.

        ProvideBindingPathAttribute (Visual Studio SDK)
        ----- 
        Website:      http://msdn.microsoft.com/en-us/library/bb166441(VS.80).aspx 
        Copyright:    Copyright (c) 2010 Microsoft
        License:      Apache 2.0

* 3rd party library dependencies should be located under a common directory within the project source tree, such as a *lib* folder. 
* Source file headers are not required and should not be used except in cases where we're incorporating OSS source code from another project. 

### 3rd Party Source Code Headers

When incorporating source code from a 3rd party, we should make sure to follow the proper steps mentioned above regarding giving proper credit. Each 3rd party source file should have a header that conforms to the license requirements. If the license does not provide a recommendation for the source file (for example, Apache has a recommended format), use the following as a template:

    /*
    COPYRIGHT YYYY AUTHORNAME

    Licensed to the Outercurve Foundation under one or more contributor license agreements.

    See the CREDITS.TXT file distributed with this work for additional information regarding copyright ownership. The Outercurve Foundation licenses this file under the LICENSE_NAME License (the "License"); you may not use this file except in compliance with the License.  You may obtain a copy of the License at:

        http://LICENSE_URL

    Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  See the License for the specific language governing permissions and limitations under the License.

    Source: http://OPTIONAL URL WHERE CODE WAS OBTAINED
    */

## Builds

The NuGet Continuous Integration (CI) server has builds directly from the source tree. 
This allows you to try out the latest successful unstable builds 
([NuGet.Tools.vsix](http://ci.nuget.org:8080/guestAuth/repository/download/bt4/.lastSuccessful/VisualStudioAddIn/NuGet.Tools.vsix)
|
[NuGet.exe](http://ci.nuget.org:8080/guestAuth/repository/download/bt4/.lastSuccessful/Console/NuGet.exe)).

Our TeamCity build server is at [http://ci.nuget.org:8080/](http://ci.nuget.org:8080/).
