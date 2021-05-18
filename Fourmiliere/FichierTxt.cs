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
        static string path = @"C:\Fichiers\Fourmis\simulation.txt";

        private static List<String> ligne = new List<string>();
        public static void creationFichierTxt()
        {

               // ligne.Add((RefTableau.tab.GetUpperBound(0) + 1) + " " + (RefTableau.tab.GetUpperBound(1) + 1) + " " + Tour.nbTours);
        }

        public static void AjoutAuFichier()
        {
            
                foreach (Case ca in RefTableau.tab)
                {
                    if(ca.fourmis!=null && ca.fourmis.porteSucre)
                    ligne.Add("F" + " " + ca.nombre_sucre + " " + ca.pheromone_nid + " " + ca.pheromone_sucre);
                    else if(ca.fourmis!=null && !ca.fourmis.porteSucre)
                    ligne.Add("f" + " " + ca.nombre_sucre + " " + ca.pheromone_nid + " " + ca.pheromone_sucre);
                    else
                    ligne.Add(ca.contenu + " " + ca.nombre_sucre + " " + ca.pheromone_nid + " " + ca.pheromone_sucre);
                }
            
        }
        public static void AjoutFinDeFichier()
        {
     
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine((RefTableau.tab.GetUpperBound(0) + 1) + " " + (RefTableau.tab.GetUpperBound(1) + 1) + " " + Tour.nbTours);

                foreach(string lign in ligne)
                {
                    sw.WriteLine(lign);
                }
            }           
        }

    }
}
