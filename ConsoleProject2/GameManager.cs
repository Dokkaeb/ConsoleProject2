using System;
using System.Collections.Generic;


namespace ConsoleProject2
{
    class GameManager
    {
        Player player = new Player();
        Store store = new Store();

        public void GameStart()
        {
            

            bool gameSart = true;


            while (gameSart)
            {
                Console.Clear();
                Console.WriteLine("메인메뉴");
                Console.WriteLine("1.사냥터  2.상태창   3.장비창  4.상점  0.종료");
                bool isOk = int.TryParse(Console.ReadLine(), out int MenuNum);
                if (isOk)
                {
                    switch (MenuNum)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("사냥하러가기");
                            Console.ReadLine();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("플레이어 상태창");
                            player.PlayerInformation();
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("장비창");
                            bool eq=true;
                            while (eq)
                            {
                                Console.Clear();
                                Console.WriteLine("1. 인벤토리 목록 전체 보기 2.장비 장착 0.메인메뉴로 돌아가기");
                                bool invenOk = int.TryParse(Console.ReadLine(), out int invenNum);
                                if (invenOk)
                                {
                                    switch (invenNum)
                                    {
                                        case 1:
                                            Console.Clear();
                                            player.ShowInven();
                                            Console.ReadLine();
                                            break;
                                        case 2:
                                            Console.Clear();
                                            player.EquipWeapon();
                                            Console.ReadLine();
                                            break;
                                        case 0:
                                            eq = false;

                                            break;
                                        default:
                                            Console.WriteLine("잘못된 값 입력");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("제대로 된 값을 입력해 주세요");
                                }
                                
                            }
                            
                            break;
                        case 4:
                            
                            while (true)
                            {
                                Console.Clear();
                                
                                
                                Weapon buyWeapon;
                                buyWeapon = store.SellWeapon();
                                if (buyWeapon != null)
                                {
                                    player.AddWeapon(buyWeapon);
                                }
                                else
                                {
                                    break;
                                }    
                            }
                            break;
                        case 0:
                            Console.WriteLine("종료");
                            gameSart = false;
                            
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("잘못입력");
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
