﻿using System;

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
            tab.InitSucre(5);
            tab.InitCailloux(20);
            tab.InitFourmis(5);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            affichage = AffichGrille(affichage);
            Console.WriteLine(affichage);
            Console.ReadKey();
            Console.WriteLine();
            
            Tour.TourDeJeu();
            
        }

        public static string AffichGrille(string affichage)
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
