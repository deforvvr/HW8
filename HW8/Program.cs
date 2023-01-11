int programm;
Boolean begin = true;

int[] arrayInt = { };

while (begin)
{
    Console.Write("Введите номер задачи >>> ");

    programm = int.Parse(Console.ReadLine());

    switch (programm)
    {
        case 54:
            Task54();
            break;

        case 56:
            Task56();
            break;

        case 58:
            Task58();
            break;

        case 60:
            Task60();
            break;

        case 62:
            Task62();
            break;

        default:
            begin = false;
            break;
    }
}

void Task54()
{
    Console.Write ("Введите количество строк массива >>> ");
    int arrRows = int.Parse(Console.ReadLine());

    Console.Write ("Введите количество столбцов массива >>> ");
    int arrColumns = int.Parse(Console.ReadLine());

    int max = 10;
    int min = 1;

    Console.WriteLine("Исходный массив >>> ");
    int[,] array = ArrGen(arrRows, arrColumns, max, min);

    for (int strIndex = 0; strIndex < arrRows; strIndex++)
    {
        SortArr(array, strIndex);
    }

    Console.WriteLine("\nРезультат >>> ");
    for (int i = 0; i < arrRows; i++)
    {

        for (int j = 0; j < arrColumns; j++)
        {
            Console.Write(array[i, j] + "\t|");
        }
        Console.WriteLine(i + 1);
    }


    void SortArr(int[,] array, int strIndex)
    {
        int x;
        for (int i = 0; i < array.GetLength(1); i++)
        {
            for (int j = array.GetLength(1) - 1; j > i; j--)
            {
                if (array[strIndex, j] < array[strIndex, j - 1])
                {
                    x = array[strIndex, j];
                    array[strIndex, j] = array[strIndex, j - 1];
                    array[strIndex, j - 1] = x;
                }
            }
        }
    }
}


void Task56()
{
    Console.Write ("Введите количество строк массива >>> ");
    int arrRows = int.Parse(Console.ReadLine());

    Console.Write ("Введите количество столбцов массива >>> ");
    int arrColumns = int.Parse(Console.ReadLine());

    int max = 10;
    int min = 1;

    Console.WriteLine("Исходный массив:");
    int[,] array = new int[arrRows, arrColumns];

    int minV = Int32.MaxValue;
    int minI = -1;

    for (int i = 0; i < arrRows; i++)
    {
        int sum = 0;

        for (int j = 0; j < arrColumns; j++)
        {
            array[i, j] = new Random().Next(min, max);
            Console.Write(array[i, j] + "\t|");

            sum += array[i, j];
        }

        Console.WriteLine(i + 1 + "\t sum = " + sum);
        if (sum < minV)
        {
            minV = sum;
            minI = i;
        }
    }
    Console.WriteLine("Строка с наименьшей суммой элементов >>> \n" + (minI + 1) + ", сумма = " + minV);
}


void Task58()
{
    Console.Write ("Введите количество строк массива >>> ");
    int arrRows = int.Parse(Console.ReadLine());

    Console.Write ("Введите количество столбцов массива >>> ");
    int arrColumns = int.Parse(Console.ReadLine());

    int max = 10;
    int min = 1;


    Console.WriteLine("Исходный массив :");
    int[,] matrix1 = ArrGen(arrRows, arrColumns, max, min);

    Console.WriteLine("\nИсходный массив 2:");
    int[,] matrix2 = ArrGen(arrRows, arrColumns, max, min);

    int[,] resArr = new int[arrRows, arrColumns];

    Console.WriteLine("\nРезультат:");
    for (int i = 0; i < arrRows; i++)
    {
        for (int j = 0; j < arrColumns; j++)
        {
            resArr[i, j] = matrix1[i, j] * matrix2[i, j];
            Console.Write(resArr[i, j] + "\t|");
        }
        Console.WriteLine(i + 1);
    }
}


void Task60()
{
    int max = 100;
    int min = 10;
    int arrSize = 2;

    int[,,] arr = new int[arrSize, arrSize, arrSize];

    int[] secArr = new int[arrSize * arrSize * arrSize];

    int x;
    for (int i = 0; i < secArr.Length; i++)
    {
        while (secArr[i] == 0)
        {
            x = new Random().Next(min, max);
            if (Array.IndexOf(secArr, x, i) == -1)
            {
                secArr[i] = x;
            }
        }
    }

    int count = 0;

    for (int arrDepth1 = 0; arrDepth1 < arrSize; arrDepth1++)
    {
        Console.Write(">");

        for (int arrDepth2 = 0; arrDepth2 < arrSize; arrDepth2++)
        {
            Console.Write(">");

            for (int arrDepth3 = 0; arrDepth3 < arrSize; arrDepth3++)
            {
                arr[arrDepth1, arrDepth2, arrDepth3] = secArr[count];
                count++;

                Console.WriteLine($"\t{arr[arrDepth1, arrDepth2, arrDepth3]}\t({arrDepth1},{arrDepth2},{arrDepth3})");
            }
        }
    }
}


void Task62()
{
    int arrSize = 4;
    int[,] arr = new int[arrSize, arrSize];

    int row = 0;
    int colum = 0;
    int count = 1;
    int maxR = arrSize - 1;
    int maxC = arrSize - 1;
    int minR = 0;
    int minC = 0;

    arr[row, colum] = count;
    count++;

    FillArray(arr, row, colum, minR, maxR, minC, maxC, count);

    void FillArray(int[,] array, int row, int colum, int minR, int maxR, int minC, int maxC, int count)
    {
        while (colum < maxC)
        {
            colum++;
            array[row, colum] = count;
            count++;
        }

        minR++;

        while (row < maxR)
        {
            row++;
            array[row, colum] = count;
            count++;
        }

        maxC--;

        while (colum > minC)
        {
            colum--;
            array[row, colum] = count;
            count++;
        }

        maxR--;

        while (row > minR)
        {
            row--;
            array[row, colum] = count;
            count++;
        }

        minC++;

        if (array[row, colum + 1] == 0) FillArray(array, row, colum, minR, maxR, minC, maxC, count);
    }

    for (int i = 0; i < arrSize; i++)
    {
        for (int j = 0; j < arrSize; j++)
        {
            Console.Write(arr[i, j] + "\t|");
        }
        Console.WriteLine();
    }

}



int[,] ArrGen(int lenRow, int lenCol, int max, int min) 
{
    int[,] arr = new int[lenRow, lenCol];
    for (int i = 0; i < lenRow; i++)
    {
        for (int j = 0; j < lenCol; j++)
        {
            arr[i, j] = new Random().Next(min, max);

            Console.Write(arr[i, j] + "\t|");
        }

        Console.WriteLine(i + 1);
    }

    return arr;
}