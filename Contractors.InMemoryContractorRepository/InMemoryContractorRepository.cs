using Contractors.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contractors.DataAccess
{
    public class InMemoryContractorRepository : IContractorRepository
    {
        private List<Contractor> _contractors = new List<Contractor>();

        public InMemoryContractorRepository()
        {
            Initialize();
        }

        private void Initialize()
        {
            _contractors.Add(
                new Contractor
                {
                    Id = Guid.NewGuid(),
                    Name = "GIG",
                    Description = "GIG description",
                    ContactPerson = "John Doe",
                    PhoneNumber = "1234567",
                    Address = new Address
                    {
                        Id = Guid.NewGuid(),
                        Street = "Wallstreet",
                        City = "New York",
                        ZIPCode = "123456",
                        Country = "USA"
                    }
                }
            );
        }

        public void Add(Contractor contractor)
        {
            _contractors.Add(contractor);
        }

        public void Delete(Contractor contractor)
        {
            _contractors.Remove(contractor);
        }

        public IEnumerable<Contractor> GetAll()
        {
            return _contractors;
        }

        public Contractor GetById(Guid id)
        {
            return _contractors.Find(c => c.Id == id);
        }

        public void Update(Contractor contractor)
        {
            int index = _contractors.FindIndex(c => c.Id == contractor.Id);
            _contractors[index] = contractor;
        }
    }
}
