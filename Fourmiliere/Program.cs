using System;

namespace Fourmiliere
{
    class Program
    {
        static void Main(string[] args)
        {
            
            


            string affichage = "";
            Tableau tab = new Tableau(20, 20);
            tab.InitialisationTableau();
            tab.InitNid();
            tab.InitPhero(tab.posNid[0], tab.posNid[1]);
            //tab.InitSucre(10);
            //tab.InitCailloux(2);
            //tab.InitFourmis(1);



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
                    Console.ForegroundColor = ConsoleColor.White;
                    string aff = "";
                    if (Tableau.tableau[i, y].contenu == '0')
                    {
                        if (Tableau.tableau[i, y].fourmis != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            aff = "F";
                            Console.Write(aff);
                        }
                        
                        else
                        {

                            aff = Tableau.tableau[i, y].pheromone_nid.ToString();

                            Console.Write(Tableau.tableau[i, y].pheromone_nid.ToString());
                        }
                    }
                    else if (Tableau.tableau[i, y].nombre_sucre > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        aff = Tableau.tableau[i, y].nombre_sucre.ToString();
                        Console.Write(Tableau.tableau[i, y].nombre_sucre.ToString());
                    }
                    else
                    {
                        if (Tableau.tableau[i, y].contenu == 'N')
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                        else if (Tableau.tableau[i, y].contenu == 'C')
                            Console.ForegroundColor = ConsoleColor.Magenta;

                        affichage += Tableau.tableau[i, y].contenu;
                        Console.Write(Tableau.tableau[i, y].contenu);
                    }

                    affichage += aff;


                }
                //affichage += "\n";
                Console.Write("\n");
            }
            affichage = "";
            return affichage;
        }
    }
}
