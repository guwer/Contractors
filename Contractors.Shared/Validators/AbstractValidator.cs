using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contractors.Shared.Validators
{
    public abstract class AbstractValidator<TEntity> : IValidator<TEntity>
    {
        public string ValidationError { get ; set; }

        public abstract bool Validate(TEntity entity);
    }
}
