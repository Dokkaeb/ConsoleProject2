using System;
using System.Collections.Generic;


namespace ConsoleProject2
{
    class Store
    {
        List<Weapon> storeList;
        public Store()
        {
            storeList = new List<Weapon>();
            storeList.Add(new Weapon("장검", 100, 20));
            storeList.Add(new Weapon("대검", 300, 40));
            storeList.Add(new Weapon("  창", 150, 30));
            storeList.Add(new Weapon("도끼",250, 35));
        }

        public void ShowStoreList()
        {
            if (storeList.Count > 0)
            {
                for (int i = 0; i < storeList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {storeList[i].WName}  공격력: {storeList[i].WDamage}   가격: {storeList[i].WPrice}");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("~~~~~~~~~다팔림~~~~~~~~");
                Console.WriteLine();
            }
            
        }

        public Weapon SellWeapon()
        {
            Weapon sell = null;
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점");
                ShowStoreList();
                Console.WriteLine("몇번 무기를 구입하시겠습니까? 0번은 나가기");
                Console.WriteLine($"현재 플레이어 골드 : {Player.PGold}");
                bool isOk = int.TryParse(Console.ReadLine(), out int index);
                if (isOk == false || index < 0 || index > storeList.Count)
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 값");
                    Console.ReadLine();
                }
                else if(isOk && index == 0)
                {
                    break;
                }
                else
                {
                   sell=storeList[index-1];
                    Console.WriteLine($"{sell.WName}을 구입하셨습니다");
                    Player.PGold-=storeList[index-1].WPrice;
                    Console.WriteLine($"남은골드 : {Player.PGold}");
                    storeList.RemoveAt(index-1);
                    break;
                }
            }
            return sell;
        }
    }
}
