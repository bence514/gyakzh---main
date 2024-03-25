using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyakZH
{
    public class Courier
    {
        public IDeliverable[] Packages { get; }
		public int count { get; private set; } = 0;

        public int WeightSum
		{
			get {
				int sum = 0;
				foreach (IDeliverable item in Packages)
				{
					if (item != null)
					sum += item.Weight;
				}
				return sum;
			}
		}

		public Courier(int n)
		{ 
			Packages = new IDeliverable[n];
		}

		public void PickupItem(IDeliverable item)
		{
			if (count >= Packages.Length)
				throw new DeliveryException("Nincs több hely!");
			Packages[count] = item;
			count++;
		}

		public IDeliverable[] FragilesSorted()
		{
			int countFragiles = 0;
			foreach(IDeliverable item in Packages)
				if (item is FragileParcel)
					countFragiles++;
			IDeliverable[] fragiles = new IDeliverable[countFragiles];
			for (int i = 0; i < Packages.Length; i++)
			{
				if (Packages[i] is FragileParcel)
				{
                    fragiles[--countFragiles] = Packages[i];
				}
			}
			Array.Sort(fragiles);
			return fragiles;
        }
	}
}
