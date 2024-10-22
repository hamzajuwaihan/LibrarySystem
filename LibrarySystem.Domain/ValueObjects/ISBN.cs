namespace LibrarySystem.Domain.ValueObjects
{
    public class ISBN
    {
        public string Value { get; private set; }

        public ISBN(string value)
        {
            // You can add validation for ISBN format here
            Value = value;
        }

        // Override Equals and GetHashCode for proper comparison
        public override bool Equals(object obj)
        {
            if (obj is ISBN isbn)
            {
                return Value == isbn.Value;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
