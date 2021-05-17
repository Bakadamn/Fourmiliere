using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Fourmiliere
{
    public class FichierTxt
    {


        static string path = @"C:\Users\admin\Desktop\Projet fourmiliere\Projet Fourmis ADAI\Bakadamn\Fourmiliere\Fourmiliere\simulation.txt";
        public static void creationFichierTxt()
        {

            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine((Tableau.tableau.GetUpperBound(0) + 1) + " " + (Tableau.tableau.GetUpperBound(1) + 1) + " " + Tour.nbToursMax);
            }
        }

        public static void AjoutAuFichier()
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                foreach (Case ca in Tableau.tableau)
                {
                    sw.WriteLine(ca.contenu + " " + ca.nombre_sucre + " " + ca.pheromone_nid + " " + ca.pheromone_sucre);
                }
            }
        }

    }
}
