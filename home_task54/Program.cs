/*
Задача 54: Задайте двумерный массив. Напишите программу,
которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
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

void SortTwoDimArrayInRowsByAsc(int[,] array)
{
    //применим метод сортировки выбором
    //Сортирует по возрастанию
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            int minIndex = j;
            //находим наименьший элемент строки
            for (int k = j + 1; k < array.GetLength(1); k++)
            {
                if (array[i, k] < array[i, minIndex])
                    minIndex = k;
            }
            if (minIndex > j)
            {
                int tmp = array[i, j];
                array[i, j] = array[i, minIndex];
                array[i, minIndex] = tmp;
            }
        }
    }
}

void SortTwoDimArrayInRowsByDesc(int[,] array)
{
    //применим метод сортировки выбором
    //Сортирует по убыванию
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            int maxIndex = j;
            //находим наибольший элемент строки
            for (int k = j + 1; k < array.GetLength(1); k++)
            {
                if (array[i, k] > array[i, maxIndex])
                    maxIndex = k;
            }
            if (maxIndex > j)
            {
                int tmp = array[i, j];
                array[i, j] = array[i, maxIndex];
                array[i, maxIndex] = tmp;
            }
        }
    }
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
int minValue = 1;
int maxValue = 10;
int[,] array = GetArray(rows, columns, minValue, maxValue);
Console.Write($"Исходный массив [{rows}*{columns}], ");
Console.WriteLine($"в диапазоне {minValue} до {maxValue}:");
ShowArray(array);

SortTwoDimArrayInRowsByDesc(array);
Console.WriteLine($"Результат:");
ShowArray(array);