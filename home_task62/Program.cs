/*
Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/

int[,] GetSpiralArray(int rows, int columns)
{
    int[,] ar = new int[rows, columns];
    int[] dR = new int[] { 0, 1, 0, -1 }; //массив-вектор приращений по рядам
    int[] dC = new int[] { 1, 0, -1, 0 }; //массив-вектор приращений по колонкам
    int k = 0;   //текущий индекс массивов dR и dC

    //текущие границы обрабатываемых строк, при повороте сдвигаются к середине массива
    int minR = 0;
    int maxR = ar.GetLength(0)-1;
    int minC = 0;
    int maxC = ar.GetLength(1)-1;
    //значение и индексы текущего заполняемого элемента массива
    int counter = 1;
    int curR = 0;
    int curC = 0;

    while (minR <= maxR && minC <= maxC)
    {
        //присваиваем значение
        ar[curR, curC] = counter;
        //Console.Write($"ar[{curR},{curC}]={ar[curR, curC]}  ");  //Отладка
        counter++;
        //проверяем необходимость разворота направления движения
        bool mustRotate = false;
        switch (k)
        {
            case 0:
                if (curC == maxC)
                    mustRotate = true;
                break;
            case 1:
                if (curR == maxR)
                    mustRotate = true;
                break;
            case 2:
                if (curC == minC)
                    mustRotate = true;
                break;
            case 3:
                if (curR == minR)
                    mustRotate = true;
                break;
        }
        
        //Console.Write($"MustRotate={mustRotate}  ");  //Отладка

        if (mustRotate)
        {
            //сдвигаем нужную границу (которая была пройдена) к центру масива
            switch (k)
            {
                case 0:
                    minR++;
                    break;
                case 1:
                    maxC--;
                    break;
                case 2:
                    maxR--;
                    break;
                case 3:
                    minC++;
                    break;
            }

            //поворот направления движения
            if (k == dR.Length - 1)
                k = 0;
            else
                k++;

            //Console.Write($"minR={minR},maxR={maxR},minC={minC},maxC={maxC}  ");  //Отладка
        }
                
        //Console.WriteLine($"k={k}"); //Отладка

        //делаем шаг в нужном направлении
        curR += dR[k];
        curC += dC[k];
    }
    return ar;
}

void ShowArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]:D2} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int rows = 6;
int columns = 6;
int[,] array = GetSpiralArray(rows, columns);
Console.WriteLine($"Результат. Массив [{rows}*{columns}], заполненный по спирали:");
ShowArray(array);