using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Ivanitcky_199_1_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            ConsoleKeyInfo ourKey;
            bool flagExit = false;
            bool inMenuOption = false;

            printMenu(a);

            string Sorting(string fileName, bool isSortingData)
            {
                char[] inputData;

                if (!(File.Exists(Environment.CurrentDirectory + "\\" + fileName)))
                {
                    try
                    {
                        File.AppendAllText(Environment.CurrentDirectory + "\\" + fileName, "Тестовая строка для сортировки 12412515245");
                    }
                    catch (Exception b)
                    {
                        Console.WriteLine(b.Message);
                        throw;
                    }
                }

                inputData = File.ReadAllText(Environment.CurrentDirectory + "\\" + fileName).ToCharArray();

                if (File.Exists(Environment.CurrentDirectory + "\\" + fileName))
                {
                    ;
                }
                else
                {
                    File.AppendAllText(Environment.CurrentDirectory + "\\" + fileName, "Тестовая строка для сортировки 12412515245");
                }

                if (isSortingData == true)
                {
                    for (int left = 0; left < inputData.Length; left++)
                    {
                        int value = inputData[left];
                        int i = left - 1;
                        for (; i >= 0; i--)
                        {
                            if (value < inputData[i])
                            {
                                inputData[i + 1] = inputData[i];
                            }
                            else
                            {
                                break;
                            }    
                        }
                        inputData[i + 1] = (char)value;
                    }
                    return new string(inputData);
                }
                else
                {
                    Console.WriteLine("Original input data from file.");
                    return new string(inputData);
                }
            }

            string About()
            {
                char[] enter = {(char)10, (char)13 };
                return string.Format("2.11.2021 15:43{0}Pratice #1{0}Ivanitsky Anton Igorevich", new string(enter));
            }

            bool Exit()
            {
                return true;
            }

            do
            {
                ourKey = Console.ReadKey();
                inMenuOption = false;
                printMenu(a);

                if (inMenuOption == false)
                {
                    if (ourKey.Key == ConsoleKey.UpArrow)
                    {
                        a--;
                        if (a < 1) a = 1;
                        printMenu(a);
                    }
                    if (ourKey.Key == ConsoleKey.DownArrow)
                    {
                        a++;
                        if (a > 3) a = 3;
                        printMenu(a);
                    }
                    if (ourKey.Key == ConsoleKey.Spacebar)
                    {
                        inMenuOption = true;
                        if (a == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Original data:");
                            Console.WriteLine(Sorting("InputData.txt", false));
                            Console.WriteLine();
                            Console.WriteLine("Sorting data:");
                            Console.WriteLine(Sorting("InputData.txt", true));
                        }
                        if (a == 2)
                        {
                            Console.Clear();
                            Console.WriteLine(About());
                        }
                        if (a == 3)
                        {
                            Console.Clear();
                            Console.WriteLine("Do you really want to exit?? \n Press 'y' for exit");

                            if (Console.ReadKey().Key == ConsoleKey.Y)
                                flagExit = Exit();

                            else
                            {
                                inMenuOption = false;
                                printMenu(a);
                            }
                        }
                    }
                }
            }
            while (flagExit == false);

            Console.Clear();
            Console.WriteLine("Пожалуйста нажмите на клавишу для выхода...");
            Console.ReadKey();

            void printMenu(int activeMenu)
            {

                string[] vs = new string[] { "Сортировка", "Дата релиза", "Выход" };
                Console.Clear();
                for (int i = 0; i < vs.Length; i++)
                {
                    if (i == a - 1) Console.ForegroundColor = ConsoleColor.Red;
                    else Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(vs[i]);
                }
                
            }
        }
    }
}
