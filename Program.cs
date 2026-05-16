using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

class CollatzParallel
{
    static void Main()
    {
        int limit = 10_000_000;
        long[] stepsArray = new long[limit + 1];
        
        Console.WriteLine($"Початок обчислень для {limit} чисел...");
        
        Stopwatch sw = Stopwatch.StartNew();

        Parallel.For(1, limit + 1, n =>
        {
            stepsArray[n] = CountCollatzSteps(n);
        });

        sw.Stop();

        // Обчислення середнього значення
        double averageSteps = 0;
        long totalSteps = 0;
        for (int i = 1; i <= limit; i++)
        {
            totalSteps += stepsArray[i];
        }
        averageSteps = (double)totalSteps / limit;

        Console.WriteLine("Результати обчислень:");
        Console.WriteLine($"Загальний час: {sw.ElapsedMilliseconds} мс");
        Console.WriteLine($"Середня кількість кроків: {averageSteps:F2}");
        Console.WriteLine($"Кількість задіяних логічних процесорів: {Environment.ProcessorCount}");
    }

    // Функція обчислення
    static int CountCollatzSteps(int n)
    {
        long current = n;
        int steps = 0;
        while (current != 1)
        {
            if (current % 2 == 0)
                current /= 2;
            else
                current = 3 * current + 1;
            steps++;
        }
        return steps;
    }
}// Фінальна версія для пул ріквесту