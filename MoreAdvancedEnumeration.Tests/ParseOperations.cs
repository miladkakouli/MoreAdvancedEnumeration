namespace MoreAdvancedEnumeration.Tests;

public class ParseOperations
{
    [Fact]
    public void TestParseFromId()
    {
        Assert.Equal(TestEnum1.FirstEnum, Enumeration.ParseFromId<TestEnum1>(1));
        Assert.Throws<InvalidOperationException>(() => Enumeration.ParseFromId<TestEnum1>(-1));
    }
    
    [Fact]
    public void TestParseFromName()
    {
        Assert.Equal(TestEnum1.FirstEnum, Enumeration.ParseFromName<TestEnum1>("FirstEnum"));
        Assert.Throws<InvalidOperationException>(() => Enumeration.ParseFromName<TestEnum1>("Random Name"));
    }
    
    [Fact]
    public void TestParse()
    {
        Assert.Equal(TestEnum1.FirstEnum, Enumeration.Parse<TestEnum1>("1"));
        Assert.Equal(TestEnum1.FirstEnum, Enumeration.Parse<TestEnum1>("FirstEnum"));
        Assert.Throws<InvalidOperationException>(() => Enumeration.Parse<TestEnum1>("Random Name"));
    }
}