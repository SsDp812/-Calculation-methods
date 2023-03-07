

class Program
{
    public static double[] Gaus(double[,] a, double[] b, int n)
    {
        //Матрица  
        double[,] matr = new double[n, n + 1]; for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++) { matr[i, j] = a[i, j]; }
            matr[i, n] = b[i];
        }
        /////вывод//// 
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n + 1; j++)
            { Console.Write("{0} ", matr[i, j]); }
            Console.WriteLine();
        }
        //прямой ход 
        for (int i = 0; i < n; i++) 
        {
            double firstNotZeroInStr = matr[i, i]; 
            for (int j = i; j < n + 1; j++){
                matr[i, j] /= firstNotZeroInStr;
            }
            for (int k = i + 1; k < n; k++) 
            {
                double firstNotZeroStrK = matr[k, i]; 
                for (int l = i; l < n + 1; l++) 
                {
                    Console.WriteLine("{0} {1} {2}", i, k, l);
                    matr[k, l] -= matr[i, l] * firstNotZeroStrK; 
                }
            }
        }
        //обратный ход 
        double[] answer = new double[n];
        for (int i = 0; i < n; i++)
        {
            answer[n - i - 1] = matr[n - i - 1, n];
            for (int j = 0; j < i; j++) 
            {
                answer[n - i - 1] -= matr[n - i - 1, n - j - 1] * answer[n - j - 1];
            }
        }
        return answer;
    }
    static void Main(string[] args)
    {
        int n = 5;
        Console.WriteLine("Массив:");
        double[,] arr = new double[5, 5] {{ 11.00, 0.11, 0.11, 0.11, 0.11 },
                { 0.12 , 12.00 , 0.12 , 0.12 , 0.12},
                { 0.13,  0.13 , 13.00,  0.13,  0.13 },
                { 0.14,  0.14,  0.14,  14.00,  0.14},
                {0.15, 0.15 , 0.15,  0.15 , 15.00 } };
        double[,] arr2 = new double[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                arr2[i, j] = arr[i, j];
            }
        }
        double[] B;
        B = new double[5] { 26.50000000000000000000,
                37.73999999999999488409,50.96000000000000795808,
                66.15999999999999658939,83.34000000000000341061 };

        double[] X;
        X = Gaus(arr, B, 5);
        Console.WriteLine();
        Console.WriteLine("Корни СЛАУ: ");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"X[{i}]= {X[i]}");
        }
        Console.WriteLine();
        Console.WriteLine("Проверка метода Гаусса:");
        double[] check;
        check = new double[n];
        for (int i = 0; i < n; i++){
            check[i] = 0;
            for (int j = 0; j < n; j++)
            {
                check[i] = check[i] + arr2[i, j] * X[j];
            }
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"proverka[{i}]= {check[i]}");
        }
        Console.ReadLine();
    }

}