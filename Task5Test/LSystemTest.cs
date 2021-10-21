using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task5;

namespace Task5Test
{
    [TestClass]
    public class LSystemTest
    {
        const string inputPath = @"..\..\Input\";
      
        [TestMethod]
        public void TestInput()
        {
            var fileName = inputPath + "koh.txt";
            LSystem system = new LSystem(fileName);
            Assert.AreEqual(0, system.StepNum);
            Assert.AreEqual("F", system.Axiom);
            Assert.AreEqual(0, system.InitailAngle);
            Assert.AreEqual(60, system.RotateAngle);
            Assert.IsTrue(system.Rules.ContainsKey('F'));
            Assert.AreEqual("F", system.CurrentState);
            Assert.AreEqual("F−F++F−F", system.Rules['F']);
        }

        [TestMethod]
        public void TestStep()
        {
            var fileName = inputPath + "koh.txt";
            LSystem system = new LSystem(fileName);
            Assert.AreEqual("F", system.CurrentState);
            system.Step();
            Assert.AreEqual("F−F++F−F", system.CurrentState);
            system.Step();
            Assert.AreEqual("F−F++F−F−F−F++F−F++F−F++F−F−F−F++F−F", system.CurrentState);
        }

        [TestMethod]
        public void TestApply()
        {
            var fileName = inputPath + "koh1.txt";
            LSystem system = new LSystem(fileName);
            var points = system.Apply(500, 500);
        }
    }
}
