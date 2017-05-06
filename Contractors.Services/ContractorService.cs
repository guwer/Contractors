using Contractors.Domain;
using Contractors.Shared;
using Contractors.Shared.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contractors.Services
{
    public class ContractorService : IContractorService
    {
        IContractorRepository _repository;
        AbstractValidator<Contractor> _addContractorValidator;

        public ContractorService(IContractorRepository repository, AbstractValidator<Contractor> addValidator)
        {
            Guard.ThrowIfArgumentIsNull(repository, nameof(repository));
            Guard.ThrowIfArgumentIsNull(addValidator, nameof(addValidator));

            _repository = repository;
            _addContractorValidator = addValidator;
        }

        public IEnumerable<Contractor> GetContractors()
        {
            return _repository.GetAll();
        }

        public Contractor GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void AddContractor(Contractor contractor)
        {
            var isValid = _addContractorValidator.Validate(contractor);

            if (!isValid)
            {
                throw new ContractorNotValidException(_addContractorValidator.ValidationError);
            }

            _repository.Add(contractor);
        }

        public void UpdateContractor(Contractor contractor)
        {
            _repository.Update(contractor);
        }

        public void DeleteContractor(Contractor contractor)
        {
            _repository.Delete(contractor);
        }
    }
}
