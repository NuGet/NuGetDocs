// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.WebPages;

[assembly: PreApplicationStartMethod(typeof(NuGet.Docs.MarkdownPathFactory), "Register")]

namespace NuGet.Docs
{
    public class MarkdownPathFactory : IVirtualPathFactory
    {
        public static void Register()
        {
            // Register the markdown extensions (md first since it's preferred)
            WebPageHttpHandler.RegisterExtension("md");
            WebPageHttpHandler.RegisterExtension("markdown");

            // Register the markdown virtual path factory
            VirtualPathFactoryManager.RegisterVirtualPathFactory(new MarkdownPathFactory());
        }

        public object CreateInstance(string virtualPath)
        {
            return new MarkdownWebPage();
        }

        public bool Exists(string virtualPath)
        {
            if (virtualPath.EndsWith(".md", StringComparison.OrdinalIgnoreCase)
                || virtualPath.EndsWith(".markdown", StringComparison.OrdinalIgnoreCase))
            {
                return HostingEnvironment.VirtualPathProvider.FileExists(virtualPath);
            }

            return false;
        }
    }
}
