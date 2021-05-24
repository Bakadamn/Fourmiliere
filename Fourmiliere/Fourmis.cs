using System;
using System.Collections.Generic;
using System.Linq;



namespace Fourmiliere
{
    public class Fourmis
    {
        public bool sestDeplacee;
        public bool porteSucre;

        private Random rnd = new Random();

        public static int nbrFourmis = 0;


        private bool chercheSucre;
        private bool chercheNid;
        public Case caseFourmi;

        private int pheroSucreVal;

        public Fourmis(Case ca)
        {
            caseFourmi = ca;
            porteSucre = false;
            chercheSucre = true;
            nbrFourmis++;
        }


        public void ChoixDeLaction() //Test de l'option la plus favorable pour la fourmi
        {
            List<Case> listePheroSucre = new List<Case>();
            List<Case> listePheroNid = new List<Case>();

            List<Case> listeCaseSucre = new List<Case>();
            List<Case> listeCaseNid = new List<Case>();




            int cptCasesValides = 0;
            foreach (Case ca in CaisseAOut.CasesAlentours(caseFourmi.X, caseFourmi.Y))
            {
                if (ca.pheromone_sucre > 0)
                    listePheroSucre.Add(ca);
                if (ca.pheromone_nid > 0)
                    listePheroNid.Add(ca);
                if (ca.nombre_sucre > 0)
                    listeCaseSucre.Add(ca);
                if (ca.contenu == 'N')
                    listeCaseNid.Add(ca);
                if (CaisseAOut.CaseValidePourFourmis(ca))
                    cptCasesValides++;
            }




            if (chercheSucre && listeCaseSucre.Count() > 0) // si un cherche sucre et qu'un sucre est a proximité, on charge la mule
            {
                int nidX = Tableau.posNidStatic[0];
                int nidY = Tableau.posNidStatic[1];

                int distanceX;
                int distanceY;

                if (nidX > caseFourmi.X)
                    distanceX = nidX - caseFourmi.X;
                else
                    distanceX = caseFourmi.X - nidX;

                if (nidY > caseFourmi.Y)
                    distanceY = nidY - caseFourmi.Y;
                else
                    distanceY = caseFourmi.Y - nidY;

                //La valeur du phéromone sucre est la distance entre le nid et le sucre fois deux (le temps de l'allez-retour) + 3 (plus trois tours supplémentaire)

                if (distanceX > distanceY)
                    pheroSucreVal = distanceX * 2 + 3;
                else
                    pheroSucreVal = distanceY * 2 + 3;



                if (listeCaseSucre[0].nombre_sucre > 0)
                {
                    listeCaseSucre[0].nombre_sucre--;
                    if (listeCaseSucre[0].nombre_sucre <= 0)
                        listeCaseSucre[0].contenu = '0';
                    porteSucre = true;
                    chercheSucre = false;
                    chercheNid = true;

                }
                return;
            }


            if (chercheNid && listeCaseNid.Count() > 0) // si cherche le nid et qu'il est a proximité, on décharge la mule
            {
                porteSucre = false;
                chercheNid = false;
                chercheSucre = true;
                DepotDePheromoneSucre();
                return;
            }

            if (cptCasesValides == 0) //Aucune case n'est valide on sort de la fonction
                return;

            if (chercheSucre && listePheroSucre.Count() > 0) //La fourmi suit la piste du sucre
            {
                int pheroMax = 0;
                int index = -1;
                int cpt = 0;
                foreach (Case ca in listePheroSucre)
                {

                    if (ca.pheromone_sucre > pheroMax && CaisseAOut.CaseValidePourFourmis(ca))
                    {
                        pheroMax = ca.pheromone_sucre;
                        index = cpt;
                    }
                    cpt++;
                }
                if (index > -1 && listePheroSucre[index].pheromone_sucre >= caseFourmi.pheromone_sucre)
                {
                    DeplacerFourmis(listePheroSucre[index].X, listePheroSucre[index].Y);
                    return;
                }
                else
                {
                    DeplacementAleatoire();
                    return;
                }

            }
            else if (chercheNid && listePheroNid.Count() > 0) //La fourmi suit la piste du Nid
            {
                int pheroMax = 0;
                int index = -1;
                int cpt = 0;

                List<Case> listePheroNidMax = new List<Case>();

                foreach (Case ca in listePheroNid)
                {
                    if (ca.pheromone_nid > pheroMax && CaisseAOut.CaseValidePourFourmis(ca))
                    {
                        pheroMax = ca.pheromone_nid;
                        index = cpt;
                    }
                    cpt++;
                }
                foreach (Case ca in listePheroNid)
                {
                    if (ca.pheromone_nid == pheroMax)
                    {
                        listePheroNidMax.Add(ca);
                    }

                }
                Case caseFinale = ChoixCaseProcheNid(listePheroNidMax);
                if (index > -1)
                {
                    DepotDePheromoneSucre();
                    DeplacerFourmis(caseFinale.X, caseFinale.Y);
                    return;
                }
                else
                {
                    DeplacementAleatoire();
                    return;
                }
            }
            else //la fourmi se déplace aléatoirement 
            {
                DeplacementAleatoire();
                return;
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
            while (!CaisseAOut.CaseValidePourFourmis(RefTableau.tab[x, y]));

            DeplacerFourmis(x, y);

        }

        private void DeplacerFourmis(int x, int y)
        {
            if (CaisseAOut.CaseValidePourFourmis(RefTableau.tab[x, y]))
            {
                RefTableau.tab[x, y].fourmis = this;

                RefTableau.tab[caseFourmi.X, caseFourmi.Y].fourmis = null;
                caseFourmi = RefTableau.tab[x, y];
            }

        }


        private void DepotDePheromoneSucre()
        {
            caseFourmi.pheromone_sucre = pheroSucreVal;

            if (pheroSucreVal > 0)
                pheroSucreVal--;
            if(pheroSucreVal > 0)
                pheroSucreVal--;
        }


        private Case ChoixCaseProcheNid(List<Case> casesPotentielles)
        {
            Case casePlusProche = casesPotentielles[0];
            int distanceMin = 999;
            int nidX = Tableau.posNidStatic[0];
            int nidY = Tableau.posNidStatic[1];
            foreach (Case c in casesPotentielles)
            {
                int distX = 0;
                int distY = 0;


                if (c.X > nidX)
                    distX = c.X - nidX;
                else
                    distX = nidX - c.X;


                if (c.Y > nidY)
                    distY = c.Y - nidY;
                else
                    distY = nidY - c.Y;


                if (distX + distY < distanceMin)
                {
                    casePlusProche = c;
                    distanceMin = distX + distY;
                }

            }
            return casePlusProche;
        }


    }
}