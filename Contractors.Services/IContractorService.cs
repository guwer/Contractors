using Contractors.Domain;
using System;
using System.Collections.Generic;

namespace Contractors.Services
{
    public interface IContractorService
    {
        IEnumerable<Contractor> GetContractors();
        Contractor GetById(Guid id);
        void AddContractor(Contractor contractor);
        void UpdateContractor(Contractor contractor);
        void DeleteContractor(Contractor id);
    }
}