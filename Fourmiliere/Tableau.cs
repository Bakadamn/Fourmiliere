using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Fourmiliere
{
    public static class RefTableau
    {
        public static Case[,] tab;
        public static Tableau classeTableau;
    }
    public class Tableau
    {
        
        Random rnd = new Random();
        public int[] posNid = new int[2];
        public int largeur;
        public int hauteur;

        public static int[] posNidStatic = new int[2];

      
        public Tableau()
        {
            RefTableau.tab = new Case[20, 20];
            largeur = 20;
            hauteur = 20;
        }

        public Tableau(int X, int Y)
        {
            RefTableau.tab = new Case[X, Y];
            largeur = X;
            hauteur = Y;
        }


        public void InitialisationTableau()
        {
            for (int i = 0; i < RefTableau.tab.GetLength(0); i++)
            {
                for (int y = 0; y < RefTableau.tab.GetLength(1); y++)
                {
                    Case caseTab = new Case(i, y);
                    RefTableau.tab[i, y] = caseTab;
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
                rndX = rnd.Next(0, RefTableau.tab.GetLength(0)-1);
                rndY = rnd.Next(0, RefTableau.tab.GetLength(1)-1);

               if(CaisseAOut.CaseEstVide(RefTableau.tab[rndX, rndY]))
                {
                    estVide = true;
                }
            }

            RefTableau.tab[rndX, rndY].contenu = 'N';
            RefTableau.tab[rndX +1, rndY].contenu = 'N';
            RefTableau.tab[rndX, rndY + 1].contenu = 'N';
            RefTableau.tab[rndX + 1, rndY + 1].contenu = 'N';

            posNid[0] =  rndX;
            posNid[1] =  rndY;

            posNidStatic[0] = rndX;
            posNidStatic[1] = rndY;
        }
       


    
        public void InitSucre(int NbrSucre)
        {
            int rndX = 0;
            int rndY = 0;


            for (int i = 0; i < NbrSucre; i++)
            {
                rndX = rnd.Next(0, RefTableau.tab.GetLength(0) - 1);
                rndY = rnd.Next(0, RefTableau.tab.GetLength(1) - 1);
                while (RefTableau.tab[rndX, rndY].contenu != '0')
                {
                    rndX = rnd.Next(0, RefTableau.tab.GetLength(0) - 1);
                    rndY = rnd.Next(0, RefTableau.tab.GetLength(1) - 1);
                }
                RefTableau.tab[rndX, rndY].contenu = 'S';
                RefTableau.tab[rndX, rndY].nombre_sucre = 9; //aléatoire?
            }
        }

        public void InitCailloux(int NbrCailloux)
        {
            int rndX = 0;
            int rndY = 0;
            

            for (int i= 0; i<NbrCailloux; i++)
            {
                rndX = rnd.Next(0, RefTableau.tab.GetLength(0) - 1);
                rndY = rnd.Next(0, RefTableau.tab.GetLength(1) - 1);
                while (RefTableau.tab[rndX, rndY].contenu != '0')
                {
                    rndX = rnd.Next(0, RefTableau.tab.GetLength(0) - 1);
                    rndY = rnd.Next(0, RefTableau.tab.GetLength(1) - 1);
                }
                RefTableau.tab[rndX, rndY].contenu = 'C';
            }
        }


        public void InitFourmis(int fourmis)
        {
            List<int[]> posPossible = new List<int[]>();

                
            posPossible.Add(CaisseAOut.DeuxValeurEnTableau(posNid[0] - 1, posNid[1] - 1));
            posPossible.Add(CaisseAOut.DeuxValeurEnTableau(posNid[0] +2, posNid[1] +2));
            for (int i = 1; i<4; i ++)
            {
                posPossible.Add(CaisseAOut.DeuxValeurEnTableau(posNid[0] - 1 + i, posNid[1] - 1));
                posPossible.Add(CaisseAOut.DeuxValeurEnTableau(posNid[0] - 1 , posNid[1] - 1 + i ));

                posPossible.Add(CaisseAOut.DeuxValeurEnTableau(posNid[0] + 2 - i, posNid[1] + 2));
                posPossible.Add(CaisseAOut.DeuxValeurEnTableau(posNid[0] + 2, posNid[1] + 2 - i));
            }
            

           
            if(posPossible.Count()>0)
            for(; ; )
            {
                int rndCase = rnd.Next(1, posPossible.Count());
                rndCase--;
                if(CaisseAOut.EstDansLeTableau(posPossible[rndCase][0], posPossible[rndCase][1]))
                    if (CaisseAOut.CaseValidePourFourmis(RefTableau.tab[posPossible[rndCase][0], posPossible[rndCase][1]]))
                    {
                        RefTableau.tab[posPossible[rndCase][0], posPossible[rndCase][1]].fourmis = new Fourmis(RefTableau.tab[posPossible[rndCase][0], posPossible[rndCase][1]]);
                     
                        return;
                    }
            }

        }

        public void InitPhero(int X, int Y)
        {
            int decalage = 3;
            int test = 0;
            int[] resultTest = {
                   hauteur - (posNid[0]+2),
                   posNid[0],
                   posNid[1],
                   largeur - (posNid[1]+2) };

            for(int i=0; i<resultTest.Length; i++)
            {
                if(resultTest[i] > test)
                {
                    test = resultTest[i];
                }
            }



            for (int i = test; i > -1; i--)
            {
                int Xactuel = X - ((test + 1) - i); // - 1, 2, 3, 4
                int Yactuel = Y - ((test + 1) - i);
                int XnegActuel = X + ((test + 2) - i);  // +2, 3, 4, 5
                int YnegActuel = Y + ((test + 2) - i);

                if (CaisseAOut.EstDansLeTableau(Xactuel, Yactuel))
                {
                    RefTableau.tab[Xactuel, Yactuel].pheromone_nid = i;
                }
                if (CaisseAOut.EstDansLeTableau(XnegActuel, YnegActuel) )
                {
                    RefTableau.tab[XnegActuel, YnegActuel].pheromone_nid = i;
                }

                for (int dec = 1; dec <= decalage; dec++)
                {
                    if (CaisseAOut.EstDansLeTableau(Xactuel + dec, Yactuel))
                    {
                        RefTableau.tab[Xactuel + dec, Yactuel].pheromone_nid = i;
                    }
                    if (CaisseAOut.EstDansLeTableau(Xactuel,Yactuel + dec))
                    {
                        RefTableau.tab[Xactuel, Yactuel + dec].pheromone_nid = i;
                    }
                    if (CaisseAOut.EstDansLeTableau(XnegActuel - dec, YnegActuel))
                    {
                        RefTableau.tab[XnegActuel - dec, YnegActuel].pheromone_nid = i;
                    }
                    if (CaisseAOut.EstDansLeTableau(XnegActuel, YnegActuel - dec))
                    {
                        RefTableau.tab[XnegActuel, YnegActuel - dec].pheromone_nid = i;
                    }
                }



                decalage += 2;
            }
        }




    }
}
