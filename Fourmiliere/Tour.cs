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
            while(MapContientSucre() && nbTours<500)
            {
                foreach (Case ca in RefTableau.tab)
                {
                    if (ca.fourmis != null)
                    {
                        ca.fourmis.sestDeplacee = false;
                    }
                }

                foreach (Case ca in RefTableau.tab)
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
               Console.WriteLine();
               Console.ReadKey();
               Console.WriteLine();

               string affichage = "";
               affichage = Program.affichGrille(affichage);
               Console.WriteLine(affichage);

                nbTours++;
                if (nbTours % 2 == 0 && Fourmis.nbrFourmis<20)
                 //   RefTableau.classeTableau.InitFourmis(1);

                FichierTxt.AjoutAuFichier();  //en commentaire pour dev
            }

            FichierTxt.AjoutFinDeFichier();



        }




        private static bool MapContientSucre()
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
