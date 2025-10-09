using System;
using System.Collections.Generic;


namespace ConsoleProject2
{
    class Store
    {
        List<Weapon> storeList; //상점 아이템 목록을 저장하는 리스트
        public Store() //상점 생성시 자동으로 리스트에 아이템들 추가
        {
            storeList = new List<Weapon>();
            storeList.Add(new Weapon("장검", 100, 20));
            storeList.Add(new Weapon("대검", 300, 40));
            storeList.Add(new Weapon("  창", 150, 30));
            storeList.Add(new Weapon("도끼",250, 35));
        }

        // 상점 목록 보여주는 메서드
        public void ShowStoreList()
        {
            if (storeList.Count > 0)
            {
                for (int i = 0; i < storeList.Count; i++)
                {
                    Console.SetCursorPosition(30, 16+i);
                    Console.WriteLine($"{i + 1}. {storeList[i].WName}  공격력: {storeList[i].WDamage}   가격: {storeList[i].WPrice}");
                }
            }
            else
            {
                Console.WriteLine();
                Console.SetCursorPosition(30, 18);
                Console.WriteLine("~~~~~~~~~다팔림~~~~~~~~");
                Console.WriteLine();
            }
            
        }

        //아이템을 판매하고 판매한 아이템정보를 반환받는 메서드
        public Weapon SellWeapon()
        {
            Weapon sell = null; //판매한 아이템
            
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(30, 15);
                Console.WriteLine("상점");
                ShowStoreList();
                Console.SetCursorPosition(30, 21);
                Console.WriteLine("몇번 무기를 구입하시겠습니까? 0번은 나가기");
                Console.SetCursorPosition(30, 22);
                Console.WriteLine($"현재 플레이어 골드 : {Player.PGold}");
                bool isOk = int.TryParse(Console.ReadLine(), out int index);
                if (isOk == false || index < 0 || index > storeList.Count)
                {
                    Console.Clear();
                    Console.SetCursorPosition(30, 15);
                    Console.WriteLine("잘못된 값");
                    Console.ReadLine();
                }
                else if(isOk && index == 0)
                {
                    break;
                }
                else
                {
                   sell=storeList[index-1];  //판매 하려는 아이템을 sell에 저장
                    Console.SetCursorPosition(30, 24);
                    Console.WriteLine($"{sell.WName}을 구입하셨습니다");
                    Player.PGold-=storeList[index-1].WPrice;
                    Console.SetCursorPosition(30, 25);
                    Console.WriteLine($"남은골드 : {Player.PGold}");
                    storeList.RemoveAt(index-1); //판매한 아이템 리스트에서 제거
                    Console.ReadLine();
                    break;
                }
            }
            return sell;
        }

        //판매한 아이템을 플레이어 인벤토리에 넣는 메서드
        public void BuyWeapon(Player p)
        {
            while (true)
            {
                Console.Clear();
                Weapon buyWeapon;
                buyWeapon = SellWeapon(); //셀웨폰 메서드에서 반환받은 무기를 저장
                if (buyWeapon != null)
                {
                    p.Eq.AddWeapon(buyWeapon); //아이템을 구매했으면 플레이어의 인벤토리 리스트에 해당 아이템을 추가
                }
                else
                {
                    break;
                }
            }
        }
    }
}
