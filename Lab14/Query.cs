using System.Dynamic;
using Lab10Lib.Entities;
using Lab10Lib.Utils;
using Lab12Lib.BinaryTree;

namespace Lab14
{
    public static class Query
    {
        public static IEnumerable<Pupil> GetPupilsWhere(
            this Stack<Dictionary<Person, Person>> city,
            Predicate<Pupil> predicate
        ) => from school in city
             from pair in school
             where pair.Value is Pupil pupil && predicate(pupil)
             select pair.Value as Pupil;

        public static int CountStudentsWhere(
            this Stack<Dictionary<Person, Person>> city,
            Predicate<Student> predicate
        ) => (from university in city
              from pair in university
              where pair.Value is Student student && predicate(student)
              select pair).Count();

        public static Stack<Dictionary<Person, Person>> MergeCitiesDatabases(
            this Stack<Dictionary<Person, Person>> city,
            Stack<Dictionary<Person, Person>> other
        ) => new(city.UnionBy(other, e => e.Keys));

        public static float GetStudentsAvgRating(
            this Stack<Dictionary<Person, Person>> city
        ) => (from university in city
              from pair in university
              where pair.Value is Student
              select (pair.Value as Student)!.Rating).Average();

        public static Stack<Dictionary<Person, Person>> GroupPersonsByType(
            this Stack<Dictionary<Person, Person>> city
        ) => new(
            from university in city
            from pair in university
            group pair by pair.Value.GetType() into g
            select new Dictionary<Person, Person>(g)
        );

        public static IEnumerable<Person> GetPersonsWithAgeGreaterThan(
            this BinaryTree<Person> tree,
            int age
        ) => tree.Where(e => e.Age > age);

        public static double GetPersonsAvgBy(
            this BinaryTree<Person> tree,
            Func<Person, int> avgValueSelector
        ) => (from person in tree select avgValueSelector(person)).Average();

        public static BinaryTree<Person> Sort(
            this BinaryTree<Person> tree,
            IComparer<Person>? comparer = null
        ) => new(tree, comparer);
    }
}