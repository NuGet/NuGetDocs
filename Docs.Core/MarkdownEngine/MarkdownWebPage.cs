using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;
using System.Web.WebPages;
using HtmlAgilityPack;
using MarkdownSharp;

namespace Docs.Core.MarkdownEngine {
    /// <summary>
    /// Each markdown page is a web page that has this harcoded logic
    /// </summary>
    public class MarkdownWebPage : WebPage {
        private const int CacheTimeout = 24 * 60 * 60;
        private static List<string> _virtualPathDependencies = new List<string> { "~/Docs/_TableOfContents.cshtml", 
                                                                                  "~/_PageStart.cshtml", 
                                                                                  "~/_Layout.cshtml",
                                                                                  "~/Docs/_DocLayout.cshtml" };

        public override void Execute() {
            InitalizeCache();

            Page.Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Path.GetFileNameWithoutExtension(VirtualPath).Replace('-', ' '));

            // Get the page content
            string markdownContent = GetMarkdownContent();

            // Transform the markdown
            string transformed = Transform(markdownContent);

            // Write the raw html it to the response (unencoded)
            WriteLiteral(transformed);
        }

        private void InitalizeCache() {
            _virtualPathDependencies.Add(VirtualPath);
            CacheDependency cd = HostingEnvironment.VirtualPathProvider.GetCacheDependency(VirtualPath, _virtualPathDependencies.ToArray(), DateTime.UtcNow);
            Response.AddCacheDependency(cd);
            Response.OutputCache(CacheTimeout);
        }

        /// <summary>
        /// Transforms the raw markdown content into html
        /// </summary>
        private string Transform(string content) {
            var markdown = new Markdown();
            var fileContents = markdown.Transform(ProcessUrls(content));
            var docteredHTML = ProcessTableOfContents(fileContents);
            return docteredHTML;
        }

        /// <summary>
        /// Takes HTML and parses out all heading and sets IDs for each heading. Then sets the Headings property on the page.
        /// </summary>
        private string ProcessTableOfContents(string content) {
            var doc = new HtmlDocument();
            doc.OptionUseIdAttribute = true;
            doc.LoadHtml(content);

            var allNodes = doc.DocumentNode.DescendantNodes();
            var allHeadingNodes = allNodes.Where(node =>
                node.Name.Length == 2
                && node.Name.StartsWith("h", System.StringComparison.InvariantCultureIgnoreCase)
                && !node.Name.Equals("hr", StringComparison.InvariantCultureIgnoreCase)).ToList();

            var headings = new List<Heading>();
            foreach (var heading in allHeadingNodes) {
                var id = heading.InnerHtml.Replace(" ", "_");
                id = HttpUtility.HtmlAttributeEncode(HttpUtility.UrlEncode(id)); // TODO: What encoding should happen here?
                heading.SetAttributeValue("id", id);
                headings.Add(new Heading(id, Convert.ToInt32(heading.Name.Remove(0, 1)), heading.InnerText));
            }

            Page.Headings = headings;

            var docteredHTML = new StringWriter();
            doc.Save(docteredHTML);
            return docteredHTML.ToString();
        }

        /// <summary>
        /// Turns app relative urls (~/foo/bar) into the resolved version of that url for this page.
        /// </summary>
        private string ProcessUrls(string content) {
            return Regex.Replace(content, @"\((?<url>~/.*?)\)", match => "(" + Href(match.Groups["url"].Value) + ")");
        }

        /// <summary>
        /// Returns the markdown content within this page
        /// </summary>
        private string GetMarkdownContent() {
            VirtualFile file = HostingEnvironment.VirtualPathProvider.GetFile(VirtualPath);
            Stream stream = file.Open();
            using (var reader = new StreamReader(stream)) {
                return reader.ReadToEnd();
            }
        }
    }
}
