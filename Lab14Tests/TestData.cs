using Lab10Lib.Utils;

namespace Lab14Tests;

public class TestData
{

    // all age: 12; rating: .2f
    internal static readonly Person a1p1 = new("a1", "p1", 12);
    internal static readonly Pupil a1p2 = new("a1", "p2", 12, .2f, 1);
    internal static readonly Student a1p3 = new("a1", "p3", 12, .2f, 1);
    internal static readonly PartTimeStudent a1p4 = new("a1", "p4", 12, .2f, 1, 0);

    // all age: 24; rating: 4.5f
    internal static readonly Person a2p1 = new("a2", "p1", 24);
    internal static readonly Pupil a2p2 = new("a2", "p2", 24, 4.5f, 1);
    internal static readonly Student a2p3 = new("a2", "p3", 24, 4.5f, 1);
    internal static readonly PartTimeStudent a2p4 = new("a2", "p4", 24, 4.5f, 1, 0);

    // temp
    internal static readonly Person a3p1 = new("a3", "p1", 99);

    internal static BinaryTree<Person> CreateTestTree()
    {
        BinaryTree<Person> tree = new(new PersonComparerIn());
        tree.AddAll(a1p1, a1p2, a1p3, a1p4, a2p1, a2p2, a2p3, a2p4);
        return tree;
    }

    internal static BinaryTree<Person> CreateReverseTree()
    {
        BinaryTree<Person> tree = new(new PersonComparerOut());
        tree.AddAll(a1p1, a1p2, a1p3, a1p4, a2p1, a2p2, a2p3, a2p4);
        return tree;
    }

    internal static Stack<Dictionary<Person, Person>> CreateTestCity()
    {
        Stack<Dictionary<Person, Person>> city = [];

        Dictionary<Person, Person> a1 = [];
        Dictionary<Person, Person> a2 = [];

        a1.Add(a1p1.ToPerson(), a1p1);
        a1.Add(a1p2.ToPerson(), a1p2);
        a1.Add(a1p3.ToPerson(), a1p3);
        a1.Add(a1p4.ToPerson(), a1p4);

        a2.Add(a2p1.ToPerson(), a2p1);
        a2.Add(a2p2.ToPerson(), a2p2);
        a2.Add(a2p3.ToPerson(), a2p3);
        a2.Add(a2p4.ToPerson(), a2p4);

        city.Push(a1);
        city.Push(a2);

        return city;
    }

    internal static Stack<Dictionary<Person, Person>> CreateTempCity()
    {
        Stack<Dictionary<Person, Person>> tmep = [];

        Dictionary<Person, Person> a1 = [];
        Dictionary<Person, Person> a3 = [];

        a1.Add(a1p1.ToPerson(), a1p1);
        a1.Add(a1p2.ToPerson(), a1p2);
        a1.Add(a1p3.ToPerson(), a1p3);
        a1.Add(a1p4.ToPerson(), a1p4);

        a3.Add(a3p1.ToPerson(), a3p1);

        tmep.Push(a1);
        tmep.Push(a3);

        return tmep;
    }

    internal static Stack<Dictionary<Person, Person>> CreateGroupsCity()
    {
        Stack<Dictionary<Person, Person>> city = [];

        Dictionary<Person, Person> a1 = [];
        Dictionary<Person, Person> a2 = [];
        Dictionary<Person, Person> a3 = [];
        Dictionary<Person, Person> a4 = [];

        a1.Add(a1p1.ToPerson(), a1p1);
        a1.Add(a2p1.ToPerson(), a2p1);

        a2.Add(a1p2.ToPerson(), a1p2);
        a2.Add(a2p2.ToPerson(), a2p2);

        a3.Add(a1p3.ToPerson(), a1p3);
        a3.Add(a2p3.ToPerson(), a2p3);

        a4.Add(a1p4.ToPerson(), a1p4);
        a4.Add(a2p4.ToPerson(), a2p4);

        city.Push(a1);
        city.Push(a2);
        city.Push(a3);
        city.Push(a4);

        return city;
    }
}
