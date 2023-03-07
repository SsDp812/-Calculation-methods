

class Program
{
    private static double Func(double x) {
        return Math.Pow(x, 3) + 3;
    }
    private static void Main()
    {
        double h = 0.5;
        for (double i = 0; i <= 3; i += h)
        {
            Console.Write("x[{0}]", i);
            Console.Write("f[{0}]={1}", i, Func(i));
            Console.WriteLine();
        }
        Console.ReadLine();
    }

}