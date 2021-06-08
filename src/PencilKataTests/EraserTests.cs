using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKataLib;

namespace PencilKataTests
{
    [TestClass]
    public class EraserTests
    {
        private const int C_eraserV = 40;
        private Paper _testPaper;
        private PencilPoint _testPencilPoint;
        private Eraser _testEraser;

        private void EraseAndAssert(string textToErase, string expected)
        {
            _testEraser.Erase(_testPaper, textToErase);
            Assert.AreEqual(expected, _testPaper.Text);
        }

        [TestInitialize]
        public void Setup()
        {
            _testPaper = new Paper();
            _testPencilPoint = new PencilPoint(100);
            _testPencilPoint.Write(_testPaper, "One fish, Two fish\n", 0);
            _testEraser = new Eraser(C_eraserV);
        }

        [TestMethod]
        public void Erasing()
        {
            EraseAndAssert("fish", "One fish, Two     \n");
            EraseAndAssert(" fish", "One     , Two     \n");
            EraseAndAssert("house", "One     , Two     \n");
        }

        [TestMethod]
        [DataRow(C_eraserV - 1, "O")]
        [DataRow(C_eraserV - 1, "o")]
        [DataRow(C_eraserV, "z")]
        [DataRow(C_eraserV, " ")]
        [DataRow(C_eraserV, "\n")]
        [DataRow(C_eraserV-3, "Two")]
        public void EraserDegradation(int expectedFinalEraserVal, string toErase)
        {
            Assert.AreEqual(C_eraserV, _testEraser.EraserValue);
            _testEraser.Erase(_testPaper, toErase);
            Assert.AreEqual(expectedFinalEraserVal, _testEraser.EraserValue);
        }

        [TestMethod]
        public void ErasingWhenEraserValueZero()
        {
            _testEraser = new Eraser(1);
            _testEraser.Erase(_testPaper, "fish");
            Assert.AreEqual("One fish, Two fis \n", _testPaper.Text);
        }
    }
}
