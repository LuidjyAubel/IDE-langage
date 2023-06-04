using System;
using System.Collections.Generic;
using System.Text;

namespace IDE_langage
{
    class Str
    {
        private Dictionary<string, string> tabString;
        public Str() { 
            tabString = new Dictionary<string, string>();
        }
        public void Dump()
        {
            Program.Form1.Write("----STRING----");
            Program.Form1.ln();
            foreach (var kvp in tabString)
                Program.Form1.Write("Key: " + kvp.Key + " value: " + kvp.Value+"\n");
        }
        public void setString(string nomVar, string val)
        {
            if (tabString.ContainsKey(nomVar))
            {
                tabString[nomVar] = val;
            }
            else
            {
                tabString.Add(nomVar, val);
            }
            
        }
        public string getString(string nomVar)
        {
            string varGET = tabString[nomVar];
            return varGET;
        }
        public bool estVide()
        {
            if (tabString.Count > 0)
            {
                return false;
            }
            return true;
        }
        public bool isIn(string key)
        {
            return tabString.ContainsKey(key);
        }
    }
}
