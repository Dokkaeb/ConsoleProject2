using System;
using System.Collections.Generic;


namespace ConsoleProject2
{
    class Weapon
    {
        public string WName { get; set; }
        public int WPrice {  get; set; }
        public int WDamage { get; set; }
        public Weapon(string inputName,int inputPrice,int inputDamage)
        {
            WName = inputName;
            WPrice = inputPrice;
            WDamage = inputDamage;
        }
        //장비 정보 출력하는 메서드
        public void Weaponinformation()
        {
            Console.WriteLine($"이름 : {WName}  공격력 : {WDamage}  가격 : {WPrice}");
        }
    }
}
