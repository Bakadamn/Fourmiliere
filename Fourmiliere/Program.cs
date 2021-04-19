using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fourmiliere
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string affichage = "";
            Tableau tab = new Tableau(20,20);
            tab.InitialisationTableau();
            tab.InitNid();
            tab.InitCailloux(20);
            Console.BackgroundColor = ConsoleColor.Red;
            
            for (int i = 0; i < tab.tableau.GetLength(0); i++)
            {
                for (int y = 0; y < tab.tableau.GetLength(1); y++)
                {
                    string aff = "";
                    if (tab.tableau[i,y].contenu=='F')
                    {
                        aff = tab.tableau[i, y].pheromone_nid.ToString();
                    }
                    else
                    {
                        affichage += tab.tableau[i, y].contenu ;
                    }

                    affichage += aff ;
                    
                    
                }
                affichage += "\n";
            }


            Console.WriteLine(affichage);
            Console.ReadKey();
        }
    }
}
