using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fourmiliere
{
    public static class Tour
    {
        public static int nbTours = 1;
        public static int nbToursMax = 25;

        public static void TourDeJeu()
        {
            while(MapContientSucre() && nbTours<=nbToursMax+1)
            {
                if (nbTours == (nbToursMax+1))
                {
                    //Console.WriteLine();
                    //Console.WriteLine("Fin du jeu");
                    //Console.ReadKey();
                    return;
                    
                }

                foreach (Case ca in Tableau.tableau)
                {
                    if (ca.fourmis != null)
                    {
                        ca.fourmis.sestDeplacee = false;
                    }
                }

                foreach (Case ca in Tableau.tableau)
                {
                    if(ca.fourmis!=null && ca.fourmis.sestDeplacee == false)
                    {
                        //méthode fourmis
                        ca.fourmis.sestDeplacee = true;
                        ca.fourmis.ChoixDeLaction();
                        
                    }
                    if(ca.pheromone_sucre>0)
                    {
                        ca.pheromone_sucre--;
                    }
                }

               
                //Console.WriteLine();
                //Console.ReadKey();
                //Console.WriteLine("Tour " + nbTours);

                string affichage = "";
                //affichage = Program.affichGrille(affichage);
                //Console.WriteLine(affichage);
                nbTours++;
                FichierTxt.AjoutAuFichier();  //en commentaire pour dev
            }
        }




        private static bool MapContientSucre()
        {
            
            foreach(Case ca in Tableau.tableau)
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
