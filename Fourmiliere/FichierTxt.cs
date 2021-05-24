using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Resources;


namespace Fourmiliere
{
    public class FichierTxt
    {
        public int ah = 3;
        

        static string path;


        public static void InitialisationFichierTexte()
        {
            if(System.Security.Principal.WindowsIdentity.GetCurrent().Name == "LAPTOP-9DANU7Q5\\cheva")
            {
                path = @"C:\xampp\htdocs\Fourmiliere\media\simulation.txt";
            }
            else
                path = @"C:\xampp\xampp\htdocs\Fourmiliere\media\simulation.txt";
        }


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
