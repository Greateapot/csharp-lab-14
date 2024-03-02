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

        public static string PrintCity(Stack<Dictionary<Person, Person>> city, string cityName = "city")
        {
            var result = "";
            result += $"--- {cityName} begin ---\n";
            var universityCounter = 1;
            foreach (var university in city)
            {
                result += $"TextCount №{universityCounter}\n";
                foreach (var (key, value) in university)
                    result += $"Key: {key}\n\tValue: {value}\n";
                if (universityCounter != city.Count) result += "\n";
                universityCounter++;
            }
            result += $"--- {cityName} end ---\n";
            return result;
        }
    }
}