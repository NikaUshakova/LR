using System;
using System.Diagnostics;

namespace ЛР2
{
    class Program
    {
        static void Main(string[] args)
        {
          Stopwatch stopwatch = new Stopwatch();
            string text = "А съешь ещё этих мягких французских булок, да выпей чаю";
            string[] textArray = text.Split(" ");
            Array.Sort(textArray);

            string searchWord = "чаю";

            stopwatch.Start();
            if (searchWord != "")
            {
                int resultPosition = -1;

                for(int i = 0; i < textArray.Length; i++ )
                {
                    Console.Write(textArray[i]+ " ");
                    if(textArray[i] == searchWord)
                    {
                        resultPosition = i;
                        break;
                    }
                }

                if (resultPosition == -1)
                {
                    Console.WriteLine("Такого ключа в массиве нет");
                }
                else
                {
                    Console.WriteLine("\nКлюч "+resultPosition+" найден");
                }
            }
            stopwatch.Stop();

            Console.WriteLine("Количество элементов в массиве: " + textArray.Length);
            Console.WriteLine("Затрачено в миллисекундах: "+ stopwatch.ElapsedMilliseconds);

        }
    }
}
