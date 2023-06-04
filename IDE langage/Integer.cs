using System;
using System.Collections.Generic;

namespace IDE_langage
{
	class Integer
	{
		protected Dictionary<string, int> tabInt;
        public Integer()
		{
			tabInt = new Dictionary<string, int>();
        }
        public void Dump()
        {
            Program.Form1.Write("----INTEGER----");
            Program.Form1.ln();
            foreach (var kvp in tabInt)
                Program.Form1.Write("Key: "+ kvp.Key+" value: "+kvp.Value+"\n");
        }
        public void setInteger(string nomVar, int val)
        {
            if (tabInt.ContainsKey(nomVar))
            {
                tabInt[nomVar] = val;
            }
            else
            {
                tabInt.Add(nomVar, val);
            }
        }
        public int getInteger(string nomVar)
        {
            int varGET = tabInt[nomVar];
            return varGET;
        }
        public bool estVide()
        {
            if (tabInt.Count > 0)
            {
                return false;
            }
            return true;
        }
        public bool isIn(string key)
        {
            return tabInt.ContainsKey(key);
        }
        public string toString(string key)
        {
            return ""+tabInt[key];
        }
    }
}
