namespace LibrarySystem.Domain.ValueObjects;

public class ISBN(string value)
{
    public string Value { get; private set; } = value;

    public override bool Equals(object? obj)
    {
        if (obj is ISBN isbn)  return Value == isbn.Value;
        
        return false;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}
