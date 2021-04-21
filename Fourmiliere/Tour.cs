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

        public static void TourDeJeu()
        {
            while(MapContientSucre())
            {
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
                        ca.fourmis.DeplacementAleatoire(ca);
                        
                    }
                }
                Console.WriteLine();
                Console.ReadKey();
                Console.WriteLine();
                string affichage = "";
                affichage = Program.affichGrille(affichage);
                Console.WriteLine(affichage);
                nbTours++;
                FichierTxt.AjoutAuFichier();
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
