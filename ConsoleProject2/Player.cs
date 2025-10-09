using System;
using System.Collections.Generic;


namespace ConsoleProject2
{
    
    class Player 
    {
        Equipment equipment; //인벤토리와 장비장착을 위한 인스턴스
        public Equipment Eq
        {
            get {  return equipment; }
            set { equipment = value; }
        }
        public int PDamage {  get; set; }
        public int PHp {  get; set; }
        public static int PGold {  get; set; }  //플레이어 골드는 스태틱으로 선언해서 어디서든 변경가능
        

        public Player()
        {
            equipment = new Equipment();
            
            PHp = 100;
            PDamage = 10;
            PGold = 1000;
        }

        // 플레이어 상태창을 출력하는 메서드
        public void PlayerInformation()
        {
            Console.SetCursorPosition(30, 16);
            Console.WriteLine($"-------------------------");
            Console.WriteLine();
            Console.SetCursorPosition(30, 18);
            Console.WriteLine($" 공격력   : {PDamage}");
            Console.SetCursorPosition(30, 19);
            Console.WriteLine($"　체력    : {PHp}");
            Console.SetCursorPosition(30, 20);
            Console.WriteLine($"보유 골드 : {PGold} G");
            Console.WriteLine();
            Console.SetCursorPosition(30, 22);
            Console.WriteLine("-------------------------");
        }

        //플레이어의 공격을 출력하는 메서드
        public void Attack()
        {
            Console.SetCursorPosition(30, 10);
            Console.WriteLine($"플레이어가 {PDamage}의 공격을 가했다");
            
        }
       

    }
}
