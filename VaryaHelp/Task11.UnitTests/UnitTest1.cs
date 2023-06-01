using NUnit.Framework;
using System;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using Task11;

namespace Task11.UnitTests
{
    public class HotelUnitTests
    {
        
        [TestFixture]
        public class HotelTests
        {
            [Test]
            public void ConstructorTest()
            {
                var abcd = CreateTestRoom();                

                Assert.AreEqual("111", abcd.HotelRoom);
                Assert.AreEqual("2", abcd.NumberOfBeds);
                Assert.AreEqual(WindowSide.North, abcd.Side);
                Assert.AreEqual("30$", abcd.DayPrise);
                Assert.AreEqual(DateTime.Now.Day + 1, abcd.TimeOfRelease);
            }
            [Test]
            public void ToString_Hotel_Room()
            {
                var abcd = CreateTestRoom();
                Assert.AreEqual("111, 2, 30$", abcd.ToString());
            }
            private Hotel CreateTestRoom()
            {
                return new Hotel(WindowSide.North, "2", "111", "30$");

            }
        }
    }
}