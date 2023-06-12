using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary;

class Program
{
    static string[] GetLongestWords(string[] text, int n)
    {
        return text.SelectMany(s => s.Split(new char[] { ' ', ',', '.', '!', '?', ':' }, StringSplitOptions.RemoveEmptyEntries))
              .Select(w => w.ToLower())
              .Distinct()
              .GroupBy(w => w.Length)
              .OrderByDescending(g => g.Key)
              .SelectMany(g => g.OrderBy(w => w))
              .Take(n)
              .ToArray();
    }

    static void PrintMaxDurationByMonth(int code, List<Record> clients)
    {
        var result =
            clients.Where(c => c.ClientID == code)
           .GroupBy(c => new { c.Year, c.Month })
           .Select(g => new { g.Key.Year, g.Key.Month, TotalDuration = g.Sum(c => c.Duration) })
           .OrderByDescending(r => r.Year)
           .ThenByDescending(r => r.TotalDuration)
           .GroupBy(r => r.Year)
           .Select(g => g.ToList().First())
           .ToList();

        if (result.Any())
        {
            Console.WriteLine($"Сведения о клиенте с кодом {code}:");
            foreach (var r in result)
            {
                Console.WriteLine($"{r.Year} {r.Month} {r.TotalDuration}");
            }
        }
        else
        {
            Console.WriteLine($"Нет данных для клиента с кодом {code}.");
        }
    }
    static void Main(string[] args)
    {
        string[] text = new string[] //В. Маяковский - Нате!
        {
            "Через час отсюда в чистый переулок",
            "вытечет по человеку ваш обрюзгший жир,",
            "а я вам открыл столько стихов шкатулок,",
            "я - бесценных слов мот и транжир.",
            "Вот вы, мужчина, у вас в усах капуста",
            "Где-то недокушанных, недоеденных щей;",
            "вот вы, женщина, на вас белила густо,",
            "вы смотрите устрицей из раковин вещей.",
            "Все вы на бабочку поэтиного сердца",
            "взгромоздитесь, грязные, в калошах и без калош.r",
            "Толпа озвереет, будет тереться,",
            "ощетинит ножки стоглавая вошь."
        };

        int n = 11;
        string[] result = GetLongestWords(text, n);

        Console.WriteLine("Слова наибольшей длины:");
        foreach (string word in result)
        {
            Console.WriteLine(word);
        }

        List<Record> clients = new List<Record>()
        {
                new Record() { ClientID = 1, Year = 2020, Month = 1, Duration = 120 },
                new Record() { ClientID = 1, Year = 2020, Month = 2, Duration = 90 },
                new Record() { ClientID = 1, Year = 2020, Month = 3, Duration = 150 },
                new Record() { ClientID = 1, Year = 2021, Month = 1, Duration = 100 },
                new Record() { ClientID = 1, Year = 2021, Month = 2, Duration = 110 },
                new Record() { ClientID = 2, Year = 2020, Month = 1, Duration = 80 },
                new Record() { ClientID = 2, Year = 2020, Month = 2, Duration = 70 },
                new Record() { ClientID = 2, Year = 2020, Month = 3, Duration = 60 },
                new Record() { ClientID = 2, Year = 2021, Month = 1, Duration = 50 },
                new Record() { ClientID = 2, Year = 2021, Month = 2, Duration = 40 }
        };

        PrintMaxDurationByMonth(1, clients);
        Console.ReadKey();

    }
}