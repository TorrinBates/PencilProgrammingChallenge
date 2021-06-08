using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKataLib;

namespace PencilKataTests
{
    [TestClass]
    public class PencilPointTests
    {
        private const string C_fish = "A purple puffer fish ";
        private const int C_pointV = 40;
        private Paper _testPaper;
        private PencilPoint _testPencilPoint;

        private void WriteAndAssert(string textToWrite, string expected)
        {
            _testPencilPoint.Write(_testPaper, textToWrite, _testPaper.Text.Length);
            Assert.AreEqual(expected, _testPaper.Text);
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
            Assert.AreEqual(C_pointV, _testPencilPoint.PointValue);
            _testPencilPoint.Write(_testPaper, toWrite, 0);
            Assert.AreEqual(expectedFinalPoint, _testPencilPoint.PointValue);
        }

        [TestMethod]
        public void WritingWhenPointValueZero()
        {
            _testPencilPoint = new PencilPoint(1);
            _testPencilPoint.Write(_testPaper, "world", 0);
            Assert.AreEqual("w    ", _testPaper.Text);
        }

        [TestMethod]
        [DataRow("onion", "An onion a day keeps the doctor away")]
        [DataRow("artichoke", "An artich@k@ay keeps the doctor away")]
        public void EditingText(string edit, string expected)
        {
            var txt = "An       a day keeps the doctor away";
            WriteAndAssert(txt, txt);
            _testPencilPoint.Write(_testPaper, edit, 3);
            Assert.AreEqual(expected, _testPaper.Text);
        }

        [TestMethod]
        public void EditingConflictPointDegradation()
        {
            Assert.AreEqual(C_pointV, _testPencilPoint.PointValue);
            _testPencilPoint.Write(_testPaper, "A", 0);
            _testPencilPoint.Write(_testPaper, "B", 0);
            Assert.AreEqual(C_pointV - 4, _testPencilPoint.PointValue);
        }

        [TestMethod]
        public void Sharpen()
        {
            Assert.AreEqual(C_pointV, _testPencilPoint.PointValue);
            _testPencilPoint.Write(_testPaper, "QWERTY", 0);
            Assert.IsTrue(_testPencilPoint.PointValue < C_pointV);
            _testPencilPoint.Sharpen();
            Assert.AreEqual(C_pointV, _testPencilPoint.PointValue);
        }
    }
}
