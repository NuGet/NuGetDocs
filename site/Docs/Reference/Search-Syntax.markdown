# Nuget Package Search Syntax

The Nuget package search engine works the same whether accessed via the nuget.org website, or via package management tools (and Visual Studio), and understands several different types of queries.

## Search by Keywords

    modern UI javascript

Enter your keywords, and search finds documents which contain as many of the three keywords as possible. Keyword search is usually case insensitive.

## Search using Phrases

    "modern UI" package

Entering a phrase between quotation marks ("") boosts documents that have exact phrase matches. This search can finds documents which contain the exact phrase "modern UI", including any variation on capitalization e.g. "Modern ui" and those documents should also contain the word "package".

## Searching within fields

You can search based on a package ID (or 'Id' or 'id'), a package title, or certain other fields by prefixing search terms with the field name.

The searchable fields are 'Title', 'Id', 'Author', 'Description' and 'Tags'.

[What's the difference between ID and Title? These are often but not always the same. The most typical deviation is that package titles contain spaces. Package IDs are not allowed to contain spaces.)]

### Examples:

    ID:jQuery
    id:NuGet.Core

finds packages with "jQuery" or "NuGet.Core" in their ID field respectively.

    Id:"Nuget.Core"

is another way to find packages with "NuGet.Core" in their ID field.

You can also search for multiple keywords in a single field, here we wish to search only the package description for two keywords 'Metro' and 'modern':

    description:Metro description:modern

### More Examples:

    Title:MVC
    author:Haack
    tags:MVC4 description:validation
