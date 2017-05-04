using System;
using System.Collections.Generic;
using System.Text;

namespace Contractors.Domain.Model
{
    public abstract class Entity : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
