using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contractors.Services
{
    public class ContractorNotValidException : Exception
    {
        public ContractorNotValidException(string msg) : base(msg)
        {

        }
    }
}
