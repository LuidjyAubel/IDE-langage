using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Linq.Expressions;

namespace IDE_langage
{
    abstract class Class2
    {
        static public Bloc Leprogramme; // le programme à construire
        static public Bloc LeBlocEnCourant; //auxilière de constructeur
        static public StreamReader fichierentre;
        public static Variables LesVariables;
        public static Integer LesInt;
        public static Str lesString;
        public static Char lesChar;
        public static Float lesFloat;
        public static Double lesDouble;
        public static Bool lesBoolean;
        static public Dictionary<string, string> temp = new Dictionary<string, string>();
        static public bool errorDeteted;

        /// <summary>
        /// Extrait le token
        /// </summary>
        /// <param name="indice"><see cref="System.Int32"/>The index of line</param>
        /// <param name="ligne"><see cref="System.String"/>The current line of the current file</param>
        static string ExtraireToken(ref int indice, string ligne)
        {
            string token = "";
            int lgn = ligne.Length;
            if (ligne == "") return token;
            if (lgn <= indice) return token;
            while (ligne[indice] <= ' ')
            {
                indice++;
                if (indice >= lgn) return token;
            }
            while (ligne[indice] > ' ')
            {
                token += ligne[indice];
                indice++;
                if (indice >= lgn) return token;
            }
            return token;
        }
        /// <summary>
        ///lit le bloc courrant
        /// </summary>
        /// <exception cref="System.Exception">
        /// </exception>
        static Bloc Lirebloc()
        {
            Bloc Ancienbloc = LeBlocEnCourant;
            LeBlocEnCourant = new Bloc();
            int i;
            string ligne = lireligne();
            i = 0;
            string token1 = ExtraireToken(ref i, ligne);
            if (token1 != "{") Erreur("{ manquante");
            // lire jusqua l'acolade fermante
            ligne = lireligne();
            i = 0;
            token1 = ExtraireToken(ref i, ligne);
            while (token1 != "}")
            {
                TraiterInstruction(ligne);
                ligne = lireligne();
                i = 0;
                token1 = ExtraireToken(ref i, ligne);
            }
            Bloc nouveaubloc = LeBlocEnCourant;     //BIDOUILLE
            LeBlocEnCourant = Ancienbloc;           //RESTAURE LE BLOC EN COURS
            return nouveaubloc;
        }

        static Bloc obj()
        {
            Bloc Ancienbloc = LeBlocEnCourant;
            LeBlocEnCourant = new Bloc();
            int i;
            string ligne = lireligne();
            i = 0;
            string token1 = ExtraireToken(ref i, ligne);
            if (token1 != "{") Erreur("{ manquante");
            // lire jusqua l'acolade fermante
            ligne = lireligne();
            i = 0;
            token1 = ExtraireToken(ref i, ligne);
            while (token1 != "}")
            {
               string token2 = ExtraireToken(ref i, ligne);
                if(token1 == "FUN")
                {
                    TraiterInstruction(ligne);
                }

                //Program.Form1.Write(token1+"\n"); //debug
                if ((token2 == " ")||(token2 == ":")) {
                    token2 = ExtraireToken(ref i, ligne);
                }
                temp.Add(token1, token2);
                Program.Form1.Write(temp.GetValueOrDefault("name"));
                //TraiterInstruction(ligne);
                ligne = lireligne();
                i = 0;
                token1 = ExtraireToken(ref i, ligne);
            }
            Bloc nouveaubloc = LeBlocEnCourant;     //BIDOUILLE
            LeBlocEnCourant = Ancienbloc;           //RESTAURE LE BLOC EN COURS
            return nouveaubloc;
        }
        /// <summary>
        /// Traite la ligne courrant
        /// </summary>
        /// <param name="ligne"><see cref="System.String"/>The current line of the current file</param>
        /// <paramref name="ligne"/> is <c>the current line</c>.
        /// <exception cref="System.Exception">
        /// </exception>
        static void TraiterInstruction(string ligne)
        {
            int i = 0;
            cpt++;
            string token = ExtraireToken(ref i, ligne);
            switch (token)
            {
                case "LET": traiterLet(i, ligne); break;
                case "ADD": traiterAdd(i, ligne); break;
                case "SUB": traiterSub(i, ligne); break;
                case "MUL": traiterMul(i, ligne); break;
                case "DIV": traiterDiv(i, ligne); break;
                case "IF": traiterIF(i, ligne); break;
                case "WHILE": traiterWhile(i, ligne); break;
                case "MOD": traiterMod(i, ligne); break;
                case "WRITE": traiterWrite(i, ligne); break;
                case "INC": traiterINC(i, ligne); break;
                case "DCR": traiterDCR(i, ligne); break;
                case "RAND": traiterRAND(i, ligne); break;
                case "FOR": traiterFOR(i, ligne);break;
                case "VAR": traiterVar(i, ligne); break;
                case "CAR": traiterCar(i, ligne);break;
                case "LIST": traiterList(i, ligne); break;
                case "GET": traiterGet(i, ligne); break;
                case "PUT": traiterPut(i, ligne); break;
                case "RMV": traiterRmv(i, ligne); break;
                case "OBJ": traiterObj(i, ligne); break;
                case "FUN": traiterFun(i, ligne); break;
                case "//": break;  //COMMENTAIRE
                case "": break;     //LIGNE VIDEUHHHH 
                default: Program.Form1.WriteErreur("ERROR: Instruction inconnue ! <" + token + "> \n"); break;
            }
            while (token != "")
            {
                token = ExtraireToken(ref i, ligne);
            }
        }
        /// <summary>
        /// Lit la ligne courrant
        /// </summary>
        static string lireligne()
        {
            return fichierentre.ReadLine();
        }
        /// <summary>
        /// Compile le fichier envoyer en paramètre 
        /// </summary>
        /// <param name="chemin"><see cref="System.String"/> the path of the file</param>
        /// <paramref name="chemin"/> is <c>path of file</c>.
        /// <exception cref="System.Exception">
        /// </exception>
        public static void Compiler(string chemin)
        {
            Leprogramme = new Bloc();
            try
            {
                fichierentre = new StreamReader(chemin);
                Leprogramme = Lirebloc();
                fichierentre.Close();
            }
            catch (Exception f)
            {
                Program.Form1.WriteErreur("\nException: " + f.Message);
            }
            finally
            {
                Program.Form1.Write("\nFin de la compilation\n");
            }
        }
        /// <summary>
        /// Affiche une erreur dans l'appel de l'instruction
        /// </summary>
        /// <param name="a"><see cref="System.String"/>Message of error</param>
        /// <paramref name="a"/> is <c>Message of error</c>.
        public static int Erreur(string a)
        {
            Program.Form1.WriteErreur("Erreur :" + a);
            errorDeteted = true;
            return -1;
        }
        /// <summary>
        /// Vérifie si le token passer en paramètre est une variable
        /// </summary>
        /// <param name="token"><see cref="System.String"/>Variable</param>
        /// <paramref name="token"/> is <c>variable</c>.
        static bool estVariable(string token)
        {
            return false;
        }
        /// <summary>
        /// Vérifie si le token passer en paramètre est un String
        /// </summary>
        /// <param name="token"><see cref="System.String"/>Variable</param>
        /// <paramref name="token"/> is <c>variable</c>.
        static bool estString(string token)
        {
            if (!token.All(char.IsDigit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Vérifie si le token passer en paramètre est un nombre ou un String
        /// </summary>
        /// <param name="token"><see cref="System.String"/>Variable</param>
        /// <paramref name="token"/> is <c>variable</c>. 
        static bool estStringOuNb(string token)
        {
            return estNombre(token) || estString(token);
        }
        /// <summary>
        /// Vérifie si le token passer en paramètre est une variable ou un String
        /// </summary>
        /// <param name="token"><see cref="System.String"/>Variable</param>
        /// <paramref name="token"/> is <c>variable</c>.
        static bool VarOuString(string token)
        {
            return estVariable(token) || estString(token);
        }
                /// <summary>
        /// Vérifie si le token passer en paramètre est un chiffre
        /// </summary>
        /// <param name="token"><see cref="System.String"/>Variable</param>
        /// <paramref name="token"/> is <c>variable</c>.
        static bool estchifre(char token)
        {
            return (token >= '0' && token <= '9');
        }
        /// <summary>
        /// Vérifie si le token passer en paramètre est un nombre
        /// </summary>
        /// <param name="token"><see cref="System.String"/>Variable</param>
        /// <paramref name="token"/> is <c>variable</c>.
        static bool estNombre(string token)
        {
            if (token.Length == 0) return false;
            for (int i = 0; i < token.Length; i++)
            {
                if (!estchifre(token[i])) return false;
            }
            return true;
        }
        /// <summary>
        /// Vérifie si le token passer en paramètre est un comparateur
        /// </summary>
        /// <param name="token"><see cref="System.String"/>Variable</param>
        /// <paramref name="token"/> is <c>variable</c>.
        static bool estComparateur(string token)
        {
            switch (token)
            {
                case "=": return true;
                case "!=": return true;
                case "<": return true;
                case ">": return true;
                case "<=": return true;
                case ">=": return true;
                default: return false;
            }
        }
        /// <summary>
        /// Vérifie si le token passer en paramètre est une constante
        /// </summary>
        /// <param name="token"><see cref="System.String"/>constante</param>
        /// <paramref name="token"/> is <c>constante</c>.
        static bool estConstant(string token)
        {
            for (int i = 0; i < token.Length; i++)
                if (estchifre(token[i])) return true;
            return false;
        }
        /// <summary>
        /// Vérifie si le token passer en paramètre est une variable ou une constante
        /// </summary>
        /// <param name="token"><see cref="System.String"/>Variable</param>
        /// <paramref name="token"/> is <c>variable</c>.
        static bool estVarConst(string token)
        {
            return estVariable(token) || estConstant(token);
        }
        static bool estType(string token)
        {
            if (token == "INT" || token == "FLOAT" || token == "STRING" || token == "CHAR" || token == "BOOL" ||token == "DOUBLE")
            {
                return true;
            }
            return false;
        }
        static int traiterLet(int i, string ligne)
        {
            string param1 = ExtraireToken(ref i, ligne);
            string param2 = ExtraireToken(ref i, ligne);
            string param3 = ExtraireToken(ref i, ligne);
            string reste = ExtraireToken(ref i, ligne);
            if (!estString(param1)) Erreur("Le 1er paramètre de Let doit être une variable");
            if (!estType(param2)) Erreur("Le 2ème paramètre de Let doit être un type");
            if (!estStringOuNb(param3)) Erreur("Le 3ème paramètre de Let doit être une variable ou une constante");
            if (reste != "") Erreur("Let n'accepte que 3 parametre");
            Instruction_Let instruction = new Instruction_Let(param1, param2, param3);
            LeBlocEnCourant.ajouter(instruction);
            return -1;
        }
        static int traiterPut(int i, string ligne)
        {
            string param1 = ExtraireToken(ref i, ligne); //VAR
            string param2 = ExtraireToken(ref i, ligne); //TAB
            string param3 = ExtraireToken(ref i, ligne); //nbr
            string reste = ExtraireToken(ref i, ligne);
            if (!estVariable(param1)) Erreur("Le 1er paramètre de put doit être une variable");
            if (!estVariable(param2)) Erreur("Le 2ème paramètre de put doit être une liste");
            if (!estStringOuNb(param3)) Erreur("Le 3ème paramètre de put doit être un entier");
            if (reste != "") Erreur("put n'accepte que 3 parametres");
            Instruction_Put instruction = new Instruction_Put(param1[0], param2[0], param3);
            LeBlocEnCourant.ajouter(instruction);
            return -1;
        }
        static int traiterGet(int i, string ligne)
        {
            string param1 = ExtraireToken(ref i, ligne); //VAR
            string param2 = ExtraireToken(ref i, ligne); //TAB
            string param3 = ExtraireToken(ref i, ligne); //index
            string reste = ExtraireToken(ref i, ligne);
            if (!estVariable(param1)) Erreur("Le 1er paramètre de get doit être une variable");
            if (!estVariable(param2)) Erreur("Le 2ème paramètre de get doit être une liste");
            if (!estStringOuNb(param3)) Erreur("Le 3ème paramètre de get doit être un entier");
            if (reste != "") Erreur("get n'accepte que 3 parametres");
            Instruction_Get instruction = new Instruction_Get(param1[0], param2[0], param3);
            LeBlocEnCourant.ajouter(instruction);
            return -1;
        }
        static int traiterRmv(int i, string ligne)
        {
            string param1 = ExtraireToken(ref i, ligne); //VAR
            string param2 = ExtraireToken(ref i, ligne); //TAB
            string param3 = ExtraireToken(ref i, ligne); //index
            string reste = ExtraireToken(ref i, ligne);
            if (!estVariable(param1)) Erreur("Le 1er paramètre de rmv doit être une variable");
            if (!estVariable(param2)) Erreur("Le 2ème paramètre de rmv doit être une liste");
            if (!estStringOuNb(param3)) Erreur("Le 3ème paramètre de rmv doit être un entier");
            if (reste != "") Erreur("rmv n'accepte que 3 parametres");
            Instruction_Rmv instruction = new Instruction_Rmv(param1[0], param2[0], param3);
            LeBlocEnCourant.ajouter(instruction);
            return -1;
        }
        static int traiterObj(int i, string ligne)
        {
            string param1 = ExtraireToken(ref i, ligne);
            string param2 = ExtraireToken(ref i, ligne);
            string reste = ExtraireToken(ref i, ligne);
            if (!estVariable(param1)) Erreur("Le 1er paramètre de Obj doit être une variable");
            if (!estStringOuNb(param2)) Erreur("Le 2ème paramètre de Obj doit être un string");
            if (reste != "") Erreur("Obj n'accepte que 3 parametre");
            Dictionary<string, string> attr = new Dictionary<string, string>();
            Bloc blocobj = obj();
            foreach (KeyValuePair<string, string> kvp in temp)
            {
                if (kvp.Key == "{")
                {
                    continue;
                }else if (kvp.Key == "FUN")
                {
                    continue;
                }
                else
                {
                    attr.Add(kvp.Key, kvp.Value);
                }
            }
            OBJ instruction = new OBJ(param1[0], param2, attr, blocobj);
            temp.Clear();
            LeBlocEnCourant.ajouter(instruction);
            return -1;
        }
        static int traiterList(int i, string ligne)
        {
            string param1 = ExtraireToken(ref i, ligne);
            string param2 = ExtraireToken(ref i, ligne);
            List<string> parm3 = new List<string>();
            if (param2 != "[") Erreur("[ manquante");
            string param3 = ExtraireToken(ref i, ligne);
            parm3.Add(param2);
            parm3.Add(param3);
            while(param3 != "]") {
                parm3.Add(ExtraireToken(ref i, ligne));
                param3 = parm3.Last();
            }
            string reste = ExtraireToken(ref i, ligne);
            if (!estString(param1)) Erreur("Le 1er paramètre de Liste doit être une variable");
            if (!estStringOuNb(param2)) Erreur("Le 2ème paramètre de Liste doit être une [");
            if (reste != "") Erreur("Liste n'accepte que 2 parametre");
            Instruction_List instruction = new Instruction_List(param1[0], parm3);
            LeBlocEnCourant.ajouter(instruction);
            return -1;
        }
        static int traiterFun(int i, string ligne)
        {
            string param1 = ExtraireToken(ref i, ligne);
            string reste = ExtraireToken(ref i, ligne);
            if (!estVariable(param1)) Erreur("Le 1er paramètre de Fun doit être une variable "+ligne+" "+i);
           // if (!estString(param2)) Erreur("Le 2ème paramètre de Fun doit être un nom"+param2);
            if (reste != "") Erreur("Fun n'accepte que 3 parametre");
            Bloc blocif = Lirebloc();
            Instruction_Fun instruction = new Instruction_Fun(param1[0], blocif);
            LeBlocEnCourant.ajouter(instruction);
            return -1;
        }
        static int traiterVar(int i, string ligne)
        {
            string param1 = ExtraireToken(ref i, ligne);
            string param2 = ExtraireToken(ref i, ligne);
            string param3 = ExtraireToken(ref i, ligne);
            string reste = ExtraireToken(ref i, ligne);
            if (!estString(param1)) Erreur("Le 1er paramètre de Var doit être une variable");
            if (!estType(param2)) Erreur("Le 2ème paramètre de Var doit être un type");
            if (!estStringOuNb(param3)) Erreur("Le 3ème paramètre de Var doit être une chiffre ou une chaine de caractère");
            if (reste != "") Erreur("Var n'accepte que 3 parametre");
            Instruction_Var instruction = new Instruction_Var(param1, param2, param3);
            LeBlocEnCourant.ajouter(instruction);
            return -1;
        }
        static int traiterRAND(int i, string ligne)
        {
            string param1 = ExtraireToken(ref i, ligne);
            string param2 = ExtraireToken(ref i, ligne);
            string param3 = ExtraireToken(ref i, ligne);
            string reste = ExtraireToken(ref i, ligne);
            if (!estVarConst(param1)) Erreur("Le 1er paramètre de Rand doit être une variable");
            if (!VarOuString(param2)) Erreur("Le 2ème paramètre de Rand doit être une variable ou une constante");
            if (!VarOuString(param3)) Erreur("Le 3ème paramètre de Rand doit être une variable ou une constante");
            if (reste != "") Erreur("Rand n'accepte que 3 parametre");
            Instruction_RAND instruction = new Instruction_RAND(param1, param2, param3);
            LeBlocEnCourant.ajouter(instruction);
            return -1;
        }
        static int traiterSub(int i, string ligne)
        {
            string param1 = ExtraireToken(ref i, ligne);
            string param2 = ExtraireToken(ref i, ligne);
            string param3 = ExtraireToken(ref i, ligne);
            string reste = ExtraireToken(ref i, ligne);
            if (!estString(param1)) Erreur("Le 1er paramètre de Sub doit être une variable");
            if (!VarOuString(param2)) Erreur("Le 2ème paramètre de Sub doit être une variable ou une constante");
            if (!VarOuString(param3)) Erreur("Le 3ème paramètre de Sub doit être une variable ou une constante");
            if (reste != "") Erreur("Sub n'accepte que 3 parametre");
            Instruction_SUB instruction = new Instruction_SUB(param1, param2, param3);
            LeBlocEnCourant.ajouter(instruction);
            return -1;
        }
        static int traiterWrite(int i, string ligne)
        {
            string param1 = ExtraireToken(ref i, ligne);
            string reste = ExtraireToken(ref i, ligne);
            if (!VarOuString(param1)) Erreur("Le 1er paramètre de Write doit être une variable ou une constante");
            if (reste != "") Erreur("Write n'accepte que 1 parametre");
            Instruction_Write instruction = new Instruction_Write(param1);
            LeBlocEnCourant.ajouter(instruction);
            return -1;
        }
        static int traiterAdd(int i, string ligne)
        {
            string param1 = ExtraireToken(ref i, ligne);
            string param2 = ExtraireToken(ref i, ligne);
            string param3 = ExtraireToken(ref i, ligne);
            string reste = ExtraireToken(ref i, ligne);
            if (!estString(param1)) Erreur("Le 1er paramètre de Add doit être une variable");
            if (!VarOuString(param2)) Erreur("Le 2ème paramètre de Add doit être une variable ou une constante");
            if (!VarOuString(param3)) Erreur("Le 3ème paramètre de Add doit être une variable ou une constante");
            if (reste != "") Erreur("Add n'accepte que 3 parametre");
            Instruction_ADD instruction = new Instruction_ADD(param1, param2, param3);
            LeBlocEnCourant.ajouter(instruction);
            return -1;
        }
        static int traiterCar(int i, string ligne)
        {
            string param1 = ExtraireToken(ref i, ligne);
            string param2 = ExtraireToken(ref i, ligne);
            string reste = ExtraireToken(ref i, ligne);
            if (!estVariable(param1)) Erreur("Le 1er paramètre de Car doit être une variable");
            if (!VarOuString(param2)) Erreur("Le 2ème paramètre de Car doit être une variable ou une constante");
            if (reste != "") Erreur("Car n'accepte que 3 parametre");
            Instruction_CAR instruction = new Instruction_CAR(param1, param2);
            LeBlocEnCourant.ajouter(instruction);
            return -1;
        }
        static int traiterMul(int i, string ligne)
        {
            string param1 = ExtraireToken(ref i, ligne);
            string param2 = ExtraireToken(ref i, ligne);
            string param3 = ExtraireToken(ref i, ligne);
            string reste = ExtraireToken(ref i, ligne);
            if (!estVariable(param1)) Erreur("Le 1er paramètre de Mul doit être une variable");
            if (!VarOuString(param2)) Erreur("Le 2ème paramètre de Mul doit être une variable ou une constante");
            if (!VarOuString(param3)) Erreur("Le 3ème paramètre de Mul doit être une variable ou une constante");
            if (reste != "") Erreur("Mul n'accepte que 3 parametre");
            Instruction_MUL instruction = new Instruction_MUL(param1, param2, param3);
            LeBlocEnCourant.ajouter(instruction);
            return -1;
        }
        static int traiterDiv(int i, string ligne)
        {
            string param1 = ExtraireToken(ref i, ligne);
            string param2 = ExtraireToken(ref i, ligne);
            string param3 = ExtraireToken(ref i, ligne);
            string reste = ExtraireToken(ref i, ligne);
            if (!estString(param1)) Erreur("Le 1er paramètre de Div doit être une variable");
            if (!VarOuString(param2)) Erreur("Le 2ème paramètre de Div doit être une variable ou une constante");
            if (!VarOuString(param3)) Erreur("Le 3ème paramètre de Div doit être une variable ou une constante");
            if (reste != "") Erreur("Div n'accepte que 3 parametre");
            Instruction_DIV instruction = new Instruction_DIV(param1, param2, param3);
            LeBlocEnCourant.ajouter(instruction);
            return -1;
        }
        static int traiterMod(int i, string ligne)
        {
            string param1 = ExtraireToken(ref i, ligne);
            string param2 = ExtraireToken(ref i, ligne);
            string param3 = ExtraireToken(ref i, ligne);
            string reste = ExtraireToken(ref i, ligne);
            if (!estString(param1)) Erreur("Le 1er paramètre de Mod doit être une variable");
            if (!VarOuString(param2)) Erreur("Le 2ème paramètre de Mod doit être une variable ou une constante");
            if (!VarOuString(param3)) Erreur("Le 3ème paramètre de Mod doit être une variable ou une constante");
            if (reste != "") Erreur("Mod n'accepte que 3 parametre");
            Instruction_MOD instruction = new Instruction_MOD(param1, param2, param3);
            LeBlocEnCourant.ajouter(instruction);
            return -1;
        }
        static int traiterIF(int i, string ligne)
        {
            string param1 = ExtraireToken(ref i, ligne);
            string param2 = ExtraireToken(ref i, ligne);
            string param3 = ExtraireToken(ref i, ligne);
            string reste = ExtraireToken(ref i, ligne);
            if (!VarOuString(param1)) Erreur("Le 1er paramètre de If doit être une variable");
            if (!estComparateur(param2)) Erreur("Le 2ème paramètre de If doit être un comarateur");
            if (!VarOuString(param3)) Erreur("Le 3ème paramètre de If doit être une variable");
            if (reste != "") Erreur("If n'accepte que 3 parametre");
            Bloc blocif = Lirebloc();
            Instruction_IF instruction = new Instruction_IF(param1, param2, param3, blocif);
            LeBlocEnCourant.ajouter(instruction);
            return -1;
        }
        static int traiterWhile(int i, string ligne)
        {
            string param1 = ExtraireToken(ref i, ligne);
            string param2 = ExtraireToken(ref i, ligne);
            string param3 = ExtraireToken(ref i, ligne);
            string reste = ExtraireToken(ref i, ligne);
            if (!estVariable(param1)) Erreur("Le 1er paramètre de While doit être une variable");
            if (!estComparateur(param2)) Erreur("Le 2ème paramètre de While doit être un comparateur");
            if (!estVariable(param3)) Erreur("Le 3ème paramètre de While doit être une variable");
            if (reste != "") Erreur("While n'accepte que 3 parametre");
            Bloc blocif = Lirebloc();
            Instruction_WHILE instruction = new Instruction_WHILE(param1, param2, param3, blocif);
            LeBlocEnCourant.ajouter(instruction);
            return -1;
        }
        static int traiterFOR(int i, string ligne)
        {
            string param1 = ExtraireToken(ref i, ligne);
            string param2 = ExtraireToken(ref i, ligne);
            string param3 = ExtraireToken(ref i, ligne);
            string reste = ExtraireToken(ref i, ligne);
            if (!VarOuString(param1)) Erreur("Le 1er paramètre de For doit être une variable");
            if (!VarOuString(param2)) Erreur("Le 2ème paramètre de For doit être une variable");
            if (!VarOuString(param3)) Erreur("Le 3ème paramètre de For doit être une variable");
            if (reste != "") Erreur("For n'accepte que 3 parametre");
            Bloc blocif = Lirebloc();
            Instruction_FOR instruction = new Instruction_FOR(param1, param2, param3, blocif);
            LeBlocEnCourant.ajouter(instruction);
            return -1;
        }
        static int traiterINC(int i, string ligne)
        {
            string param1 = ExtraireToken(ref i, ligne);
            string reste = ExtraireToken(ref i, ligne);
            if (!estString(param1)) Erreur("Le 1er paramètre de Inc doit être une variable");
            if (reste != "") Erreur("Inc n'accepte que 1 parametre");
            Instruction_INC instruction = new Instruction_INC(param1);
            LeBlocEnCourant.ajouter(instruction);
            return -1;
        }
        static int traiterDCR(int i, string ligne)
        {
            string param1 = ExtraireToken(ref i, ligne);
            string reste = ExtraireToken(ref i, ligne);
            if (!estString(param1)) Erreur("Le 1er paramètre de Dcr doit être une variable");
            if (reste != "") Erreur("Dcr n'accepte que 1 parametre");
            Instruction_DCR instruction = new Instruction_DCR(param1);
            LeBlocEnCourant.ajouter(instruction);
            return -1;
        }
        static int cpt = 0;
    }
}
