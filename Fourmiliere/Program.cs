using System;
using System.Diagnostics;

namespace Fourmiliere
{
    class Program
    {
        static void Main(string[] args)
        {
            
            


            string affichage = "";
            RefTableau.classeTableau = new Tableau(20, 20);

            Console.SetWindowSize(RefTableau.tab.GetLength(1)*3+1, RefTableau.tab.GetLength(0)*2+3);
            RefTableau.classeTableau.InitialisationTableau();
            RefTableau.classeTableau.InitNid();
            RefTableau.classeTableau.InitPhero(RefTableau.classeTableau.posNid[0], RefTableau.classeTableau.posNid[1]);
            RefTableau.classeTableau.InitSucre(10);
            RefTableau.classeTableau.InitCailloux(5);
            RefTableau.classeTableau.InitFourmis(1);



            //affichage = affichGrille(affichage);
            //Console.WriteLine(affichage);
            //Console.WriteLine();
            //Console.ReadKey();

            FichierTxt.creationFichierTxt();  //mis en commentaire pour dev
            Tour.TourDeJeu();

            Start();
        }


        public static void Start()
        {
            Process.Start("https://localhost/Fourmiliere/index.php");
        }

        public static string affichGrille(string affichage)
        {

            for (int i = 0; i < RefTableau.tab.GetLength(0); i++)
            {
                for (int y = 0; y < RefTableau.tab.GetLength(1); y++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    string aff = "";
                    Console.Write("|");
                    if (RefTableau.tab[i, y].contenu == '0')
                    {
                        if (RefTableau.tab[i, y].fourmis != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            aff = "F ";
                            
                        }
                        
                        else
                        {
                            if(RefTableau.tab[i,y].pheromone_sucre>0)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                aff = RefTableau.tab[i, y].pheromone_sucre.ToString();
                            }
                            else
                            aff=RefTableau.tab[i, y].pheromone_nid.ToString();
                        }
                    }
                    else if (RefTableau.tab[i, y].nombre_sucre > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        aff = RefTableau.tab[i, y].nombre_sucre.ToString();
                    }
                    else
                    {
                        if (RefTableau.tab[i, y].contenu == 'N')
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                        else if (RefTableau.tab[i, y].contenu == 'C')
                            Console.ForegroundColor = ConsoleColor.Magenta;

                        aff = RefTableau.tab[i, y].contenu.ToString();
                    }

                    if(aff.Length == 1)
                    Console.Write(aff + " ");
                    else
                    Console.Write(aff);

                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|\n");
                for(int a = 0; a< RefTableau.tab.GetLength(1); a++)
                {
                    Console.Write("---");
                }
                Console.Write("-\n");
            }
            affichage = "";
            return affichage;
        }
    }
}
