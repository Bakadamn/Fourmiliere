using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace Fourmiliere
{
    public class FichierTxt
    {
        public int ah = 3;
        

        static string path;


        public static void InitialisationFichierTexte() // initialisation du fichier texte, à placer dans le fichier HTdocs de Xampp
        {
            //en fonction de sur quel pc on lance l'appli le chemin n'est pas le meme (nous étions deux à travailler sur le C#)
            if(System.Security.Principal.WindowsIdentity.GetCurrent().Name == "LAPTOP-9DANU7Q5\\cheva")
            {
                path = @"C:\xampp\htdocs\Fourmiliere\media\simulation.txt";
                if (File.Exists(path))
                    File.Delete(path);
            }
            else
            {

                path = @"C:\xampp\xampp\htdocs\Fourmiliere\media\simulation.txt";
                if (File.Exists(path))
                    File.Delete(path);
            }
        }
        [STAThread]
        public static void ChoixFolderFichierTxt() //Fonction pour que l'utilisateur choisisse l'emplacement en cas de génération de texte seulement
        {
            
            FolderBrowserDialog fenetre = new FolderBrowserDialog();
            if(fenetre.ShowDialog() == DialogResult.OK )
            {
                path = fenetre.SelectedPath+"//simulation.txt";
            }
            else 
            {
                InitialisationFichierTexte();
            }
        }

        private static List<String> ligne = new List<string>();

        public static void AjoutAuFichier()
        {
            // ici on rempli une liste de string, qui servira a la fin de la simulation à créer le fichier texte
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
            // ici on lit chaque lignes de la liste et on les écrit dans le fichier texte
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
