


class Program
{
    public static double[] Gaus(double[,] a, double[] b, int n, double y, double[] result)
    {
        double[,] matr = new double[n, n + 1];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matr[i, j] = a[i, j];
            }
            matr[i, n] = b[i];
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n + 1; j++)
            {
                Console.Write("{0} ", matr[i, j]);
            }
            Console.WriteLine();
        }
        //прямой ход 
        //внешний цикл по строкам
        for (int i = 0; i < n; i++) 
        {
            double firstNotZeroInStr = matr[i, i];  //первый ненулевой элемент стр.i 
                                                      //делим текущую iю строку на её первый ненулевой эл-т.
            for (int j = i; j < n + 1; j++) 
            {
                matr[i, j] /= firstNotZeroInStr;
            }                 //цикл по оставшимся строкам матрицы
            for (int k = i + 1; k < n; k++) 
            {
                double firstNotZeroStrK = matr[k, i]; //первый ненулевой эл-т строки k 
                                                        //вычитаем из строки К i-ю домнаженную на 1й ненулевой эл-т
                for (int l = i; l < n + 1; l++) 
                {
                    matr[k, l] -= matr[i, l] * firstNotZeroStrK;
                }
            }
        }
        double[] a1 = new double[n];
        double[] b1 = new double[n];
        y = a[0, 0]; a1[0] = -a[0, 1] / y;
        b1[0] = b[0] / y;
        for (int i = 1; i < n - 1; i++)
        {
            y = a[i, i] + a[i, i - 1] * a1[i - 1];
            a1[i] = -a[i, i + 1] / y;
            b1[i] = (b[i] - a[i, i - 1] * b1[i - 1]) / y;
        }
        //обратный ход 
        double[] otv = new double[n];
        for (int i = 0; i < n; i++)
        { //запоминает iе зн-е столбца B
            otv[n - i - 1] = matr[n - i - 1, n];
            for (int j = 0; j < i; j++) 
            {
                otv[n - i - 1] -= matr[n - i - 1, n - j - 1] * otv[n - j - 1];
            }
        }
        result[n - 1] = (b[n - 1] - a[n - 1, n - 2] * b1[n - 2]) / (a[n - 1, n - 1] + a[n - 1, n - 2] * a1[n -2]);
        for (int i = n - 2; i >= 0; i--)
        {
            result[i] = a1[i] * result[i + 1] + b1[i];
        }
        for (int i = 0; i < n; i++) {
            Console.WriteLine($"x[{i}]= {result[i]}");
        }
        return otv;
    }
    static void Main(string[] args)
    {
        int n = 4;
        double y = 0;
        double[] res = new double[n];
        double[,] a = new double[n, n];
        double[,] A;
        A = new double[4, 4] {{ 8.00, -2.00, 0.00, 0.00},
                {-1.00 , 6.00 , -2.00, 0.00},
                {0.00, 2.00,  10.0 , -4.00 },{0.00,  0.00,  -1.00,  6.00 } };
        double[,] A2;
        A2 = new double[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                A2[i, j] = A[i, j];
            }
        }
        double[] B;
        B = new double[4] { 6.00, 3.00, 8.00, 5.00, };
        double[] X = Gaus(A, B, n, y, res);
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
        for (int i = 0; i < n; i++)
        {
            check[i] = 0;
            for (int j = 0; j < n; j++)
            {
                check[i] = check[i] + A2[i, j] * X[j];
            }
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Проверка[{i}]= {check[i]}");
        }
        Console.ReadLine();
    }

}