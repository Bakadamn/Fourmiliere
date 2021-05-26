﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fourmiliere
{
    public class Case // la classe case, conforme au cahier des charges
    {
        public char contenu;
        public int nombre_sucre;
        public int pheromone_nid;
        public int pheromone_sucre;
        public Fourmis fourmis;
        public int X;
        public int Y;

        public Case(int x, int y) // constructeur par défaut, inclut une position 
        {
            contenu = '0';
            X = x;
            Y = y;
        }
    }
}
