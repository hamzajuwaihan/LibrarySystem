using System;

namespace LibrarySystem.Domain.Primitives
{
    public abstract class Entity : IEquatable<Entity>
    {
        protected Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private init; } // init will set the Id once and then it won't be available to be used

        public static bool operator ==(Entity? first, Entity? second)
        {
            return first is not null && second is not null && first.Equals(second);
            // Note here that we are using `Equals()` that we already implemented.
        }

        public static bool operator !=(Entity? first, Entity? second)
        {
            // Here we are using the `== operator` that we already implemented
            return !(first == second);
        }

        // This method is coming from the `IEquatable<Entity>`
        public bool Equals(Entity? other)
        {
            if (other is null) { return false; }
            if (other.GetType() != this.GetType()) { return false; }
            return other.Id == this.Id;
        }

        // This will check the equality between 2 objects
        public override bool Equals(object? obj)
        {
            if (obj is null) { return false; }
            if (obj.GetType() != this.GetType()) { return false; }
            if (obj is not Entity entity) { return false; }
            return entity.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() * 41; // You can replace 41 with any prime number
        }
    }
}
