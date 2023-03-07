


class Program
{
    static double func(double x, double y) {
        return (11 * x - y) / x;
    }
    static double[] MethodElera(double a, double h, double n, double[] X, double[] Y)
    {
        for (int i = 1; i <= n; i++)
        {
            X[i] = a + i * h;
            Y[i] = Y[i - 1] + h * func(X[i - 1], Y[i - 1]);
        }
        Console.WriteLine("Эйлер");
        Console.WriteLine();
        for (int i = 0; i <= n; i++)
        {

            Console.WriteLine("X[{0}]={1}", i, X[i]);
            Console.WriteLine("F[X]={0}", Y[i]);
            Console.WriteLine();
        }
        Console.WriteLine("====================================");
        return Y;
    }
    static double[] ModifiedEler(double h, double n, double[] X, double[] Y)
    {
        for (int i = 0; i < n - 1; i++)
        {
            X[i + 1] = X[i] + h;
            Y[i + 1] = Y[i] + h * func(X[i] + h / 2, Y[i] + h / 2 * func(X[i], Y[i]));
        }
        Console.WriteLine("Модифицированный Эйлер");
        Console.WriteLine();
        for (int i = 0; i <= n; i++)
        {
            Console.WriteLine("X[{0}]={1}", i, X[i]);
            Console.WriteLine("F[X]={0}", Y[i]);
            Console.WriteLine();
        }
        Console.WriteLine("====================================");
        return Y;
    }
    static double[] PrediktCorrector(double h, double n, double[] X, double[] Y, double[] Y_)
    {
        for (int i = 0; i < n; i++)
        {
            X[i + 1] = X[i] + h;
            Y_[i + 1] = Y[i] + h * func(X[i], Y[i]);
            Console.WriteLine("Глобальное значение: {0}", Y_[i + 1]);
            Y[i + 1] = Y[i] + h * (func(X[i], Y[i]) + func(X[i + 1], Y[i + 1])) / 2;
            Console.WriteLine("Коррекция: {0}", Y[i + 1]);
        }
        Console.WriteLine();
        Console.WriteLine("Предиктор-корректор");
        Console.WriteLine();
        for (int i = 0; i <= n; i++)
        {
            Console.WriteLine("X[{0}]={1}", i, X[i]);
            Console.WriteLine("F[X]={0}", Y_[i]);
            Console.WriteLine();
        }
        Console.WriteLine("====================================");
        return Y;
    }
    static void Main(string[] args)
    {
        double a = 1;
        double b = 2;
        double h = 0.2;
        double n = (b - a) / h;
        double[] X = new double[(int)n + 1];
        double[] Y = new double[(int)n + 1];
        double[] Y_ = new double[(int)n + 1];
        X[0] = a;
        Y[0] = 7.5;
        MethodElera(a, h, n, X, Y);
        ModifiedEler(h, n, X, Y);
        PrediktCorrector(h, n, X, Y, Y_);
        Console.ReadLine();
    }

}