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

        private bool chercheSucre;
        private bool chercheNid;
        public Case caseFourmis;

        public Fourmis(Case ca)
        {
            caseFourmis = ca;
            porteSucre = false;
            chercheSucre = true;
        }
        
        public void DeplacerFourmis(Case c1, Case c2) 
        {
            c1.fourmis = null;
            c2.fourmis = this;
        }


    }
}
