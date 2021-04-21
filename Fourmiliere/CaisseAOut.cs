using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fourmiliere
{
    static class CaisseAOut
    {
        public static bool CaseValidePourFourmis(Case ca) //verifie si une case est elligible a un déplacement de fourmi
        {
            if (!CaseEstVide(ca))
                return false;
            if (!EstDansLeTableau(ca.X, ca.Y))
                return false;
            if (!CaseEstSansFourmis(ca.X, ca.Y))
                return false;
            
            return true;
        }
        public static int[] DeuxValeurEnTableau(int une, int deux) //met deux int dans un int[]
        {
            int[] instance = new int[2];
            instance[0] = une;
            instance[1] = deux;

            return instance;
        }

        public static bool CaseEstVide(Case ca) //verifie si la case ne contient pas d'element (cailloux, sucre, nid)
        {
            if (ca.contenu == '0')          //marche pas tout le temps u_u avec les 'C' uniquement?
            {
                return true;
            }
            else
                return false;
        }
        public static bool EstDansLeTableau(int x, int y) //verifie que les coordonnées sont bien dans les limites du tableau
        {
            if (x < Tableau.tableau.GetLength(0)-1 && x >= 0 && y < Tableau.tableau.GetLength(1)-1 && y>= 0) 
            {                                       
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CaseEstSansFourmis(int x, int y) //verifie si une case ne contient pas de fourmis
        { 
            if (Tableau.tableau[x, y].fourmis == null)
                return true;
            else
                return false;
        }
    }
}
