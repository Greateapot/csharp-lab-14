using ConsoleIOLib;
using Lab10Lib.Entities;
using Lab10Lib.Utils;

namespace Lab14
{
    public class Utils
    {
        private static readonly Random random = new(DateTimeOffset.Now.Millisecond);

        public static Stack<Dictionary<Person, Person>> CreateCity(int k) => new(
            Enumerable
                .Range(0, random.Next() % k + 1)
                .Select(_ => new Dictionary<Person, Person>(
                        PersonGenerator
                            .GetRandomPerson(random.Next() % k + 1)
                            .Select(person => new KeyValuePair<Person, Person>(person.ToPerson(), person)
                    )
                )
            )
        );

        public static void PrintCity(Stack<Dictionary<Person, Person>> city, string cityName = "city")
        {
            ConsoleIO.WriteLine($"--- {cityName} begin ---");
            var universityCounter = 1;
            foreach (var university in city)
            {
                ConsoleIO.WriteLine($"TextCount №{universityCounter}");
                foreach (var (key, value) in university)
                    ConsoleIO.WriteLine($"Key: {key}\n\tValue: {value}");
                if (universityCounter != city.Count) ConsoleIO.Write('\n');
                universityCounter++;
            }
            ConsoleIO.WriteLine($"--- {cityName} end ---");
        }
    }
}