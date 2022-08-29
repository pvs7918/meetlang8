/*
Задача 55. задайте двумерный массив. Напишите программу, которая заменяем строки на столбцы.
В случае, если это невозможно, программа должна вывести сообщение для пользователя.
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

bool RotateArray(int[,] array)
{
    if (array.GetLength(0) != array.GetLength(1))
        return false;

    for (int i = 0; i < array.GetLength(1); i++)
    {
        for (int j = 0; j < i; j++)
        {
            int tmp = array[i, j];
            array[i, j] = array[j, i];
            array[j, i] = tmp;
        }
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

int rows = 4;
int columns = 4;
int minValue = -10;
int maxValue = 10;
int[,] array = GetArray(rows, columns, minValue, maxValue);
Console.Write($"Исходный массив [{rows}*{columns}], ");
Console.WriteLine($"в диапазоне {minValue} до {maxValue}:");
ShowArray(array);

bool isSuccessful = RotateArray(array);
if (isSuccessful)
{
    Console.WriteLine($"Результат:");
    ShowArray(array);
}
else
{
    Console.WriteLine("Невозможно заменить строки на столбцы!");
}