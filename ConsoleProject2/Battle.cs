using System;
using System.Collections.Generic;

namespace ConsoleProject2
{
    class Battle
    {
        
        Monster monster;
        public void BattleMonster(Player player)
        {
            bool battleOn = true;
            while (battleOn)
            {
                Console.WriteLine("사냥터에 왔음 누구랑 싸울래?");
                Console.WriteLine("1. 칼든 고양이   2. 창든 고양이   0.사냥터 나가기");
                bool bt=int.TryParse(Console.ReadLine(), out int battleNum);
                if(bt==true && battleNum == 1)
                {
                    monster = new SwordCat();
                    while (true)
                    {
                        Console.WriteLine($"{monster.MName} 체력: {monster.MHp} 공격력: {monster.MDamage} ");
                        Console.WriteLine("1.공격 2.도망");
                        bool fight = int.TryParse(Console.ReadLine(), out int fightNum);
                        if(fight == true && fightNum == 1)
                        {
                            player.Attack();
                            
                        }
                    }
                    
                }
            }
        }
    }
    class Monster
    {
        public string MName { get; set; }
        public int MHp {  get; set; }
        public int MDamage {  get; set; }

    }
    class SwordCat : Monster
    {
        public SwordCat()
        {
            MName = "칼든 고양이";
            MHp = 100;
            MDamage = 10;
        }
    }
    class SpearCat : Monster
    {
        public SpearCat()
        {
            MName = "창든 고양이";
            MHp = 150;
            MDamage = 20;
        }
    }
    
}
