using System;

namespace NSE.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        public override bool Equals(object obj)
        {
            if (obj is not Entity compareTo) return false;
            if (ReferenceEquals(this, compareTo)) return true;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode() => HashCode.Combine(Id);

        public override string ToString() => $"{GetType().Name} [Id={Id}]";
    }
}