using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fourmiliere
{
    public static class Tour
    {
        public static int nbTours = 0;

        //fonction qui effectue les actions du jeu à chaque tour
        //parametre ecriture console définit si on écrit dans la console ou non
        //parametre fourmisMaximum donne le nombre maximum de fourmi
        public static void TourDeJeu(bool ecritureConsole, int fourmisMaximum)
        {
            while(!SimulationEstTerminee() && nbTours<500) // on a mit une limite de 500 tours pour éviter les fichiers trop lourds
            {
                foreach (Case ca in RefTableau.tab)
                {
                    if (ca.fourmis != null)
                    {
                        ca.fourmis.sestDeplacee = false; //on parcours d'abord le tableau pour mettre le statut s'est déplacée des fourmis à faux
                    }
                }

                foreach (Case ca in RefTableau.tab)
                {
                    if(ca.fourmis!=null && ca.fourmis.sestDeplacee == false)
                    {//on vérifie que les fourmi ne se sont pas encore déplacee puis on les fait se deplacer
                  
                        ca.fourmis.sestDeplacee = true;
                        ca.fourmis.ChoixDeLaction();

                        
                    }
                    if(ca.pheromone_sucre>0) // si il y a des phéromones sucres on les décrémente (évaporation des phéromones)
                    {
                        ca.pheromone_sucre--;
                    }
                }
                if(ecritureConsole == true) // ici l'écriture dans la console de la grille
                {
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.WriteLine();

                    string affichage = "";
                    affichage = Program.affichGrille(affichage);
                    Console.WriteLine(affichage);
                }

                nbTours++;
                if (nbTours % 2 == 0 && Fourmis.nbrFourmis<fourmisMaximum)
                    RefTableau.classeTableau.InitFourmis();

                FichierTxt.AjoutAuFichier();  //en commentaire pour dev


            }

            FichierTxt.AjoutFinDeFichier();
            // on créer le fichier texte à la fin


        }

        private static bool SimulationEstTerminee() //verifie si les conditions de fin sont réunies
        {
            if (!MapContientSucre())
                if (!FourmisPortentDuSucre())
                    return true;

            return false;
        }


        private static bool FourmisPortentDuSucre() //verifie que plus aucune fourmi ne porte de sucre
        {
            foreach (Case ca in RefTableau.tab)
            {
                if (ca.fourmis != null)
                {
                    if(ca.fourmis.porteSucre)
                    return true;
                }
            }
            return false;
        }

        private static bool MapContientSucre() //verifie que la map contient du sucre
        {
            
            foreach(Case ca in RefTableau.tab)
            {
                if(ca.nombre_sucre > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
