using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Docs.Core {
    public class Topic {
        private const string MetadataFile = "_metadata";

        public string Title { get; private set; }
        public string Url { get; private set; }
        public IEnumerable<Topic> SubTopics { get; private set; }

        public Topic() {
            SubTopics = new List<Topic>();
        }

        /// <summary>
        /// Gets a list of topics from the a directory. Only supports one level of nesting.
        /// </summary>
        public static IEnumerable<Topic> GetTopics(string virtualPath) {
            VirtualDirectory topicDir = HostingEnvironment.VirtualPathProvider.GetDirectory(virtualPath);
            Func<string, Metadata> getTopicMetadata = GetMetadataMapping(virtualPath);

            return from directory in topicDir.Directories.Cast<VirtualDirectory>()
                   let title = GetTitle(directory)
                   let metadata = getTopicMetadata(title)
                   let getSubTopicMetadata = GetMetadataMapping(directory.VirtualPath)
                   orderby metadata.Order, title
                   select new Topic {
                       Title = title,
                       SubTopics = from file in directory.Files.Cast<VirtualFile>()
                                   let subTitle = GetTitle(file)
                                   let subMetadata = getSubTopicMetadata(subTitle)
                                   where !subTitle.Equals(MetadataFile, StringComparison.OrdinalIgnoreCase)
                                        && Path.GetExtension(file.Name) == ".markdown"
                                   orderby subMetadata.Order, subTitle
                                   select new Topic {
                                       Title = subTitle,
                                       Url = GetUrl(file)
                                   }
                   };

        }

        /// <summary>
        /// The order mapping is a file named order in the same virtual path.
        /// </summary>
        private static Func<string, Metadata> GetMetadataMapping(string virtualPath) {
            var vpp = HostingEnvironment.VirtualPathProvider;
            string metadataFile = VirtualPathUtility.AppendTrailingSlash(virtualPath) + MetadataFile;

            var mapping = new Dictionary<string, Metadata>();
            int index = 0;
            if (vpp.FileExists(metadataFile)) {
                VirtualFile file = vpp.GetFile(metadataFile);
                Stream stream = file.Open();
                using (var reader = new StreamReader(stream)) {
                    string line = null;
                    while ((line = reader.ReadLine()) != null) {
                        mapping[Normalize(line)] = new Metadata {
                            Order = index++
                        };
                    }
                }
            }

            return title => {
                Metadata metadata;
                if (mapping.TryGetValue(title, out metadata)) {
                    return metadata;
                }
                return Metadata.Empty;
            };
        }

        private static string GetTitle(VirtualDirectory dir) {
            return Normalize(dir.VirtualPath.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries).Last());
        }

        private static string GetTitle(VirtualFile file) {
            return Normalize(Path.GetFileNameWithoutExtension(file.VirtualPath));
        }

        private static string Normalize(string path) {
            return path.Replace("-", " ").Trim();
        }

        private static string GetUrl(VirtualFile file) {
            string dir = VirtualPathUtility.GetDirectory(file.VirtualPath);
            string filePath = Path.GetFileNameWithoutExtension(file.VirtualPath);
            return VirtualPathUtility.Combine(dir, filePath).ToLowerInvariant();
        }

        private class Metadata {
            public static readonly Metadata Empty = new Metadata() {
                Order = Int32.MaxValue
            };

            public int Order { get; set; }
        }
    }
}
