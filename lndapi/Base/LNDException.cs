using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lndapi
{
    public class LNDException : Exception
    {
        public LNDException(string message) : base(message)
        {
        }
    }
}
