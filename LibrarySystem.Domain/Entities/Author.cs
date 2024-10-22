using System;
using LibrarySystem.Domain.Primitives;

namespace LibrarySystem.Domain.Entities
{
    public class Author : Entity
    {
        public string Name { get; private set; }
        public string Biography { get; private set; }

        public Author(Guid id, string name, string biography)
            : base(id) // Call the base constructor to set the Id
        {
            Name = name;
            Biography = biography;
        }

        // Add methods for business logic if needed
    }
}
