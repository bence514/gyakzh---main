using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyakZH
{
    public class Envelope : IDeliverable
    {
        public int Weight { get; }
        public string Address { get; }
        string description;
        public Envelope(int w, string a, string d)
        { 
            this.Weight = w;
            this.Address = a;
            this.description = d;
        }
        public double CalculatePrice(bool fromLocker)
        {
            if (Weight < 51)
                return 200;
            else if (Weight < 501)
                return 400;
            else if (Weight < 2001)
                return 1000;
            else
                throw new OverWeightException();
        }
        public override string ToString()
        {
            return $"Címzett: {Address} / Leírás: {description} / Tömeg:{Weight} g";
        }
    }
}
