namespace LibrarySystem.Domain.Primitives;
/// <summary>
/// Entity class Abtraction of Any Domain Entity, Any domain Entity should be inherited by this class
/// </summary>
/// <param name="id"></param>
public abstract class Entity(Guid id) : IEquatable<Entity>
{
    public Guid Id { get; protected init; } = id;

    public static bool operator ==(Entity? first, Entity? second)
    {
        return first is not null && second is not null && first.Equals(second);
    }

    public static bool operator !=(Entity? first, Entity? second)
    {

        return !(first == second);
    }


    public bool Equals(Entity? other)
    {
        if (other is null) { return false; }
        if (other.GetType() != GetType()) { return false; }
        return other.Id == Id;
    }


    public override bool Equals(object? obj)
    {
        if (obj is null) { return false; }
        if (obj.GetType() != GetType()) { return false; }
        if (obj is not Entity entity) { return false; }
        return entity.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode() * 41; // You can replace 41 with any prime number
    }
}
