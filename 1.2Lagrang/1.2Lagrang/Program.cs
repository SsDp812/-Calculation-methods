class Program
{
    static double Lagrang(double x, float[] mas_x_i, float[] mas_y_i)
    {
        int size = mas_x_i.Length; double sum = 0;
        for (int i = 0; i < size; i++)
        {
            double mul = 1;
            for (int j = 0; j < size; j++)
            {
                if (i != j)
                {
                    mul *= (x - mas_x_i[j]) / (mas_x_i[i] - mas_x_i[j]);
                }
            }
            sum += mas_y_i[i] * mul;
        }
        return sum;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Введите количество элементов:");
        int a = int.Parse(Console.ReadLine());
        float[] dataArr = new float[a];
        for (int i = 0; i < a; i++)
        {
            Console.WriteLine("Значения x{0}: ", i);
            dataArr[i] = int.Parse(Console.ReadLine());
        }
        float[] arr2 = new float[a];
        for (int i = 0; i < a; i++)
        {
            Console.WriteLine("Введите значения F[{0}]: ", i);
            arr2[i] = int.Parse(Console.ReadLine());
        }
        for (int j = 0; j < a - 1; j++)
        {
            double x = (dataArr[j] + dataArr[j + 1]) / 2;
        }
        double[] mas1;
        mas1 = new double[a * 2];
        double[] mas2;
        mas2 = new double[a * 2];
        int k = 0;
        for (int i = 0; i < a; i++)
        {
            mas2[k] = arr2[i]; mas1[k] = dataArr[i];
            k += 2;
        }
        k = 1;
        for (int j = 0; j < a - 1; j++)
        {
            double x = (dataArr[j] + dataArr[j + 1]) / 2;
            mas2[k] = Lagrang(x, dataArr, arr2);
            mas1[k] = x; k += 2;
        }
        Console.WriteLine("Результат:");
        for (int i = 0; i < a * 2 - 1; i++)
        {
            Console.WriteLine("x_" + i + "=" + mas1[i] + '\t' + " F[x_" + i + "]" + "=" + mas2[i]);
        }
        Console.ReadLine();
    }
}
