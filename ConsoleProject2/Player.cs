using System;
using System.Collections.Generic;


namespace ConsoleProject2
{
    
    class Player 
    {
        List<Weapon> inventory;
        public int PDamage {  get; set; }
        public int PHp {  get; set; }
        public static int PGold {  get; set; }
        

        public Player()
        {
            inventory = new List<Weapon>();
            inventory.Add(new Weapon("단검",0,10));
            PHp = 100;
            PDamage = 10;
            PGold = 1000;
        }
        public void PlayerInformation()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            
            Console.WriteLine($" 공격력   : {PDamage}");
            Console.WriteLine($"　체력    : {PHp}");
            Console.WriteLine($"보유 골드 : {PGold} G");
            Console.WriteLine();
            Console.WriteLine("-------------------------");
        }
        public void Attack()
        {
            Console.WriteLine($"{PDamage}의 공격을 가했다");
            
        }
        public void AddWeapon(Weapon inputWeapon)
        {
            inventory.Add(inputWeapon);
        }
        public void ShowInven()
        {
            if (inventory.Count > 0)
            {
                Console.WriteLine("인벤토리 목록");
                Console.WriteLine("--------------------------------------------------");
                for (int i = 0; i < inventory.Count; i++)
                {
                    Console.Write($" [{i + 1}.{inventory[i].WName}] ");
                }
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"가진 골드 : {Player.PGold} G");
                
            }
            else
            {
                Console.WriteLine("인벤토리가 비어있습니다!");
            }
        }

        public void EquipWeapon()
        {
            if(inventory.Count > 0)
            {
                Dictionary<int, Weapon> equip = new Dictionary<int, Weapon>();
                for (int i = 0; i < inventory.Count; i++)
                {
                    equip.Add(i + 1, inventory[i]);
                }
                while (true)
                {
                    ShowInven();
                    Console.WriteLine("몇번 장비를 장착하시겠습니까? 0번은 나가기");

                    bool isOk = int.TryParse(Console.ReadLine(), out int index);
                    if (isOk == false || index < 0 || index > inventory.Count)
                    {
                        Console.WriteLine("잘못된 값을 입력하셨습니다");
                    }
                    else if(isOk==true && index == 0)
                    {
                        break;
                    }
                    else
                    {
                        PDamage = 10;
                        Console.WriteLine($"{equip[index].WName}을 장착했습니다");
                        PDamage += equip[index].WDamage;
                        Console.WriteLine($"현재 공격력 : {PDamage}");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("인벤토리가 비어있습니다!");
            }
        }

    }
}
