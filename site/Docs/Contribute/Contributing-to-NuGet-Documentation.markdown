# Contributing to NuGet Documentation

These docs are written in markdown. For an introduction to markdown, see [our sample markdown](#Sample_Markdown). For documentation conventions, see [our documentation  conventions](#Documentation_Conventions).

## Workflow
The basic workflow for contributing to NuGet Docs is simple.

0. **Create a Fork.** Within the NuGet Docs codeplex website, create a fork. [Detailed instructions are below](#Create_a_Fork).

1. **Clone the repository.** [Mercurial](http://tortoisehg.bitbucket.org/download/index.html) (hg)
(for instructions using Visual Studio integration, see the next section, 
[Setting up Source Control with Visual HG](#Setting_up_Source_Control_with_Visual_HG))

        hg clone https://hg01.codeplex.com/{username}/{forkname}

2. **Edit the docs.** Open the `Site.sln` solution in Visual Studio (or Visual Web Developer) and 
edit the .markdown files within the `Docs` folder.
3. **Add new files to the repository.** If you add new files, be sure to run:

        hg add

4. **Commit changes.** Remember, this commits changes to your local repository.

        hg commit

5. **Push the repository.** When you are done with your changes, push your repository to your online fork.

        hg push

6. **[Send a pull request](#Send_a_Pull_Request)** and we&#8217;ll review 
your changes and if they&#8217;re good, we&#8217;ll pull them into the main docs.
7. **Admire your handy work!** by visiting http://docs.nuget.org/ !

## Setting up Source Control with Visual HG
If you have never used HG before or if you&#8217;d like a refresher 
then [HG init](http://hginit.com/) is a good starting point.

Another helpful tool to make editing our docs easy is [VisualHG](http://visualhg.codeplex.com), 
which integrates into Visual Studio.

The following steps will help you get started...

### Pre-requisites
1. Install VisualHg from [http://visualhg.codeplex.com](http://visualhg.codeplex.com).
2. Create a local folder for the NuGet docs repository such as `C:\dev\nugetdocs`.

### Create a Fork
Unless you have direct commit access to the repository (which most of you won&#8217;t), you&#8217;ll 
need to create a fork of the docs in order to contribute docs.

1. Navigate to the [Source Code tab](http://nugetdocs.codeplex.com/SourceControl/list/changesets) 
of the [NuGetDocs CodePlex website](http://nugetdocs.codeplex.com/).
2. Click on the **Create Fork** link. Enter a name and description for the fork and click **Save**.
    ![Creating a fork](images/creating-a-fork.png)
3. Once the fork is created, you&#8217;ll have a personalized repository URL for your fork that looks like:
**https://hg01.codeplex.com/forks/*{your-username}*/*{your-fork-name}***
    ![A Fork](images/list-of-forks.png)

### Clone the repository
There is a bug in VisualHG 1.4.1 that prevents cloning a repository directly from within Visual 
Studio in some machines. You can install TortoiseHG to do this.

1. **Using VisualHG** Clone the repository:
	1. Run VisualHg (from Visual Studio:  **File** -> **VisualHg** -> **Repo Browser**).  
    2. The **TortoiseHg Workbench** window is displayed.
	3. Select **File** -> **Clone Repository** to launch the Clone Repository Dialog.

2. **Using TortoiseHG** If the previous step fails due to the bug mentioned earlier, use TortoiseHG ([install](http://tortoisehg.bitbucket.org/download/index.html)) instead to clone the repository.
    1. Within Windows Explorer, right click on the local nuget docs folder you created.
    2. Select **TortoiseHG** -> **Clone** (or `CTRL+SHIFT+N`) to launch the Clone Repository Dialog.
    ![TortoiseHg Workbench](images/TortoiseHg-Workbench.png)
3. This brings up the Clone Repository dialog. Enter the URL to your fork (e.g. **https://hg01.codeplex.com/forks/myusername/myfork**) as the source 
and your local folder as the destination.<br />
    ![Clone dialog box](images/Clone-dialog-box.png)
4. For those of you more familiar with Team System or Subversion, the followings steps are useful for making 
VisualHG behave more like Subversion or TFS. Set up VisualHg to automatically "update" after "pull":
	1. From the **TortoiseHg Workbench** dialog box select **File** -> **Settings**.
	2. In the **TortoiseHg Settings** dialog box, click the tab for the NuGet Docs repository.
	4. Click **Workbench** on the left and make sure **After Pull Operation** is set to **Update** on the right.  
    ![Update after Pull](images/After-Pull-Operation.png)
5. To make a VisualHg "commit" work like a SVN or TFS check-in, set up Visual Hg to automatically "push" after "commit":
    1. In the **TortoiseHg Settings** dialog box, click the tab for the NuGet Docs repository.
	2. Click **Commit** on the left and put the repository URL in the **Push After Commit** box on the right. 
    ![Push after Commit](images/Push-After-Commit.png)
6. To make Visual Studio recognize markdown files and apply some of the 
markdown formatting while you edit, use the Extension Manager to find and install
the extension named "Markdown Mode".

### Write some documentation

1. Get the latest version of the docs (from **TortoiseHg Workbench** click **Pull Incoming Changes from Selected URL**).
2. Make your changes.
3. Test the changes by running the site locally (`CTRL + F5` in Visual Studio) and reviewing the docs.
3. Save your changes to the repository:
    1. Right-click the project or the folder that has your changes
	and select VisualHg -> Commit.
    2. The changed files about to be committed are shown and you are prompted to enter
	a brief comment describing the changes.  
	![Commit dialog box](images/VisualHG-Commit-dialog-box.png)
	3. Click Commit

### Send a Pull Request
1. When you&#8217;re done with all of your changes, go to the [Forks Page](http://nugetdocs.codeplex.com/SourceControl/network). 
2. To the right of your fork is a link to **Send Pull Request**.
3. Clicking this brings up a dialog to enter details about your pull request.

Once we get the pull request, we'll review it and merge the changes into the main docs.


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

#### Informatiom
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