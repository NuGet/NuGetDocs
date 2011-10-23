using System;
using System.Web.Hosting;
using System.Web.WebPages;

namespace Docs.Core.MarkdownEngine {
    public class MarkdownVirtualPathFactory : IVirtualPathFactory {
        public object CreateInstance(string virtualPath) {
            // All we need to do here is to create a new page.
            // REVIEW: We could do some smart caching but this is really fast and light.
            return new MarkdownWebPage();
        }

        public bool Exists(string virtualPath) {
            if (virtualPath.EndsWith(".markdown", StringComparison.OrdinalIgnoreCase)) {
                // Make sure the file exists in the vpp (basically on disk)
                return HostingEnvironment.VirtualPathProvider.FileExists(virtualPath);
            }
            return false;
        }
    }
}
