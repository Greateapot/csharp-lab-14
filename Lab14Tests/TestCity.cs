namespace Lab14Tests;

public class TestCity
{
    [Fact]
    public void GetPupilsWhere()
    {
        // arrange
        var city = TestData.CreateTestCity();
        var rating = 2f;
        IEnumerable<Pupil> excepted = [TestData.a2p2];

        // act
        IEnumerable<Pupil> result = city.GetPupilsWhere(e => e.Rating > rating);

        // assert
        Assert.Equal(excepted, result);
    }

    [Fact]
    public void CountStudentsWhere()
    {
        // arrange
        var city = TestData.CreateTestCity();
        var rating = 2f;
        var excepted = 2;

        // act
        var result = city.CountStudentsWhere(e => e.Rating > rating);

        // assert
        Assert.Equal(excepted, result);
    }

    [Fact]
    public void MergeCitiesDatabases()
    {
        // arrange
        var city = TestData.CreateTestCity();
        var temp = TestData.CreateTempCity();
        IEnumerable<Person> excepted = [TestData.a1p1, TestData.a1p2, TestData.a1p3, TestData.a1p4, TestData.a2p1, TestData.a2p2, TestData.a2p3, TestData.a2p4, TestData.a3p1];

        // act
        IEnumerable<Person> result = city.MergeCitiesDatabases(temp);

        // assert
        result.Should().BeEquivalentTo(excepted);
    }

    [Fact]
    public void GetStudentsAvgRating()
    {
        // arrange
        var city = TestData.CreateTestCity();
        var excepted = (4.5f + .2f) / 2;

        // act
        var result = city.GetStudentsAvgRating();

        // assert
        Assert.Equal(excepted, result);
    }

    [Fact]
    public void GroupPersonsByType()
    {
        // arrange
        var city = TestData.CreateTestCity();
        var excepted = TestData.CreateGroupsCity();

        // act
        var result = city.GroupPersonsByType();

        // assert
        result.Should().BeEquivalentTo(excepted);
    }
}