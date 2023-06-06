namespace MoreAdvancedEnumeration.Tests;

class TestEnum2 : Enumeration
{
    public static readonly TestEnum2 FirstEnum = new TestEnum2(1, nameof(FirstEnum));
    public static readonly TestEnum2 SecondEnum = new TestEnum2(2, nameof(SecondEnum));

    private TestEnum2(int id, string name) : base(id, name)
    {
    }
}