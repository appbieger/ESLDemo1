using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("UnitTestESLCore")]
namespace ESLCore
{
    public class ESEngine
    {
        private readonly string url;
        private readonly string shortCut;
        private readonly string name;
        private readonly string id;

        public ESEngine(string url, string shortCut, string name, string id)
        {
            this.url = url;
            this.shortCut = shortCut;
            this.name = name;
            this.id = id;
        }

        internal string GetURL()
        {
            return url;
        }

        internal string GetName()
        {
            return name;
        }

        internal string GetShortCut()
        {
            return shortCut;
        }

        internal string GetID()
        {
            return id;
        }
    }
}
