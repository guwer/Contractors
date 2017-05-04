using Contractors.Domain.Model;
using System;

namespace Contractors.Domain
{
    public class Contractor : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        
    }
}
