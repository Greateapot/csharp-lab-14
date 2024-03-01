using Lab10Lib.Utils;

namespace Lab14Tests;

public class TestTree
{

    [Fact]
    public void GetPersonsWithAgeGreaterThan()
    {
        // arrange
        var tree = TestData.CreateTestTree();
        IEnumerable<Person> excepted = [TestData.a2p1, TestData.a2p2, TestData.a2p3, TestData.a2p4];

        // act
        IEnumerable<Person> result = tree.GetPersonsWithAgeGreaterThan(12);

        // assert
        Assert.Equal(excepted, result);
    }

    [Fact]
    public void GetPersonsAvgBy()
    {
        // arrange
        var tree = TestData.CreateTestTree();
        var excepted = 36d / 2;

        // act
        var result = tree.GetPersonsAvgBy(e => e.Age);

        // assert
        Assert.Equal(excepted, result);
    }

    [Fact]
    public void Sort()
    {
        // arrange
        var tree = TestData.CreateTestTree();
        var excepted = TestData.CreateReverseTree();

        // act
        var result = tree.Sort(new PersonComparerOut());

        // assert
        result.Should().BeEquivalentTo(excepted);
    }
}
