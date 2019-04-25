using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("UnitTestESLCore")]
namespace ESLCore
{
    public class ESEngineController
    {
        private ESEngine e;
        private static readonly string seperator = ":";
        private static readonly int seperatorPosition = 3;
        private static readonly string searchActionSeperator = " - ";

        public ESEngineController(ESEngine e)
        {
            this.e = e;
        }

        internal bool ResponseToID(string v)
        {
            return this.e.GetID() == v;
        }

        internal bool ResponseToSearchString(string v)
        {
            if (v != null)
            {
                return v.ToLower().StartsWith(e.GetShortCut().ToLower() + GetSeperator());
            }
            return false;
        }

        internal string GetURL(string v)
        {
            if (v != null)
            {
                if (GetShortCutFromString(v) != null)
                {
                    string searchStringWithoutShortCut = GetSearchStringFromString(v);
                    return e.GetURL() + Uri.EscapeUriString(searchStringWithoutShortCut);
                }
                return e.GetURL() + Uri.EscapeUriString(v);
            }
            return e.GetURL();
        }

        static internal string GetSeperator()
        {
            return seperator;
        }

        internal int GetSeperatorPosition()
        {
            return seperatorPosition;
        }


        internal string GetSearchActionSeperatorn()
        {
            return searchActionSeperator;
        }

        internal string GetShortCutFromString(string v)
        {
            if (v != null)
            {
                int indexOfSeperator = v.IndexOf(ESEngineController.GetSeperator());
                if (indexOfSeperator == this.GetSeperatorPosition() - 1)
                {
                    return v.Substring(0, this.GetSeperatorPosition() - 1);
                }
            }
            return null;
        }

        internal string GetCompleatSearchString(string v)
        {
            if (v != null)
            {
                if (IsResondingToShortCut(v))
                {
                    return v;
                }
                return GetShortCut() + GetSeperator() + v;
            }
            return GetShortCut() + GetSeperator();
        }

        internal string GetShortCut()
        {
            return e.GetShortCut();
        }



        internal string GetSearchStringFromString(string v)
        {
            if (v != null)
            {
                int indexOfSeperator = v.IndexOf(ESEngineController.GetSeperator());
                if (indexOfSeperator == this.GetSeperatorPosition() - 1)
                {
                    return v.Substring(this.GetSeperatorPosition());
                }
            }
            return v;
        }

        internal string GetID()
        {
            return e.GetID();
        }

        internal string GetActionString(string v)
        {
            if (v != null)
            {
                if (v == "")
                {
                    return e.GetName();
                }
                if (this.IsResondingToShortCut(v))
                {
                    return v + searchActionSeperator + e.GetName();
                }
                return v + searchActionSeperator + e.GetName();
            }
            return e.GetName();
        }

        internal bool IsResondingToShortCut(string v)
        {
            if (this.GetShortCutFromString(v) != null)
            {
                return true;
            }
            return false;
        }
    }
}
