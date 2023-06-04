
using System;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Security.Policy;
using System.Diagnostics;
using System.Globalization;

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
        string variable;
        string type;
        string valeur;
        public Instruction_Let(string var, string ty, string val)
        {
            this.variable = var;
            this.type = ty;
            this.valeur = val;
        }
        public override void afficher()
        {
            Program.Form1.Write("LET " + this.variable +" "+this.type+" " + this.valeur + " ");
        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("$"+this.variable+" = "+this.valeur+";");
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
            if (this.type == "INT")
            {
                Class2.LesInt.setInteger(this.variable.ToString(), Int32.Parse(this.valeur));
            }else if (this.type == "FLOAT"){
                Class2.lesFloat.setFloat(this.variable.ToString(), float.Parse(this.valeur, CultureInfo.InvariantCulture.NumberFormat));
            }else if (this.type == "DOUBLE"){
                Class2.lesDouble.setDouble(this.variable.ToString(), double.Parse(this.valeur, CultureInfo.InvariantCulture.NumberFormat));
            }else if (this.type == "CHAR"){
                Class2.lesChar.setChar(this.variable.ToString(), char.Parse(this.valeur));
            }else if (this.type == "BOOL"){
                Class2.lesBoolean.setBool(this.variable.ToString(), bool.Parse(this.valeur));
            }else {
                Class2.lesString.setString(this.variable.ToString(), this.valeur);;
            }
        }
    }
    class Instruction_Var : Instruction
    {
        string variable;
        string type;
        string valeur;
        public Instruction_Var(string var, string ty, string val)
        {
            this.variable = var;
            this.type = ty;
            this.valeur = val;
        }
        public override void afficher()
        {
            Program.Form1.Write("VAR " + this.variable +" "+this.type+ " " + this.valeur + " ");
        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("$" + this.variable + " = " + this.valeur + ";");
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
            if (this.type == "INT")
            {
                Class2.LesInt.setInteger(this.variable.ToString(), Int32.Parse(this.valeur));
            }
            else if (this.type == "FLOAT")
            {
                Class2.lesFloat.setFloat(this.variable.ToString(),float.Parse(this.valeur, CultureInfo.InvariantCulture.NumberFormat));
            }
            else if (this.type == "DOUBLE")
            {
                Class2.lesDouble.setDouble(this.variable.ToString(), double.Parse(this.valeur, CultureInfo.InvariantCulture.NumberFormat));
            }
            else if (this.type == "CHAR")
            {
                Class2.lesChar.setChar(this.variable.ToString(), char.Parse(this.valeur));
            }
            else if (this.type == "BOOL")
            {
                Class2.lesBoolean.setBool(this.variable.ToString(), bool.Parse(this.valeur));
            }
            else
            {
                Class2.lesString.setString(this.variable.ToString(), this.valeur); ;
            }
        }
    }
    class Instruction_ADD : Instruction
    {
        string variable;
        string variable2;
        string variable3;
        public Instruction_ADD(string var, string var2, string var3)
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
            string va2 = this.variable2;
            string va3 = this.variable3;
            int? nb1 = null;
            int? nb2 = null;
            float? n1 = null;
            float? n2 = null;
            double? nomb1 = null;
            double? nomb2 = null;
            if (int.TryParse(va2, out _))
            {
                nb1 = Int32.Parse(va2);
            }
            else if (float.TryParse(va2, out _))
            {
                n1 = float.Parse(va2);
            }else if (double.TryParse(va2, out _))
            {
                nomb1 = double.Parse(va2);
            }
            else
            {
                if (Class2.LesInt.estVide() == false && Class2.LesInt.isIn(va2))
                {
                   nb1 = Class2.LesInt.getInteger(va2);
                }
                else if (Class2.lesFloat.estVide()==false && Class2.lesFloat.isIn(va2))
                {
                   n1 = Class2.lesFloat.getFloat(va2);
                }
                else
                {
                    nomb1 = Class2.lesDouble.getDouble(va2);
                }
            }
            if (int.TryParse(va3, out _))
            {
                nb2 = Int32.Parse(va3);
            }else if (float.TryParse(va3, out _))
            {
                n2 = float.Parse(va3);
            }else if (double.TryParse(va3, out _))
            {
                nomb2 = double.Parse(va3);
            }
            else
            {
                if (Class2.LesInt.estVide() == false && Class2.LesInt.isIn(va3))
                {
                    nb2 = Class2.LesInt.getInteger(va3);
                }
                else if (Class2.lesFloat.estVide() == false && Class2.lesFloat.isIn(va3))
                {
                    n2 = Class2.lesFloat.getFloat(va3);
                }
                else
                {
                    nomb2 = Class2.lesDouble.getDouble(va3);
                }
            }
            if (nb1 != null && nb2 != null)
            {
                int res = (int)(nb1 + nb2);
                Class2.LesInt.setInteger(this.variable, res);
            }else if (nb1 != null && n2 != null)
            {
                float res = (float)((float) nb1 + n2);
                Class2.lesFloat.setFloat(this.variable, res);
            }else if (n1 != null && nb2 != null)
            {
                float res = (float)((float)n1 + nb2);
                Class2.lesFloat.setFloat(this.variable, res);
            }else if (n1 != null && n2 != null)
            {
                float res = (float)((float)n1 + n2);
                Class2.lesFloat.setFloat(this.variable, res);
            }else if (nb1 != null && nomb2 != null)
            {
                double res = (double)((double)nb1 + nomb2);
                Class2.lesDouble.setDouble(this.variable, res);
            }else if (nomb1 != null && nb2 != null)
            {
                double res = (double)((double)nomb1 + nb2);
                Class2.lesDouble.setDouble(this.variable, res);
            }else if (n1 != null && nomb2 != null)
            {
                double res = (double)((double)n1 + nomb2);
                Class2.lesDouble.setDouble(this.variable, res);
            }else if (nomb1 != null && n2 != null)
            {
                double res = (double)((double)nomb1 + n2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
            else
            {
                double res = (double)((double)nomb1 + nomb2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
        }
    }
    class Instruction_CAR : Instruction
    {
        string variable;
        string variable2;
        public Instruction_CAR(string var, string var2)
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
            int? nb1 = null;
            float? n1 = null;
            double? nomb1 = null;
            if (int.TryParse(va2, out _))
            {
                nb1 = Int32.Parse(va2);
            }
            else if (float.TryParse(va2, out _))
            {
                n1 = float.Parse(va2);
            }
            else if (double.TryParse(va2, out _))
            {
                nomb1 = double.Parse(va2);
            }
            else
            {
                if (Class2.LesInt.estVide() == false && Class2.LesInt.isIn(va2))
                {
                    nb1 = Class2.LesInt.getInteger(va2);
                }
                else if (Class2.lesFloat.estVide() == false && Class2.lesFloat.isIn(va2))
                {
                    n1 = Class2.lesFloat.getFloat(va2);
                }
                else
                {
                    nomb1 = Class2.lesDouble.getDouble(va2);
                }
            }
            if (nb1 != null)
            {
                int res = (int)(nb1 * nb1);
                Class2.LesInt.setInteger(this.variable, res);
            }
            else if (n1 != null)
            {
                float res = (float)((float)n1 * n1);
                Class2.lesFloat.setFloat(this.variable, res);
            }
            else if (nomb1 != null)
            {
                double res = (double)((double)nomb1 * nomb1);
                Class2.lesDouble.setDouble(this.variable, res);
            }
        }
    }
    class Instruction_MOD : Instruction
    {
        string variable;
        string variable2;
        string variable3;
        public Instruction_MOD(string var, string var2, string var3)
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
            int? nb1 = null;
            int? nb2 = null;
            float? n1 = null;
            float? n2 = null;
            double? nomb1 = null;
            double? nomb2 = null;
            if (int.TryParse(va2, out _))
            {
                nb1 = Int32.Parse(va2);
            }
            else if (float.TryParse(va2, out _))
            {
                n1 = float.Parse(va2);
            }
            else if (double.TryParse(va2, out _))
            {
                nomb1 = double.Parse(va2);
            }
            else
            {
                if (Class2.LesInt.estVide() == false && Class2.LesInt.isIn(va2))
                {
                    nb1 = Class2.LesInt.getInteger(va2);
                }
                else if (Class2.lesFloat.estVide() == false && Class2.lesFloat.isIn(va2))
                {
                    n1 = Class2.lesFloat.getFloat(va2);
                }
                else
                {
                    nomb1 = Class2.lesDouble.getDouble(va2);
                }
            }
            if (int.TryParse(va3, out _))
            {
                nb2 = Int32.Parse(va3);
            }
            else if (float.TryParse(va3, out _))
            {
                n2 = float.Parse(va3);
            }
            else if (double.TryParse(va3, out _))
            {
                nomb2 = double.Parse(va3);
            }
            else
            {
                if (Class2.LesInt.estVide() == false && Class2.LesInt.isIn(va3))
                {
                    nb2 = Class2.LesInt.getInteger(va3);
                }
                else if (Class2.lesFloat.estVide() == false && Class2.lesFloat.isIn(va3))
                {
                    n2 = Class2.lesFloat.getFloat(va3);
                }
                else
                {
                    nomb2 = Class2.lesDouble.getDouble(va3);
                }
            }
            if (nb1 != null && nb2 != null)
            {
                int res = (int)(nb1 % nb2);
                Class2.LesInt.setInteger(this.variable, res);
            }
            else if (nb1 != null && n2 != null)
            {
                float res = (float)((float)nb1 % n2);
                Class2.lesFloat.setFloat(this.variable, res);
            }
            else if (n1 != null && nb2 != null)
            {
                float res = (float)((float)n1 % nb2);
                Class2.lesFloat.setFloat(this.variable, res);
            }
            else if (n1 != null && n2 != null)
            {
                float res = (float)((float)n1 % n2);
                Class2.lesFloat.setFloat(this.variable, res);
            }
            else if (nb1 != null && nomb2 != null)
            {
                double res = (double)((double)nb1 % nomb2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
            else if (nomb1 != null && nb2 != null)
            {
                double res = (double)((double)nomb1 % nb2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
            else if (n1 != null && nomb2 != null)
            {
                double res = (double)((double)n1 % nomb2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
            else if (nomb1 != null && n2 != null)
            {
                double res = (double)((double)nomb1 % n2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
            else
            {
                double res = (double)((double)nomb1 % nomb2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
        }
    }
    class Instruction_SUB : Instruction
    {
        string variable;
        string variable2;
        string variable3;
        public Instruction_SUB(string var, string var2, string var3)
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
            string va2 = this.variable2;
            string va3 = this.variable3;
            int? nb1 = null;
            int? nb2 = null;
            float? n1 = null;
            float? n2 = null;
            double? nomb1 = null;
            double? nomb2 = null;
            if (int.TryParse(va2, out _))
            {
                nb1 = Int32.Parse(va2);
            }
            else if (float.TryParse(va2, out _))
            {
                n1 = float.Parse(va2);
            }
            else if (double.TryParse(va2, out _))
            {
                nomb1 = double.Parse(va2);
            }
            else
            {
                if (Class2.LesInt.estVide() == false && Class2.LesInt.isIn(va2))
                {
                    nb1 = Class2.LesInt.getInteger(va2);
                }
                else if (Class2.lesFloat.estVide() == false && Class2.lesFloat.isIn(va2))
                {
                    n1 = Class2.lesFloat.getFloat(va2);
                }
                else
                {
                    nomb1 = Class2.lesDouble.getDouble(va2);
                }
            }
            if (int.TryParse(va3, out _))
            {
                nb2 = Int32.Parse(va3);
            }
            else if (float.TryParse(va3, out _))
            {
                n2 = float.Parse(va3);
            }
            else if (double.TryParse(va3, out _))
            {
                nomb2 = double.Parse(va3);
            }
            else
            {
                if (Class2.LesInt.estVide() == false && Class2.LesInt.isIn(va3))
                {
                    nb2 = Class2.LesInt.getInteger(va3);
                }
                else if (Class2.lesFloat.estVide() == false && Class2.lesFloat.isIn(va3))
                {
                    n2 = Class2.lesFloat.getFloat(va3);
                }
                else
                {
                    nomb2 = Class2.lesDouble.getDouble(va3);
                }
            }
            if (nb1 != null && nb2 != null)
            {
                int res = (int)(nb1 - nb2);
                Class2.LesInt.setInteger(this.variable, res);
            }
            else if (nb1 != null && n2 != null)
            {
                float res = (float)((float)nb1 - n2);
                Class2.lesFloat.setFloat(this.variable, res);
            }
            else if (n1 != null && nb2 != null)
            {
                float res = (float)((float)n1 - nb2);
                Class2.lesFloat.setFloat(this.variable, res);
            }
            else if (n1 != null && n2 != null)
            {
                float res = (float)((float)n1 - n2);
                Class2.lesFloat.setFloat(this.variable, res);
            }
            else if (nb1 != null && nomb2 != null)
            {
                double res = (double)((double)nb1 - nomb2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
            else if (nomb1 != null && nb2 != null)
            {
                double res = (double)((double)nomb1 - nb2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
            else if (n1 != null && nomb2 != null)
            {
                double res = (double)((double)n1 - nomb2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
            else if (nomb1 != null && n2 != null)
            {
                double res = (double)((double)nomb1 - n2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
            else
            {
                double res = (double)((double)nomb1 - nomb2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
        }
    }
    class Instruction_DCR : Instruction
    {
        string variable;
        public Instruction_DCR(string var)
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
            int valeur;
            try
            {
                 valeur = Class2.LesInt.getInteger(this.variable);
                valeur = valeur - 1;
                Class2.LesInt.setInteger(this.variable, valeur);
            }
            catch (Exception e)
            {
                Class2.Erreur("La variable n'est pas un integer : "+e);
            }
        }
    }
    class Instruction_RAND : Instruction
    {
        string variable;
        string variable2;
        string variable3;
        public Instruction_RAND(string var, string var2, string var3)
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
            string va2 = this.variable2;
            string va3 = this.variable3;
            int? nb1 = null;
            int? nb2 = null;
            if (Class2.LesInt.isIn(va2) && Class2.LesInt.isIn(va3))
            {
                nb1 = Class2.LesInt.getInteger(this.variable2);
                nb2 = Class2.LesInt.getInteger(this.variable3);
                int i = (int)(nb1);
                int j = (int)(nb2);
                int valeur = rnd.Next(i, j);
                Class2.LesInt.setInteger(this.variable, valeur);
            } else if (Class2.LesInt.isIn(va2) && Class2.LesInt.isIn(va3) == false)
            {
                nb1 = Class2.LesInt.getInteger(this.variable2);
                nb2 = int.Parse(va3);
                int i = (int)(nb1);
                int j = (int)(nb2);
                int valeur = rnd.Next(i, j);
                Class2.LesInt.setInteger(this.variable, valeur);
            } else if (Class2.LesInt.isIn(va2) == false && Class2.LesInt.isIn(va3))
            {
                nb1 = int.Parse(va2);
                nb2 = Class2.LesInt.getInteger(this.variable3);
                int i = (int)(nb1);
                int j = (int)(nb2);
                int valeur = rnd.Next(i, j);
                Class2.LesInt.setInteger(this.variable, valeur);
            }
            else
            {
                nb1 = int.Parse(va2);
                nb2 = int.Parse(va3);
                int i = (int)(nb1);
                int j = (int)(nb2);
                int valeur = rnd.Next(i, j);
                Class2.LesInt.setInteger(this.variable, valeur);
            }
        }
    }
    class Instruction_MUL : Instruction
    {
        string variable;
        string variable2;
        string variable3;
        public Instruction_MUL(string var, string var2, string var3)
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
            string va2 = this.variable2;
            string va3 = this.variable3;
            int? nb1 = null;
            int? nb2 = null;
            float? n1 = null;
            float? n2 = null;
            double? nomb1 = null;
            double? nomb2 = null;
            if (int.TryParse(va2, out _))
            {
                nb1 = Int32.Parse(va2);
            }
            else if (float.TryParse(va2, out _))
            {
                n1 = float.Parse(va2);
            }
            else if (double.TryParse(va2, out _))
            {
                nomb1 = double.Parse(va2);
            }
            else
            {
                if (Class2.LesInt.estVide() == false && Class2.LesInt.isIn(va2))
                {
                    nb1 = Class2.LesInt.getInteger(va2);
                }
                else if (Class2.lesFloat.estVide() == false && Class2.lesFloat.isIn(va2))
                {
                    n1 = Class2.lesFloat.getFloat(va2);
                }
                else
                {
                    nomb1 = Class2.lesDouble.getDouble(va2);
                }
            }
            if (int.TryParse(va3, out _))
            {
                nb2 = Int32.Parse(va3);
            }
            else if (float.TryParse(va3, out _))
            {
                n2 = float.Parse(va3);
            }
            else if (double.TryParse(va3, out _))
            {
                nomb2 = double.Parse(va3);
            }
            else
            {
                if (Class2.LesInt.estVide() == false && Class2.LesInt.isIn(va3))
                {
                    nb2 = Class2.LesInt.getInteger(va3);
                }
                else if (Class2.lesFloat.estVide() == false && Class2.lesFloat.isIn(va3))
                {
                    n2 = Class2.lesFloat.getFloat(va3);
                }
                else
                {
                    nomb2 = Class2.lesDouble.getDouble(va3);
                }
            }
            if (nb1 != null && nb2 != null)
            {
                int res = (int)(nb1 * nb2);
                Class2.LesInt.setInteger(this.variable, res);
            }
            else if (nb1 != null && n2 != null)
            {
                float res = (float)((float)nb1 * n2);
                Class2.lesFloat.setFloat(this.variable, res);
            }
            else if (n1 != null && nb2 != null)
            {
                float res = (float)((float)n1 * nb2);
                Class2.lesFloat.setFloat(this.variable, res);
            }
            else if (n1 != null && n2 != null)
            {
                float res = (float)((float)n1 * n2);
                Class2.lesFloat.setFloat(this.variable, res);
            }
            else if (nb1 != null && nomb2 != null)
            {
                double res = (double)((double)nb1 * nomb2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
            else if (nomb1 != null && nb2 != null)
            {
                double res = (double)((double)nomb1 * nb2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
            else if (n1 != null && nomb2 != null)
            {
                double res = (double)((double)n1 * nomb2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
            else if (nomb1 != null && n2 != null)
            {
                double res = (double)((double)nomb1 * n2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
            else
            {
                double res = (double)((double)nomb1 * nomb2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
        }
    }
    class Instruction_DIV : Instruction
    {
        string variable;
        string variable2;
        string variable3;
        public Instruction_DIV(string var, string var2, string var3)
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
            string va2 = this.variable2;
            string va3 = this.variable3;
            int? nb1 = null;
            int? nb2 = null;
            float? n1 = null;
            float? n2 = null;
            double? nomb1 = null;
            double? nomb2 = null;
            if (int.TryParse(va2, out _))
            {
                nb1 = Int32.Parse(va2);
            }
            else if (float.TryParse(va2, out _))
            {
                n1 = float.Parse(va2);
            }
            else if (double.TryParse(va2, out _))
            {
                nomb1 = double.Parse(va2);
            }
            else
            {
                if (Class2.LesInt.estVide() == false && Class2.LesInt.isIn(va2))
                {
                    nb1 = Class2.LesInt.getInteger(va2);
                }
                else if (Class2.lesFloat.estVide() == false && Class2.lesFloat.isIn(va2))
                {
                    n1 = Class2.lesFloat.getFloat(va2);
                }
                else
                {
                    nomb1 = Class2.lesDouble.getDouble(va2);
                }
            }
            if (int.TryParse(va3, out _))
            {
                nb2 = Int32.Parse(va3);
            }
            else if (float.TryParse(va3, out _))
            {
                n2 = float.Parse(va3);
            }
            else if (double.TryParse(va3, out _))
            {
                nomb2 = double.Parse(va3);
            }
            else
            {
                if (Class2.LesInt.estVide() == false && Class2.LesInt.isIn(va3))
                {
                    nb2 = Class2.LesInt.getInteger(va3);
                }
                else if (Class2.lesFloat.estVide() == false && Class2.lesFloat.isIn(va3))
                {
                    n2 = Class2.lesFloat.getFloat(va3);
                }
                else
                {
                    nomb2 = Class2.lesDouble.getDouble(va3);
                }
            }
            if (nb1 != null && nb2 != null)
            {
                int res = (int)(nb1 / nb2);
                Class2.LesInt.setInteger(this.variable, res);
            }
            else if (nb1 != null && n2 != null)
            {
                float res = (float)((float)nb1 / n2);
                Class2.lesFloat.setFloat(this.variable, res);
            }
            else if (n1 != null && nb2 != null)
            {
                float res = (float)((float)n1 / nb2);
                Class2.lesFloat.setFloat(this.variable, res);
            }
            else if (n1 != null && n2 != null)
            {
                float res = (float)((float)n1 / n2);
                Class2.lesFloat.setFloat(this.variable, res);
            }
            else if (nb1 != null && nomb2 != null)
            {
                double res = (double)((double)nb1 / nomb2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
            else if (nomb1 != null && nb2 != null)
            {
                double res = (double)((double)nomb1 / nb2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
            else if (n1 != null && nomb2 != null)
            {
                double res = (double)((double)n1 / nomb2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
            else if (nomb1 != null && n2 != null)
            {
                double res = (double)((double)nomb1 / n2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
            else
            {
                double res = (double)((double)nomb1 / nomb2);
                Class2.lesDouble.setDouble(this.variable, res);
            }
        }
    }
    class Instruction_INC : Instruction
    {
        string variable;
        public Instruction_INC(string var)
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
            try
            {
                int valeur = Class2.LesInt.getInteger(this.variable);
                valeur = valeur + 1;
                Class2.LesInt.setInteger(this.variable, valeur);
            }
            catch(Exception e)
            {
                Class2.Erreur("Erreur la variable n'est pas un Integer : "+e);
            }
        }
    }
    class Instruction_IF : Instruction
    {
        string variable1;
        string variable2;
        string comparateur;
        Bloc blocalors;
        public Instruction_IF(string var1, string comparateur, string var2, Bloc bloc)
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
            if (Class2.LesInt.isIn(this.variable1) && Class2.LesInt.isIn(this.variable2))
            {
               int valeur1 = Class2.LesInt.getInteger(this.variable1);
               int valeur2 = Class2.LesInt.getInteger(this.variable2);
                bool res = false;
                switch (comparateur)
                {
                    case "=": res = valeur1 == valeur2; break;
                    case "!=": res = valeur1 != valeur2; break;
                    case "<": res = valeur1 < valeur2; break;
                    case ">": res = valeur1 > valeur2; break;
                    case "<=": res = valeur1 <= valeur2; break;
                    case ">=": res = valeur1 >= valeur2; break;
                    default: res = false; break;
                }
                if (res == true)
                {
                    blocalors.executer();
                }
            }
            else if (Class2.lesString.isIn(this.variable1) && Class2.lesString.isIn(this.variable2))
            {
                string valeur1 = Class2.lesString.getString(this.variable1);
                string valeur2 = Class2.lesString.getString(this.variable2);
                bool res = false;
                switch (comparateur)
                {
                    case "=": res = valeur1 == valeur2; break;
                    case "!=": res = valeur1 != valeur2; break;
                    default: res = false; break;
                }
                if (res == true)
                {
                    blocalors.executer();
                }
            }
            else if (Class2.lesFloat.isIn(this.variable1) && Class2.lesFloat.isIn(this.variable2))
            {
               float valeur1 = Class2.LesInt.getInteger(this.variable1);
               float valeur2 = Class2.LesInt.getInteger(this.variable2);
                bool res = false;
                switch (comparateur)
                {
                    case "=": res = valeur1 == valeur2; break;
                    case "!=": res = valeur1 != valeur2; break;
                    case "<": res = valeur1 < valeur2; break;
                    case ">": res = valeur1 > valeur2; break;
                    case "<=": res = valeur1 <= valeur2; break;
                    case ">=": res = valeur1 >= valeur2; break;
                    default: res = false; break;
                }
                if (res == true)
                {
                    blocalors.executer();
                }
            }
            else if (Class2.lesDouble.isIn(this.variable1) && Class2.lesDouble.isIn(this.variable2))
            {
               double valeur1 = Class2.LesInt.getInteger(this.variable1);
               double valeur2 = Class2.LesInt.getInteger(this.variable2);
                bool res = false;
                switch (comparateur)
                {
                    case "=": res = valeur1 == valeur2; break;
                    case "!=": res = valeur1 != valeur2; break;
                    case "<": res = valeur1 < valeur2; break;
                    case ">": res = valeur1 > valeur2; break;
                    case "<=": res = valeur1 <= valeur2; break;
                    case ">=": res = valeur1 >= valeur2; break;
                    default: res = false; break;
                }
                if (res == true)
                {
                    blocalors.executer();
                }
            }
            else if (Class2.LesInt.isIn(this.variable1) && Class2.lesFloat.isIn(this.variable2))
            {
               int valeur1 = Class2.LesInt.getInteger(this.variable1);
               float valeur2 = Class2.LesInt.getInteger(this.variable2);
                bool res = false;
                switch (comparateur)
                {
                    case "=": res = valeur1 == valeur2; break;
                    case "!=": res = valeur1 != valeur2; break;
                    case "<": res = valeur1 < valeur2; break;
                    case ">": res = valeur1 > valeur2; break;
                    case "<=": res = valeur1 <= valeur2; break;
                    case ">=": res = valeur1 >= valeur2; break;
                    default: res = false; break;
                }
                if (res == true)
                {
                    blocalors.executer();
                }
            }else if (Class2.lesFloat.isIn(this.variable1) && Class2.LesInt.isIn(this.variable2))
            {
              float valeur1 = Class2.LesInt.getInteger(this.variable1);
              int valeur2 = Class2.LesInt.getInteger(this.variable2);
                bool res = false;
                switch (comparateur)
                {
                    case "=": res = valeur1 == valeur2; break;
                    case "!=": res = valeur1 != valeur2; break;
                    case "<": res = valeur1 < valeur2; break;
                    case ">": res = valeur1 > valeur2; break;
                    case "<=": res = valeur1 <= valeur2; break;
                    case ">=": res = valeur1 >= valeur2; break;
                    default: res = false; break;
                }
                if (res == true)
                {
                    blocalors.executer();
                }
            }else if (Class2.lesDouble.isIn(this.variable1) && Class2.LesInt.isIn(this.variable2))
            {
               double valeur1 = Class2.LesInt.getInteger(this.variable1);
               int valeur2 = Class2.LesInt.getInteger(this.variable2);
                bool res = false;
                switch (comparateur)
                {
                    case "=": res = valeur1 == valeur2; break;
                    case "!=": res = valeur1 != valeur2; break;
                    case "<": res = valeur1 < valeur2; break;
                    case ">": res = valeur1 > valeur2; break;
                    case "<=": res = valeur1 <= valeur2; break;
                    case ">=": res = valeur1 >= valeur2; break;
                    default: res = false; break;
                }
                if (res == true)
                {
                    blocalors.executer();
                }
            }else if (Class2.LesInt.isIn(this.variable1) && Class2.lesDouble.isIn(this.variable2))
            {
               int valeur1 = Class2.LesInt.getInteger(this.variable1);
               double valeur2 = Class2.LesInt.getInteger(this.variable2);
                bool res = false;
                switch (comparateur)
                {
                    case "=": res = valeur1 == valeur2; break;
                    case "!=": res = valeur1 != valeur2; break;
                    case "<": res = valeur1 < valeur2; break;
                    case ">": res = valeur1 > valeur2; break;
                    case "<=": res = valeur1 <= valeur2; break;
                    case ">=": res = valeur1 >= valeur2; break;
                    default: res = false; break;
                }
                if (res == true)
                {
                    blocalors.executer();
                }
            }else if (Class2.lesFloat.isIn(this.variable1) && Class2.lesDouble.isIn(this.variable2))
            {
               float valeur1 = Class2.LesInt.getInteger(this.variable1);
               double valeur2 = Class2.LesInt.getInteger(this.variable2);
                bool res = false;
                switch (comparateur)
                {
                    case "=": res = valeur1 == valeur2; break;
                    case "!=": res = valeur1 != valeur2; break;
                    case "<": res = valeur1 < valeur2; break;
                    case ">": res = valeur1 > valeur2; break;
                    case "<=": res = valeur1 <= valeur2; break;
                    case ">=": res = valeur1 >= valeur2; break;
                    default: res = false; break;
                }
                if (res == true)
                {
                    blocalors.executer();
                }
            }
            if (Class2.lesDouble.isIn(this.variable1) && Class2.lesFloat.isIn(this.variable2))
            {
               double valeur1 = Class2.LesInt.getInteger(this.variable1);
               float valeur2 = Class2.LesInt.getInteger(this.variable2);
                bool res = false;
                switch (comparateur)
                {
                    case "=": res = valeur1 == valeur2; break;
                    case "!=": res = valeur1 != valeur2; break;
                    case "<": res = valeur1 < valeur2; break;
                    case ">": res = valeur1 > valeur2; break;
                    case "<=": res = valeur1 <= valeur2; break;
                    case ">=": res = valeur1 >= valeur2; break;
                    default: res = false; break;
                }
                if (res == true)
                {
                    blocalors.executer();
                }
            }
        }
    }
    class Instruction_WHILE : Instruction
    {
        string variable1;
        string variable2;
        string comparateur;
        Bloc blocalors;
        public Instruction_WHILE(string var1, string comparateur, string var2, Bloc bloc)
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
                if (Class2.LesInt.isIn(this.variable1) && Class2.LesInt.isIn(this.variable2))
                {
                    int val1 = Class2.LesInt.getInteger(this.variable1);
                    int val2 = Class2.LesInt.getInteger(this.variable2);
                    switch (comparateur)
                    {
                        case "=": res = val1 == val2; break;
                        case "!=": res = val1 != val2; break;
                        case "<": res = val1 < val2; break;
                        case ">": res = val1 > val2; break;
                        case "<=": res = val1 <= val2; break;
                        case ">=": res = val1 >= val2; break;
                        default: res = false; break;
                    }
                    if ((res == true) && (!Program.Form1.wantStop))
                    {
                        blocalors.executer();
                    }
                    else if ((res == true) && (Program.Form1.wantStop))
                    {
                        Application.DoEvents();
                    }
                }
                else if (Class2.lesFloat.isIn(this.variable1) && Class2.lesFloat.isIn(this.variable2))
                {
                    float val1 = Class2.LesInt.getInteger(this.variable1);
                    float val2 = Class2.LesInt.getInteger(this.variable2);
                    switch (comparateur)
                    {
                        case "=": res = val1 == val2; break;
                        case "!=": res = val1 != val2; break;
                        case "<": res = val1 < val2; break;
                        case ">": res = val1 > val2; break;
                        case "<=": res = val1 <= val2; break;
                        case ">=": res = val1 >= val2; break;
                        default: res = false; break;
                    }
                    if ((res == true) && (!Program.Form1.wantStop))
                    {
                        blocalors.executer();
                    }
                    else if ((res == true) && (Program.Form1.wantStop))
                    {
                        Application.DoEvents();
                    }
                }
                else if (Class2.lesDouble.isIn(this.variable1) && Class2.lesDouble.isIn(this.variable2))
                {
                    double val1 = Class2.LesInt.getInteger(this.variable1);
                    double val2 = Class2.LesInt.getInteger(this.variable2);
                    switch (comparateur)
                    {
                        case "=": res = val1 == val2; break;
                        case "!=": res = val1 != val2; break;
                        case "<": res = val1 < val2; break;
                        case ">": res = val1 > val2; break;
                        case "<=": res = val1 <= val2; break;
                        case ">=": res = val1 >= val2; break;
                        default: res = false; break;
                    }
                    if ((res == true) && (!Program.Form1.wantStop))
                    {
                        blocalors.executer();
                    }
                    else if ((res == true) && (Program.Form1.wantStop))
                    {
                        Application.DoEvents();
                    }
                }
                else if (Class2.LesInt.isIn(this.variable1) && Class2.lesDouble.isIn(this.variable2))
                {
                    int val1 = Class2.LesInt.getInteger(this.variable1);
                    double val2 = Class2.lesDouble.getDouble(this.variable2);
                    switch (comparateur)
                    {
                        case "=": res = val1 == val2; break;
                        case "!=": res = val1 != val2; break;
                        case "<": res = val1 < val2; break;
                        case ">": res = val1 > val2; break;
                        case "<=": res = val1 <= val2; break;
                        case ">=": res = val1 >= val2; break;
                        default: res = false; break;
                    }
                    if ((res == true) && (!Program.Form1.wantStop))
                    {
                        blocalors.executer();
                    }
                    else if ((res == true) && (Program.Form1.wantStop))
                    {
                        Application.DoEvents();
                    }
                }
                else if (Class2.lesDouble.isIn(this.variable1) && Class2.LesInt.isIn(this.variable2))
                {
                    double val1 = Class2.lesDouble.getDouble(this.variable1);
                    int val2 = Class2.LesInt.getInteger(this.variable2);
                    switch (comparateur)
                    {
                        case "=": res = val1 == val2; break;
                        case "!=": res = val1 != val2; break;
                        case "<": res = val1 < val2; break;
                        case ">": res = val1 > val2; break;
                        case "<=": res = val1 <= val2; break;
                        case ">=": res = val1 >= val2; break;
                        default: res = false; break;
                    }
                    if ((res == true) && (!Program.Form1.wantStop))
                    {
                        blocalors.executer();
                    }
                    else if ((res == true) && (Program.Form1.wantStop))
                    {
                        Application.DoEvents();
                    }
                }
                else if (Class2.LesInt.isIn(this.variable1) && Class2.lesFloat.isIn(this.variable2))
                {
                    int val1 = Class2.LesInt.getInteger(this.variable1);
                    float val2 = Class2.lesFloat.getFloat(this.variable2);
                    switch (comparateur)
                    {
                        case "=": res = val1 == val2; break;
                        case "!=": res = val1 != val2; break;
                        case "<": res = val1 < val2; break;
                        case ">": res = val1 > val2; break;
                        case "<=": res = val1 <= val2; break;
                        case ">=": res = val1 >= val2; break;
                        default: res = false; break;
                    }
                    if ((res == true) && (!Program.Form1.wantStop))
                    {
                        blocalors.executer();
                    }
                    else if ((res == true) && (Program.Form1.wantStop))
                    {
                        Application.DoEvents();
                    }
                }
                else if (Class2.lesFloat.isIn(this.variable1) && Class2.LesInt.isIn(this.variable2))
                {
                    float val1 = Class2.lesFloat.getFloat(this.variable1);
                    int val2 = Class2.LesInt.getInteger(this.variable2);
                    switch (comparateur)
                    {
                        case "=": res = val1 == val2; break;
                        case "!=": res = val1 != val2; break;
                        case "<": res = val1 < val2; break;
                        case ">": res = val1 > val2; break;
                        case "<=": res = val1 <= val2; break;
                        case ">=": res = val1 >= val2; break;
                        default: res = false; break;
                    }
                    if ((res == true) && (!Program.Form1.wantStop))
                    {
                        blocalors.executer();
                    }
                    else if ((res == true) && (Program.Form1.wantStop))
                    {
                        Application.DoEvents();
                    }
                }
                else if (Class2.lesFloat.isIn(this.variable1) && Class2.lesDouble.isIn(this.variable2))
                {
                    float val1 = Class2.lesFloat.getFloat(this.variable1);
                    double val2 = Class2.lesDouble.getDouble(this.variable2);
                    switch (comparateur)
                    {
                        case "=": res = val1 == val2; break;
                        case "!=": res = val1 != val2; break;
                        case "<": res = val1 < val2; break;
                        case ">": res = val1 > val2; break;
                        case "<=": res = val1 <= val2; break;
                        case ">=": res = val1 >= val2; break;
                        default: res = false; break;
                    }
                    if ((res == true) && (!Program.Form1.wantStop))
                    {
                        blocalors.executer();
                    }
                    else if ((res == true) && (Program.Form1.wantStop))
                    {
                        Application.DoEvents();
                    }
                }
                else if (Class2.lesDouble.isIn(this.variable1) && Class2.lesFloat.isIn(this.variable2))
                {
                    double val1 = Class2.lesDouble.getDouble(this.variable1);
                    float val2 = Class2.lesFloat.getFloat(this.variable2);
                    switch (comparateur)
                    {
                        case "=": res = val1 == val2; break;
                        case "!=": res = val1 != val2; break;
                        case "<": res = val1 < val2; break;
                        case ">": res = val1 > val2; break;
                        case "<=": res = val1 <= val2; break;
                        case ">=": res = val1 >= val2; break;
                        default: res = false; break;
                    }
                    if ((res == true) && (!Program.Form1.wantStop))
                    {
                        blocalors.executer();
                    }
                    else if ((res == true) && (Program.Form1.wantStop))
                    {
                        Application.DoEvents();
                    }
                }
                else if (Class2.lesString.isIn(this.variable1) && Class2.lesString.isIn(this.variable2))
                {
                    string val1 = Class2.lesString.getString(this.variable1);
                    string val2 = Class2.lesString.getString(this.variable2);
                    switch (comparateur)
                    {
                        case "=": res = val1 == val2; break;
                        case "!=": res = val1 != val2; break;
                        default: res = false; break;
                    }
                    if ((res == true) && (!Program.Form1.wantStop))
                    {
                        blocalors.executer();
                    }
                    else if ((res == true) && (Program.Form1.wantStop))
                    {
                        Application.DoEvents();
                    }
                }
            }
        }
    }
    class Instruction_FOR : Instruction
    {
        string variable1;
        string variable2;
        string variable3;
        Bloc blocalors;
        public Instruction_FOR(string var1, string var2, string var3, Bloc bloc)
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
            int val1;
            int val2;
            int val3;
            val2 = Class2.LesInt.getInteger(this.variable2);
            Class2.LesInt.setInteger(this.variable1, val2);
            while (res)
            {
                val1 = Class2.LesInt.getInteger(this.variable1);
                val2 = Class2.LesInt.getInteger(this.variable2);
                val3 = Class2.LesInt.getInteger(this.variable3);
                if ((res == true) && (!Program.Form1.wantStop))
                {
                    blocalors.executer();
                }
                else if ((res == true) && (Program.Form1.wantStop))
                {
                    Application.DoEvents();
                }
                val1 = val1 + 1;
                Class2.LesInt.setInteger(this.variable1, val1);
                if (val1 <= val3)
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
        List<object> val;
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
        string variable;

        public Instruction_Write(string var)
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
            if (Class2.LesInt.isIn(this.variable))
            {
                int valeur = Class2.LesInt.getInteger(this.variable);
                Program.Form1.Write(" " + valeur);
                Program.Form1.ln();
            }
            else if (Class2.lesDouble.isIn(this.variable))
            {
                double valeur = Class2.lesDouble.getDouble(this.variable);
                Program.Form1.Write(" " + valeur);
                Program.Form1.ln();
            }else if (Class2.lesFloat.isIn(this.variable))
            {
                float valeur = Class2.lesFloat.getFloat(this.variable);
                Program.Form1.Write(" " + valeur);
                Program.Form1.ln();
            }else if (Class2.lesChar.isIn(this.variable))
            {
                char valeur = Class2.lesChar.getChar(this.variable);
                Program.Form1.Write(" " + valeur);
                Program.Form1.ln();
            }else if (Class2.lesBoolean.isIn(this.variable))
            {
                bool valeur = Class2.lesBoolean.getBool(this.variable);
                Program.Form1.Write(" " + valeur);
                Program.Form1.ln();
            }
            else if (Class2.lesString.isIn(this.variable))
            {
                string valeur = Class2.lesString.getString(this.variable);
                Program.Form1.Write(" " + valeur);
                Program.Form1.ln();
            }
            else
            {
                Program.Form1.Write(this.variable);
                Program.Form1.ln();
            }
        }
    }
    class Instruction_Fun : Instruction
    {
        char variable1;
        Bloc blocalors;
        public Instruction_Fun(char var1, Bloc bloc)
        {
            this.variable1 = var1;
            this.blocalors = bloc;
        }
        public override void afficher()
        {
            Program.Form1.Write(" fun " + this.variable1 + " ");
            Program.Form1.ln();
        }
        public override void traduire()
        {
            Program.Form1.WriteTrad("");
            Program.Form1.lnTrad();
        }
        public override void executer()
        {
            Class2.LesVariables.setVariable(this.variable1, blocalors+"");
               // blocalors.executer();
               // TODO idée : Enregistrer le contenue de la fonction dans un fichier
               // pour l'execute plutart
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
