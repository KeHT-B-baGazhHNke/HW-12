using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW_12
{
    internal class Program
    {
        static void Numbers()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }
        static int Square(int num)
        {
            Console.WriteLine($"Квадрат от {num} == {num * num}");
            return num * num;
        }
        static int Fact(int num)
        {
            Thread.Sleep(8000);
            int factorial = num;
            for (int i = num - 1; i > 0; i--)
            {
                factorial = factorial * i;
            }
            Console.WriteLine($"Факториал от {num} = {factorial}");
            return factorial;
        }
        static async Task FactAsync(int num)
        {
            await Task.Run(() => Fact(num));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 1 числа от 1 до 10");
            Thread thread1 = new Thread(Numbers);
            Thread thread2 = new Thread(Numbers);
            Thread thread3 = new Thread(Numbers);
            thread1.Start();
            Thread.Sleep(1000);
            thread2.Start();
            Thread.Sleep(1000);
            thread3.Start();
            Thread.Sleep(1000);
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();

            Console.WriteLine("Упражнение 2 факториал и квадрат");
            Square(8);
            FactAsync(8);
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();

            Console.WriteLine("Упражнение 3 все методы класса");
            foreach (var methodInfo in typeof(Refl).GetMethods())
            {
                Console.WriteLine(methodInfo.Name);
            }
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}
