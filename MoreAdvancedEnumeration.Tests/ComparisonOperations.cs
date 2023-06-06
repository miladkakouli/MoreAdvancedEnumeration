namespace MoreAdvancedEnumeration.Tests;

public class ComparisonOperations
{
    [Fact]
    public void TestEquality()
    {
        TestEnum1? t = null;
        TestEnum1 oTestEnum1First = TestEnum1.FirstEnum;
        Assert.True(TestEnum1.FirstEnum == oTestEnum1First);
        Assert.True(oTestEnum1First == TestEnum1.FirstEnum);
        Assert.True(TestEnum1.FirstEnum == 1);
        Assert.True(1 == TestEnum1.FirstEnum);
        Assert.True(TestEnum1.FirstEnum == "FirstEnum");
        Assert.True("FirstEnum" == TestEnum1.FirstEnum);
        Assert.False(TestEnum1.FirstEnum == TestEnum1.SecondEnum);
        Assert.False(TestEnum1.FirstEnum == null);
        Assert.False(TestEnum1.FirstEnum == t);
        Assert.False(TestEnum1.FirstEnum == TestEnum2.FirstEnum);
    }
    
    [Fact]
    public void TestNotEquality()
    {
        TestEnum1? t = null;
        TestEnum1 oTestEnum1First = TestEnum1.FirstEnum;
        Assert.False(TestEnum1.FirstEnum != oTestEnum1First);
        Assert.False(oTestEnum1First != TestEnum1.FirstEnum);
        Assert.False(TestEnum1.FirstEnum != 1);
        Assert.False(1 != TestEnum1.FirstEnum);
        Assert.False(TestEnum1.FirstEnum != "FirstEnum");
        Assert.False("FirstEnum" != TestEnum1.FirstEnum);
        Assert.True(TestEnum1.FirstEnum != TestEnum1.SecondEnum);
        Assert.True(TestEnum1.FirstEnum != null);
        Assert.True(TestEnum1.FirstEnum != t);
        Assert.True(TestEnum1.FirstEnum != TestEnum2.FirstEnum);

    }
}