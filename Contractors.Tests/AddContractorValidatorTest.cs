using Contractors.Domain;
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
    public class AddContractorValidatorTest
    {
        AbstractValidator<Contractor> _validator;

        public AddContractorValidatorTest()
        {
            _validator = new AddContractorValidator();
        }

        [Fact]
        void Validate_ShouldReturnTrue_IfContractorIdNotEmpty()
        {
            var contractor = new Contractor { Id = Guid.NewGuid() };

            var result = _validator.Validate(contractor);

            Assert.True(result);
        }

        [Fact]
        void Validate_ShouldReturnFalse_IfContractorIdIsEmpty()
        {
            var contractor = new Contractor();

            var result = _validator.Validate(contractor);

            Assert.False(result);
        }
    }
}
