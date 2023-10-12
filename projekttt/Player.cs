using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekttt
{
    class Player
    {
        public int HP;
        public int Mp;
        public string Name;
        public int level;
        public int MaxHP;
        public int MaxMp;
        public int MpReg;
        public int exp;
        public string[] PAttacks;
        public int expm;
        public int Gold;

        public Player()
        {

        }
        public Player(int hP, int mp, string name, int Level, int maxHP, int maxMp, int mpReg, int exp, string[] pAttacks, int expm, int gold)
        {
            HP = hP;
            Mp = mp;
            Name = name;
            level = Level;
            MaxHP = maxHP;
            MaxMp = maxMp;
            MpReg = mpReg;
            this.exp = exp;
            PAttacks = pAttacks;
            this.expm = expm;
            Gold = gold;
        }
    }
}
