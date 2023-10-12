using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace projekttt
{
    class Ops
    {
        public int EHp;
        public int EMp;
        public string EName;
        public string[] Attacks;
        public int GoldR;
        public int ex422;
 
        public Ops()
        {

        }
        public Ops(int hp, string Name, string[] attac, int goldR, int ex422)
        {
            EHp = hp;
            EName = Name;
            Attacks = attac;
            GoldR = goldR;
            this.ex422 = ex422;
        }

    }
}
