using NSE.Core.DomainObjects;
using NSE.Core.DomainObjects.ValueObjects;
using System;

namespace NSE.Customers.API.Models
{
    public class Customer : Entity
    {
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }
        public bool Deleted { get; private set; }
        public Address Address { get; private set; }

        // Constructor for EF
        protected Customer()
        {
        }

        public Customer(Guid id, string name, string email, string cpf)
        {
            Id = id;
            Name = name;
            Email = new Email(email);
            Cpf = new Cpf(cpf);
            Deleted = false;
        }

        public void ChangeEmail(string email) => Email = new Email(email);

        public void SetAddress(Address address) => Address = address;
    }
}