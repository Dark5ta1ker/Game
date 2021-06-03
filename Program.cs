using System;

namespace Game
{
    class Player
    {
        public void Change(int n)
        {
            switch (n)
            {
                case 1:
                    play = new ("plain");
                    Console.WriteLine("Что ж, полетели!\n");
                    Console.WriteLine($"Здоровье:{play.heals}\nБроня:{play.armor}\nПробивание брони:{play.ap}\nУрон:{play.damage}\nПатроны:{play.ammo}");
                    break;
                case 2:
                    play = new ("ZRK");
                    Console.WriteLine("Мы попадём во врага. Когда нибудь...\n");
                    Console.WriteLine($"Здоровье:{play.heals}\nБроня:{play.armor}\nПробивание брони:{play.ap}\nУрон:{play.damage}\nПатроны:{play.ammo}");
                    break;
                case 3:
                    play = new ("Tank");
                    Console.WriteLine("Танки грязи не боятся\n");
                    Console.WriteLine($"Здоровье:{play.heals}\nБроня:{play.armor}\nПробивание брони:{play.ap}\nУрон:{play.damage}\nПатроны:{play.ammo}");
                    break;         
            }
        }
        public MEH play;
    }
    class Enemy
    {
        public Enemy()
            {
            int n = Program.ab.Next(1, 4);
            switch (n)
            {
                case 1:
                    Console.WriteLine("Воздух!\n");
                    enem = new("plain");
                    break;
                case 2:
                    Console.WriteLine("Машина с пушкой на горизонте!\n");
                    enem = new("ZRK");
                    break;
                case 3:
                    Console.WriteLine("А нормально, что тот куст шевелится?\n");
                    enem = new("Tank");
                    break;
            }
        }
        public MEH enem;
    }
    class MEH
    {
        public int aheals;
        public int heals;
        public int armor;
        public int ap;
        public int damage;
        public int aammo;
        public int ammo;
        public int number;

        public MEH(string name)
        {
            switch(name)
            {
                case "plain":
                    heals = 20;
                    aheals = 10;
                    armor = 2;
                    ap = 7;
                    damage = 7;
                    ammo = 2;
                    aammo = 2;
                    number = 1;
                    break;
                case "ZRK":
                    heals = 15;
                    aheals = 15;
                    armor = 5;
                    ap = 6;
                    damage = 5;
                    ammo = 100;
                    aammo = 100;
                    number = 10;
                    break;
                case "Tank":
                    heals = 22;
                    aheals = 22;
                    armor = 10;
                    ap = 6;
                    damage = 10;
                    ammo = 5;
                    aammo = 5;
                    number = 1;
                    break;
            }
        }
    }
    class Program
    {
        public int rhealth = 1;
        public int rammo = 2;
        public int health;
        public string win;
        static public Random ab = new();
        
        public void Result(ref Player gamer, ref Enemy pc)
        {
            int n = ab.Next(1, 3);
            switch (n)
            {       
                case 1:
                    Console.WriteLine("Наша очередь, в атаку!");
                    win = Pshoot(ref gamer, ref pc);
                    break;
                case 2:
                    Console.WriteLine("Их. ход, нас атакуют, внимание!");
                    win = Eshoot(ref gamer, ref pc);
                    break;
            }
            switch (win)
            { 
                case "win":
                   Console.WriteLine("Победа, победа, вместо обеда");
                   break;
                case "false":
                   Console.WriteLine("Не сегодня...");
                   break;
                case "notwin":
                   Console.WriteLine("Бой продолжается");
                   break;
            }
           
        }

        static void Main(string[] args)
        {   Player gamer = new();
            Enemy pc = new();
            
            Console.WriteLine("Выберите класс техники:\n1 - Самолёт\n2 - ПВО\n3 - Танк");
            gamer.Change(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Выбор сделан, можно воевать");
            Program res = new Program();
            while (true)
            {
                res.Result(ref gamer, ref pc);
                
                if (res.win == "win" || res.win == "false")
                {
                     break;
                }
                else
                {
                    res.win = res.Bye(ref gamer);
                    if (res.win == "false")
                    {
                        break;
                    }
                }
                Console.ReadKey();     
            }
        }
        string Pshoot(ref Player gamer, ref Enemy pc)
        {
            int damage;
            if (1 <= gamer.play.ammo)
            {
                gamer.play.ammo -= gamer.play.number;
                if (gamer.play.ap > pc.enem.armor)
                {
                    Console.WriteLine("Есть пробите!");
                    pc.enem.heals -= gamer.play.damage;
                    if (pc.enem.heals <= 0)
                    {
                        Console.WriteLine("Враг уничтожен!");
                        Console.WriteLine($"Осталось {gamer.play.ammo} патронов");
                        win = "win";
                    }
                    else
                    {
                        Console.WriteLine($"Кое-кто хочет добавки!\nОсталось {pc.enem.heals} hp");
                        Console.WriteLine($"Осталось {gamer.play.ammo} патронов");
                        win = "notwin";
                    }
                }
                else
                {
                    damage = gamer.play.damage - pc.enem.armor;
                    pc.enem.heals -= damage;
                    if (pc.enem.heals <= 0)
                    {
                        Console.WriteLine("Враг уничтожен!");
                        Console.WriteLine($"Осталось {gamer.play.ammo} патронов");
                        win = "win";
                    }
                    else
                    {
                        Console.WriteLine($"Кое-кто хочет добавки!\nОсталось {pc.enem.heals} hp");
                        win = "notwin";
                    }
                }
            }
            else
            {
                Console.WriteLine("А стрелять-то нечем!");
            }
            return win;
        }
        string Eshoot(ref Player gamer, ref Enemy pc)
        {
            int damage;
            if (1 <= pc.enem.ammo)
            {
                pc.enem.ammo -= pc.enem.number;

                if (pc.enem.ap > gamer.play.armor)
                {
                    Console.WriteLine("Нас пробили!");
                    gamer.play.heals -= pc.enem.damage;
                    if (gamer.play.heals <= 0)
                    {
                        Console.WriteLine("Все, довоевались, покинуть машину!");
                        win = "false";
                    }
                    else
                    {
                        Console.WriteLine($"Наводчик контужен!\nОсталось {gamer.play.heals} hp");
                        win = "notwin";
                    }
                }
                else
                {
                    Console.WriteLine("НЕ пробили!");
                    damage = pc.enem.damage - gamer.play.armor;
                    gamer.play.heals -= damage;
                    if (gamer.play.heals <= 0)
                    {
                        Console.WriteLine("Все, довоевались, покинуть машину!");
                        win = "false";
                    }
                    else
                    {
                        Console.WriteLine($"Наводчик контужен!\nОсталось {gamer.play.heals} hp");
                        win = "notwin";
                    }
                }
            }
            else
            {
                Console.WriteLine("У кого-то кончились патроны!");
            }
            return win;
        }
        string Bye(ref Player gamer)
        {
            
            Console.WriteLine("Магазин открыт!\n1 - Пополнить БК\n2 - Восстановить машину\n3 - Смываемся!\n4 - Обойдёмся без покупок");
            int mag = Convert.ToInt32(Console.ReadLine());
            switch (mag)
            {
                case 1:
                    if (rammo > 0)
                    {
                        rammo -= 1;
                        gamer.play.ammo = gamer.play.aammo;
                        Console.WriteLine($"БК пополнен! Теперь у нас {gamer.play.ammo}. Можно пополнить ещё {rammo} раз");

                    }                 
                    else
                    {
                        Console.WriteLine("Склад пустой!");
                    }
                    break;
                case 2:
                    if (rhealth > 0)
                    {
                        rhealth -= 1;
                        gamer.play.heals = gamer.play.aheals;
                        Console.WriteLine($"Машина в норме! Теперь у нас {gamer.play.heals}. Можно починить ещё {rhealth} раз");
                    }
                    else
                    {
                        Console.WriteLine("Такое не починишь!");
                    }
                    break;
                case 3:
                    Console.WriteLine("Валим отсюда");
                    win = "false";
                    break;
                case 4:
                    Console.WriteLine("Итак справимся!");
                    break;
            }
            return win;
        }
    }
    
}
