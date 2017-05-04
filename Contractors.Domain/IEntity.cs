using System;
using System.Collections.Generic;
using System.Text;

namespace Contractors.Domain
{
    interface IEntity<T>
    {
        T Id { get; set; }
    }
}
