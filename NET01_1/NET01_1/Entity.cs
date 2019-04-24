using System;

namespace NET01_1
{
    public abstract class Entity
    {
        private const int Length = 256;
        private string _description;

        public Guid Id { get; set; }

        public string Description
        {
            get => _description;
            set
            {
                if (value != null && value.Length > Length)
                {
                    throw new ArgumentException("Text length over 256 characters");
                }

                _description = value;
            }
        }

        public Entity()
        {
            this.NewId();
        }

        protected Entity(string description = null) : this()
        {
            Description = description;
        }

        public override string ToString()
        {
            return _description;
        }

        public override bool Equals(object obj)
        {
            var temp = obj as Entity;
            return temp != null && temp.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}