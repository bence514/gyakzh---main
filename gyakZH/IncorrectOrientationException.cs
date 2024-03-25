using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyakZH
{
    public class IncorrectOrientationException : DeliveryException
    {
        public IncorrectOrientationException(string message, IDeliverable Obj) : base(message) { }
    }
}
