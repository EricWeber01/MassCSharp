using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassCSharp
{
    internal class Program
    {
        static Random rand = new Random();
        static void GenerateArr2(int[,] array)
        {
            for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
                for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                    array[i, j] = rand.Next(-100, 100);
        }
        static void ShowArr2(int[,] array)
        {
            for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                    Console.Write($"{array[i, j]} \t");
                Console.WriteLine();
            }
        }
        static int FindSum2(int[,] array)
        {
            int min_x_coord = 0, min_y_coord = 0, max_x_coord = 0, max_y_coord = 0;
            int min = array.Cast<int>().Min();
            int max = array.Cast<int>().Max();
            Console.WriteLine($"\n{min}");
            Console.WriteLine($"\n{max}");
            for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
                for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                    if (array[i, j] == min)
                    {
                        min_x_coord = i;
                        min_y_coord = j;
                        break;
                    }
            for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
                for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                    if (array[i, j] == max)
                    {
                        max_x_coord = i;
                        max_y_coord = j;
                        break;
                    }
            int sum = 0;
            if (max_x_coord >= min_x_coord)
            {
                if (max_y_coord >= min_y_coord)
                {
                    for (int i = min_x_coord; i <= max_x_coord; i++)
                        for (int j = min_y_coord; j <= max_y_coord; j++)
                            sum += array[i, j];
                }
                else
                {
                    for (int i = min_x_coord; i <= max_x_coord; i++)
                        for (int j = max_y_coord; j <= min_y_coord; j++)
                            sum += array[i, j];
                }
            }
            else
            {
                if (max_y_coord >= min_y_coord)
                {
                    for (int i = max_x_coord; i <= min_x_coord; i++)
                        for (int j = min_y_coord; j <= max_y_coord; j++)
                            sum += array[i, j];
                }
                else
                {
                    for (int i = max_x_coord; i <= min_x_coord; i++)
                        for (int j = max_y_coord; j <= min_y_coord; j++)
                            sum += array[i, j];
                }
            }
            return sum;
        }
        static void GenerateArr(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
                mas[i] = rand.Next(-100, 100);
        }
        static void ShowArr(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
                Console.Write($"{mas[i]} \t");
            Console.WriteLine();
        }
        static int[] AddToEnd(int[] mas)
        {
            Console.Write("Укажите число ==> ");
            int num = int.Parse(Console.ReadLine());
            Array.Resize(ref mas, mas.Length + 1);
            mas[mas.Length - 1] = num;
            return mas;
        }
        static int[] AddToBegin(int[] mas)
        {
            Console.Write("Укажите число ==> ");
            int num = int.Parse(Console.ReadLine());
            Array.Resize(ref mas, mas.Length + 1);
            for (int i = mas.Length - 1; i > 0; i--)
                mas[i] = mas[i - 1];
            mas[0] = num;
            return mas;
        }
        static int[] AddToPos(int[] mas)
        {
            Console.Write("Укажите число ==> ");
            int num = int.Parse(Console.ReadLine());
            Console.Write("Укажите позицию ==> ");
            int pos = int.Parse(Console.ReadLine());
            if (pos > 0 && pos <= mas.Length)
            {
                Array.Resize(ref mas, mas.Length + 1);
                for (int i = mas.Length - 1; i > pos - 1; i--)
                    mas[i] = mas[i - 1];
                mas[pos - 1] = num;
            }
            return mas;
        }
        static int[] DeleteFromEnd(int[] mas)
        {
            if (mas.Length != 0)
                Array.Resize(ref mas, mas.Length - 1);
            return mas;
        }
        static int[] DeleteFromBegin(int[] mas)
        {
            if (mas.Length != 0)
            {
                for (int i = 0; i < mas.Length - 1; i++)
                    mas[i] = mas[i + 1];
                Array.Resize(ref mas, mas.Length - 1);
            }
            return mas;
        }
        static int[] DeleteFromPos(int[] mas)
        {
            if (mas.Length != 0)
            {
                Console.Write("Укажите позицию ==> ");
                int pos = int.Parse(Console.ReadLine());
                if (pos > 0 && pos <= mas.Length)
                {
                    for (int i = pos - 1; i < mas.Length - 1; i++)
                        mas[i] = mas[i + 1];
                    Array.Resize(ref mas, mas.Length - 1);
                }
            }
            return mas;
        }
        static void Main(string[] args)
        {
            int[,] array = new int[5, 5];
            GenerateArr2(array);
            ShowArr2(array);
            Console.WriteLine($"\n{FindSum2(array)}");
            int[] mas = new int[5];
            GenerateArr(mas);
            int choice = 0;
            do
            {
                ShowArr(mas);
                Console.WriteLine("1 ==> Добавить элемент в конец массива. \n2 ==> Добавить элемент в начало массива. \n3 ==> Добавить элемент  в позицию. \n4 ==> Удалить элемент с конца массива. \n5 ==> Удалить элемент с начала массива. \n6 ==> Удалить с позиции в массиве.");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            mas = AddToEnd(mas);
                        }
                        break;
                    case 2:
                        {
                            mas = AddToBegin(mas);
                        }
                        break;
                    case 3:
                        {
                            mas = AddToPos(mas);
                        }
                        break;
                    case 4:
                        {
                            mas = DeleteFromEnd(mas);
                        }
                        break;
                    case 5:
                        {
                            mas = DeleteFromBegin(mas);
                        }
                        break;
                    case 6:
                        {
                            mas = DeleteFromPos(mas);
                        }
                        break;
                }
            } while (choice != 0);
            int[] mas1 = new int[13];
            int[] mas2 = new int[7];
            int[] mas3 = new int[mas1.Length + mas2.Length];
            GenerateArr(mas1);
            GenerateArr(mas2);
            Console.Write($"mas1: ");
            ShowArr(mas1);
            Console.Write($"mas2: ");
            ShowArr(mas2);
            int counter_id = 0;
            for (int i = 0; i < mas1.Length; i++, counter_id++)
                mas3[counter_id] = mas1[i];
            for (int i = 0; i < mas2.Length; i++, counter_id++)
                mas3[counter_id] = mas2[i];
            Console.Write($"mas3 = mas1 + mas2: ");
            ShowArr(mas3);
            Console.ReadKey();
        }
    }
}