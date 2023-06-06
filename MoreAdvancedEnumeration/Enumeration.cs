using System.Reflection;

namespace MoreAdvancedEnumeration;

public abstract class Enumeration : IComparable
{
    private readonly string _name;
    private readonly int _id;

    protected Enumeration(int id, string name)
    {
        _id = id;
        _name = name;
    }

    public sealed override string ToString() => _name;
    public override int GetHashCode() => _id.GetHashCode();

    private static IEnumerable<T> GetAll<T>() where T : Enumeration =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null))
            .Cast<T>();

    public override bool Equals(object? obj)
    {
        if (!(obj is Enumeration otherValue))
        {
            return false;
        }

        var typeMatches = GetType() == obj.GetType();
        var valueMatches = _id.Equals(otherValue._id);

        return typeMatches && valueMatches;
    }

    public int CompareTo(object? obj)
    {
        if (obj == null) return 1;
        Enumeration? o = obj as Enumeration;
        if (o == null || o.GetType() != GetType())
            throw new ArgumentException("Object is not a " + this.GetType());
        return _id.CompareTo(o._id);
    }

    protected T FromId<T>(int id) where T : Enumeration
    {
        var matchingItem = Parse<T>(item => item._id == id);
        return matchingItem;
    }

    protected T FromName<T>(string name) where T : Enumeration
    {
        var matchingItem = Parse<T>(item => item._name == name);
        return matchingItem;
    }

    public static T ParseFromId<T>(int id) where T : Enumeration
    {
        var matchingItem = Parse<T>(item => item._id == id);
        return matchingItem;
    }

    public static T ParseFromName<T>(string name) where T : Enumeration
    {
        var matchingItem = Parse<T>(item => item._name == name);
        return matchingItem;
    }

    public static T Parse<T>(string nameOrId) where T : Enumeration
    {
        return int.TryParse(nameOrId, out int result)
            ? Parse<T>(item => item._id == result)
            : Parse<T>(item => item._name == nameOrId);
    }

    private static T Parse<T>(Func<T, bool> predicate) where T : Enumeration
    {
        return GetAll<T>().First(predicate);
    }

    public static bool operator ==(Enumeration? a, Enumeration? b)
        => a!.Equals(b!);

    public static bool operator ==(Enumeration a, string b)
    {
        var method = a.GetType().GetMethod("FromName",
            BindingFlags.NonPublic | BindingFlags.Instance)?.MakeGenericMethod(new[] { a.GetType() });
        var enumObj = method?.Invoke(a, new Object[] { b });
        return enumObj != null && enumObj.Equals(a);
    }

    public static bool operator ==(string b, Enumeration a)
        => a == b;

    public static bool operator ==(Enumeration a, int b)
    {
        var method = a.GetType().GetMethod("FromId", BindingFlags.NonPublic | BindingFlags.Instance)
            ?.MakeGenericMethod(new[] { a.GetType() });
        var enumObj = method?.Invoke(a, new Object[] { b });
        return enumObj != null && enumObj.Equals(a);
    }

    public static bool operator ==(int b, Enumeration a)
        => a == b;

    public static bool operator ==(Enumeration a, object b)
        => a == b.ToString()!;

    public static bool operator ==(object b, Enumeration a)
        => a == b;

    public static bool operator !=(Enumeration a, Enumeration b)
        => !(a == b);

    public static bool operator !=(object b, Enumeration a)
        => !(b == a);

    public static bool operator !=(Enumeration a, object b)
        => !(a == b);

    public static bool operator !=(Enumeration a, int b)
        => !(a == b);

    public static bool operator !=(int b, Enumeration a)
        => !(a == b);

    public static bool operator !=(string b, Enumeration a)
        => !(b == a);

    public static bool operator !=(Enumeration a, string b)
        => !(a == b);

    public static implicit operator int(Enumeration d) => d._id;
    public static implicit operator string(Enumeration d) => d.ToString();
}