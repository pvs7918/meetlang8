/*
Задача 53: Задайте двумерный массив. Напишите программу,
которая поменяет местами первую и последнюю строку массива.
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

bool ReplaceFirstAndLastRowsInArray(int[,] array)
{
    if (array.GetLength(0) < 2)
        return false;

    int lastRow = array.GetLength(0) - 1;
    for (int i = 0; i < array.GetLength(1); i++)
    {
        int tmp = array[0, i];
        array[0, i] = array[lastRow, i];
        array[lastRow, i] = tmp;
    }
    return true;
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
int minValue = -10;
int maxValue = 10;
int[,] array = GetArray(rows, columns, minValue, maxValue);
Console.Write($"Исходный массив [{rows}*{columns}], ");
Console.WriteLine($"в диапазоне {minValue} до {maxValue}:");
ShowArray(array);

bool isSuccessfulReplaced = ReplaceFirstAndLastRowsInArray(array);
if (isSuccessfulReplaced)
{
    Console.WriteLine($"Результат:");
    ShowArray(array);
}
else
{
    Console.WriteLine("Невозможно поменять строки местами!");
}