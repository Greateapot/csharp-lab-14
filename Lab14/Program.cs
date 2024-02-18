using ConsoleIOLib;
using Lab10Lib.Entities;
using Lab10Lib.Utils;

namespace Lab14
{
    public class Program
    {
        public static void Main()
        {
            // List<List<Person>> list = [];
            // for (int i = 0; i < 6; i++)
            // {
            //     List<Person> sub = [];
            //     sub.AddRange(PersonGenerator.GetRandomPerson(10));
            //     list.Add(sub);
            // }
        }
    }

    public static class Queries
    {
        public static IEnumerable<Student> GetStudentsWithRatingGreaterThan(this Stack<Dictionary<Person, Person>> city, float rating)
            => from university in city
               from pair in university
               where pair.Value is Student student && student.Rating > rating
               select pair.Value as Student;

        public static int GetPartTimeStudentsCount(this Stack<Dictionary<Person, Person>> city)
            => (from university in city
                from pair in university
                where pair.Value is PartTimeStudent
                select pair.Key).Count();

        public static IEnumerable<Person> GetAbnormalPersons(
            this Stack<Dictionary<Person, Person>> city,
            Stack<Dictionary<Person, Person>> other
        ) => city.SelectMany(element => element.Values).Intersect(
            other.SelectMany(element => element.Values));

        public static float GetPupilsAvgRating(this Stack<Dictionary<Person, Person>> city)
            => (from school in city
                from pair in school
                where pair.Value is Pupil
                select (pair.Value as Pupil)!.Rating).Average();

        public static IEnumerable<IEnumerable<Person>> GroupPersonsByAge(this Stack<Dictionary<Person, Person>> city)
            => from university in city
               from pair in university
               group pair.Value by pair.Value.Age into g
               select g.AsEnumerable();
    }
}
