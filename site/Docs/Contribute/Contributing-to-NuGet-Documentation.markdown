# Contributing to NuGet Documentation

These docs are written in markdown. For an introduction to markdown, see [our sample markdown](#Sample_Markdown). For documentation conventions, see [our documentation  conventions](#Documentation_Conventions).

## Making a change to existing documentation
The basic workflow for contributing to NuGet Docs is simple.

1. Visit the [NuGet Docs project on Github](https://github.com/NuGet/NuGetDocs/)

2. Fork the project. There's a big Fork button towards the upper right. That creates a copy of this project under your account. It's really fast and lets you make edits without worrying that you're affecting the real site.

3. Find the page you want to edit within the /site/Docs folder. This folder contains all of the documentation markdown files. 
For example, the page you're [reading is here](https://github.com/NuGet/NuGetDocs/blob/master/site/Docs/Contribute/Contributing-to-NuGet-Documentation.markdown).

4. Click the link labelled "Edit this file".

5. Edit the markdown, type in a commit message below, and click "Commit Changes".

6. Send a pull request for your change. There's a button near the top of the page that says "Pull Request". That's it!

## Adding a new document
Adding a new document requires that you use Git to clone the repository and send a pull request. 
If you don't know what that means or how to use Git, feel free to propose that the NuGet team add a new page for you to edit.

## Documentation Conventions

1. All documentation is placed under the "docs" folder in the site.
2. Folder/File names use dashes (Tilde Slash) as separators.
3. Use relative URL for images and links (tilde slash will be resolved if you use it).


## Sample Markdown

### Code and Preformatted Text

Indent four spaces to create an escaped &lt;pre&gt;&lt;code&gt; block:

    printf("goodbye world!");  /* his suicide note
                                  was in C */
The text will be wrapped in tags, and displayed in a monospaced font. The first four spaces will 
be stripped off, but all other whitespace will be preserved.

Markdown and HTML is ignored within a code block:

    <blink>
       You would hate this if it weren't
       wrapped in a code block.
    </blink>

### Message Boxes
We have added support for some well know classes to add styles to draw attention to items you want 
to call out in a document. Unfortunately mark down does not have a way to added class attributes 
so you will have to write the HTML by hand and embed it.

#### Information
<p class="info">
    &lt;p class="info"&gt;Some Informational Text...&lt;/p&gt;
</p>

#### Caution
<p class="caution">
    &lt;p class="caution"&gt;Some Caution Text...&lt;/p&gt;
</p>

#### Error
<p class="error">
    &lt;p class="error"&gt;Some Error Text...&lt;/p&gt;
</p>

### Code Spans

Use backticks to create an inline &lt;code&gt; span:

Press the `<Tab>` key, then type a `$`.
(The backtick key is in the upper left corner of most keyboards.)

Like code blocks, code spans will be displayed in a monospaced font. Markdown and HTML will not 
work within them. Note that, unlike code blocks, code spans require you to manually escape any 
HTML within!

### Linebreaks

End a line with two spaces to add a &lt;br/&gt; linebreak:

How do I love thee?    
Let me count the ways
Italics and Bold

*This is italicized*, and so is _this_.
**This is bold**, and so is __this__.
Use ***italics and bold together*** if you ___have to___.

###Basic Links

There are three ways to write links. Each is easier to read than the last:

Here's an inline link to [Google](http://www.google.com/).
Here's a reference-style link to [Google][1].
Here's a very readable link to [Yahoo!][yahoo].

  [1]: http://www.google.com/
  [yahoo]: http://www.yahoo.com/
The link definitions can appear anywhere in the document -- before or after the place where you 
use them. The link definition names [1] and [yahoo] can be any unique string, and are case-insensitive; 
[yahoo] is the same as [YAHOO].

### Advanced Links

Links can have a title attribute, which will show up on hover. Title attributes can also be added; they 
are helpful if the link itself is not descriptive enough to tell users where they're going.

Here's a [poorly-named link](http://www.google.com/ "Google").
Never write "[click here][^2]".
Visit [us][web].

  [^2]: http://www.w3.org/QA/Tips/noClickHere
        (Advice against the phrase "click here")
  [web]: http://stackoverflow.com/ "Stack Overflow"
You can also use standard HTML hyperlink syntax.

<a href="http://example.com" title="example">example</a>
### Bare URLs

We have modified our Markdown parser to support "naked" URLs (in most but not all cases -- beware of 
unusual characters in your URLs); they will be converted to links automatically:

I often visit http://example.com.
Force URLs by enclosing them in angle brackets:

Have you seen <http://example.com>?
All URLs must be fully qualified path names. We do not support relative paths.

### Horizontal Rules

Insert a horizontal rule &lt;hr/&gt; by putting three or more hyphens, asterisks, or underscores 
on a line by themselves:

Rule #1

---

Rule #2

*******

Rule #3

___

Using spaces between the characters also works:

Rule #4    

- - - -

### Simple lists

A bulleted &lt;ul&gt; list:

- Use a minus sign for a bullet
+ Or plus sign
* Or an asterisk
A numbered &lt;ol&gt; list:

1. Numbered lists are easy
2. Markdown keeps track of the numbers for you
7. So this will be item 3.
A double-spaced list:

- This list gets wrapped in &lt;p&gt; tags
 
- So there will be extra space between items
Advanced lists: Nesting

To put other Markdown blocks in a list; just indent four spaces for each nesting level:

1. Lists in a list item:
    - Indented four spaces.
        * indented eight spaces.
    - Four spaces again.
2.  Multiple paragraphs in a list items:
    It's best to indent the paragraphs four spaces
    You can get away with three, but it can get
    confusing when you nest other things.
    Stick to four.
 
    We indented the first line an extra space to align
    it with these paragraphs.  In real use, we might do
    that to the entire list so that all items line up.
 
    This paragraph is still part of the list item, but it looks messy to humans.  So it's a 
	good idea to wrap your nested paragraphs manually, as we did with the first two.
 
3. Blockquotes in a list item:
 
> Skip a line and
    > indent the >'s four spaces.
 
4. Preformatted text in a list item:
 
        Skip a line and indent eight spaces.
        That's four spaces for the list
        and four to trigger the code block.
### Simple Blockquotes

Add a > to the beginning of any line to create a &lt;blockquote&gt;.

> The syntax is based on the way email programs
> usually do quotations. You don't need to hard-wrap
> the paragraphs in your blockquotes, but it looks much nicer if you do.  Depends how lazy you feel.
Advanced blockquotes: Nesting

To put other Markdown blocks in a &lt;blockquote&gt;, just add a &gt; followed by a space:

> The > on the blank lines is optional.
> Include it or don't; Markdown doesn't care.
> 
> But your plain text looks better to
> humans if you include the extra `>`
> between paragraphs.
Blockquotes within a blockquote:

> A standard blockquote is indented
> > A nested blockquote is indented more
> > > > You can nest to any depth.
Lists in a blockquote:

> - A list in a blockquote
> - With a > and space in front of it
>    * A sublist
Preformatted text in a blockquote:

>     Indent five spaces total.  The first
>     one is part of the blockquote designator.
Images

Images are exactly like links, but they have an exclamation point in front of them:

![Valid XHTML](http://w3.org/Icons/valid-xhtml10).
The word in square brackets is the alt text, which gets displayed if the browser can't show 
the image. Be sure to include meaningful alt text for screen-reading software.

Just like links, images work with reference syntax and titles:

This page is ![valid XHTML][checkmark].
 
[checkmark]: http://w3.org/Icons/valid-xhtml10
             "What are you smiling at?"
Note: Markdown does not currently support the shortest reference syntax for images:

Here's a broken ![checkmark].
But you can use a slightly more verbose version of implicit reference names:

This ![checkmark][] works.
The reference name is also used as the alt text.

### Inline HTML

If you need to do something that Markdown can't handle, use HTML. Note that we only support a very strict subset of HTML!

 Strikethrough humor is <strike>funny</strike>.
Markdown is smart enough not to mangle your span-level HTML:

<u>Markdown works *fine* in here.</u>
Block-level HTML elements have a few restrictions:

They must be separated from surrounding text by blank lines.
The begin and end tags of the outermost block element must not be indented.
Markdown can't be used within HTML blocks.
<pre>
    You can <em>not</em> use Markdown in here.
</pre>