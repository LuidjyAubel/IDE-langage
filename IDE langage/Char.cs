using System;
using System.Collections.Generic;
using System.Text;

namespace IDE_langage
{
    internal class Char
    {
        private Dictionary<string, char> tabChar;
        public Char()
        {
            tabChar = new Dictionary<string, char>();
        }
        public void Dump()
        {
            Program.Form1.Write("----CHAR----");
            Program.Form1.ln();
            foreach (var kvp in tabChar)
                Program.Form1.Write("Key: " + kvp.Key + " value: " + kvp.Value+"\n");
        }
        public void setChar(string nomVar, char val)
        {
            if (tabChar.ContainsKey(nomVar))
            {
                tabChar[nomVar] = val;
            }
            else
            {
                tabChar.Add(nomVar, val);
            }
        }
        public char getChar(string nomVar)
        {
            char varGET = tabChar[nomVar];
            return varGET;
        }
        public bool estVide()
        {
            if (tabChar.Count > 0)
            {
                return false;
            }
            return true;
        }
        public bool isIn(string key)
        {
            return tabChar.ContainsKey(key);
        }
    }
}
