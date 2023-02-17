
using System;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Collections.Generic;


namespace IDE_langage
{
    class Bloc
    {
        Instruction instruction;
        Bloc suivant;
        public Bloc()
        {
            suivant = null;
        }
        public void ajouter(Instruction instruction)
        {
            if (this.suivant == null)
            {
                this.suivant = new Bloc();
                this.instruction = instruction;
            }
            else this.suivant.ajouter(instruction);
        }
        public void afficher()
        {
            if (this.suivant != null)
            {
                instruction.afficher();
                suivant.afficher();        
            }
        }
        public void traduire()
        {
            if (this.suivant != null)
            {
                instruction.traduire();
                suivant.traduire();        
            }
        }
        public void executer()
        {
            if ((this.suivant != null) && (!Program.Form1.wantStop))
            {
                instruction.executer();
               Application.DoEvents();
                suivant.executer();        
            }else if ((this.suivant != null) && (Program.Form1.wantStop))
            {
                Application.DoEvents();
            }
        }
    }
    class Instruction
    {
        public virtual void afficher()
        {
            Program.Form1.Write("Je ne devrais pas être là");
            Program.Form1.ln();
        }
        public virtual void traduire()
        {
            Program.Form1.WriteTrad("Je ne doit pas être là !");
            Program.Form1.lnTrad();
        }
        public virtual void executer()
        {
            Program.Form1.Write("Je ne devrais pas etre la non plus ");
            Program.Form1.ln();
        }
    }
    class Instruction_Let : Instruction
    {
        char variable;
        string valeur;
        public Instruction_Let(char var, string val)
        {
            this.variable = var;
            this.valeur = val;
        }
        public override void afficher()
        {
            Program.Form1.Write("LET " + this.variable + " " + this.valeur + " ");
        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("$"+this.variable+" = "+this.valeur+";");
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
            Class2.LesVariables.setVariable(this.variable, this.valeur);
        }
    }
    class Instruction_Var : Instruction
    {
        char variable;
        string valeur;
        public Instruction_Var(char var, string val)
        {
            this.variable = var;
            this.valeur = val;
        }
        public override void afficher()
        {
            Program.Form1.Write("VAR " + this.variable + " " + this.valeur + " ");
        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("$" + this.variable + " = " + this.valeur + ";");
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
            Class2.LesVariables.setVariable(this.variable, this.valeur);
        }
    }
    class Instruction_ADD : Instruction
    {
        char variable;
        string variable2;
        string variable3;
        public Instruction_ADD(char var, string var2, string var3)
        {
            this.variable = var;
            this.variable2 = var2;
            this.variable3 = var3;
        }
        public override void afficher()
        {
            Program.Form1.Write("ADD " + this.variable + " " + this.variable2 + " " + this.variable3 + " ");
            Program.Form1.ln();
        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("$"+this.variable+" = "+"$"+this.variable2+" + $"+this.variable3+";");
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
            //string b = this.valeur.ToString();
            /* string valeur1 = Class2.LesVariables.getVariable(this.variable2);
             string valeur2 = Class2.LesVariables.getVariable(this.variable3);
             int nb1 = Int32.Parse(valeur1);
             int nb2 = Int32.Parse(valeur2);
             int valeur = nb1 + nb2;
             string val1 = valeur.ToString();
             Class2.LesVariables.setVariable(this.variable, val1);*/
            string va2 = this.variable2;
            string va3 = this.variable3;
            string valeur1;
            string valeur2;
            int nb1;
            int nb2;
            if (va2.All(char.IsDigit))
            {
                nb1 = Int32.Parse(va2);
            }
            else
            {
                char a = this.variable2[0];
                valeur1 = Class2.LesVariables.getVariable(a);
                nb1 = Int32.Parse(valeur1);
            }
            if (va3.All(char.IsDigit))
            {
                nb2 = Int32.Parse(va3);
            }
            else
            {
                char b = this.variable3[0];
                valeur2 = Class2.LesVariables.getVariable(b);
                nb2 = Int32.Parse(valeur2);
            }
            // valeur1 = Class2.LesVariables.getVariable(this.variable2);
            //  string valeur2 = Class2.LesVariables.getVariable(this.variable3);
            //int nb1 = Int32.Parse(valeur1);
            //int nb2 = Int32.Parse(valeur2);
            int valeur = nb1 + nb2;
            string val1 = valeur.ToString();
            Class2.LesVariables.setVariable(this.variable, val1);
        }
    }
    class Instruction_CAR : Instruction
    {
        char variable;
        string variable2;
        public Instruction_CAR(char var, string var2)
        {
            this.variable = var;
            this.variable2 = var2;
        }
        public override void afficher()
        {
            Program.Form1.Write("CAR " + this.variable + " " + this.variable2 + " ");
            Program.Form1.ln();
        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("$" + this.variable + " = " + "$" + this.variable2 +"^2;");
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
            string va2 = this.variable2;
            string valeur1;
            int nb1;
            if (va2.All(char.IsDigit))
            {
                nb1 = Int32.Parse(va2);
            }
            else
            {
                char a = this.variable2[0];
                 valeur1 = Class2.LesVariables.getVariable(a);
                 nb1 = Int32.Parse(valeur1);
            }
            int valeur = nb1 * nb1;
            string val1 = valeur.ToString();
            Class2.LesVariables.setVariable(this.variable, val1);
        }
    }
    class Instruction_MOD : Instruction
    {
        char variable;
        string variable2;
        string variable3;
        public Instruction_MOD(char var, string var2, string var3)
        {
            this.variable = var;
            this.variable2 = var2;
            this.variable3 = var3;
        }
        public override void afficher()
        {
            Program.Form1.Write("MOD " + this.variable + " " + this.variable2 + " " + this.variable3 + " ");
            Program.Form1.ln();
        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("$"+this.variable+" = "+"$"+this.variable2+" % $"+this.variable3+";");
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
            string va2 = this.variable2;
            string va3 = this.variable3;
            string valeur1;
            string valeur2;
            int nb1;
            int nb2;
            if (va3.All(char.IsDigit))
            {
                nb1 = Int32.Parse(va2);
            }
            else
            {
                char a = this.variable2[0];
                valeur1 = Class2.LesVariables.getVariable(a);
                nb1 = Int32.Parse(valeur1);
            }
            if (va3.All(char.IsDigit))
            {
                nb2 = Int32.Parse(va3);
            }
            else
            {
                char b = this.variable3[0];
                valeur2 = Class2.LesVariables.getVariable(b);
                nb2 = Int32.Parse(valeur2);
            }
            // valeur1 = Class2.LesVariables.getVariable(this.variable2);
            //  string valeur2 = Class2.LesVariables.getVariable(this.variable3);
            //int nb1 = Int32.Parse(valeur1);
            //int nb2 = Int32.Parse(valeur2);
           /* string valeur1 = Class2.LesVariables.getVariable(this.variable2);
            string valeur2 = Class2.LesVariables.getVariable(this.variable3);
            int nb1 = Int32.Parse(valeur1);
            int nb2 = Int32.Parse(valeur2);*/
            int valeur = nb1 % nb2;
            string val1 = valeur.ToString();
            Class2.LesVariables.setVariable(this.variable, val1);
        }
    }
    class Instruction_SUB : Instruction
    {
        char variable;
        string variable2;
        string variable3;
        public Instruction_SUB(char var, string var2, string var3)
        {
            this.variable = var;
            this.variable2 = var2;
            this.variable3 = var3;
        }
        public override void afficher()
        {
            Program.Form1.Write("SUB " + this.variable + " " + this.variable2 + " " + this.variable3 + " ");
        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("$"+this.variable+" = $"+this.variable2+" - $"+this.variable3+";");
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
            //Console.WriteLine("execute MOD");
            /*string valeur1 = Class2.LesVariables.getVariable(this.variable2);
            string valeur2 = Class2.LesVariables.getVariable(this.variable3);
            int nb1 = Int32.Parse(valeur1);
            int nb2 = Int32.Parse(valeur2);*/
            string va2 = this.variable2;
            string va3 = this.variable3;
            string valeur1;
            string valeur2;
            int nb1;
            int nb2;
            if (va2.All(char.IsDigit))
            {
                nb1 = Int32.Parse(va2);
            }
            else
            {
                char a = this.variable2[0];
                valeur1 = Class2.LesVariables.getVariable(a);
                nb1 = Int32.Parse(valeur1);
            }

            if (va3.All(char.IsDigit))
            {
                nb2 = Int32.Parse(va3);
            }
            else
            {
                char b = this.variable3[0];
                valeur2 = Class2.LesVariables.getVariable(b);
                nb2 = Int32.Parse(valeur2);
            }
            // valeur1 = Class2.LesVariables.getVariable(this.variable2);
            //  string valeur2 = Class2.LesVariables.getVariable(this.variable3);
            //int nb1 = Int32.Parse(valeur1);
            //int nb2 = Int32.Parse(valeur2);
            int valeur = nb1 - nb2;
            string val1 = valeur.ToString();
            Class2.LesVariables.setVariable(this.variable, val1);
        }
    }
    class Instruction_DCR : Instruction
    {
        char variable;
        public Instruction_DCR(char var)
        {
            this.variable = var;
        }
        public override void afficher()
        {
            Program.Form1.Write("DCR " + this.variable + "- 1");
            Program.Form1.ln();
        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("$" + this.variable + "--;");
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
            string valeur1 = Class2.LesVariables.getVariable(this.variable);
            int nb1 = Int32.Parse(valeur1);
            int valeur = nb1 - 1;
            string val1 = valeur.ToString();
            Class2.LesVariables.setVariable(this.variable, val1);
        }
    }
    class Instruction_RAND : Instruction
    {
        char variable;
        string variable2;
        string variable3;
        public Instruction_RAND(char var, string var2, string var3)
        {
            this.variable = var;
            this.variable2 = var2;
            this.variable3 = var3;
        }
        public override void afficher()
        {
            Program.Form1.Write("RAND " + this.variable + " " + this.variable2 + " " + this.variable3);
        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("$"+this.variable+" = random_int($" + this.variable2 + " $" + this.variable3 + ");");
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
            Random rnd = new Random();
            /* string valeur1 = Class2.LesVariables.getVariable(this.variable2);
             string valeur2 = Class2.LesVariables.getVariable(this.variable3);
             int nb1 = Int32.Parse(valeur1);
             int nb2 = Int32.Parse(valeur2);*/
            string va2 = this.variable2;
            string va3 = this.variable3;
            string valeur1;
            string valeur2;
            int nb1;
            int nb2;
            if (va2.All(char.IsDigit))
            {
                nb1 = Int32.Parse(va2);
            }
            else
            {
                char a = this.variable2[0];
                valeur1 = Class2.LesVariables.getVariable(a);
                nb1 = Int32.Parse(valeur1);
            }
            if (va3.All(char.IsDigit))
            {
                nb2 = Int32.Parse(va3);
            }
            else
            {
                char b = this.variable3[0];
                valeur2 = Class2.LesVariables.getVariable(b);
                nb2 = Int32.Parse(valeur2);
            }
            int valeur = rnd.Next(nb1, nb2);
            string val1 = valeur.ToString();
            Class2.LesVariables.setVariable(this.variable, val1);
        }
    }
    class Instruction_MUL : Instruction
    {
        char variable;
        string variable2;
        string variable3;
        public Instruction_MUL(char var, string var2, string var3)
        {
            this.variable = var;
            this.variable2 = var2;
            this.variable3 = var3;
        }
        public override void afficher()
        {
            Program.Form1.Write("MUL " + this.variable + " " + this.variable2 + " " + this.variable3 + " ");
            Program.Form1.ln();
        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("$"+this.variable+" = $"+this.variable2+" * $"+this.variable3+";");
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
            //Console.WriteLine("execute MOD");
            /*string valeur1 = Class2.LesVariables.getVariable(this.variable2);
            string valeur2 = Class2.LesVariables.getVariable(this.variable3);
            int nb1 = Int32.Parse(valeur1);
            int nb2 = Int32.Parse(valeur2);*/
            string va2 = this.variable2;
            string va3 = this.variable3;
            string valeur1;
            string valeur2;
            int nb1;
            int nb2;
            if (va2.All(char.IsDigit))
            {
                nb1 = Int32.Parse(va2);
            }
            else
            {
                char a = this.variable2[0];
                valeur1 = Class2.LesVariables.getVariable(a);
                nb1 = Int32.Parse(valeur1);
            }
            if (va3.All(char.IsDigit))
            {
                nb2 = Int32.Parse(va3);
            }
            else
            {
                char b = this.variable3[0];
                valeur2 = Class2.LesVariables.getVariable(b);
                nb2 = Int32.Parse(valeur2);
            }
            int valeur = nb1 * nb2;
            string val1 = valeur.ToString();
            Class2.LesVariables.setVariable(this.variable, val1);
        }
    }
    class Instruction_DIV : Instruction
    {
        char variable;
        string variable2;
        string variable3;
        public Instruction_DIV(char var, string var2, string var3)
        {
            this.variable = var;
            this.variable2 = var2;
            this.variable3 = var3;
        }
        public override void afficher()
        {
            Program.Form1.Write("DIV " + this.variable + " " + this.variable2 + " " + this.variable3 + " ");
        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("$"+this.variable+" = $"+this.variable2+" / $"+this.variable3+";");
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
            //Console.WriteLine("execute MOD");
            /* string valeur1 = Class2.LesVariables.getVariable(this.variable2);
             string valeur2 = Class2.LesVariables.getVariable(this.variable3);
             int nb1 = Int32.Parse(valeur1);
             int nb2 = Int32.Parse(valeur2);*/
            string va2 = this.variable2;
            string va3 = this.variable3;
            string valeur1;
            string valeur2;
            int nb1;
            int nb2;
            if (va2.All(char.IsDigit))
            {
                nb1 = Int32.Parse(va2);
            }
            else
            {
                char a = this.variable2[0];
                valeur1 = Class2.LesVariables.getVariable(a);
                nb1 = Int32.Parse(valeur1);
            }
            if (va3.All(char.IsDigit))
            {
                nb2 = Int32.Parse(va3);
            }
            else
            {
                char b = this.variable3[0];
                valeur2 = Class2.LesVariables.getVariable(b);
                nb2 = Int32.Parse(valeur2);
            }
            int valeur = nb1 / nb2;
            string val1 = valeur.ToString();
            Class2.LesVariables.setVariable(this.variable, val1);
        }
    }
    class Instruction_INC : Instruction
    {
        char variable;
        public Instruction_INC(char var)
        {
            this.variable = var;
        }
        public override void afficher()
        {
            Program.Form1.Write("INC " + this.variable + "+ 1");
            Program.Form1.ln();
        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("$"+this.variable+"++;");
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
            string valeur1 = Class2.LesVariables.getVariable(this.variable);
            int nb1 = Int32.Parse(valeur1);
            int valeur = nb1 + 1;
            string val1 = valeur.ToString();
            Class2.LesVariables.setVariable(this.variable, val1);
        }
    }
    class Instruction_IF : Instruction
    {
        char variable1;
        char variable2;
        string comparateur;
        Bloc blocalors;
        public Instruction_IF(char var1, string comparateur, char var2, Bloc bloc)
        {
            this.variable1 = var1;
            this.variable2 = var2;
            this.comparateur = comparateur;
            this.blocalors = bloc;
        }
        public override void afficher()
        {
            Program.Form1.Write(" IF " + this.variable1 + " " + this.comparateur + " " + this.variable2);
            Program.Form1.ln();
        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("if ($"+this.variable1+" "+this.comparateur+" $"+this.variable2+")" );
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
            string valeur1 = Class2.LesVariables.getVariable(this.variable1);
            string valeur2 = Class2.LesVariables.getVariable(this.variable2);
            int nb1 = Int32.Parse(valeur1);
            int nb2 = Int32.Parse(valeur2);
            bool res = false;
            switch (comparateur)
            {
                case "=": res = nb1 == nb2; break;
                case "!=": res = nb1 != nb2; break;
                case "<": res = nb1 < nb2; break;
                case ">": res = nb1 > nb2; break;
                case "<=": res = nb1 <= nb2; break;
                case ">=": res = nb1 >= nb2; break;
                default: res = false; break;
            }
            if (res == true)  {
             blocalors.executer();
            }
        }
    }
    class Instruction_WHILE : Instruction
    {
        char variable1;
        char variable2;
        string comparateur;
        Bloc blocalors;
        public Instruction_WHILE(char var1, string comparateur, char var2, Bloc bloc)
        {
            this.variable1 = var1;
            this.variable2 = var2;
            this.comparateur = comparateur;
            this.blocalors = bloc;
        }
        public override void afficher()
        {
            Program.Form1.Write(" WHILE " + this.variable1 + " " + this.comparateur + " " + this.variable2);
            Program.Form1.ln();
        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("while ($"+this.variable1+" "+this.comparateur+" $"+this.variable2+")");
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
            bool res = true;
            while (res)
            {
                string val1 = Class2.LesVariables.getVariable(this.variable1);
                string val2 = Class2.LesVariables.getVariable(this.variable2);
                int nb1 = Int32.Parse(val1);
                int nb2 = Int32.Parse(val2);
                switch (comparateur)
                {
                    case "=": res = nb1 == nb2; break;
                    case "!=": res = nb1 != nb2; break;
                    case "<": res = nb1 < nb2; break;
                    case ">": res = nb1 > nb2; break;
                    case "<=": res = nb1 <= nb2; break;
                    case ">=": res = nb1 >= nb2; break;
                    default: res = false; break;
                }
                if ((res == true) && (!Program.Form1.wantStop))
                {
                    blocalors.executer();
                }else if ((res == true) && (Program.Form1.wantStop)){
                    Application.DoEvents();
                }
            }
        }
    }
    class Instruction_FOR : Instruction
    {
        char variable1;
        char variable2;
        char variable3;
        Bloc blocalors;
        public Instruction_FOR(char var1, char var2, char var3, Bloc bloc)
        {
            this.variable1 = var1;
            this.variable2 = var2;
            this.variable3 = var3;
            this.blocalors = bloc;
        }
        public override void afficher()
        {
            Program.Form1.Write(" For " + this.variable1 + " " + this.variable2 + " " + this.variable3);
            Program.Form1.ln();
        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("for ($" + this.variable1 + " " + this.variable2 + " $" + this.variable3 + ")");
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
            bool res = true;
            string val1;
            string val2;
            string val3;
            val2 = Class2.LesVariables.getVariable(this.variable2);
           Class2.LesVariables.setVariable(this.variable1, val2);
            while (res)
            {
                val1 = Class2.LesVariables.getVariable(this.variable1);
                val2 = Class2.LesVariables.getVariable(this.variable2);
                val3 = Class2.LesVariables.getVariable(this.variable3);
                int nb1 = Int32.Parse(val1);
                int nb2 = Int32.Parse(val2);
                int nb3 = Int32.Parse(val3);
                if ((res == true) && (!Program.Form1.wantStop))
                {
                    blocalors.executer();
                }
                else if ((res == true) && (Program.Form1.wantStop))
                {
                    Application.DoEvents();
                }
                nb1 = nb1 + 1;
                Class2.LesVariables.setVariable(this.variable1, val1);
                if (nb1 <= nb3)
                {
                    res = true;
                }
                else res = false;
            }
        }
    }
    class Instruction_List : Instruction
    {
        char variable;
        List<string> valeur;
        public Instruction_List(char var, List<string> b)
        {
            this.variable = var;
            this.valeur = b;
        }
        public override void afficher()
        {
            string text = string.Join(" ", this.valeur);
            Program.Form1.Write("LIST " + this.variable + " "+text);
            Program.Form1.ln();
        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("");
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
            
            string valeur1 = Class2.LesVariables.getVariable(this.variable);
            string text = string.Join(" ", this.valeur);
            Class2.LesVariables.setVariable(this.variable, text);
        }
    }
    class Instruction_Get :Instruction
    {
        char variable;
        char tab;
        string indice;
        public Instruction_Get(char var, char var2, string index)
        {
            this.variable = var;
            this.tab = var2;
            this.indice = index;
        }
        public override void afficher()
        {
            Program.Form1.Write("GET " + this.variable + " "+this.tab+" "+this.indice);
            Program.Form1.ln();
        }
        public override void traduire()
        {
        }
        public override void executer()
        {
            string valeur = Class2.LesVariables.getVariable(this.tab);
            string[] items = valeur.Split(' ');
            int a = Int32.Parse(this.indice);
            int ind = a +1;
            string result = items[ind];
            Class2.LesVariables.setVariable(this.variable, result);
        }
    }
    class Instruction_Put : Instruction
    {
        char variable;
        char tab;
        string nbr;
        public Instruction_Put(char var, char var2, string nbr)
        {
            this.variable = var;
            this.tab = var2;
            this.nbr = nbr;
        }
        public override void afficher()
        {
            Program.Form1.Write("PUT " + this.variable + " " + this.tab + " " + this.nbr);
            Program.Form1.ln();
        }
        public override void traduire()
        {
        }
        public override void executer()
        {
            string valeur = Class2.LesVariables.getVariable(this.tab);
            string[] items = valeur.Split(' ');
            List<string> parm3 = new List<string>();
            int  tab = items.Length;
            for(int i = 0; i < tab; i++)
            {
                parm3.Add(items[i]);
            }
            parm3 = parm3.Take(tab - 1).ToList<String>();
            parm3.Add(this.nbr);
            parm3.Add("]");
            string text = string.Join(" ", parm3);
            Class2.LesVariables.setVariable(this.variable, text);
        }
    }
    class Instruction_Rmv : Instruction
    {
        char variable;
        char tab;
        string indice;
        public Instruction_Rmv(char var, char var2, string ind)
        {
            this.variable = var;
            this.tab = var2;
            this.indice = ind;
        }
        public override void afficher()
        {
            Program.Form1.Write("RMV " + this.variable + " " + this.tab + " " + this.indice);
            Program.Form1.ln();
        }
        public override void traduire()
        {
        }
        public override void executer()
        {
            string valeur = Class2.LesVariables.getVariable(this.tab);
            string[] items = valeur.Split(' ');
            List<string> parm3 = new List<string>();
            int tab = items.Length;
            for (int i = 0; i < tab; i++)
            {
                parm3.Add(items[i]);
            }
            int ind = Int32.Parse(this.indice) + 1;
            parm3.RemoveAt(ind);
            string text = string.Join(" ", parm3);
            Class2.LesVariables.setVariable(this.variable, text);
        }
    }
    class Instruction_Write : Instruction
    {
        char variable;
        //char variable2;        //soit var soit const si c'est une valeur ça contient un ! utiliser la valeur
        //bool param2var;
        public Instruction_Write(char var)
        {
                this.variable = var;
        }
        public override void afficher()
        {
                Program.Form1.Write("WRITE " + this.variable + " ");
                Program.Form1.ln();
        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("print($"+this.variable+");");
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
                string valeur = Class2.LesVariables.getVariable(this.variable);
                Program.Form1.Write(" " + valeur);
                Program.Form1.ln();
        }
    }
    class OBJ : Instruction
    {
        char variable;
        string name;
        Dictionary<string, string> attribute;
        Bloc blocalors;
        public OBJ(char var, string name, Dictionary<string, string> attr, Bloc blocobj)
        {
            this.name = name;
            this.variable = var;
            this.blocalors = blocobj;
            this.attribute = attr;
        }
        public override void afficher()
        {
            string text = string.Join(" ", this.attribute);
            Program.Form1.Write("OBJ " + this.variable + " " + this.name+" "+text);
        }
        public override void traduire()
        {
        }
        public override void executer()
        {
            blocalors.executer();
            string text = string.Join(" ", this.attribute);
            Class2.LesVariables.setVariable(this.variable,this.name+" "+text);
        }
    }

    class Variables
    {
        protected string[] tabvar;
        public Variables()
        {
            tabvar = new string[26];
            Init();
        }
        public void Init()
        {
            for (int i = 0; i < 26; i++)
            {
                tabvar[i] = " ";
            }
        }
        public void Dump()
        {
            for (int i = 0; i < 26; i++)
            {
                Program.Form1.Write(" [" + tabvar[i] + "] ");
            }
        }
        public void setVariable(char nomVar, string val)
        {
            for (int i = 0; i < 26; i++)
            {
                if (i == nomVar - 'A')
                {
                    tabvar[i] = val;
                    return;
                }
            }
        }
        public string getVariable(char nomVar)
        {
            string varGET = tabvar[nomVar - 'A'];
            return varGET;
        }
    }
}
