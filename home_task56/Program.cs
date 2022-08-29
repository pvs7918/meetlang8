/*
Задача 56: Задайте прямоугольный двумерный массив. Напишите программу,
которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки
с наименьшей суммой элементов: 1 строка
*/

int[,] GetArray(int rows, int columns, int minRandomValue, int maxRandomValue)
{
    int[,] array = new int[rows, columns];
    var ran = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = ran.Next(minRandomValue, maxRandomValue + 1);
        }
    }
    return array;
}

int FindMinSummRow(int[,] array)
{
    int minRowIndex = 0;
    int minRowSumm = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int curRowSumm = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            curRowSumm += array[i, j];
        }
        if (i == 0 || curRowSumm < minRowSumm)
        {
            minRowSumm = curRowSumm;
            minRowIndex = i;
        }
    }
    return minRowIndex;
}

void ShowArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int rows = 3;
int columns = 4;
int minValue = 1;
int maxValue = 10;
int[,] array = GetArray(rows, columns, minValue, maxValue);
Console.Write($"Исходный массив [{rows}*{columns}], ");
Console.WriteLine($"в диапазоне {minValue} до {maxValue}:");
ShowArray(array);

int minSummRow = FindMinSummRow(array);
Console.WriteLine($"Ряд с наименьшей суммой элементов: {minSummRow + 1} строка");