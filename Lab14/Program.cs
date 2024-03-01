using Lab10Lib.Entities;
using Lab10Lib.Utils;
using Lab12Lib.BinaryTree;

namespace Lab14
{
    public static partial class Program
    {
        public static void Main()
        {
            var tree = new BinaryTree<Person>(new PersonComparerIn());
            tree.AddAll(PersonGenerator.GetRandomPerson(10));

            InstanceHolder.Set(Utils.CreateCity(5));
            InstanceHolder.Set(tree);

            MainDialog().Show();
        }

    }
}
