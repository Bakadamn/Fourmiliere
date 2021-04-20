using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fourmiliere
{
    class Tour
    {
        private Tableau map;
        public Tour(Tableau tab)
        {
            map = tab;
        }
        
        public void TourDeJeu()
        {
            while(MapContientSucre())
            {
                foreach(Case ca in map.tableau)
                {
                    if(ca.fourmis!=null)
                    {
                        //méthode fourmis
                    }
                }
            }
        }



        private bool MapContientSucre()
        {
            
            foreach(Case ca in map.tableau)
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
