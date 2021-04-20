using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fourmiliere
{
    public static class Tour
    {

        public static void TourDeJeu()
        {
            while(MapContientSucre())
            {
                foreach(Case ca in Tableau.tableau)
                {
                    if(ca.fourmis!=null)
                    {
                        //méthode fourmis
                        ca.fourmis.DeplacementAleatoire(ca);
                    }
                }
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
