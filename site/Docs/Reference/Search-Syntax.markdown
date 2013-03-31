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

You can search for a specific package ID (or 'Id' or 'id'), a package Title, or certain other fields by prefixing search terms with the field name.

Currently the searchable fields are 'Title', 'Id', 'Description', 'Tags', and 'Author'.

[What's the difference between ID and Title? ID is the name you use in package management console. Title is what is shown at the top of the package page in search results.
Note that Titles often contain spaces but Package IDs are not allowed to contain spaces, and often contain dots.)]

### Examples:

    ID:jQuery
    id:NuGet.Core

finds packages with "jQuery" or "NuGet.Core" in their ID field respectively.

    Id:"Nuget.Core"

is another way to find packages with "NuGet.Core" in their ID field.

You can also search for multiple keywords in a single field, here we wish to search only the package description for two keywords 'Metro' and 'modern':

    description:Metro description:modern

And you can perform phrase searches

### More Examples:

    Title:MVC
    tags:MVC4
	description:validation
	description:"javascript library"
