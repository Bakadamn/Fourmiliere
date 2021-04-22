using System;

namespace Fourmiliere
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;


            string affichage = "";
            Tableau tab = new Tableau(20, 20);
            tab.InitialisationTableau();
            tab.InitNid();
            tab.InitSucre(2);
            tab.InitCailloux(2);
            tab.InitFourmis(1);
            tab.InitFourmis(1);
            tab.InitFourmis(1);


            affichage = affichGrille(affichage);
            Console.WriteLine(affichage);
            Console.WriteLine();
            Console.ReadKey();
            //FichierTxt.creationFichierTxt();  //mis en commentaire pour dev
            Tour.TourDeJeu();
           
        }

        public static string affichGrille(string affichage)
        {
            for (int i = 0; i < Tableau.tableau.GetLength(0); i++)
            {
                for (int y = 0; y < Tableau.tableau.GetLength(1); y++)
                {
                    string aff = "";
                    if (Tableau.tableau[i, y].contenu == '0')
                    {
                        if (Tableau.tableau[i, y].fourmis != null)
                        {
                            aff = "F";
                        }
                        
                        else
                            aff = Tableau.tableau[i, y].pheromone_nid.ToString();
                    }
                    else if (Tableau.tableau[i, y].nombre_sucre > 0)
                    {
                        aff = Tableau.tableau[i, y].nombre_sucre.ToString();
                    }
                    else
                    {
                        affichage += Tableau.tableau[i, y].contenu;
                    }

                    affichage += aff;


                }
                affichage += "\n";
            }

            return affichage;
        }
    }
}
