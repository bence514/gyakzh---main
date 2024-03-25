using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyakZH
{
    public class NormalParcel : Parcel
    {
        public NormalParcel(int w, string a) : base(w, a) 
        { 
            Random r = new Random();
            this.PreferedOrientation = (orientation)r.Next(0,3);
        }
        public override double CalculatePrice(bool fromLocker)
        {
            return 500 + this.Weight - (fromLocker ? 250 : 0);
        }
    }
}
