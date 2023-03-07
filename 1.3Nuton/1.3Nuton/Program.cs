class Program
{
    static double Nuton(double x, int a, double[] arrFi, double[] mas_fi)
    {
        double res = mas_fi[0], F, den;
        int i, j, k;
        for (i = 1; i < a; i++)
        {
            F = 0;
            for (j = 0; j <= i; j++)
            {
                den = 1;

                for (k = 0; k <= i; k++)
                {
                    if (k != j)
                    {
                        den *= (arrFi[j] - arrFi[k]);
                    }
                }
                //считаем разделенную разность 
                F += mas_fi[j] / den;
            }
            for (k = 0; k < i; k++)
            {
                F *= (x - arrFi[k]);
                res += F;
            }

        }
        return res;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Количество элементов:");
        int a = int.Parse(Console.ReadLine());
        double[] arrXi;
        arrXi = new double[a];
        for (int i = 0; i < a; i++)
        {
            Console.WriteLine("Значения x_{0}: ", i);
            arrXi[i] = int.Parse(Console.ReadLine());
        }
        double[] aarrFI;
        aarrFI = new double[a];
        for (int i = 0; i < a; i++)
        {
            Console.WriteLine("Введите значения F[x_{0}]: ", i);
            aarrFI[i] = int.Parse(Console.ReadLine());
        }
        for (int j = 0; j < a - 1; j++)
        {
            double x = (arrXi[j] + arrXi[j + 1]) / 2;
        }
        double[] arr1;
        arr1 = new double[a * 2];
        double[] arr2;
        arr2 = new double[a * 2];
        int k = 0;
        for (int i = 0; i < a; i++)
        {
            arr2[k] = aarrFI[i];
            arr1[k] = arrXi[i];
            k = k + 2;
        }
        k = 1;
        for (int j = 0; j < a - 1; j++)
        {
            double x = (arrXi[j] + arrXi[j + 1]) / 2;
            arr2[k] = Nuton(x, a, arrXi, aarrFI);
            arr1[k] = x;
            k = k + 2;
        }
        Console.WriteLine("Результат:");
        for (int i = 0; i < a * 2 - 1; i++)
        {
            Console.WriteLine("x" + i + "=" + arr1[i] + '\t' + " f(x_i)" + i + "=" + arr2[i]);
        }
        Console.ReadLine();
    }

}