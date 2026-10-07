class Program
{
    static void Main()
    {
        int[] scores = { 96, 85, 60, 75, 90, 97, 64 };

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\n=== Меню ===");
            Console.WriteLine("0. Вихід");
            Console.WriteLine("1. Додати результат");
            Console.WriteLine("2. Показати всі результати");
            Console.WriteLine("3. Показати середній бал");
            Console.WriteLine("4. Показати найвищий і найнижчий бал");
            Console.WriteLine("5. Показати розподіл за категоріями");


            int choice = ReadInt("Ваш вибір: ", 0, 6);

            isRunning = choice switch
            {
                1 => HandleAdd(ref scores),
                2 => HandleShow(scores),
                3 => HandleCalculateAverage(scores),
                4 => HandleMaxMin(scores),
                5 => HandleClassify(scores),
                0 => false,
                _ => true 
            };
        }

        Console.WriteLine("Роботу завершено.");
    }

    static bool HandleAdd(ref int[] scores)
    {
        AddResult(ref scores);
        return true;
    }

    static bool HandleShow(int[] scores)
    {
        if (scores.Length == 0)
        {
            Console.WriteLine("Немає даних.");
            return true;
        }

        Console.WriteLine(string.Join(", ", scores));
        return true;
    }

    static bool HandleCalculateAverage(int[] scores)
    {
        if (scores.Length == 0)
        {
            Console.WriteLine("Немає даних.");
            return true;
        }

        Console.WriteLine(CalculateAverage(scores));
        return true;
    }

    static bool HandleMaxMin(int[] scores)
    {
        int maxPos = FindMax(scores);
        Console.WriteLine($"Максимальний бал: {maxPos}) {scores[maxPos]}");
        int minPos = FindMin(scores);
        Console.WriteLine($"Мінімальний бал: {minPos}) {scores[minPos]}");
        return true;
    }

    static bool HandleClassify(int[] scores)
    {
        Classify(scores);
        return true;
    }

    static void AddResult(ref int[] scores)
    {
        int newScore = ReadInt("Новий бал: ");

        if (newScore >= 0 && newScore <= 100)
        {
            Array.Resize(ref scores, scores.Length + 1);
            scores[^1] = newScore;
        }
        else
        {
            Console.WriteLine("Неправильний ввід");
        }
    }

    static double CalculateAverage(int[] scores)
    {
        if (scores.Length == 0)
        {
            return 0;
        }

        int sum = 0;

        foreach (int v in scores)
        {
            sum += v;
        }

        return (double)sum / scores.Length;
    }

    static int FindMax(int[] scores)
    {
        int max = scores[0];
        int maxPos = 0;
        for (int v = 0; v < scores.Length; v++)
        {
            if (scores[v] > max)
            {
                max = scores[v];
                maxPos = v;
            }
        }
        return maxPos;
    }

    static int FindMin(int[] scores)
    {
        int min = scores[0];
        int minPos = 0;
        for (int v = 0; v < scores.Length; v++)
        {
            if (scores[v] < min)
            {
                min = scores[v];
                minPos = v;
            }
        }
        return minPos;
    }

    static void Classify(int[] scores)
    {
        int excellent = 0;
        int good = 0;
        int satisfactory = 0;
        int unsatisfactory = 0;

        foreach (int v in scores)
        {
            if (v >= 90)
            {
                excellent++;
            }
            else if (v >= 75)
            {
                good++;
            }
            else if (v >= 60)
            {
                satisfactory++;
            }
            else
            {
                unsatisfactory++;
            }
        }
        Console.WriteLine($"Відмінно: {excellent}");
        Console.WriteLine($"Добре: {good}");
        Console.WriteLine($"Задовільно: {satisfactory}");
        Console.WriteLine($"Незадовільно: {unsatisfactory}");
    }

    static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int value) && value >= min && value <= max)
            {
                return value;
            }

            Console.WriteLine($"Некоректне значення. Введіть ціле число від {min} до {max}.");
        }
    }
}