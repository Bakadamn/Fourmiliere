using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Fourmiliere
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //on propose une liste de choix à l'utilisateur
            Console.WriteLine("Choisissez une méthode de génération (tapez le chiffre puis entrer): \n"+
                "1.Créer la simulation et l'afficher dans un navigateur web\n" +
                "2.Créer la simulation et l'afficher dans la console\n" +
                "3.Créer le fichier TXT uniquement\n");
           
            int reponse = ChoixParametres(1,3);

            

          
            if (reponse == 3)
                FichierTxt.ChoixFolderFichierTxt();
            else
                FichierTxt.InitialisationFichierTexte();


            Console.WriteLine("1. Génération de la simulation par défaut \n2. Génération personnalisée");
            int generation = ChoixParametres(1, 2);
            int tailleX;
            int tailleY;
            int nombreFourmis;
            int nombreSucre;
            int nombreCailloux;
            if (generation == 1) // si carte par défaut
            {
                tailleX = 20;
                tailleY = 20;
                nombreFourmis = 20;
                nombreSucre = 10;
                nombreCailloux = 10;
            }
            else // si carte personnalisée par l'utilisateur
            {
                Console.WriteLine("\n\nDefinissez la taille de la carte puis tapez entrer (par défaut 20x20 conseillé)\n" +
                    "Nombre de case (largeur) (minimum 10, maximum 100) : ");
                tailleX = ChoixParametres(10, 100);
                Console.WriteLine("Nombre de case (hauteur) (minimum 10, maximum 100) : ");
                tailleY = ChoixParametres(10, 100);
                Console.WriteLine("Nombre de fourmis maximum (minimum 1, maximum 50) : ");
                nombreFourmis = ChoixParametres(1, 50);
                Console.WriteLine("Nombre de sucre (minimum 1, maximum 50) : ");
                nombreSucre = ChoixParametres(1, 50);
                Console.WriteLine("Nombre de cailloux (minimum 1, maximum 50) : ");
                nombreCailloux = ChoixParametres(1, 50);
            }

            bool GenerationConsole = false;



            //Création du tableau et remplissage en fonction des parametres définis au dessus

            RefTableau.classeTableau = new Tableau(tailleX,tailleY);
            RefTableau.classeTableau.InitialisationTableau();
            RefTableau.classeTableau.InitNid();
            RefTableau.classeTableau.InitPhero(RefTableau.classeTableau.posNid[0], RefTableau.classeTableau.posNid[1]);
            RefTableau.classeTableau.InitSucre(nombreSucre);
            RefTableau.classeTableau.InitCailloux(nombreCailloux);
            RefTableau.classeTableau.InitFourmis();

            if(reponse == 2) // si laffichage console est activé
            {
                GenerationConsole = true;
                string affichage = "";
                affichage = affichGrille(affichage);
                Console.WriteLine(affichage);
                Console.WriteLine();
                Console.ReadKey();
            }

           /// FichierTxt.creationFichierTxt();  //mis en commentaire pour dev

            Tour.TourDeJeu(GenerationConsole, nombreFourmis); // on lance les tours de jeux


            if(reponse == 1) // si lancement par url 
            Start();
        }


        static int ChoixParametres(int minimum, int maximum) // fonction qui demande a l'utilisateur une valeur entre un minimum et un maximum en console
        {
            int result;
            do
            {
                try 
                {
                    result = int.Parse(Console.ReadLine());

                    if (result > maximum || result < minimum)
                        Console.WriteLine("Le chiffre saisi est hors limite");
                }
                catch
                {
                    result = -1;
                    Console.WriteLine("Erreur dans les données saisies");
                }

            }while (result > maximum || result < minimum);
            return result;
        }

        public static void Start()
        {
            Process.Start("https://localhost/Fourmiliere/index.php");
        }

        public static string affichGrille(string affichage) // fonction qui affiche la grille a chaque tour sur la console en couleur
        {

            for (int i = 0; i < RefTableau.tab.GetLength(0); i++)
            {
                for (int y = 0; y < RefTableau.tab.GetLength(1); y++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    string aff = "";
                    Console.Write("|");
                    if (RefTableau.tab[i, y].contenu == '0')
                    {
                        if (RefTableau.tab[i, y].fourmis != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            if (RefTableau.tab[i, y].fourmis.porteSucre == true)
                                aff = "F ";
                            else
                                aff = "f";
                            
                        }
                        
                        else
                        {
                            if(RefTableau.tab[i,y].pheromone_sucre>0)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                aff = RefTableau.tab[i, y].pheromone_sucre.ToString();
                            }
                            else
                            aff=RefTableau.tab[i, y].pheromone_nid.ToString();
                        }
                    }
                    else if (RefTableau.tab[i, y].nombre_sucre > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        aff = RefTableau.tab[i, y].nombre_sucre.ToString();
                    }
                    else
                    {
                        if (RefTableau.tab[i, y].contenu == 'N')
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                        else if (RefTableau.tab[i, y].contenu == 'C')
                            Console.ForegroundColor = ConsoleColor.Magenta;

                        aff = RefTableau.tab[i, y].contenu.ToString();
                    }

                    if(aff.Length == 1)
                    Console.Write(aff + " ");
                    else
                    Console.Write(aff);

                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|\n");
                for(int a = 0; a< RefTableau.tab.GetLength(1); a++)
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
