using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace projekttt
{
    internal class Program // |
    {
        static void Main(string[] args)
        {

            //Ops Gremlin = new Ops(100, 50, "Gremlin" );
            //Console.WriteLine(Gremlin.EName);
            string[] PAttacks = { };
            int Man = 0;
            int Hpp = 0;
            int numbb = 0;
            int Manre = 0;
            string namm = "";
            Random rnd = new Random();
            


            print("| G E A M |");
            print("Start the game?         [ENTER]");
            Console.ReadLine();
            wait(16);
            print("|    CHOOSE YOUR STARTING CLASS     |");
            wait(14);
            print("CLASS     HP     MP     NUMBER  ");
            wait(5);
            print("");
            print("");
            print("WARRIOR   100    10      [1]  ");
            wait(3);
            print("");
            print("WIZARD    60     16      [2]  ");
            wait(3);
            print("");
            print("ROGUE     75     13      [3]  ");
            int wybor1 = Convert.ToInt32(Console.ReadLine());
            wait(3);

            switch (wybor1)
            {
                case 1:
                    Man = 10;
                    Hpp = 100;
                    numbb = 1;
                    Manre = 5;
                    namm = "Warrior";
                    break;
                case 2:
                    Man = 16;
                    Hpp = 60;
                    numbb = 2;
                    Manre = 7;
                    namm = "Wizard";
                    break;
                case 3:
                    Man = 13;
                    Hpp = 75;
                    numbb = 3;
                    Manre = 6;
                    namm = "Rogue";
                    break;

            }
            Player player = new Player(Hpp, Man, namm, 1, Hpp, Man, Manre, 0, PAttacks, 100, 0);
            wait(3);

            
            
            //reminder to do move constructor with subspecs and shi
            switch (wybor1)
            {

                case 1:
                    player.PAttacks = player.PAttacks.Append("[Bash](+5M) ").ToArray();
                    player.PAttacks = player.PAttacks.Append("[Battle Heal](-3M) ").ToArray();
                    player.PAttacks = player.PAttacks.Append("[Rage](-5M) ").ToArray();
                    break;
                case 2:
                    player.PAttacks = player.PAttacks.Append("[Bash](+5M) ").ToArray();
                    player.PAttacks = player.PAttacks.Append("[Fireball](-15M) ").ToArray();
                    player.PAttacks = player.PAttacks.Append("[Mp Reg](+20M) ").ToArray();
                    break;
                case 3:
                    player.PAttacks = player.PAttacks.Append("[Bash](+5M) ").ToArray();
                    player.PAttacks = player.PAttacks.Append("[Sneak Attack](0M) ").ToArray();
                    player.PAttacks = player.PAttacks.Append("[Steal](-5M) ").ToArray();
                    break;

            }
            profil();
            wait(5);
            

            while (true)
            {
                print("[1] keep going [2] check status");
                int dss = Convert.ToInt32(Console.ReadLine());
                if (dss == 2) {
                    profil();
                }
                else {
                    int c = rnd.Next(2);
                    wait(20);
                    if(c == 0)
                    {
                        print("you've ran into goblin");
                        FS("Goblinior", 50 + (player.level * 5), 5, null, 50, 1);
                    }
                    if (c == 1)
                    {
                        print("you've ran into skeleton");
                        FS("czacha", 60 + (player.level * 5), 7, null, 75, 2);
                    }
                    if (c == 2)
                    {
                        print("you found inn, heal for 7 gold?");
                        print("[1] yes [2] no");
                        int ds = Convert.ToInt32(Console.ReadLine());
                        if (ds == 1) { 
                            if( player.Gold >= 7)
                            {
                                player.Gold -= 7;
                                player.HP += 35;
                                if (player.HP > player.MaxHP) {
                                    player.HP = player.MaxHP;
                                
                                }
                                
                            }
                            else
                            {
                                print("2poor");
                            }

                            
                        }
                    }

                }
                



            }
            




            
        void FS(string name, int hp, int goldr, string[] attack, int exp, int Type)
            {
                int dmu = 1;
                int tura = 0;
                Ops op = new Ops(hp, name, attack, goldr, exp);
                int maxhp = op.EHp;
                Random rs = new Random();
                while (true)                                                    
                {
                    Console.Clear();
                    tura++;
                    int a = rs.Next(1);
                    wyswietlacz();
                    as42();
                    if (op.EHp <= 0)
                    {
                        wait(10);
                        print(op.EName + "got defeated!");
                        player.Gold += goldr;
                        print("you got" + goldr + "Gold");
                        print("you got" + exp + "exp");
                        level(exp, player.level);
                        break;

                    }
                    if (a == 0 ) 
                    {
                        Enmoves(Type, 1);

                    }
                    if (a == 1)
                    {
                        Enmoves(Type, 2);
                    }
                    if (player.HP == 0)
                    {
                        print("You lost");
                        break;
                    }
                    wait(3);
                    print("[Enter to countinue]");
                    Console.ReadKey();
                    



                }
                void as42(){
                    print("Choose ability (1, 2, 3)");
                    wait(5);
                    print(player.PAttacks[0] + " " + player.PAttacks[1] + " " + player.PAttacks[2]);
                    int fds = Convert.ToInt32(Console.ReadLine());
                    fds--;
                    string wyb = player.PAttacks[fds];
                    wait(5);
                    Moves(wyb);

                }
                void Enmoves(int type, int att)
                {
                    if (type == 1)
                    {
                        if (att == 1)
                        {
                            int dm = 6 + (player.level * 2);
                            player.HP -= dm;
                            print("Goblin damaged you for " + Convert.ToString(dm) + "dmg");
                            wait(10);

                        }
                        if (att == 2)
                        {
                            int dm = 2 + (player.level * 2);
                            player.HP -= dm;
                            player.Gold -= 1;
                            print("Goblin damaged you for " + Convert.ToString(dm) + "dmg" + "and stole 1 gold");
                            wait(10);
                        }
                    }
                    if (type == 2)
                    {
                        if (att == 1)
                        {
                            int dm = 6 + (player.level * 2);
                            player.HP -= dm;
                            print("Skeleton damaged you for " + Convert.ToString(dm) + "dmg");
                            wait(10);
                        }
                        if (att == 2)
                        {
                            int dm = 6 + (player.level * 2);
                            player.HP -= dm;
                            op.EHp += dm / 2;
                            print("Skeleton you for " + Convert.ToString(dm) + "dmg" + "and healed himself for" + Convert.ToString(dm/2));
                            wait(10);
                        }
                    }
                }
                void Moves(string atak) 
                { 
                    if(atak == "[Bash](+5M) ")
                    {
                        player.Mp += 5;
                        if(player.Mp > player.MaxMp)
                        {
                            player.Mp = player.MaxMp;
                        }
                        int Dmg = 10*dmu;
                        print("You dealt " + Convert.ToString(Dmg) + " DMG");
                        op.EHp -= Dmg;
                        dmu = 1;
                        wait(3);

                    }
                    if (atak == "[Battle Heal](-3M) ")
                    {
                        
                        if (player.Mp >= 3)
                        {
                            player.Mp -= 3;
                            int Heal = 8;
                            print("You healed " + Convert.ToString(Heal) + " Hp");
                            player.HP += Heal;
                            if(player.HP > player.MaxHP)
                            {

                                player.HP = player.MaxHP;
                            }
                        }
                        else
                        {
                            print("Not enough mp");
                        }
                        wait(3);


                    }
                    if (atak == "[Rage](-5M) ")
                    {
                        if (player.Mp >= 5)
                        {
                            player.Mp -= 5;
                            dmu = 3;
                            print("Your next attack deals triple dmg");
                        }
                        else
                        {
                            print("Not enough mp");
                        }
                        wait(3);

                    }
                    if (atak == "[Fireball](-15M) ")
                    {
                        if (player.Mp >= 15)
                        {
                            player.Mp -= 15;
                            int DMG = 35;
                            print("You dealt " + Convert.ToString(DMG) + " DMG");
                            op.EHp -= DMG;
                        }
                        else
                        {
                            print("Not enough mp");
                            wait(1);
                        }
                    }
                    if (atak == "[Mp Reg](+20M) ")
                    {
                        player.Mp += 20;
                        if (player.Mp > player.MaxMp)
                        {
                            player.Mp = player.MaxMp;
                            print("You restored 20 Mana");
                        }
                        wait(1);
                    }
                    if (atak == "[Sneak Attack](0M) ")
                    {
                        Random random = new Random();
                        int gdg = random.Next(2);
                        int dmg = 12*gdg;
                        int golds = 3;
                        print("You dealt " + Convert.ToString(dmg) + " DMG");
                        op.EHp -= dmg;
                    }
                    if (atak == "[Steal](-5M) ")
                    {
                        Random random = new Random();
                        int gdg = random.Next(6);
                        print("You stolen " + Convert.ToString(gdg) + " Gold");
                        player.Gold += gdg;
                    }

                }
                void wyswietlacz()
                {
                    
                    print("--------------------------------------" + " Tura " +Convert.ToString(tura)+"" + "--------------------------------------");
                    print("                                                                                  ");
                    print("                                                                                  ");
                    print("    " + player.Name +"                                  " + op.EName + " ["+ Convert.ToString(op.EHp)+"/"+ Convert.ToString(maxhp)+"]"+  "                      ");
                    print("   [" + Convert.ToString(player.HP) + "/" + Convert.ToString(player.MaxHP) + "]" + "                                                                        ");
                    print("             O   /                                _____                           ");
                    print("            /│--/                                │? ?  │                          ");
                    print("          /  │                                   │     │                          ");
                    print("            / │                                  / /│ │                           ");
                    print("           /  │                                 / / │ │                           ");
                    print("----------------------------------------------------------------------------------");
                    

                }
                
            }
           
        static void wait(int time)
        {
            Thread.Sleep(time*100);
            
        }
        static void print(string message)
        {
            string textToEnter = message;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            
        }
        void profil()
            {
                print("------------------------------------------------------------");
                print(player.Name);
                print(Convert.ToString(player.level) + " Level");
                print("Hp " + Convert.ToString(player.HP) + "/" + Convert.ToString(player.MaxHP));
                print("Mp " + Convert.ToString(player.Mp) + "/" + Convert.ToString(player.MaxMp));
                print("Gold " + Convert.ToString(player.Gold));
                print("Your Deck " + Convert.ToString(player.PAttacks[0]) + Convert.ToString(player.PAttacks[1]) + Convert.ToString(player.PAttacks[2]));
                print("Exp " + Convert.ToString(player.exp) + "/" + Convert.ToString(player.expm));
                print("-------------------------------------------------------------");
                

            }
        void level(int amount, int level) 
            {
                amount = amount + level * 2;
                player.exp = player.exp + amount;
                while (true)
                {
                    if(player.exp >= player.expm) 
                    {
                        player.level +=  1;
                        player.exp -= player.expm;
                        print("Level up!");
                        player.expm += 30;
                        print((Convert.ToString(player.level-1) + " ------> " + (Convert.ToString(player.level)+ " [Lv]" )));
                        
                        print((Convert.ToString(player.MaxHP) + " ------> " + (Convert.ToString(player.MaxHP + 10) + " [MAXHP]")));
                        player.MaxHP += 10;
                        player.HP += 10;
                        print((Convert.ToString(player.MaxMp) + " ------> " + (Convert.ToString(player.MaxMp + 2) + " [MAXMP]")));
                        player.MaxMp += 2;
                        player.Mp += 2;

                    }
                    else
                    {
                        break;
                    }
                    
                }
               

            }
    } 
    
        }
    }



