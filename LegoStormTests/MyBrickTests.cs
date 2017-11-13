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
    public class MyBrickTests
    {
        [TestMethod()]
        public void AlignToWallTest()
        {
            //arrange
            MyBrick vTest = new MyBrick();
            //act

            //assert
            Assert.Fail();
        }

        [TestMethod()]
        public void MakeConnectionTest()
        {
            //arrange
            MyBrick vTest = new MyBrick();
            //act
            vTest.MakeConnection();
            //assert
            
        }
    }
}