using System;
using System.Diagnostics;

namespace ЛР3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[300];
            Random rand = new Random();
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rand.Next(100);
                //Console.Write(mas[i] + " ");
            }
            Array.Sort(mas);
            Console.WriteLine();
            //Console.WriteLine(String.Join(" ", mas));
            Console.WriteLine("Введите число для посика: ");
            int searchNumber = int.Parse(Console.ReadLine());
            Stopwatch stopwatch = new Stopwatch();
                

            if (searchNumber >= 0)
            {
                stopwatch.Start();

                int low = 0;
                int high = mas.Length - 1;
                var result = Interpolic(searchNumber, mas, low, high);

                stopwatch.Stop();

               // Console.WriteLine(String.Join(" ", mas));
                Console.WriteLine("Затрачено времени в миллисекундах для массива, где l = " +mas.Length + ": " + stopwatch.ElapsedMilliseconds);
                Console.WriteLine("Ключ под номером: " + result);
            }

            
        }

        static int Interpolic(int searchNumber, int[] mas, int low, int high)
        {
            if (mas[low] < searchNumber && mas[high] > searchNumber)
            {
                int middle = low + (searchNumber - mas[low]) * (high - low) / (mas[high] - mas[low]);

                if (mas[middle] < searchNumber)
                {
                    low = middle + 1;
                }
                else
                {
                    if (mas[middle] < searchNumber)
                    {
                        high = middle - 1;
                    }
                    else return middle;
                }
            }
            
            if (mas[low] == searchNumber)
            {
                return low;
            }
            else
            {
                if (mas[high] == searchNumber)
                {
                    return high;
                }
                //else return "Искомый номер не найден";
            }

            return Interpolic(searchNumber, mas, low, high);
        }
    }
}
