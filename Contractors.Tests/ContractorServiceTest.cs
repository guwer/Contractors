using Contractors.DataAccess;
using Contractors.Domain;
using Contractors.Services;
using Contractors.Services.Validators;
using Contractors.Shared.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Contractors.Tests
{
    public class ContractorServiceTest
    {
        IContractorService _service;
        IContractorRepository _repository;
        AbstractValidator<Contractor> _validator;

        public ContractorServiceTest()
        {
            _validator = new AddContractorValidator();
            _repository = new InMemoryContractorRepository();
        }

        [Fact]
        public void Test()
        {
            _service = new ContractorService(_repository, _validator);

            var ex = Assert.Throws<ContractorNotValidException>(() => _service.AddContractor(new Contractor { Id = Guid.Empty }));
            Assert.Equal("Contractor id is not set.", ex.Message);
        }
    }
}
