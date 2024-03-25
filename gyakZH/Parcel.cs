using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyakZH
{
    public enum orientation
    { 
        Arbitrary = 0, Horizontal = 1, Vertical = 2
    }
    public abstract class Parcel : IDeliverable, IComparable
    {
        public int Weight { get; }
        public string Address { get; }
        public orientation PreferedOrientation { get; set; }

        public Parcel(int w, string a, orientation o)
        { 
            this.Weight = w;
            this.Address = a;
            this.PreferedOrientation = o;
        }

        public Parcel(int w, string a) 
        {
            this.Weight= w;
            this.Address = a;
        }
        public abstract double CalculatePrice(bool fromLocker);

        public int CompareTo(object? obj)
        {
            if (obj is IDeliverable)
            {
                IDeliverable tmp = obj as IDeliverable;
                return this.Weight - tmp.Weight;
            }
            throw new ArgumentException();
        }
        public override string ToString()
        {
            return $"Címzett: {Address} / Elhelyezési mód: {PreferedOrientation.ToString()} / Tömeg:{Weight} g";
        }
    }
}
