using System;

namespace NSE.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity compareTo)) return false;
            if (ReferenceEquals(this, compareTo)) return true;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode() => HashCode.Combine(Id);

        public override string ToString() => $"{GetType().Name} [Id={Id}]";
    }
}