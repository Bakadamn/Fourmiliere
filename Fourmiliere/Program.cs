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
            int cpt = 0;
            string affichage = "";
            for (int i = 0; i < Tableau.tableau.GetLength(0); i++)
            {
                for (int y = 0; y < Tableau.tableau.GetLength(1); y++)
                {
                    affichage += "0 ";
                    
                }
                affichage += "\n";
            }
            Console.WriteLine(affichage);
            Console.ReadKey();
        }
    }
}
