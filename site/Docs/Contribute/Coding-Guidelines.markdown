# Coding Guidelines

Let's face it. No matter what coding guidelines we choose, we're not going to make everyone happy. 
In fact, some people out there might be downright angry at the choices we make. 
But the fact of the matter is that there is no "one true bracing style," despite 
<a title="The One True Bracing Style" href="http://en.wikipedia.org/wiki/Indent_style#Variant:_1TBS">attempts to name a bracing style as such</a>. 
While we would like to embrace everyone's individual style, working together on the same codebase would be utter chaos 
if we don't enforce some consistency. When it comes to coding guidelines, consistency can be even more important than 
being "right."

## Definitions

* <a href="http://en.wikipedia.org/wiki/CamelCase">Camel case</a> is a casing convention where the first letter is lower-case, words are not separated by any character but have their first letter capitalized. Example: <code>thisIsCamelCased</code>. 
* <a href="http://c2.com/cgi/wiki?PascalCase">Pascal case</a> is a casing convention where the first letter of each word is capitalized, and no separating character is included between words. Example: <code>ThisIsPascalCased</code>. 

## C# coding conventions

We are using the C# coding conventions described in this document: <a href="http://blogs.msdn.com/brada/articles/361363.aspx">C# Coding Guidelines</a> with the following exceptions:

* Opening braces are on the same line as the statement that begins the block, with a space before the brace (this is consistent with what we do in JavaScript), a.k.a. K&R convention. 
* Private fields are prefixed with an underscore and camel-cased. 
* Each file should not start with a copyright notice. The ones at the root of the source tree will suffice. 
* Regions (#region) are not used. 
* using statements are on top of a file (outside of namespace {...}) 
* Use var only if you have an anonymous type or you can clearly tell what the type is from the right hand side of the expression (see examples below). 

Examples:

    // This is ok
	var tuple = new { Name = >"John", Age = 50 }; 

	// This is ok
	var stream = new MemoryStream();

	// This is ok
	var product = (Product)GetProduct();

	// This is NOT ok
	var values = GetProducts();

Here is some sample code that follows these conventions.

	using System;
	namespace NuGet {
		public class ClassName {
			private List<SomeType> _privateMember;

			public List<SomeType>; SomeProperty {
				get {
					return _privateMember;
				}
			}

			public string SomeAutoProperty { get; set; }

			public string SomeMethod(bool someCondition) {
				if (someCondition) {
					DoSomething(someArgument);
				}
				else {
					return someArray[10];
				}

				switch (status) {
					case Status.Foo:
						return <span class="str">"Foo";

					case Status.Bar:
						return <span class="str">"Bar";

					default:
						return <span class="str">"Bar";
				}
				return String.Empty;
			}
		}
    }
		
## JavaScript coding conventions

* Namespaces are Pascal-cased. 
* Class names are Pascal-cased. 
* Plugin names are Camel-cased. 
* Properties, fields, local variables are Camel-cased. 
* Parameters are Camel-cased. 
* Function names are Camel-cased unless they really are class constructors or namespaces (in other words, global/local functions and methods are Camel-cased). 
* Private/internal/protected members are underscore-prefixed and Camel-cased. 
* Constants are just static fields (apply same rules as for fields). 
* JavaScript coding conventions follow C# conventions except for Pascal vs. Camel. 
* " and ' are interchangeable (strictly equivalent). XHTML attributes should be in double quotes and if code needs to be in there, it has to use single quotes. ex: (note: this kind of DOM-0 event creating is itself discouraged and is only shown here as an example). In pure JS code, use double quotes for string delimiters. When the string is one character and the intent is a character, use single quote for consistency with managed code. 
* There is no need for String.Empty, just use "". 
* Localizable strings need to be isolated into resource dictionaries until we figure out our client localization story. ex. alert(Foo.badArgument); ... Foo = {badArgument: "Teh argument was bad."}; 
* Don't worry about string concatenation unless you have specific evidence that regular concatenation is significantly harming performance in your specific scenario. 
* Use the <a href="http://en.wikipedia.org/wiki/Indent_style">K&R</a> style for opening braces (put the opening brace on the opening line). This is because in JavaScript, the semicolon is optional, which can cause difficult to spot bugs (see <a href="http://msmvps.com/blogs/luisabreu/archive/2009/08/26/the-semicolon-bug.aspx">http://msmvps.com/blogs/luisabreu/archive/2009/08/26/the-semicolon-bug.aspx</a> for an example). 
