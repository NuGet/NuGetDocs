// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
namespace NuGet.Docs
{
    public class Heading
    {
        public string ID { get; private set; }
        public int Level { get; private set; }
        public string Text { get; private set; }

        public Heading(string id, int level, string text)
        {
            ID = id;
            Level = level;
            Text = text;
        }
    }
}