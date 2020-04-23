using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sbt.Test.Refactoring.Interfaces;
using Sbt.Test.Refactoring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbt.Test.Refactoring.Tests
{
    [TestClass]
    public class TractorTest
    {
        [TestMethod]
        public void TestShouldMoveForward()
        {
            Tractor tractor = new Tractor();
            
            tractor.Command("F");
            Assert.AreEqual(0, tractor.GetPositionX());
            Assert.AreEqual(1, tractor.GetPositionY());
        }

        [TestMethod]
        public void TestShouldTurn()
        {
            Tractor tractor = new Tractor();
            
            tractor.Command("T");
            Assert.AreEqual(Orientation.East, tractor.Orientation);

            tractor.Command("T");
            Assert.AreEqual(Orientation.South, tractor.Orientation);

            tractor.Command("T");
            Assert.AreEqual(Orientation.West, tractor.Orientation);

            tractor.Command("T");
            Assert.AreEqual(Orientation.North, tractor.Orientation);
        }

        [TestMethod]
        public void TestShouldTurnAndMoveInTheRightDirection()
        {
            Tractor tractor = new Tractor();

            tractor.Command("T");
            tractor.Command("F");
            Assert.AreEqual(1, tractor.GetPositionX());
            Assert.AreEqual(0, tractor.GetPositionY());

            tractor.Command("T");
            tractor.Command("F");
            Assert.AreEqual(1, tractor.GetPositionX());
            Assert.AreEqual(-1, tractor.GetPositionY());

            tractor.Command("T");
            tractor.Command("F");
            Assert.AreEqual(0, tractor.GetPositionX());
            Assert.AreEqual(-1, tractor.GetPositionY());

            tractor.Command("T");
            tractor.Command("F");
            Assert.AreEqual(0, tractor.GetPositionX());
            Assert.AreEqual(0, tractor.GetPositionY());
        }

        [TestMethod]
        public void TestShouldThrowExceptionIfFallsOffPlateau()
        {
            Tractor tractor = new Tractor();

            tractor.Command("F");
            tractor.Command("F");
            tractor.Command("F");
            tractor.Command("F");
            tractor.Command("F");

            try
            {
                tractor.Command("F");
                Assert.Fail("Tractor was expected to fall off the plateau");
            }
            catch (TractorInDitchException ex)
            {
            }
        }

        [TestMethod]
        public void TestWillUnitsFollowOnlyTheirCommands()
        {
            IList<ICommandable> elements = new List<ICommandable>
            {
                    new Tractor(),
                    new Tractor(),
                    new Tractor(),
                    new Wind()           
            };

            foreach(var element in elements) 
            {
                element.Command("F");
            }

            foreach (var element in elements)
            {
                if (element is IPositionable) {
                    Assert.AreEqual(0, ((IPositionable) element).GetPositionX());
                    Assert.AreEqual(1, ((IPositionable) element).GetPositionY());
                }
            }

        }
    }
}
