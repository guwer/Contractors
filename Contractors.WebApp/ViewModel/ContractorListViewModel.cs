using Contractors.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contractors.WebApp.ViewModel
{
    public class ContractorListViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
    }
}