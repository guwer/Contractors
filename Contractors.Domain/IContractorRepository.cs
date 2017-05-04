using System;
using System.Collections.Generic;
using System.Text;

namespace Contractors.Domain
{
    public interface IContractorRepository
    {
        IEnumerable<Contractor> GetAll();
        Contractor GetById(Guid id);
        void Add(Contractor contractor);
        void Update(Contractor contractor);
        void Delete(Contractor contractor);
    }
}
