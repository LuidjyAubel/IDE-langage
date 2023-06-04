using System;
using System.Collections.Generic;
using System.Text;

namespace IDE_langage
{
    internal class Float
    {
        private Dictionary<string, float> tabFloat;
        public Float() { 
            tabFloat = new Dictionary<string, float>();
        }
        public void Dump()
        {
            Program.Form1.Write("----FLOAT----");
            Program.Form1.ln();
            foreach (var kvp in tabFloat)
                Program.Form1.Write("Key: " + kvp.Key + " value: " + kvp.Value+"\n");
        }
        public void setFloat(string nomVar, float val)
        {
            if (tabFloat.ContainsKey(nomVar))
            {
                tabFloat[nomVar] = val;
            }
            else
            {
                tabFloat.Add(nomVar, val);
            }
        }
        public float getFloat(string nomVar)
        {
            float varGET = tabFloat[nomVar];
            return varGET;
        }
        public bool estVide()
        {
            if (tabFloat.Count > 0)
            {
                return false;
            }
            return true;
        }
        public bool isIn(string key)
        {
            return tabFloat.ContainsKey(key);
        }
        public string toString(string key)
        {
            return "" + tabFloat[key];
        }
    }
}
