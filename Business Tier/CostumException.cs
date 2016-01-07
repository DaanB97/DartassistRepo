using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier
{
    class CostumException : Exception
    {
        public CostumException(string message) : base (message)
        {

        }
    }
}
