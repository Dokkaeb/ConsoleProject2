using System;
using System.Collections.Generic;

namespace ConsoleProject2
{
    class Battle
    {
        
        Monster monster;

        //배틀 클래스내 메서드들을 관리하는 메서드
        public void BattleMonster(Player player)
        {
            bool battleOn = true;
            while (battleOn)
            {
                Console.Clear();
                Console.SetCursorPosition(30, 15);
                Console.WriteLine("사냥터에 왔음 누구랑 싸울래?");
                Console.SetCursorPosition(20, 17);
                Console.WriteLine("1. 칼든 고양이   2. 창든 고양이   0.사냥터 나가기");
                bool bt=int.TryParse(Console.ReadLine(), out int battleNum);
                if(bt==true && battleNum == 1)
                {
                    monster = new SwordCat();
                    FightandRun(monster, player);
                    
                }
                else if(bt == true && battleNum == 2)
                {
                    monster = new SpearCat();
                    FightandRun(monster, player);
                }
                else if(bt == true && battleNum == 0)
                {
                    break;
                }
            }
        }

        //몬스터와 배틀or 도망을 구현하는 메서드
        public void FightandRun(Monster m, Player p)
        {
            while (true)
            {
                Console.Clear();
                Console.SetWindowSize(100, 50);                
                Console.WriteLine(m.AscArt[0]); //선택한 몬스터의 아스키 아트를 보여주기
                Console.SetCursorPosition(30, 5);
                Console.WriteLine($"{m.MName} 체력: {m.MHp} 공격력: {m.MDamage} ");
                Console.SetCursorPosition(30, 8);
                Console.WriteLine("1.공격 2.도망");
                
                bool fight = int.TryParse(Console.ReadLine(), out int fightNum);
                if (fight == true && fightNum == 1)
                {
                    if (p.PHp <= 0)  //플레이어의 체력이 0이면 사망처리
                    {
                        Console.SetCursorPosition(30, 10);
                        Console.WriteLine("사망했습니다 여관에서 체력을 채워 오세요");
                        Console.ReadLine();
                        break;
                    }
                    //플레이어의 공격
                    p.Attack();
                    m.MHp -= p.PDamage;

                    if (m.MHp <= 0)  //몬스터의 체력이 0이되면 처리되는 부분
                    {
                        Console.Clear();
                        Console.WriteLine(m.AscArt[1]);
                        Console.SetCursorPosition(35, 20);
                        Console.WriteLine($"{m.MName}를 쓰러뜨렸습니다!");
                        Console.SetCursorPosition(35, 21);
                        Console.WriteLine($"100골드를 획득했습니다");
                        Console.SetCursorPosition(35, 22);
                        Console.WriteLine("체력을 회복합니다");
                        Player.PGold += 100;
                        p.PHp = 100;
                        Console.SetCursorPosition(35, 23);
                        Console.WriteLine($"현재 골드 :{Player.PGold}G");
                        Console.ReadLine();
                        break;
                    }
                    //몬스터의 공격
                    m.Attack();
                    p.PHp -= m.MDamage;
                    Console.SetCursorPosition(30, 13);
                    Console.WriteLine($"플레이어  체력: {p.PHp}");
                    Console.ReadLine();
                }
                //도망가는 기능
                else if (fight == true && fightNum == 2)
                {
                    Console.SetCursorPosition(30, 10);
                    Console.WriteLine("도망갑니다");
                    Console.ReadLine();
                    break;
                }
            }
        }
    }
    //몬스터를 상속받는 칼고양이와 창고양이 구현
    class Monster
    {
        public string MName { get; set; }
        public int MHp {  get; set; }
        public int MDamage {  get; set; }
        string[] ascArt = new string[2];
        public string[] AscArt
        {
            get {  return ascArt; }
            set { ascArt = value; }
        }
        public  void Attack()
        {
            Console.SetCursorPosition(30, 11);
            Console.WriteLine($"{MName}가 {MDamage}의 공격을 가했다 ");
        }
    }
    class SwordCat : Monster
    {
        public SwordCat()
        {
            MName = "칼든 고양이";
            MHp = 100;
            MDamage = 10;
            AscArt[0] = "              =                                  \r\n             %%-     =@#                         \r\n            :#:@    +#-%                         \r\n            @. -#  *+:@%                         \r\n           .%. #%@@* *@%                         \r\n           -#.%      :@@                         \r\n           -+          @                         \r\n           %.           @                        \r\n          -#            #.                       \r\n          ==     @-   #% @                       \r\n          %      @-   #% @                       \r\n          %              @                       \r\n          *.        #%   @                       \r\n          -#             @                       \r\n *@.       @=      %%%* @.                       \r\n+=.@       %.          @-                        \r\n@  -      .%          .@                         \r\n@  =      =*           @                         \r\n@  -.     %            :%                        \r\n%  :+     %      :  @@% @.                       \r\n+: .@    ++      +  @-%  %       .-=====#@@@-    \r\n=* .@    +=  #   #  @-%--@=#@@@@%#####*-    %=   \r\n.#  @    % -@@.  -**@-@%%*:                  #@. \r\n @  :-   @ @ %@   %-@-%................        @+\r\n -#  @   # @ *:@  -+@-%                        @=\r\n  @  -# := =%@@@@*%@@-@%*-                   *@. \r\n  :%  %++=  :.  .:: @-%%@**@@@@%#####+:     ##   \r\n   =*  *@=          @-# @.      .:----+#@@@@-    \r\n    =*  ::          @@# @                        \r\n     =@=                @                        \r\n       *@+              @                        \r\n         %.            .@                        \r\n         =*            .*                        \r\n          @    :.  ..  @                         \r\n          @   %#=+%*   @                         \r\n          @  #*    #- :%                         \r\n          %  @     -* +:                         \r\n          =+ +=     @ :@                         \r\n          .@@@-     *@@%                         \r\n";
            AscArt[1] = "                         ..                       \r\n                        +#@                       \r\n                      :%%:@=                      \r\n                     =%#-:@*                      \r\n                    *%*:..%*                      \r\n                  %@@-+ . %*                      \r\n             . .*#*:   := @*                      \r\n             =:#+. -      -%=                     \r\n           . :@* :* =+     :%%=@@@@@              \r\n            +#*: * + ::     .***+-.@              \r\n      :#:   :%:..:-%=--       -..-:@              \r\n     :@%@*.#@=   % + :.       -:.=*%              \r\n     %# .#+ %=   .=-:-         -=.%:              \r\n     *#  .#:@-     .     +%*+  : -@               \r\n      %   -@%=       *: -- .:=   #:               \r\n      %=   =@-      .== :=+*.@  +#.               \r\n      -=    .      *.*  --.* @  @.                \r\n      :%.         -:%*  .-::+   @                 \r\n      .#.         -:#*    --.  +@                 \r\n       ++.:        -@          #:                 \r\n       =@*                   :*%..                \r\n       :@.                   :%- .                \r\n       +#                   #@*+                  \r\n      .#.                 *%#%  :                 \r\n      :%.                 -%..=                   \r\n      :+                   #=                     \r\n      +=                   :%-                    \r\n      #=                --  =@                    \r\n      @=                -- :.#*                   \r\n      @=                -#+%# %:                  \r\n      @=                .%@ # =*                  \r\n      #=                 :#@#@+@                  \r\n      ==                   +#@@@  .*.             \r\n      :+                    * -@ .%-#.            \r\n      :%.                     +#@*:=#.            \r\n      .#.                    +%+@:+%.             \r\n       +*                  .#@#@.=#@+             \r\n       +#              ===#%+=#:+#- #+            \r\n       *:            =%@*::.+@.*@.=: *#           \r\n   .:  *.          *@%-     +@++%* =: -#:         \r\n   .:  +=     =++  +@        ==  *- -. :%=        \r\n   :=. =@    *@-#   @+           .#  -. .@+       \r\n    ::  *%:  ** +@  .%:           =@. -.  *+.     \r\n    --:  =%*==@  @=  +#:           =*  :.  =#:    \r\n           :@@@   @-  +@+           +-  -   :@.   \r\n                  -%.  :##-.        .%:  :   -%:  \r\n                   +%:  .-%%**+.     :@:  .   :%  \r\n                    *@:     -%@@.     .*   .   @. \r\n                     -%=.      =@      ++      %- \r\n                      .%%=      @      .%+     ++ \r\n                        -%@*:..#%        %-..  :+ \r\n                          -+*##+         :++##*++ \r\n                             .               ..:: \r\n";
        }
        
    }
    class SpearCat : Monster
    {
        public SpearCat()
        {
            MName = "창든 고양이";
            MHp = 150;
            MDamage = 20;
            AscArt[0] = "              .:     .:                           \r\n              *%-    #@                           \r\n             :#:#. .%+@                           \r\n             %=:*#*+ *@                           \r\n             @:*:    *@                           \r\n            .%        -+                          \r\n            +.         =:                         \r\n            *    -=  .+:=                         \r\n            +    #%  -@ #                         \r\n            +       -.. #                         \r\n            *       *-  #                         \r\n    --      +-     ::: -=                         \r\n   =#-#     =+      ...*                          \r\n   +  %     +         %.                          \r\n   +  %     *         :+                          \r\n   +  %    .+    .     *.                         \r\n   +  %    #:    *     --                         \r\n   -+ +-   @  .  +.     %                ::::.    \r\n    @  *   @  -.  %   + #             +***---=*+  \r\n *%%%%%%%%%%%%%@. :@%%@@@%%%%%%%%%%%%%@:.#     :@-\r\n **************#%--#**@-%++++++++++++*@#**    =*+:\r\n     =: *-*      *%   %@@               :*=#@@-   \r\n      #- +@            =:               .-:.      \r\n       *:              =:                         \r\n        =*=.           +.                         \r\n          .@           #                          \r\n           %:          *                          \r\n           .+   %##%+ .*                          \r\n            + .*:.:*  %:                          \r\n            + *:   +- %                           \r\n            *.#:   .@:@.                          \r\n            =##.    *##.                          \r\n";
            AscArt[1] = "                                                  \r\n            ..  %+  =+                            \r\n           :.  ##=# :#                            \r\n            - +#*+% :           .                 \r\n              +. :%          :@@@%                \r\n +*           *   %        +%--==*                \r\n.@=#.         *   #.   :=*%+ =.*+                 \r\n %=.@:        #   ::  %@:    +  %                 \r\n  =#.#=       %   .%:%-   .+  .*+                 \r\n   :@.*=      %    %#.    :*    #-                \r\n     @.+*     %    #=    #@@%    @-..             \r\n  ** .*+:%    %     .     ==      :::+%-          \r\n @==%  +*.@:  #           :.       .=-#           \r\n-*  @   +# #- #                    =##=           \r\n=   @    :%:=#*            +   .+  -%=            \r\n*  :%      #-+@          ===: ++#- *=             \r\n*  -+       @:-%.         :-   -+: %              \r\n+  -=      =%*+.%-             == :+              \r\n-. :#     -#  -# #-               %:              \r\n-# .@    :%    :@.#=             :#               \r\n @  @.  .%.     .#--#           -@                \r\n +- -+  %-        *+-%.     --=*#                 \r\n  %  #.#-          #+.%:    #@*.                  \r\n  :*  %@      = #   =#.***-  #                    \r\n   =+ #    .  #+%.=- :%#=.   *  .                 \r\n    +@+    :%#-:+**    +     =   :.               \r\n   %*       .%   =*    %.    #  : -               \r\n  *=       =*:   :**:  :**@#@*  .                 \r\n  %         :#. .=:     @.=% #-                   \r\n .-          %*#%*%    +-  :%:=#                  \r\n =-         := == ..  .#    .*=-#                 \r\n-%:  :::.      :.     %-      #=-%.               \r\n#: :@=.-%%:          :*        +*.%=              \r\n.=%#.    .=#=        %. .       -%.*+             \r\n            #%.      =. ..       .@.*+.           \r\n              %*     :+ ..:        #=:%+          \r\n               +*    .% :.          +*+=* +       \r\n                *+   :=              *#-#@#*      \r\n                 *   @.               +% # :#     \r\n                 ++ =*                 =%=: -*    \r\n                 -%:-%                 @: .- +=   \r\n                  .@@#                 .@.  = #:  \r\n                                        .+*.  .%  \r\n                                          :%=. -- \r\n                                            :@@:@ \r\n                                              :-*:\r\n";
        }
        
    }
    
}
