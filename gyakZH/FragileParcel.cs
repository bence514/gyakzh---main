using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyakZH
{
    public class FragileParcel : Parcel
    {
        public FragileParcel(int w, string a, orientation o) : base(w, a)
        {
            if (o == orientation.Arbitrary)
                throw new IncorrectOrientationException("A csomag elhelyezési módját kötelező megadni!", this);
            this.PreferedOrientation = o;
        }
        public override double CalculatePrice(bool fromLocker)
        {
            if (fromLocker)
                throw new DeliveryException("Nem lehet autómatával feladni törékeny csomagot!");
            return 1000 + this.Weight * 2;
        }
    }
}
