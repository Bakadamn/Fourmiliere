
using System.Collections.Generic;

namespace Fourmiliere
{
    static class CaisseAOut
    {
        public static bool CaseValidePourFourmis(Case ca) //verifie si une case est elligible a un déplacement de fourmi
        {
            if (!CaseEstVide(ca))
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
            if (ca.contenu == '0')          
            {
                return true;
            }
            else
                return false;
        }
        public static bool EstDansLeTableau(int x, int y) //verifie que les coordonnées sont bien dans les limites du tableau
        {
            if (x < RefTableau.tab.GetLength(0) && x >= 0 &&
                y < RefTableau.tab.GetLength(1) && y>= 0) 
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
            if (RefTableau.tab[x, y].fourmis == null)
                return true;
            else
                return false;
        }

        public static List<Case> CasesAlentours(int x, int y) //retourne la liste des cases qui entourent la fourmi
        {
            List<Case> liste = new List<Case>();

            for (int i = 0; i < 3; i++)
            {
                if (CaisseAOut.EstDansLeTableau(x - 1 + i, y - 1))
                    liste.Add(RefTableau.tab[x - 1 + i, y - 1]);

                if (CaisseAOut.EstDansLeTableau(x - 1 + i, y + 1))
                    liste.Add(RefTableau.tab[x - 1 + i, y + 1]);

                if (CaisseAOut.EstDansLeTableau(x - 1 + i, y) && i != 1)
                    liste.Add(RefTableau.tab[x - 1 + i, y]);
            }


            return liste;

        }
    }
}
