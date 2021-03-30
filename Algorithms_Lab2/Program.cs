using System;

namespace Algorithms_Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            RBTree tree = null;
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("0 Добавленеие элемента");
                Console.WriteLine("1 Удаление элемента");
                Console.WriteLine("2 Вывод дерева");

                int a = Int32.Parse(Console.ReadLine());
                int value=0;

                if (a<2)
                {
                    Console.WriteLine("Введите значение элемента");
                    value = Int32.Parse(Console.ReadLine());
                }

                switch (a)
                {
                    case 0:
                        {
                            if (tree == null)
                                tree = new RBTree(value);
                            else
                                tree.Add(value);
                            break;
                        }
                    case 1:
                        {
                            if (tree == null)
                                Console.WriteLine("Дерево пусто");
                            else
                                tree.Remove(value);
                            break;
                        }
                    case 2:
                        {
                            if (tree == null)
                                Console.WriteLine("Дерево пусто");
                            else
                                tree.Print();
                            break;
                        }
                }
            }
        }
    }
}
