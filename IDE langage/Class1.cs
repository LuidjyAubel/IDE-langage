using System;
using System.Windows.Forms;

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
                suivant.afficher();         //récursif
            }
        }
        public void traduire()
        {
            if (this.suivant != null)
            {
                instruction.traduire();
                suivant.traduire();         //récursif
            }
        }
        public void executer()
        {
            if ((this.suivant != null) && (!Program.Form1.wantStop))
            {
                instruction.executer();
                Application.DoEvents();
                //instruction.execute();
                suivant.executer();         //récursif
            }
        }
    }
    class Instruction
    {
        //public string name;
        public virtual void afficher()
        {
            //Console.WriteLine("Je ne devrais pas être là");
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
           // Console.WriteLine("Je ne devrais pas etre la non plus ");
            Program.Form1.Write("Je ne devrais pas etre la non plus ");
            Program.Form1.ln();
        }
    }
    class Instruction_Let : Instruction
    {
        char variable;
        string valeur;
        //char variable2;        //soit var soit const si c'est une valeur ça contient un ! utiliser la valeur
        //bool param2var;

        public Instruction_Let(char var, string val)
        {
            //this.name = "LET "+var+" "+val;
            //this.name = "" + var + " = " + val+";";  traduction C#
            //this.name = "$" + var + " = " + val+";"; traduction php
            this.variable = var;
            this.valeur = val;
        }
        public override void afficher()
        {
            //Console.WriteLine("LET " + this.variable + " " + this.valeur + " ");
            Program.Form1.Write("LET " + this.variable + " " + this.valeur + " ");
        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("$"+this.variable+" = "+this.valeur+";");
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
            //string b = this.valeur.ToString();
            //Console.WriteLine("execute let");
            Class2.LesVariables.setVariable(this.variable, this.valeur);
        }

        /*      public void execute()
              {
                  int lavaleur;
                  if (param2var)
                  {
                      lavaleur = recuperervaleur(variable2);
                  }
                  else lavaleur = valeur;
                  rangervaleurdansvariable(lavaleur, variable);
                  //ranger la valeur dans la variable
              }*/
    }
    class Instruction_Var : Instruction
    {
        char variable;
        string valeur;
        //char variable2;        //soit var soit const si c'est une valeur ça contient un ! utiliser la valeur
        //bool param2var;

        public Instruction_Var(char var, string val)
        {
            //this.name = "LET "+var+" "+val;
            //this.name = "" + var + " = " + val+";";  traduction C#
            //this.name = "$" + var + " = " + val+";"; traduction php
            this.variable = var;
            this.valeur = val;
        }
        public override void afficher()
        {
            //Console.WriteLine("LET " + this.variable + " " + this.valeur + " ");
            Program.Form1.Write("VAR " + this.variable + " " + this.valeur + " ");
        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("$" + this.variable + " = " + this.valeur + ";");
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
            //Console.WriteLine("execute let");
            Class2.LesVariables.setVariable(this.variable, this.valeur);
        }

        /*      public void execute()
              {
                  int lavaleur;
                  if (param2var)
                  {
                      lavaleur = recuperervaleur(variable2);
                  }
                  else lavaleur = valeur;
                  rangervaleurdansvariable(lavaleur, variable);
                  //ranger la valeur dans la variable
              }*/
    }
    class Instruction_ADD : Instruction
    {
        char variable;
        char variable2;
        char variable3;
        //char variable2;        //soit var soit const si c'est une valeur ça contient un ! utiliser la valeur
        //bool param2var;
        public Instruction_ADD(char var, char var2, char var3)
        {
            //this.name = "ADD " + var + " " + var2 +" "+var3;
            //this.name = "" + var + " = " + var2+" + "+var3+";";  //traduction C#
            //this.name = "$" + var + " = $" + var2+" $"+var3+;";
            this.variable = var;
            this.variable2 = var2;
            this.variable3 = var3;
        }
        public override void afficher()
        {
            //Console.WriteLine("ADD " + this.variable + " " + this.variable2 + " " + this.variable3 + " ");
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
            string valeur1 = Class2.LesVariables.getVariable(this.variable2);
            string valeur2 = Class2.LesVariables.getVariable(this.variable3);
            int nb1 = Int32.Parse(valeur1);
            int nb2 = Int32.Parse(valeur2);
            int valeur = nb1 + nb2;
            string val1 = valeur.ToString();
            Class2.LesVariables.setVariable(this.variable, val1);
        }
        /*      public void execute()
              {
                  int lavaleur;
                  if (param2var)
                  {
                      lavaleur = recuperervaleur(variable2);
                  }
                  else lavaleur = valeur;
                  rangervaleurdansvariable(lavaleur, variable);
                  //ranger la valeur dans la variable
              }*/
    }
    class Instruction_MOD : Instruction
    {
        char variable;
        char variable2;
        char variable3;
        //char variable2;        //soit var soit const si c'est une valeur ça contient un ! utiliser la valeur
        //bool param2var;
        public Instruction_MOD(char var, char var2, char var3)
        {
            //this.name = "ADD " + var + " " + var2 +" "+var3;
            //this.name = "" + var + " = " + var2+" + "+var3+";";  //traduction C#
            //this.name = "$" + var + " = $" + var2+" $"+var3+;";
            this.variable = var;
            this.variable2 = var2;
            this.variable3 = var3;
        }
        public override void afficher()
        {
            //Console.WriteLine("MOD " + this.variable + " " + this.variable2 + " " + this.variable3 + " ");
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
            //Console.WriteLine("execute MOD");
            string valeur1 = Class2.LesVariables.getVariable(this.variable2);
            string valeur2 = Class2.LesVariables.getVariable(this.variable3);
            int nb1 = Int32.Parse(valeur1);
            int nb2 = Int32.Parse(valeur2);
            int valeur = nb1 % nb2;
            string val1 = valeur.ToString();
            Class2.LesVariables.setVariable(this.variable, val1);
        }
        /*      public void execute()
              {
                  int lavaleur;
                  if (param2var)
                  {
                      lavaleur = recuperervaleur(variable2);
                  }
                  else lavaleur = valeur;
                  rangervaleurdansvariable(lavaleur, variable);
                  //ranger la valeur dans la variable
              }*/
    }
    class Instruction_SUB : Instruction
    {
        char variable;
        char variable2;
        char variable3;
        //char variable2;        //soit var soit const si c'est une valeur ça contient un ! utiliser la valeur
        //bool param2var;
        public Instruction_SUB(char var, char var2, char var3)
        {
            //this.name = "ADD " + var + " " + var2 +" "+var3;
            //this.name = "" + var + " = " + var2+" + "+var3+";";  //traduction C#
            //this.name = "$" + var + " = $" + var2+" $"+var3+;";
            this.variable = var;
            this.variable2 = var2;
            this.variable3 = var3;
        }
        public override void afficher()
        {
            //Console.WriteLine("SUB " + this.variable + " " + this.variable2 + " " + this.variable3 + " ");
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
            string valeur1 = Class2.LesVariables.getVariable(this.variable2);
            string valeur2 = Class2.LesVariables.getVariable(this.variable3);
            int nb1 = Int32.Parse(valeur1);
            int nb2 = Int32.Parse(valeur2);
            int valeur = nb1 - nb2;
            string val1 = valeur.ToString();
            Class2.LesVariables.setVariable(this.variable, val1);
        }
        /*      public void execute()
              {
                  int lavaleur;
                  if (param2var)
                  {
                      lavaleur = recuperervaleur(variable2);
                  }
                  else lavaleur = valeur;
                  rangervaleurdansvariable(lavaleur, variable);
                  //ranger la valeur dans la variable
              }*/
    }
    class Instruction_RAND : Instruction
    {
        char variable;
        char variable2;
        char variable3;
        //char variable2;        //soit var soit const si c'est une valeur ça contient un ! utiliser la valeur
        //bool param2var;
        public Instruction_RAND(char var, char var2, char var3)
        {
            //this.name = "ADD " + var + " " + var2 +" "+var3;
            //this.name = "" + var + " = " + var2+" + "+var3+";";  //traduction C#
            //this.name = "$" + var + " = $" + var2+" $"+var3+;";
            this.variable = var;
            this.variable2 = var2;
            this.variable3 = var3;
        }
        public override void afficher()
        {
            //Console.WriteLine("SUB " + this.variable + " " + this.variable2 + " " + this.variable3 + " ");
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
            string valeur1 = Class2.LesVariables.getVariable(this.variable2);
            string valeur2 = Class2.LesVariables.getVariable(this.variable3);
            int nb1 = Int32.Parse(valeur1);
            int nb2 = Int32.Parse(valeur2);
            int valeur = rnd.Next(nb1, nb2);
            string val1 = valeur.ToString();
            Class2.LesVariables.setVariable(this.variable, val1);
        }
        /*      public void execute()
              {
                  int lavaleur;
                  if (param2var)
                  {
                      lavaleur = recuperervaleur(variable2);
                  }
                  else lavaleur = valeur;
                  rangervaleurdansvariable(lavaleur, variable);
                  //ranger la valeur dans la variable
              }*/
    }
    class Instruction_MUL : Instruction
    {
        char variable;
        char variable2;
        char variable3;
        //char variable2;        //soit var soit const si c'est une valeur ça contient un ! utiliser la valeur
        //bool param2var;
        public Instruction_MUL(char var, char var2, char var3)
        {
            //this.name = "ADD " + var + " " + var2 +" "+var3;
            //this.name = "" + var + " = " + var2+" + "+var3+";";  //traduction C#
            //this.name = "$" + var + " = $" + var2+" $"+var3+;";
            this.variable = var;
            this.variable2 = var2;
            this.variable3 = var3;
        }
        public override void afficher()
        {
            //Console.WriteLine("MUL " + this.variable + " " + this.variable2 + " " + this.variable3 + " ");
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
            string valeur1 = Class2.LesVariables.getVariable(this.variable2);
            string valeur2 = Class2.LesVariables.getVariable(this.variable3);
            int nb1 = Int32.Parse(valeur1);
            int nb2 = Int32.Parse(valeur2);

            int valeur = nb1 * nb2;
            string val1 = valeur.ToString();
            Class2.LesVariables.setVariable(this.variable, val1);
        }
        /*      public void execute()
              {
                  int lavaleur;
                  if (param2var)
                  {
                      lavaleur = recuperervaleur(variable2);
                  }
                  else lavaleur = valeur;
                  rangervaleurdansvariable(lavaleur, variable);
                  //ranger la valeur dans la variable
              }*/
    }
    class Instruction_DIV : Instruction
    {
        char variable;
        char variable2;
        char variable3;
        //char variable2;        //soit var soit const si c'est une valeur ça contient un ! utiliser la valeur
        //bool param2var;
        public Instruction_DIV(char var, char var2, char var3)
        {
            //this.name = "ADD " + var + " " + var2 +" "+var3;
            //this.name = "" + var + " = " + var2+" + "+var3+";";  //traduction C#
            //this.name = "$" + var + " = $" + var2+" $"+var3+;";
            this.variable = var;
            this.variable2 = var2;
            this.variable3 = var3;
        }
        public override void afficher()
        {
           // Console.WriteLine("DIV " + this.variable + " " + this.variable2 + " " + this.variable3 + " ");
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
            string valeur1 = Class2.LesVariables.getVariable(this.variable2);
            string valeur2 = Class2.LesVariables.getVariable(this.variable3);
            int nb1 = Int32.Parse(valeur1);
            int nb2 = Int32.Parse(valeur2);
            int valeur = nb1 / nb2;
            string val1 = valeur.ToString();
            Class2.LesVariables.setVariable(this.variable, val1);
        }
        /*      public void execute()
              {
                  int lavaleur;
                  if (param2var)
                  {
                      lavaleur = recuperervaleur(variable2);
                  }
                  else lavaleur = valeur;
                  rangervaleurdansvariable(lavaleur, variable);
                  //ranger la valeur dans la variable
              }*/
    }
    class Instruction_INC : Instruction
    {
        char variable;
        //char variable2;        //soit var soit const si c'est une valeur ça contient un ! utiliser la valeur
        //bool param2var;
        public Instruction_INC(char var)
        {
            this.variable = var;
        }
        public override void afficher()
        {
           // Console.WriteLine("INC " + this.variable + " 1");
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
            //Console.WriteLine("execute add");
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
            //this.name = "LET "+var1+" "+val; //bidouille
            this.variable1 = var1;
            this.variable2 = var2;
            this.comparateur = comparateur;
            this.blocalors = bloc;
        }

        public override void afficher()
        {
            //Console.WriteLine(" IF " + this.variable1 + " " + this.comparateur + " " + this.variable2);
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
            //Console.WriteLine("IF " + val1 +" "+ comparateur+" "+ val2);
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
            //this.name = "LET "+var1+" "+val; //bidouille
            this.variable1 = var1;
            this.variable2 = var2;
            this.comparateur = comparateur;
            this.blocalors = bloc;
        }

        public override void afficher()
        {
            //Console.WriteLine(" WHILE " + this.variable1 + " " + this.comparateur + " " + this.variable2);
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
                    Application.DoEvents();
                    blocalors.executer();
                }
            }

            //Console.WriteLine("IF " + val1 +" "+ comparateur+" "+ val2);
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
            //this.name = "LET "+var1+" "+val; //bidouille
            this.variable1 = var1;
            this.variable2 = var2;
            this.variable3 = var3;
            this.blocalors = bloc;
        }
        public override void afficher()
        {
            //Console.WriteLine(" WHILE " + this.variable1 + " " + this.comparateur + " " + this.variable2);
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
                    Application.DoEvents();
                    blocalors.executer();
                }
                nb1 = nb1 + 1;
                Class2.LesVariables.setVariable(this.variable1, val1);
                if (nb1 <= nb3)
                {
                    res = true;
                    
                }
                else res = false;


            }
            //Console.WriteLine("IF " + val1 +" "+ comparateur+" "+ val2);
        }

    }
    class Instruction_Write : Instruction
    {
        char variable;
        //char variable2;        //soit var soit const si c'est une valeur ça contient un ! utiliser la valeur
        //bool param2var;
        public Instruction_Write(char var)
        {
            //this.name = "WRITE " + var;
            //this.name = "" + var + " = " + val+";";  traduction C#
            //this.name = "$" + var + " = " + val+";";
                this.variable = var;

        }
        public override void afficher()
        {
                Program.Form1.Write("WRITE " + this.variable + " ");
                Program.Form1.ln();
            // Console.WriteLine("WRITE " + this.variable + " ");

        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("print($"+this.variable+");");
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
            //Console.WriteLine("execution de Write");
                string valeur = Class2.LesVariables.getVariable(this.variable);
                Program.Form1.Write(" " + valeur);
                Program.Form1.ln();
              
            //Console.WriteLine(valeur);
        }
    }
   /* class Variables
    {
        protected int[] tabvar;
        public Variables()
        {
            tabvar = new int[26];
            Init();
        }
        public void Init()
        {
            for (int i = 0; i < 26; i++)
            {
                tabvar[i] = 0;
            }
        }
        public void Dump()
        {
            for (int i = 0; i < 26; i++)
            {
                //Console.Write(" " + tabvar[i] + " ");
                Program.Form1.Write(" [" + tabvar[i] + "] ");
            }

        }
        public void setVariable(char nomVar, int val)
        {
            for (int i = 0; i < 26; i++)
            {
                //i = charname - 'A';
                if (i == nomVar - 'A')
                {
                    tabvar[i] = val;
                    return;
                }
            }
        }
        public int getVariable(char nomVar)
        {  
            int varGET = tabvar[nomVar - 'A'];
            return varGET;
        }
    }*/

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
                //Console.Write(" " + tabvar[i] + " ");
                Program.Form1.Write(" [" + tabvar[i] + "] ");
            }

        }
        public void setVariable(char nomVar, string val)
        {
            for (int i = 0; i < 26; i++)
            {
                //i = charname - 'A';
                if (i == nomVar - 'A')
                {
                    tabvar[i] = val;
                    return;
                }
            }
        }
        public string getVariable(char nomVar)
        {
            /*for (int i = 0; i < 26; i++)
            {
                if (i == nomVar - 'A')
                {
                    //Console.WriteLine(nomVar + " = " + tabvar[i]);
                }
            }*/
            string varGET = tabvar[nomVar - 'A'];
            return varGET;
        }
    }
}