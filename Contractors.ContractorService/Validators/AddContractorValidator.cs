using System;
using System.Collections.Generic;
using System.Text;
using Contractors.Domain;
using Contractors.Shared.Validators;

namespace Contractors.Services.Validators
{
    public class AddContractorValidator : AbstractValidator<Contractor>
    {
        public override bool Validate(Contractor contractor)
        {
            if (contractor.Id == Guid.Empty)
            {
                return false;
            }

            return true;
        }
    }
}
