using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fourmiliere
{
    public class Tableau
    {
        public Case[,] tableau;
        Random rnd = new Random();
        int[] posNid = new int[2];


        public Tableau()
        {
            tableau = new Case[20, 20];
        }

        public Tableau(int X, int Y)
        {
            tableau = new Case[X, Y];
        }


        public void InitialisationTableau()
        {
            for (int i = 0; i < tableau.GetLength(0); i++)
            {
                for (int y = 0; y < tableau.GetLength(1); y++)
                {
                    Case caseTab = new Case();
                    tableau[i, y] = caseTab;
                }
              
            }
        }

        public void InitNid()
        {
            bool estVide = false;
            int rndX = 0;
            int rndY = 0;
            while (!estVide)
            {
                rndX = rnd.Next(0, tableau.GetLength(0)-1);
                rndY = rnd.Next(0, tableau.GetLength(1)-1);

               if(CaseEstVide(tableau[rndX, rndY]))
                {
                    estVide = true;
                }
            }

            tableau[rndX, rndY].contenu = 'N';
            tableau[rndX +1, rndY].contenu = 'N';
            tableau[rndX, rndY + 1].contenu = 'N';
            tableau[rndX + 1, rndY + 1].contenu = 'N';

            posNid[0] =  rndX;
            posNid[1] =  rndY;

           // InitPhero(rndX, rndY);
        }
        /*
        private void InitPhero(int X, int Y)
        {
            int decalage = 3;
            for(int i = 9; i>-1; i--)
            {
                int Xactuel = X - (10 - i); // - 1, 2, 3, 4
                int Yactuel = Y - (10 - i);
                int XnegActuel = X + (11 - i);  // +2, 3, 4, 5
                int YnegActuel = Y + (11 - i);

               if( EstDansLeTableau(Xactuel, 0) &&  EstDansLeTableau(Yactuel, 1))
                {
                    tableau[Xactuel, Yactuel].pheromone_nid = i;
                }
                if( EstDansLeTableau(XnegActuel, 0) &&  EstDansLeTableau(YnegActuel, 1))
                {
                    tableau[XnegActuel, YnegActuel].pheromone_nid = i;
                }

                for(int dec = 1; dec<=decalage; dec++)
                {
                    if(EstDansLeTableau(Xactuel + dec, 0) && (EstDansLeTableau(Yactuel , 1)))
                    {
                        tableau[Xactuel + dec, Yactuel ].pheromone_nid = i;
                    }
                    if(EstDansLeTableau(Xactuel , 0) && (EstDansLeTableau(Yactuel +dec, 1)))
                    {
                        tableau[Xactuel , Yactuel + dec].pheromone_nid = i;
                    }
                    if (EstDansLeTableau(XnegActuel - dec, 0) && (EstDansLeTableau(YnegActuel, 1)))
                    {
                        tableau[XnegActuel - dec, YnegActuel].pheromone_nid = i;
                    }
                    if (EstDansLeTableau(XnegActuel, 0) && (EstDansLeTableau(YnegActuel - dec, 1)))
                    {
                        tableau[XnegActuel, YnegActuel - dec].pheromone_nid = i; 
                    }
                }



                decalage += 2;
            }
        } */


    
        public void InitSucre(int NbrSucre)
        {
            int rndX = 0;
            int rndY = 0;


            for (int i = 0; i < NbrSucre; i++)
            {
                rndX = rnd.Next(0, tableau.GetLength(0) - 1);
                rndY = rnd.Next(0, tableau.GetLength(1) - 1);
                while (tableau[rndX, rndY].contenu != '0')
                {
                    rndX = rnd.Next(0, tableau.GetLength(0) - 1);
                    rndY = rnd.Next(0, tableau.GetLength(1) - 1);
                }
                tableau[rndX, rndY].contenu = 'S';
                tableau[rndX, rndY].nombre_sucre = 99; //aléatoire?
            }


        }
        public void InitCailloux(int NbrCailloux)
        {
            int rndX = 0;
            int rndY = 0;
            

            for (int i= 0; i<NbrCailloux; i++)
            {
                rndX = rnd.Next(0, tableau.GetLength(0) - 1);
                rndY = rnd.Next(0, tableau.GetLength(1) - 1);
                while (tableau[rndX, rndY].contenu != '0')
                {
                    rndX = rnd.Next(0, tableau.GetLength(0) - 1);
                    rndY = rnd.Next(0, tableau.GetLength(1) - 1);
                }
                tableau[rndX, rndY].contenu = 'C';
            }
        }


        public void InitFourmis(int fourmis)
        {

        }

        private bool CaseEstVide(Case ca)
        {
            if (ca.contenu == '0')
            {
                return true;
            }
            else
                return false;
        }
        private bool EstDansLeTableau(int valeur, int dimension)
        {
            if (valeur < tableau.GetLength(dimension) && valeur >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
