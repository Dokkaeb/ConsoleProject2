using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2
{
    class Equipment
    {
        List<Weapon> inventory; //장비들을 저장하는 인벤토리 리스트
        Weapon current = null;  //현재 장착한 장비를 저장하는 current
        public Equipment()
        {
            inventory = new List<Weapon>();
            inventory.Add(new Weapon("단검", 0, 10)); //기본장비로 단검이 인벤토리에 들어옴
        }

        // 인벤토리에 장비 추가하는 메서드
        public void AddWeapon(Weapon inputWeapon)
        {
            inventory.Add(inputWeapon);
        }

        //인벤목록 보기와 장비창착 메서드를 관리하기 위한 메서드
        public void ShowAndEquip(Player p)
        {
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(30, 15);
                Console.WriteLine("1. 인벤토리 보기   2.장비교체  0.나가기");
                bool isOk=int.TryParse(Console.ReadLine(), out int num);
                if (isOk && num == 1)
                {
                    Console.Clear();
                    ShowInven();
                    
                }
                else if (isOk && num == 2)
                {
                    Console.Clear();
                    EquipWeapon(p);
                    
                }
                else if(isOk && num == 0)
                {
                    break;
                }
            }
        }

        //인벤토리 목록과 선택한 장비의 설명을 보여주는 메서드
        public void ShowInven()
        {
            while (true)
            {
                if (inventory.Count > 0)
                {
                    Console.Clear();
                    Console.SetCursorPosition(30, 15);
                    Console.WriteLine("인벤토리 목록 (현재 장착중인 장비는 초록색으로 표시)");
                    Console.SetCursorPosition(30, 16);
                    Console.WriteLine("--------------------------------------------------");
                    Console.SetCursorPosition(30, 17);
                    for (int i = 0; i < inventory.Count; i++)
                    {
                        if (current == inventory[i])  //현재 장비를 장착하고 있으면 초록색으로 표시해주는 기능
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($" [{i + 1}.{inventory[i].WName}] ");
                            Console.ResetColor();
                            continue;
                        }
                        Console.Write($" [{i + 1}.{inventory[i].WName}] ");
                    }
                    Console.SetCursorPosition(30, 19);
                    Console.WriteLine();
                    Console.SetCursorPosition(30, 20);
                    Console.WriteLine("--------------------------------------------------");
                    Console.SetCursorPosition(30, 21);
                    Console.WriteLine($"가진 골드 : {Player.PGold} G");
                    Console.WriteLine();

                    Console.SetCursorPosition(20, 23);
                    Console.WriteLine("상세설명을 보고싶은 장비의 번호를 입력해 주세요  0번 입력시 나가기");
                    bool isOk = int.TryParse(Console.ReadLine(), out int num);

                    //선택한 장비의 정보를 보여주는 기능
                    if (isOk && num <= inventory.Count && num > 0)
                    {
                        Console.SetCursorPosition(20, 25);
                        inventory[num - 1].Weaponinformation();
                        Console.ReadLine();
                    }
                    else if(isOk && num == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(20, 26);
                        Console.WriteLine("제대로된 번호를 입력해 주세요");
                        Console.ReadLine();
                    }

                }
                else
                {
                    Console.WriteLine("인벤토리가 비어있습니다!");
                    Console.ReadLine();
                    break;
                }
            }
            
        }


        //장비 장착과 해체를 해주는 메서드
        public void EquipWeapon(Player p)
        {
            if (inventory.Count > 0)
            {
                Dictionary<int, Weapon> equip = new Dictionary<int, Weapon>();   //관리 편하게 딕셔너리에 넣기
                
                for (int i = 0; i < inventory.Count; i++)
                {
                    equip.Add(i + 1, inventory[i]);
                }
                while (true)
                {
                    Console.Clear();
                    Console.SetCursorPosition(30, 15);
                    Console.WriteLine("인벤토리 목록 (현재 장착중인 장비는 초록색으로 표시됨)");
                    Console.SetCursorPosition(30, 16);
                    Console.WriteLine("--------------------------------------------------");
                    Console.SetCursorPosition(30, 17);
                    for (int i = 0; i < inventory.Count; i++)
                    {
                        if (current == inventory[i]) //장비 장착중이면 초록색으로 표시해주는 기능
                        {
                            Console.ForegroundColor= ConsoleColor.Green;
                            Console.Write($" [{i + 1}.{inventory[i].WName}] ");
                            Console.ResetColor();
                            continue;
                        }

                        
                        Console.Write($" [{i + 1}.{inventory[i].WName}] ");
                    }
                    Console.SetCursorPosition(30, 18);
                    Console.WriteLine();
                    Console.SetCursorPosition(30, 19);
                    Console.WriteLine("--------------------------------------------------");
                    Console.SetCursorPosition(30, 20);
                    Console.WriteLine($"가진 골드 : {Player.PGold} G");
                    Console.WriteLine();
                    Console.SetCursorPosition(30, 22);
                    Console.WriteLine("몇번 장비를 장착하시겠습니까? 0번은 나가기");

                    bool isOk = int.TryParse(Console.ReadLine(), out int index);
                    if (isOk == false || index < 0 || index > inventory.Count)
                    {
                        Console.SetCursorPosition(30, 24);
                        Console.WriteLine("잘못된 값을 입력하셨습니다");
                        Console.ReadLine();
                    }
                    else if (isOk == true && index == 0)
                    {
                        break;
                    }
                    else
                    {
                        //이미 장착한 장비를 선택시 해체할 수 있는 기능
                        if(current == equip[index])
                        {
                            Console.SetCursorPosition(30, 24);
                            Console.WriteLine("이미 장착한 장비입니다! 장착 해체하시겠습니까? 해체를 원하면 1번 입력");
                            bool isUninstall = int.TryParse(Console.ReadLine(), out int yesNo);
                            if(isUninstall==true && yesNo == 1)
                            {
                                current = null;
                                p.PDamage = 10;
                                Console.SetCursorPosition(30, 25);
                                Console.WriteLine($"장착을 해체했습니다! 현재 공격력 : {p.PDamage}");
                                Console.ReadLine();
                                continue;
                            }
                            continue;
                            
                        }

                        //선택한 장비 장착하는 기능
                        p.PDamage = 10;
                        Console.SetCursorPosition(30, 24);
                        Console.WriteLine($"{equip[index].WName}을 장착했습니다");
                        current=equip[index];
                        p.PDamage += equip[index].WDamage;
                        Console.SetCursorPosition(30, 25);
                        Console.WriteLine($"현재 공격력 : {p.PDamage}");
                        Console.ReadLine();
                        
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
