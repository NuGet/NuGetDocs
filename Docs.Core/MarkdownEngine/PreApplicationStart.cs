using System.Web;
using System.Web.WebPages;
using Docs.Core.MarkdownEngine;

[assembly: PreApplicationStartMethod(typeof(PreApplicationStart), "Start")]

namespace Docs.Core.MarkdownEngine {
    public class PreApplicationStart {
        public static void Start() {
            // Register the markdown extension
            WebPageHttpHandler.RegisterExtension("markdown");

            // Register the markdown virtual path factory
            VirtualPathFactoryManager.RegisterVirtualPathFactory(new MarkdownVirtualPathFactory());
        }
    }
}
