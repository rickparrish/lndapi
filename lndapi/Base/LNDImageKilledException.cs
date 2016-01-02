using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lndapi
{
    /// <summary>
    /// Custom exception thrown when API result does not contain success=yes
    /// </summary>
    public class LNDImageKilledException : LNDException
    {
        public LNDImageKilledException(string message) : base(message)
        {
        }
    }
}
