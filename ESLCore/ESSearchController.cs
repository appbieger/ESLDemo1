using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTestESLCore")]
namespace ESLCore
{
    public  interface ESSearchControllerInterface
    {
        string GetActionTextFor(string v);
        string SelectNext(string v);
        string SelectPrev(string v);
        string GetURLForSearchString(string v);
    }
    
    public class ESSearchController : ESSearchControllerInterface
    {
        internal ESEngineController[] EngineCollection { get; set; }

        public ESEngineController DefaultEngine { get; set; } = new ESEngineController(new ESEngine("https://groupfind.volkswagenag.com/jctgroupfind/groupfind2/search?q=", "gf", "GroupFind", "com.volkswagenag.groupfind"));
        static internal ESEngineController EngineGroupFind { get; } = new ESEngineController(new ESEngine("https://groupfind.volkswagenag.com/jctgroupfind/groupfind2/search?q=", "gf", "GroupFind", "com.volkswagenag.groupfind"));
        static internal ESEngineController EngineGoogle { get; } = new ESEngineController(new ESEngine("https://www.google.com/search?q=", "go", "Google", "com.google"));
        static internal ESEngineController EngineBing { get; } = new ESEngineController(new ESEngine("https://www.bing.com/search?q=", "bi", "Bing", "com.bing"));
        static internal ESEngineController EngineDuckDuckGo { get; } = new ESEngineController(new ESEngine("https://www.duckduckgo.com/search?q=", "dd", "DuckDuckGo", "com.duckduckgo"));
        static internal ESEngineController EngineWikipedia { get; } = new ESEngineController(new ESEngine("https://en.wikipedia.org/w/index.php?search=", "wp", "Wikipedia", "org.wikipedia.de"));
        static internal ESEngineController EngineStackoverflow { get; } = new ESEngineController(new ESEngine("https://stackoverflow.com/search?q=", "so", "Stackoverflow", "com.stackoverflow"));

        public ESSearchController() : this(new ESEngineController[]
                {EngineGroupFind,EngineGoogle,EngineBing,EngineDuckDuckGo,EngineWikipedia,EngineStackoverflow}) 
        {   
        }

        public ESSearchController(ESEngineController[] EngineCollection)
        {
            this.EngineCollection = EngineCollection;
        }

        public string GetActionTextFor(string v)
        {
            foreach (ESEngineController ec in EngineCollection)
            {
                if (ec.ResponseToSearchString(v))
                {
                    string action = ec.GetActionString(v);
                    if (action != null)
                    {
                        return action;
                    }
                }
            }
            return DefaultEngine.GetActionString(v); ;
        }

        internal ESEngineController GetEngineByID(string v)
        {
            foreach (ESEngineController ec in EngineCollection)
            {
                if (ec.ResponseToID(v)){
                    return ec;
                }
            }
            return null;
        }

        internal ESEngineController GetEngineByString(string v)
        {
            foreach (ESEngineController ec in EngineCollection)
            {
                if (ec.ResponseToSearchString(v))
                {
                    return ec;
                }
            }
            return null;
        }

        public string GetURLForSearchString(string v)
        {
            foreach (ESEngineController ec in EngineCollection)
            {
                if (ec.ResponseToSearchString(v))
                {
                    return ec.GetURL(v);
                }
            }
            return DefaultEngine.GetURL(v);
        }
        

        public string SelectNext(string v)
        {
            ESEngineController newEngine = DefaultEngine;

            string cleanText = newEngine.GetSearchStringFromString(v);
            string shortCut = newEngine.GetShortCutFromString(v);
            if (shortCut != null)
            {
                for (int i = 0; i < EngineCollection.Length; i++)
                {
                    if (EngineCollection[i].GetShortCut() + ESEngineController.GetSeperator() == (shortCut + ESEngineController.GetSeperator()))
                    {
                        if (i < EngineCollection.Length -1)
                        {
                            newEngine = EngineCollection[i + 1];
                        }
                        else
                        {
                            newEngine = EngineCollection[i];
                        }
                    }
                }
            }
            return newEngine.GetCompleatSearchString(cleanText);
        }


        public string SelectPrev(string v)
        {
            ESEngineController newEngine = DefaultEngine;

            string cleanText = newEngine.GetSearchStringFromString(v);
            string shortCut = newEngine.GetShortCutFromString(v);
            if (shortCut != null)
            {
                for (int i = 0; i < EngineCollection.Length; i++)
                {
                    if (EngineCollection[i].GetShortCut() + ESEngineController.GetSeperator()  == (shortCut + ESEngineController.GetSeperator()))
                    {
                        if (i >= 1)
                        {
                            newEngine = EngineCollection[i - 1];
                        }
                        else
                        {
                            newEngine = EngineCollection[i];
                        }
                    }
                }
            }

            return newEngine.GetCompleatSearchString(cleanText);
        }
    }
}
