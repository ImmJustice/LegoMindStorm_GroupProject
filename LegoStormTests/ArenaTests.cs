using Microsoft.VisualStudio.TestTools.UnitTesting;
using LegoStormGrp5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoStormGrp5.Tests
{
    [TestClass()]
    public class ArenaTests
    {
        [TestMethod()]
        public void ArenaTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetLocationTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetNearestWallColorTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MovementLogicTestLeft()
        {
            Arena vTest = new Arena();

            vTest.HomeCnr = new int[] { 2,5 };
            var result = vTest.MovementLogic(5);
            Assert.AreEqual(-90, result);
        }

        [TestMethod()]
        public void MovementLogicTestRight()
        {
            Arena vTest = new Arena();

            vTest.HomeCnr = new int[] { 1, 5 };
            var result = vTest.MovementLogic(5);
            Assert.AreEqual(90, result);
        }

        [TestMethod()]
        public void MovementLogicTestReverse()
        {
            Arena vTest = new Arena();

            vTest.HomeCnr = new int[] { 2, 5 };
            var result = vTest.MovementLogic(4);
            Assert.AreEqual(180, result);
        }

    }
}