using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Fourmiliere
{
    public class Fourmis 
    {

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
            caseFourmis = ca;           //faire les test 

            int x = this.caseFourmis.X;
            int y = this.caseFourmis.Y;

            int rndX = rnd.Next(3);
            if(rndX == 0)
            {
                if (x != 0)
                {
                    x -= 1;
                }
                
            }
            else if(rndX == 1)
            {
                if (x != 19)
                {
                    x += 1;
                }
               
            }

            int rndY = 0;
            do
            {
                rndY = rnd.Next(3);
                if (rndY == 0)
                {
                    if (y != 0)
                    {
                        y -= 1;
                    }
                }
                else if (rndY == 1)
                {
                    if (y != 19)
                    {
                        y += 1;
                    }
                    
                }
            }
            while (rndX == 2 && rndY == 2);

            DeplacerFourmis(x, y);

        }

        public void DeplacerFourmis(int x, int y)
        {
            Tableau.tableau[caseFourmis.X, caseFourmis.Y].fourmis = null;
            Tableau.tableau[x, y].fourmis = this;            
        }




    }
}