/*
Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/

int[,,] GetArray3D(int[] len, int minRandomValue, int maxRandomValue)
{
    int[,,] array = new int[len[0], len[1], len[2]];
    var ran = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                array[i, j, k] = ran.Next(minRandomValue, maxRandomValue + 1);
            }
        }
    }
    return array;
}

void ShowArray3D(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write($"A[{i},{j},{k}]={array[i, j, k]}  ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

int[] len = {5,3,4};

int minValue = 10;
int maxValue = 99;
int[,,] array = GetArray3D(len, minValue, maxValue);

Console.Write($"Значения трехмерного массива ");
Console.WriteLine($"размерностью [{len[0]},{len[1]},{len[2]}]:");
ShowArray3D(array);

