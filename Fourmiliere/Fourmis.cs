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
        public Case caseFourmi;

        private int distanceNid;
        private int distanceSucre;

        public Fourmis(Case ca)
        {
            caseFourmi = ca;
            porteSucre = false;
            chercheSucre = true;
        }


        public void ChoixDeLaction() //Test de l'option la plus favorable pour la fourmi
        {
            List<Case> listePheroSucre = new List<Case>();
            List<Case> listePheroNid = new List<Case>();

            

            int cptCasesValides = 0;
            foreach(Case ca in CaisseAOut.CasesAlentours(caseFourmi.X, caseFourmi.Y))
            {
                if (ca.pheromone_sucre > 0)
                    listePheroSucre.Add(ca);
                if (ca.pheromone_nid > 0)
                    listePheroNid.Add(ca);
                if (CaisseAOut.CaseValidePourFourmis(ca))
                    cptCasesValides++;
            }

            if (cptCasesValides==0) //Aucune case n'est valide on sort de la fonction
                return;

            if (chercheSucre && listePheroSucre.Count()>0)
            {
                int pheroMax = 0;
                int index = -1;
                foreach(Case ca in listePheroSucre)
                {
                    int cpt = 0;
                    if(ca.pheromone_sucre>pheroMax && CaisseAOut.CaseValidePourFourmis(ca))
                    {
                        pheroMax = ca.pheromone_sucre; 
                        index = cpt;
                    }
                    cpt++;
                }
                if (index > -1)
                    DeplacerFourmis(listePheroSucre[index].X, listePheroSucre[index].Y);
                else
                    DeplacementAleatoire();
            }
            else if(chercheNid && listePheroNid.Count()>0)
            {
                int pheroMax = 0;
                int index = -1;
                foreach (Case ca in listePheroNid)
                {
                    int cpt = 0;
                    if (ca.pheromone_nid > pheroMax && CaisseAOut.CaseValidePourFourmis(ca))
                    {
                        pheroMax = ca.pheromone_sucre;
                        index = cpt;
                    }
                    cpt++;
                }
                if (index > -1)
                    DeplacerFourmis(listePheroNid[index].X, listePheroNid[index].Y);
                else
                    DeplacementAleatoire();
            }
            else
            {
                DeplacementAleatoire();
            }
        }


        public void DeplacementAleatoire()
        {            
            int x;
            int y;
            do
            {

                do
                {
                    x = caseFourmi.X;
                    
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
                    int cpt = 0;
                    do
                    {
                        cpt++;
                        y = caseFourmi.Y;
                        rndY = rnd.Next(3);
                        if (rndY == 0)
                        {
                            y -= 1;
                        }
                        else if (rndY == 1)
                        {
                            y += 1;
                        }
                        if (cpt > 5)
                            break;
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
            Tableau.tableau[caseFourmi.X, caseFourmi.Y].fourmis = null;
            Tableau.tableau[x, y].fourmis = this;
            caseFourmi = Tableau.tableau[x, y];
        }


        private void DepotDePheromone()
        {

        }

      

    }
}