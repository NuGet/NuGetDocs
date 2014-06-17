# NuGet Package Search Syntax

NuGet package search works the same whether you use the nuget.org website, or the Visual Studio Extensions.

## Search by Keywords

    modern UI javascript

Search will do its best effort to find relevant documents containing all 3 keywords, and return matching documents.

## Search using Phrases and keywords

    "modern UI" package

Entering a phrase between quotation marks ("") change the search to look for the particular phrase instead of separate keywords. 
Matching documents should usually contain the exact phrase "modern UI", including variations on capitalization e.g. 
"Modern ui", and also usually contain the word 'package'.

## Filtering on fields

You can search for a specific package ID (or 'Id' or 'id'), or certain other fields by prefixing search terms with the field name.

Currently the searchable fields are 'Id', 'Version', 'Tags', 'Author', and 'Owner'.

[What's the difference between ID and Title? ID is the name you use in package management console. Title is what is shown at the top of the package page in search results.]

### Examples:

    ID:jQuery
    id:NuGet.Core

finds packages with "jQuery" or "NuGet.Core" in their ID field respectively.

    Id:"Nuget.Core"

is another way to find packages with "NuGet.Core" in their ID field.

The 'Id' filter is a substring match, so if you search for the following:

    Id:jquery
    
You'll get results like 'jQuery.UI.Combined' and 'jQuery.Validation'. If you want to perform an exact search, use the 'packageid' field. This will filter to show **only** the one package with the ID you specified (or nothing if there is no package with that ID). For example:

    PackageId:jquery

You can also search for multiple keywords in a single field. Or mix and match fields.

    id:jquery tags:validation
    id:jquery id:ui

And you can perform phrase searches:

    id:"jquery.ui"
    
Finally, if you use a field we don't support, such as 'title', we'll just ignore it and search all the fields. So the following query

    title:jquery ui
    
Is interpreted exactly the same as this query:

    jquery ui
