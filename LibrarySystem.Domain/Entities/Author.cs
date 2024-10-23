using LibrarySystem.Domain.Primitives;

namespace LibrarySystem.Domain.Entities
{
    public class Author(Guid id, string name, string biography) : Entity(id)
    {
        public string Name { get; private set; } = name;
        public string Biography { get; private set; } = biography;

    }
}
