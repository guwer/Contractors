using Contractors.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contractors.Domain
{
    public class Address : Entity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string ZIPCode { get; set; }
        public string Country { get; set; }
    }
}
