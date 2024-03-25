using NUnit.Framework;
using gyakZH;
using System.Collections.Generic;

namespace test
{
    [TestFixture]
    public class Class1
    {
        [TestCase(48, true, 200)]
        [TestCase(250, true, 400)]
        [TestCase(1000, false, 1000)]
        public void EnvelopeNormal(int weight, bool automata, int result)
        {
            Envelope testObj = new Envelope(weight, "Bécs", "Lemez");

            Assert.That(testObj.CalculatePrice(automata), Is.EqualTo(result));
        }

        [Test]
        public void EnvelopeOverWeigt()
        {
            Envelope testObj = new Envelope(2001, "asd", "asd");

            Assert.Throws<OverWeightException>(() => testObj.CalculatePrice(false));
        }

        [Test]
        public void FragileParcelAutomata()
        {
            FragileParcel testObj = new FragileParcel(250, "asd", orientation.Horizontal);

            Assert.Throws<DeliveryException>(() => testObj.CalculatePrice(true));
        }

        [Test]
        public void FragileParcelOrientation()
        {
            FragileParcel testObj;

            Assert.Throws<IncorrectOrientationException>(() => testObj = new FragileParcel(250, "asd", orientation.Arbitrary));
        }

        [Test]
        public void CourierNormal()
        {
            Courier testObj = new Courier(5);

            Envelope testEnvelope = new Envelope(250, "Bécs", "Lemez");

            FragileParcel testParcel = new FragileParcel(2000, "asd", orientation.Horizontal);

            Assert.That(testObj.WeightSum, Is.EqualTo(0));

            testObj.PickupItem(testEnvelope);

            Assert.That(testObj.WeightSum, Is.EqualTo(250));

            testObj.PickupItem(testParcel);

            Assert.That(testObj.WeightSum, Is.EqualTo(2250));
        }

        [Test]
        public void CourierSort() 
        {
            Courier testObj = new Courier(5);

            Envelope testEnvelope = new Envelope(250, "Bécs", "Lemez");

            FragileParcel testParcel = new FragileParcel(2000, "asd", orientation.Horizontal);
            FragileParcel testParcel2 = new FragileParcel(4000, "asd", orientation.Horizontal);
            FragileParcel testParcel4 = new FragileParcel(4000, "asd", orientation.Horizontal);
            FragileParcel testParcel3 = new FragileParcel(3000, "asd", orientation.Horizontal);

            testObj.PickupItem(testEnvelope);

            testObj.PickupItem(testParcel);
            testObj.PickupItem(testParcel2);
            testObj.PickupItem(testParcel3);
            testObj.PickupItem(testParcel4);

            IDeliverable[] output = testObj.FragilesSorted();

            if (output[0].Weight == 2000 && output[1].Weight == 3000 && output[2].Weight == 4000 && output[3].Weight == 4000) 
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
    }
}