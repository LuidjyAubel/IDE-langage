using System;
using System.Collections.Generic;
using System.Text;

namespace IDE_langage
{
    class Bool
    {
        public Dictionary<string, bool> tabBool;
        public Bool()
        {
            tabBool = new Dictionary<string, bool>();
        }
        public void Dump()
        {
            Program.Form1.Write("----BOOL----");
            Program.Form1.ln();
            foreach (var kvp in tabBool)
                Program.Form1.Write("Key: " + kvp.Key + " value: " + kvp.Value+"\n");
        }
        public void setBool(string nomVar, bool val)
        {
            if (tabBool.ContainsKey(nomVar))
            {
                tabBool[nomVar] = val;
            }
            else
            {
                tabBool.Add(nomVar, val);
            }
        }
        public bool getBool(string nomVar)
        {
            bool varGET = tabBool[nomVar];
            return varGET;
        }
        public bool estVide()
        {
            if (tabBool.Count > 0)
            {
                return false;
            }
            return true;
        }
        public bool isIn(string key)
        {
            return tabBool.ContainsKey(key);
        }
    }
}
