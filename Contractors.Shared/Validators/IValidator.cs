using System;
using System.Collections.Generic;
using System.Text;

namespace Contractors.Shared.Validators
{
    public interface IValidator<TEntity>
    {
        string ValidationError { get; set; }
        bool Validate(TEntity entity);
    }
}
