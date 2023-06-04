using System;
using System.Collections.Generic;
using System.Text;

namespace IDE_langage
{
    class Double
    {
        private Dictionary<string,double> tabDouble;
        public Double() { 
            tabDouble = new Dictionary<string,double>();
        }
        public void Dump()
        {
            Program.Form1.Write("----DOUBLE----");
            Program.Form1.ln();
            foreach (var kvp in tabDouble)
                Program.Form1.Write("Key: " + kvp.Key + " value: " + kvp.Value+"\n");
        }
        public void setDouble(string nomVar, double val)
        {
            if (tabDouble.ContainsKey(nomVar))
            {
                tabDouble[nomVar] = val;
            }
            else
            {
                tabDouble.Add(nomVar, val);
            }
        }
        public double getDouble(string nomVar)
        {
            double varGET = tabDouble[nomVar];
            return varGET;
        }
        public bool estVide()
        {
            if (tabDouble.Count > 0)
            {
                return false;
            }
            return true;
        }
        public bool isIn(string key)
        {
            return tabDouble.ContainsKey(key);
        }
        public string toString(string key)
        {
            return "" + tabDouble[key];
        }
    }
}
