using System;
using System.Collections.Generic;


namespace ConsoleProject2
{
    class GameManager
    {
        Player player = new Player();
        Store store = new Store();
        Battle battle = new Battle();
        public void GameStart()
        {
            

            bool gameSart = true;


            while (gameSart)
            {
                Console.SetWindowSize(100, 50);
                Console.Clear();
                Console.SetCursorPosition(30, 15);
                Console.WriteLine("-----------  고양이 사냥 RPG  ----------");
                Console.SetCursorPosition(25, 20);
                Console.WriteLine("1.사냥터  2.상태창   3.장비창  4.상점  5.여관  0.종료");
                bool isOk = int.TryParse(Console.ReadLine(), out int MenuNum);
                if (isOk)
                {
                    switch (MenuNum)
                    {
                        case 1:
                            Console.Clear();

                            battle.BattleMonster(player);                            
                            break;

                        case 2:
                            Console.Clear();
                            Console.SetCursorPosition(30, 15);
                            Console.WriteLine("플레이어 상태창");
                            player.PlayerInformation();
                            Console.ReadLine();
                            break;

                        case 3:
                            Console.Clear();
                            
                            player.Eq.ShowAndEquip(player);
                            break;

                        case 4:
                            store.BuyWeapon(player);
                            break;

                        case 5:
                            Console.Clear();
                            Console.SetCursorPosition(30, 15);
                            Console.WriteLine("잠을자고 체력을 회복합니다");
                            player.PHp = 100;
                            Console.SetCursorPosition(30, 17);
                            Console.WriteLine("+ + + ♡ + + + ");
                            Console.SetCursorPosition(30, 19);
                            Console.WriteLine($"플레이어 현재 체력 : {player.PHp}");
                            Console.SetCursorPosition(30, 21);
                            Console.WriteLine("+ + + ♡ + + + ");
                            Console.ReadLine();
                            break;

                        case 0:
                            Console.WriteLine("종료");
                            gameSart = false;                           
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("잘못된 값 입력됨");
                            Console.ReadLine();
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 값 입력됨");
                    Console.ReadLine();
                }
            }
        }
    }
}
