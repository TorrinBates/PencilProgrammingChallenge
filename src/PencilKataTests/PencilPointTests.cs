using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKataLib;

namespace PencilKataTests
{
    [TestClass]
    public class PencilPointTests
    {
        private const string C_fish = "A purple puffer fish ";
        private const int C_pointV = 25;
        private Paper _testPaper;
        private PencilPoint _testPencilPoint;

        private void WriteAndAssert(string textToWrite, string expected)
        {
            _testPencilPoint.Write(_testPaper, textToWrite, _testPaper.Text.Length);
            Assert.AreEqual(_testPaper.Text, expected);
        }

        [TestInitialize]
        public void Setup()
        {
            _testPaper = new Paper();
            _testPencilPoint = new PencilPoint(C_pointV);
        }

        [TestMethod]
        [DataRow(C_fish, "swims")]
        [DataRow("", C_fish)]
        [DataRow(C_fish, "")]
        public void Writing(string writeFirst, string writeSecond)
        {
            WriteAndAssert(writeFirst, writeFirst);
            WriteAndAssert(writeSecond, writeFirst + writeSecond);
        }

        [TestMethod]
        [DataRow(C_pointV-2, "A")]
        [DataRow(C_pointV-1, "a")]
        [DataRow(C_pointV, " ")]
        [DataRow(C_pointV, "\n")]
        [DataRow(C_pointV-7, "WaSd.")]
        public void PointDegradation(int expectedFinalPoint, string toWrite)
        {
            Assert.AreEqual(_testPencilPoint.PointValue, C_pointV);
            _testPencilPoint.Write(_testPaper, toWrite, 0);
            Assert.AreEqual(_testPencilPoint.PointValue, expectedFinalPoint);
        }

        [TestMethod]
        public void WritingWhenPointValueZero()
        {
            _testPencilPoint = new PencilPoint(1);
            _testPencilPoint.Write(_testPaper, "world", 0);
            Assert.AreEqual(_testPaper.Text, "w    ");
        }
    }
}
