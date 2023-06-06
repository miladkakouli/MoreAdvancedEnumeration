namespace MoreAdvancedEnumeration.Tests;

public class ImplicitOperations
{
    [Fact]
    public void TestImplicitIntOp()
    {
        int intValue = TestEnum1.FirstEnum;
        Assert.Equal(1, intValue);
    }
    
    [Fact]
    public void TestImplicitStringOp()
    {
        string stringValue = TestEnum1.SecondEnum;
        Assert.Equal("SecondEnum", stringValue);
    }
}