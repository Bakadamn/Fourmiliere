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

        private int distanceNid;
        private int distanceSucre;

        public Fourmis(Case ca)
        {
            caseFourmis = ca;
            porteSucre = false;
            chercheSucre = true;
        }


        public void ChoixDeLaction()
        {



            DeplacementAleatoire();
        }

        public void DeplacementAleatoire()
        {
            CasesAlentours();
            int x;
            int y;
            do
            {

                do
                {
                    x = caseFourmis.X;
                    
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
                        y = caseFourmis.Y;
                        rndY = rnd.Next(3);
                        if (rndY == 0)
                        {
                            y -= 1;
                        }
                        else if (rndY == 1)
                        {
                            y += 1;
                        } // prévoir une solution si la fourmis ne peux pas bouger
                    }
                    while (rndX == 2 && rndY == 2);
                }
                while (!CaisseAOut.EstDansLeTableau(x, y));
            }
            while (!CaisseAOut.CaseValidePourFourmis(Tableau.tableau[x, y]));

            DeplacerFourmis(x, y);

        }

        private void DeplacerFourmis(int x, int y)
        {
            DepotDePheromone();
            Tableau.tableau[caseFourmis.X, caseFourmis.Y].fourmis = null;
            Tableau.tableau[x, y].fourmis = this;
            caseFourmis = Tableau.tableau[x, y];
        }


        private void DepotDePheromone()
        {

        }

        private List<Case> CasesAlentours() //retourne la liste des cases entourant la fourmi
        {
            int x = caseFourmis.X;
            int y = caseFourmis.Y;
            List<Case> liste = new List<Case>();

            for(int i = 0; i<3;i++)
            {
                if (CaisseAOut.EstDansLeTableau(x - 1 + i, y - 1))
                    liste.Add(Tableau.tableau[x-1 +i, y-1]);

                if (CaisseAOut.EstDansLeTableau(x - 1 + i, y + 1)) 
                    liste.Add(Tableau.tableau[x-1 +i, y+1]);

                if (CaisseAOut.EstDansLeTableau(x - 1 + i, y ) && i != 1)
                    liste.Add(Tableau.tableau[x - 1 + i, y]);
            }

            foreach(Case cac in liste)
            {
                Console.WriteLine(cac.X +" ; " + cac.Y);
            }
            Console.WriteLine("ok ok ok ");

            return liste;

        }

    }
}