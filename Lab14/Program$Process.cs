using ConsoleIOLib;
using Lab10Lib.Entities;
using Lab10Lib.Utils;
using Lab12Lib.BinaryTree;

namespace Lab14
{
    public static partial class Program
    {
        private static void Task1Option1Process()
        {
            var city = InstanceHolder.Get<Stack<Dictionary<Person, Person>>>();
            var rating = ConsoleIO.Input<float>(
                $"Введите рейтинг ({Pupil.MinRating} <= значение <= {Pupil.MaxRating}): ",
                v => v >= Pupil.MinRating && v <= Pupil.MaxRating
                    ? null
                    : "Недопустимое значение!"
            );
            var pupils = city.GetPupilsWhere(e => e.Rating > rating);

            ConsoleIO.WriteLine(Messages.Task1Option1Process);
            foreach (var pupil in pupils)
                ConsoleIO.WriteLine(pupil);
        }

        private static void Task1Option2Process()
        {
            var city = InstanceHolder.Get<Stack<Dictionary<Person, Person>>>();
            var rating = ConsoleIO.Input<float>(
                $"Введите рейтинг ({Pupil.MinRating} <= значение <= {Pupil.MaxRating}): ",
                v => v >= Pupil.MinRating && v <= Pupil.MaxRating
                    ? null
                    : "Недопустимое значение!"
            );

            ConsoleIO.WriteLineFormat(Messages.Task1Option2Process, city.CountStudentsWhere(e => e.Rating > rating));
        }

        private static void Task1Option3Process()
        {
            var city = InstanceHolder.Get<Stack<Dictionary<Person, Person>>>();

            ConsoleIO.WriteLine(Messages.Task1Option3ProcessNewCreated);
            var temp = Utils.CreateCity(3);
            temp.Pop();
            temp.Push(new Dictionary<Person, Person>(city.Last()));
            Utils.PrintCity(temp, Messages.Task1Option3ProcessNewPrint);

            var result = city.MergeCitiesDatabases(temp);
            Utils.PrintCity(result, Messages.Task1Option3ProcessMergedPrint);
        }

        private static void Task1Option4Process()
        {
            var city = InstanceHolder.Get<Stack<Dictionary<Person, Person>>>();
            ConsoleIO.WriteLineFormat(Messages.Task1Option4Process, city.GetStudentsAvgRating());
        }

        private static void Task1Option5Process()
        {
            var city = InstanceHolder.Get<Stack<Dictionary<Person, Person>>>();
            var result = city.GroupPersonsByType();
            Utils.PrintCity(result, Messages.Task1Option5Process);
        }

        private static void Task2Option1Process()
        {
            var tree = InstanceHolder.Get<BinaryTree<Person>>();
            var age = ConsoleIO.Input<int>(
                $"Введите возраст ({Person.MinAge} <= значение <= {Person.MaxAge}): ",
                v => v >= Person.MinAge && v <= Person.MaxAge
                    ? null
                    : "Недопустимое значение!"
            );

            var persons = tree.GetPersonsWithAgeGreaterThan(age);

            ConsoleIO.WriteLine(Messages.Task2Option1Process);
            foreach (var person in persons)
                ConsoleIO.WriteLine(person);
        }

        private static void Task2Option2Process()
        {
            var tree = InstanceHolder.Get<BinaryTree<Person>>();
            ConsoleIO.WriteLineFormat(Messages.Task2Option2Process, tree.GetPersonsAvgBy(e => e.Age));
        }

        private static void Task2Option3Process() => InstanceHolder.Set(new BinaryTree<Person>(
            InstanceHolder.Get<BinaryTree<Person>>(),
            InputBoolean(Messages.Task2Option3Process)
                ? new PersonComparerIn()
                : new PersonComparerOut()
        ));
    }
}