using System;

namespace ConsoleApp3 // Note: actual namespace depends on the project name.
{
    public class Przeciwnicy
    {
        int En1D = 10;
        int En1Hp = 40;
        int En2D = 20;
        int En2Hp = 25;
    }
    internal class Program
    {
        int Lv = 1;
        int Hp = 100;
        int MaxHp = 100;
        int Mana = 20;
        string Klasa = "Aligator";
        int Kapsle = 10;

        static void Levelup()
        {

        }
        static void MyMethod(int Hp, int Dmg, string imie, int MaxHp, int myhp, int mana)

        {
           
            int Tura = 0;
            Console.WriteLine($"Wdałeś się w walke z {imie}");

            while (true)
            {

                Tura = Tura + 1;
                Console.WriteLine($"--------Tura {Tura}---------");
                Console.WriteLine("1. Ugryzienie [+10M] 2. Strzał [-10M] 3. Regeneracja [-5M] ");

                int number = int.Parse(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        Hp = Hp - 15;
                        mana = mana + 10;
                        
                        Console.WriteLine("Ugryzłeś przeciwnika za 15 obrażeń");
                        break;
                    case 2:
                        if (10 <= mana)
                        {
                            Hp = Hp - 25;
                            mana = mana - 10;
                            Console.WriteLine("Postrzeliłeś przeciwnika za 25 obrażeń");
                        }
                        else { Console.WriteLine("Nie masz wystarczająco many"); }
                        break;
                    case 3:
                       
                        
                        if (5 <= mana) {
                            myhp = myhp + 20;
                            if (myhp > MaxHp) {
                                myhp = MaxHp;
                            }
                            mana = mana - 5;
                            Console.WriteLine("Uleczyłeś się 20 pż");
                        }
                        else { Console.WriteLine("Nie masz wystarczająco many"); }
                        break;




                }
                
                if (Hp <= 0) {
                    Console.WriteLine("Przeciwnik nie żyje");
                  
                    
                    break;
                    
                }
                Console.WriteLine($"Przeciwnik ma teraz {Hp} pż ");
                myhp -= Dmg;
                Console.WriteLine($"Zostałeś uderzony za {Dmg} pż, masz teraz {myhp} pż");
                if (myhp <= 0) {
                Console.WriteLine("NIE ŻYJESZ, ZRESTARTUJ GRE");
                Console.ReadKey();
                }


            }
            
            
            
        }
        static void Main(string[] args)
        {
            Program obj = new Program();
            while (true)
            {
                Console.WriteLine("a. Wylecz sie b. Walka");

                string input = Console.ReadLine();
                if (input == "b")
                {


                    Random rnd = new Random();
                    int num = rnd.Next(3);
                    Console.WriteLine(num);
                    if (num == 1)
                    {
                        MyMethod(60*(obj.Lv/4 + 1), 15 * (obj.Lv / 4 + 1), "Bezdomny", 100* (obj.Lv / 6 + 1), obj.Hp, obj.Mana);
                        obj.Kapsle += 20;
                        Console.WriteLine("Otrzymałeś 20 kapsli");
                    }
                    if (num == 2)
                    {
                        MyMethod(75 * (obj.Lv / 4 + 1), 10 * (obj.Lv / 4 + 1), "Ochroniarz", 100 * (obj.Lv / 6 + 1), obj.Hp, obj.Mana);
                        obj.Kapsle += 20;
                        Console.WriteLine("Otrzymałeś 20 kapsli");
                    }

                }
                if (input == "a")
                {
                    if (obj.Kapsle >= 10)
                    { if (obj.Hp <= obj.MaxHp - 20)
                        {
                            obj.Kapsle = obj.Kapsle - 10;
                            obj.Hp = obj.MaxHp;
                            Console.WriteLine("Wyleczyłeś sie 20hp");
                        }
                    else {
                            obj.Hp = obj.Hp + 20;
                                }
                        Console.WriteLine("Wyleczyłeś sie 20hp");
                        obj.Kapsle = obj.Kapsle - 10;
                          
                    }
                    else { Console.WriteLine("Nie masz wystarczajaco kapsli"); }
                }






                
            }

        }

    }
}
