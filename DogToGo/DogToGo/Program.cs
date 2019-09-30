
using System;

namespace DogWalk
    {
    class Program
    {
        static void Main(string[] args)
        {

            int i, j;
            int size = 10; // Размер массива
            Random rnd = new Random(); // рассположение аптек и бомб
            int DogHealth = 100; // здоровье собаки

            Console.WriteLine("Нажмите любую клавишу для старта игры");
            Console.ReadKey();
            Console.Clear();

            char[,] GamePlant = new char[size, size]; // обьявляем - создаем массив 
            int row = GamePlant.GetUpperBound(0) + 1;
            int col = GamePlant.Length / row;

            //заполнение массива
            for (i = 0; i < row; i++)
            {
                for (j = 0; j < col; j++)
                {
                    GamePlant[i, j] = '-';
                    GamePlant[0, 0] = '@';
                    GamePlant[row - 1, col - 1] = 'F';
                }
            }
            // перезаписываем бомбы и апети на место уже заполненного маассива
            for (i = 0; i < row; i++)
            {
                j = rnd.Next(1, col - 1);
                while (GamePlant[i, j] != '-')
                {
                    j = rnd.Next(1, col - 1);
                }
                GamePlant[i, j] = '*';

                while (GamePlant[i, j] != '-')
                {
                    j = rnd.Next(1, col - 1);
                }
                GamePlant[i, j] = '+';
            }

            //вывод начального поля
            for (i = 0; i < row; i++)
            {
                for (j = 0; j < col; j++)
                {
                    Console.Write("  ", GamePlant[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\nЗдоровье собаки:" + DogHealth);



            for (; ; )
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                Boolean Endfor = true; 

                for (i = 0; i < row && Endfor; i++)
                {
                    for (j = 0; j < col && Endfor; j++)
                    {
                        if (GamePlant[i, j] == '@')
                        {
                            // Двидение D,                           
                            if (key.Key == ConsoleKey.D)
                            {
                                if (j != col - 1) // проверяем конец строки
                                {
                                    DogHealth = DogHealth - 10;
                                    if (GamePlant[i, j + 1] == '*')
                                        DogHealth = DogHealth - 40;
                                    if (GamePlant[i, j + 1] == '+')
                                    {
                                        DogHealth = DogHealth + 40;
                                        if (DogHealth > 100)
                                            DogHealth = 100;
                                    }
                                    GamePlant[i, j] = '-';
                                    GamePlant[i, j + 1] = '@';
                                }
                                else
                                {
                                    DogHealth = DogHealth - 10; // перебросить собако в начало
                                    GamePlant[i, 0] = '@';
                                    GamePlant[i, j] = '-';

                                }
                                Endfor = false;
                            }

                            // Двидение A,
                            else if (key.Key == ConsoleKey.A)
                            {
                                if (j != 0)  // проверяем конец строки
                                {
                                    DogHealth = DogHealth - 10;
                                    if (GamePlant[i, j - 1] == '*')
                                        DogHealth = DogHealth - 40;
                                    if (GamePlant[i, j - 1] == '+')
                                    {
                                        DogHealth = DogHealth + 40;
                                        if (DogHealth > 100)
                                            DogHealth = 100;
                                    }
                                    GamePlant[i, j] = '-';
                                    GamePlant[i, j - 1] = '@';
                                }
                                else  
                                {
                                    DogHealth = DogHealth - 10;
                                    GamePlant[i, col - 1] = '@';
                                    GamePlant[i, j] = '-';
                                }
                                Endfor = false;
                            }

                            // Двидение W,
                            else if (key.Key == ConsoleKey.W)
                            {
                                if (i != 0)  // проверяем конец 
                                {
                                    DogHealth = DogHealth - 10;
                                    if (GamePlant[i - 1, j] == '*')
                                        DogHealth = DogHealth - 40;
                                    if (GamePlant[i - 1, j] == '+')
                                    {
                                        DogHealth = DogHealth + 40;
                                        if (DogHealth > 100)
                                            DogHealth = 100;
                                    }
                                    GamePlant[i, j] = '-';
                                    GamePlant[i - 1, j] = '@';
                                }
                                else //перебросить собако в начало
                                {
                                    DogHealth = DogHealth - 5;
                                    GamePlant[row - 1, j] = '@';
                                    GamePlant[i, j] = '-';
                                }
                                Endfor = false;
                            }

                            // Двидение S,
                            else if (key.Key == ConsoleKey.S)
                            {
                                if (i != row - 1) // проверяем конец 
                                {
                                    DogHealth = DogHealth - 10;
                                    if (GamePlant[i + 1, j] == '*')
                                        DogHealth = DogHealth - 40;
                                    if (GamePlant[i + 1, j] == '+')
                                    {
                                        DogHealth = DogHealth + 40;
                                        if (DogHealth > 100)
                                            DogHealth = 100;
                                    }
                                    GamePlant[i, j] = '-';
                                    GamePlant[i + 1, j] = '@';
                                }
                                else
                                {
                                    DogHealth = DogHealth - 5; // перенос в начало
                                    GamePlant[0, j] = '@';
                                    GamePlant[i, j] = '-';
                                }
                                Endfor = false;
                            }
                        }
                    }
                }
                // Результаты (),  вывод массива, вывод здоровья собаки.
                Console.Clear();
                if (GamePlant[row - 1, col - 1] == '@')
                {
                    Console.WriteLine(" Вы добрались конца, ПОЗДРОВЛЯЕМ!!!");
                    break;
                }
                 if (DogHealth <= 0)
                {
                    Console.WriteLine(" Соба не смогла приодолеть, путь. Вы ПРОИГРАЛИ!!!");
                    break;
                }
                
                else
                {
                    for (i = 0; i < row; i++)
                    {
                        for (j = 0; j < col; j++)
                        {
                            Console.Write(GamePlant[i, j]);
                        }
                        Console.WriteLine();
                    }
                    
                    Console.WriteLine("\n\nЗдоровье собаки:" + DogHealth);
                }
            }
            Console.ReadKey();
        }
    }
}