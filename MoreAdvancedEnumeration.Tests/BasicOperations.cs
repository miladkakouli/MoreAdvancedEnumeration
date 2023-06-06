namespace MoreAdvancedEnumeration.Tests;

public class BasicOperations
{
    [Fact]
    public void TestToString()
    {
        Assert.Equal("FirstEnum",TestEnum1.FirstEnum.ToString());
    }
    
    [Fact]
    public void TestGetHashCode()
    {
        Assert.Equal(2.GetHashCode(),TestEnum1.SecondEnum.GetHashCode());
    }
    
    [Fact]
    public void TestEquals()
    {
        object oTestEnum1First = TestEnum1.FirstEnum;
        object oTestEnum1Second = TestEnum1.SecondEnum;
        object oTestEnum2Second = TestEnum2.SecondEnum;
        object? oNull = null;
        
        Assert.True(TestEnum1.SecondEnum.Equals(oTestEnum1Second));
        Assert.False(TestEnum1.SecondEnum.Equals(oTestEnum1First));
        Assert.False(TestEnum1.SecondEnum.Equals(oTestEnum2Second));
        Assert.False(TestEnum1.SecondEnum.Equals(oNull));
    }
    
    [Fact]
    public void TestCompareTo()
    {
        object oTestEnum1First = TestEnum1.FirstEnum;
        object oTestEnum1Second = TestEnum1.SecondEnum;
        object oTestEnum2Second = TestEnum2.SecondEnum;
        object? oNull = null;
        
        Assert.Equal(0, TestEnum1.SecondEnum.CompareTo(oTestEnum1Second));
        Assert.Equal(1,TestEnum1.SecondEnum.CompareTo(oTestEnum1First));
        Assert.Throws<ArgumentException>(() =>TestEnum1.SecondEnum.CompareTo(new object()));
        Assert.Throws<ArgumentException>(() => TestEnum1.SecondEnum.CompareTo(oTestEnum2Second));
        Assert.Equal(1, TestEnum1.SecondEnum.CompareTo(oNull));
        Assert.Equal(-1,TestEnum1.FirstEnum.CompareTo(oTestEnum1Second));
    }
}