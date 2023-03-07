

class Program
{
    public static double[] Gaus(double[,] a, double[] b, int n)
    {
        double[] opredel = new double[n];
        double[,] matr = new double[n, n + 1];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matr[i, j] = a[i, j];
            }
            matr[i, n] = b[i];
        }
        double opr_1 = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n + 1; j++) {
                Console.Write("{0} ", matr[i, j]);
            }
            Console.WriteLine();
        }
        //прямой ход 
        //внешний цикл по строкам
        for (int i = 0; i < n; i++) 
        {
            double firstNotZeroInStr = matr[i, i];  //первый ненулевой элемент стр.i                                                           //делим текущую iю строку на её первый ненулевой эл-т.
            opr_1 *= firstNotZeroInStr;
            for (int j = i; j < n + 1; j++) 
            {
                matr[i, j] /= firstNotZeroInStr;
            }                 //цикл по оставшимся строкам матрицы
            for (int k = i + 1; k < n; k++) 
            {
                double firstNotZeroStrK = matr[k, i]; //первый ненулевой эл-т строки k                                                             //вычитаем из строки К i-ю домнаженную на 1й ненулевой эл-т 
                for (int l = i; l < n + 1; l++)
                {
                    matr[k, l] -= matr[i, l] * firstNotZeroStrK;
                }
            }
        }
        Console.WriteLine();
        Console.Write("Определитель {0}", opr_1);
        Console.WriteLine(); return opredel;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Массив:"); int n = 5;
        double[,] a = new double[n, n]; double[] b = new double[n];
        double[,] A;
        A = new double[5, 5] {{ 11.00, 0.11, 0.11, 0.11, 0.11 },
                { 0.12 , 12.00 , 0.12 , 0.12 , 0.12},
                { 0.13,  0.13 , 13.00,  0.13,  0.13 },
                { 0.14,  0.14,  0.14,  14.00,  0.14},
                {0.15, 0.15 , 0.15,  0.15 , 15.00 } };
        double[,] A2; A2 = new double[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                A2[i, j] = A[i, j];
            }
        }
        double[] B; B = new double[5]{
                    26.50000000000000000000,37.73999999999999488409,50.96000000000000795808,
                    66.15999999999999658939,83.34000000000000341061 };
        double[] X = Gaus(A, B, n);
        Console.ReadLine();
    }

}