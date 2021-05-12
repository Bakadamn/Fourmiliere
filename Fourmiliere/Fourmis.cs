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
        private int pheroSucreVal;

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

            List<Case> listeCaseSucre = new List<Case>();
            List<Case> listeCaseNid = new List<Case>();


            

            int cptCasesValides = 0;
            foreach(Case ca in CaisseAOut.CasesAlentours(caseFourmi.X, caseFourmi.Y))
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



         
            if(chercheSucre && listeCaseSucre.Count()>0) // si un cherche sucre et qu'un sucre est a proximité, on charge la mule
            {
                int nidY = Math.Abs(Tableau.posNidStatic[0]);
                int nidX = Math.Abs(Tableau.posNidStatic[1]);

                listeCaseSucre[0].nombre_sucre--;
                porteSucre = true;
                chercheSucre = false;
                chercheNid = true;
                pheroSucreVal = (Math.Abs(nidX- caseFourmi.X ))+ (Math.Abs(nidY- caseFourmi.Y )) ;
                return;
            }

            
            if(chercheNid && listeCaseNid.Count()>0) // si cherche le nid et qu'il est a proximité, on décharge la mule
            {
                porteSucre = false;
                chercheNid = false;
                chercheSucre = true;
                DepotDePheromoneSucre();
                return;
            }

            if (cptCasesValides == 0) //Aucune case n'est valide on sort de la fonction
                return;

            if (chercheSucre && listePheroSucre.Count()>0) //La fourmi suit la piste du sucre
            {
                int pheroMax = 0;
                int index = -1;
                int cpt = 0;
                foreach (Case ca in listePheroSucre)
                {
                    
                    if(ca.pheromone_sucre>pheroMax && CaisseAOut.CaseValidePourFourmis(ca))
                    {
                        pheroMax = ca.pheromone_sucre; 
                        index = cpt;
                    }
                    cpt++;
                }
                if (index > -1 && listePheroSucre[index].pheromone_sucre>=caseFourmi.pheromone_sucre)
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
            else if(chercheNid && listePheroNid.Count()>0) //La fourmi suit la piste du Nid
            {
                int pheroMax = 0; //a faire : choisir la case la plus proche du nid si égalité de pheromone
                int index = -1;
                int cpt = 0;
                foreach (Case ca in listePheroNid)
                {
                    if (ca.pheromone_nid > pheroMax && CaisseAOut.CaseValidePourFourmis(ca))
                    {
                        pheroMax = ca.pheromone_nid;
                        index = cpt;
                     
                    }
                    cpt++;

                }
                if (index > -1)
                {
                    DepotDePheromoneSucre();
                    DeplacerFourmis(listePheroNid[index].X, listePheroNid[index].Y);
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
            while (!CaisseAOut.CaseValidePourFourmis(Tableau.tableau[x, y]));

            DeplacerFourmis(x, y);

        }

        private void DeplacerFourmis(int x, int y)
        {
            
            Tableau.tableau[caseFourmi.X, caseFourmi.Y].fourmis = null;
            Tableau.tableau[x, y].fourmis = this;
            caseFourmi = Tableau.tableau[x, y];
        }


        private void DepotDePheromoneSucre()
        {
            caseFourmi.pheromone_sucre = pheroSucreVal;
            pheroSucreVal--;
            pheroSucreVal--;
        }

      

    }
}