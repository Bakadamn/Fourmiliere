using System;
using System.Diagnostics;

namespace Fourmiliere
{
    class Program
    {
        static void Main(string[] args)
        {

            //Start();

            string affichage = "";
            Tableau tab = new Tableau(20, 20);

            //Console.SetWindowSize(Tableau.tableau.GetLength(1)*3+1, Tableau.tableau.GetLength(0)*2+3);
            tab.InitialisationTableau();
            tab.InitNid();
            tab.InitPhero(tab.posNid[0], tab.posNid[1]);
            tab.InitSucre(10);
            tab.InitCailloux(5);
            tab.InitFourmis(1);
            tab.InitFourmis(1);



            //affichage = affichGrille(affichage);
            //Console.WriteLine(affichage);
            //Console.WriteLine();
            //Console.ReadKey();
            FichierTxt.creationFichierTxt();  //creation fichier TXT de la simulation
            Tour.TourDeJeu();

            
        }

        private static void Start()
        {
                Process.Start("https://google.fr");
        }





        public static string affichGrille(string affichage)
        {

            for (int i = 0; i < Tableau.tableau.GetLength(0); i++)
            {
                for (int y = 0; y < Tableau.tableau.GetLength(1); y++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    string aff = "";
                    Console.Write("|");
                    if (Tableau.tableau[i, y].contenu == '0')
                    {
                        if (Tableau.tableau[i, y].fourmis != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            aff = "F ";
                            
                        }
                        
                        else
                        {
                            if(Tableau.tableau[i,y].pheromone_sucre>0)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                aff = Tableau.tableau[i, y].pheromone_sucre.ToString();
                            }
                            else
                            aff=Tableau.tableau[i, y].pheromone_nid.ToString();
                        }
                    }
                    else if (Tableau.tableau[i, y].nombre_sucre > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        aff = Tableau.tableau[i, y].nombre_sucre.ToString();
                    }
                    else
                    {
                        if (Tableau.tableau[i, y].contenu == 'N')
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                        else if (Tableau.tableau[i, y].contenu == 'C')
                            Console.ForegroundColor = ConsoleColor.Magenta;

                        aff = Tableau.tableau[i, y].contenu.ToString();
                    }

                    if(aff.Length == 1)
                    Console.Write(aff + " ");
                    else
                    Console.Write(aff);

                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|\n");
                for(int a = 0; a< Tableau.tableau.GetLength(1); a++)
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
