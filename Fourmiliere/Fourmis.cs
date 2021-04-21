using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Fourmiliere
{
    public class Fourmis 
    {
        public bool sestDeplacee;
        public bool porteSucre;

        private Random rnd = new Random();

        

        private bool chercheSucre;
        private bool chercheNid;
        public Case caseFourmis;
        


        public Fourmis(Case ca)
        {
            caseFourmis = ca;
            porteSucre = false;
            chercheSucre = true;
        }

        public void DeplacementAleatoire(Case ca)
        {
            caseFourmis = ca;
            int x;
            int y;
            do
            {
               
                do
                {
                    x = caseFourmis.X;
                    y = caseFourmis.Y;
                    int rndX = rnd.Next(3);
                    if (rndX == 0)
                    {
                        x -= 1;
                    }
                    else if (rndX == 1)
                    {
                        x += 1;
                    }

                    int rndY;
                    do
                    {
                        rndY = rnd.Next(3);
                        if (rndY == 0)
                        {
                            y -= 1;
                        }
                        else if (rndY == 1)
                        {
                            y += 1;
                        } // prévoir une solution si la formis ne peux pas bouger
                    }
                    while (rndX == 2 && rndY == 2);
                }
                while (!CaisseAOut.EstDansLeTableau(x, y));
            }
            while (!CaisseAOut.CaseValidePourFourmis(Tableau.tableau[x, y]));

            DeplacerFourmis(x, y);

        }

        public void DeplacerFourmis(int x, int y)
        {
            Tableau.tableau[caseFourmis.X, caseFourmis.Y].fourmis = null;
            Tableau.tableau[x, y].fourmis = this;            
        }




    }
}