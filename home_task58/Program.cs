/*
Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
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

void ShowArray(int[,] array)
{
    Console.WriteLine($"размерностью [{array.GetLength(0)}*{array.GetLength(1)}]:");
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

bool AbilityMultiplyMatrixes(int[,] matrB, int[,] matrC)
{
    if (matrB.GetLength(1) != matrC.GetLength(0))
        return false;
    else
        return true;
}

int[,] MultiplyMatrixes(int[,] matrB, int[,] matrC)
{
    int[,] matrA = new int[matrB.GetLength(0), matrC.GetLength(1)];

    for (int i = 0; i < matrB.GetLength(0); i++)
    {
        for (int j = 0; j < matrC.GetLength(1); j++)
        {
            matrA[i, j] = 0;
            for (int k = 0; k < matrB.GetLength(1); k++)
            {
                matrA[i, j] += matrB[i, k] * matrC[k, j];
            }
        }
    }
    return matrA;
}


int rows = 3;
int columns = 4;
int minValue = 1;
int maxValue = 5;
int[,] matrB = GetArray(rows, columns, minValue, maxValue);

rows = 4;
columns = 5;
int[,] matrC = GetArray(rows, columns, minValue, maxValue);

if (!AbilityMultiplyMatrixes(matrB, matrC))
{
    Console.WriteLine("Данные матрицы нельзя перемножить, так как");
    Console.WriteLine("не совпадает кол-во столбцов и строк первой и второй матрицы");
}
else
{
    Console.Write($"Исходная матрица B ");
    Console.WriteLine($"значения от {minValue} и до {maxValue}:");
    ShowArray(matrB);

    Console.Write($"Исходная матрица C ");
    Console.WriteLine($"значения от {minValue} и до {maxValue}:");
    ShowArray(matrC);

    Console.WriteLine($"Результирующая матрица A=B*C ");
    int[,] matrA = MultiplyMatrixes(matrB, matrC);
    ShowArray(matrA);
}