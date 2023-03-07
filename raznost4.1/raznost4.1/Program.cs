class Program
{
    static double count_y_exact(double x, double T, double v) { return v * Math.Pow(x, 2) * (x - T); }
    static double func(double x, double v, double T)
    { return -(4 * v * Math.Pow(x, 4) - 3 * v * T * Math.Pow(x, 3) + 6 * v * x - 2 * v * T); }
    static double p_k(double x) { return -x * x; }
    static double q_k(double x) { return -x; }



    static void Main(string[] args)
    {
        int variant = 11;
        int n = 110; 
        double x_0 = 0;
        double xT = variant;
        double h = (xT - x_0) / n;
        double[] x = new double[n + 1];
        double[] y = new double[n + 1];
        double[] y_ex = new double[n + 1];
        double[] e = new double[n + 1];
        for (int i = 0; i < n + 1; i++)
        {
            x[i] = x_0 + i * h;
            y_ex[i] = count_y_exact(x[i], xT, variant);
        }
        double[] A = new double[n + 1];
        double[] B = new double[n + 1];
        double[] C = new double[n + 1];
        double[] F = new double[n + 1];
        double[] a = new double[n + 1];
        double[] b = new double[n + 1];
        F[0] = 0;
        F[n] = 0;
        a[1] = 0;
        b[1] = F[0];
        for (int i = 1; i < n;i++){
            A[i] = 0.5 * (1 + 0.5 * h * p_k(x[i]));
            B[i] = 0.5 * (1 - 0.5 * h * p_k(x[i]));
            C[i] = 1 + 0.5 * h * h * q_k(x[i]);
            F[i] = 0.5 * h * h * func(x[i], variant, xT);
        }
    ////систеема
    for (int j = 1; j < n;j++) {
        a[j + 1] = B[j] / (C[j] - A[j] * a[j]);
        b[j + 1] = (F[j] + A[j] * b[j]) / (C[j] - A[j] * a[j]);
    }
    for (int j = n - 1; j > 0; j--)
    {
        y[j] = a[j + 1] * y[j + 1] + b[j + 1];
        Console.WriteLine("x:\ty:\ty_T:\te:");
    }
    for (int i = 0; i < n + 1; i++){
        e[i] = Math.Abs(y[i] - y_ex[i]);
        Console.WriteLine($"{x[i]:f1}\t\t\t{y[i]:f1}\t\t\t{y_ex[i]:f1}\t\t\t{e[i]:f1}");
    }
        Console.ReadLine();
    }
}