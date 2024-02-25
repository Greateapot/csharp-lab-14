using ConsoleIOLib;
using Lab10Lib.Entities;

namespace Lab14
{
    public class Program
    {
        public static void Main()
        {
            Stack<Dictionary<Person, Person>> city = new(
                Enumerable
                    .Range(0, 10)
                    .Select(_ => new Dictionary<Person, Person>(
                        Enumerable
                            .Range(0, 10)
                            .Select(_ =>
                            {
                                var person = Person.RandomInit();
                                return new KeyValuePair<Person, Person>(person, person);
                            }
                        )
                    )
                )
            );

            PrintCity(city);

            var a = Queries.GroupPersonsBy(city, e => e.Age);

            PrintCity(a);
        }

        private static void PrintCity(Stack<Dictionary<Person, Person>> city)
        {
            foreach (var university in city)
            {
                foreach (var (key, value) in university)
                    ConsoleIO.WriteLine($"(K: V) {key}: {value}");
                ConsoleIO.Write('\n');
            }
        }
    }

    public static class Queries
    {
        public static IEnumerable<Person> Where(
            this Stack<Dictionary<Person, Person>> city,
            Func<Person, bool> predicate
        ) => from university in city
             from pair in university
             where predicate(pair.Value)
             select pair.Value;

        public static int CountWhere(
            this Stack<Dictionary<Person, Person>> city,
            Func<Person, bool> predicate
        ) => (from university in city
              from pair in university
              where predicate(pair.Value)
              select pair.Key).Count();

        public static Stack<Dictionary<Person, Person>> MergeCitiesDatabases(
            this Stack<Dictionary<Person, Person>> city,
            Stack<Dictionary<Person, Person>> other
        ) => new(city.UnionBy(other, e => e.Keys));

        public static float GetPupilsAvgRating(this Stack<Dictionary<Person, Person>> city)
            => (from school in city
                from pair in school
                where pair.Value is Pupil
                select (pair.Value as Pupil)!.Rating).Average();

        public static Stack<Dictionary<Person, Person>> GroupPersonsBy(
            this Stack<Dictionary<Person, Person>> city,
            Func<Person, object> predicate
        ) => new(
                from university in city
                from pair in university
                group pair by predicate(pair.Key) into g
                select new Dictionary<Person, Person>(g)
            );
    }
}
