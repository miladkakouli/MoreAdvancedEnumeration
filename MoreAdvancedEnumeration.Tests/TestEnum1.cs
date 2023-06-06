namespace MoreAdvancedEnumeration.Tests;

class TestEnum1 : Enumeration
{
    public static readonly TestEnum1 FirstEnum = new TestEnum1(1, nameof(FirstEnum));
    public static readonly TestEnum1 SecondEnum = new TestEnum1(2, nameof(SecondEnum));

    private TestEnum1(int id, string name) : base(id, name)
    {
    }
}