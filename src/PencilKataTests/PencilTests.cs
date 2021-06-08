using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKataLib;

namespace PencilKataTests
{
    [TestClass]
    public class PencilTests
    {
        private const string C_color = "Red fish, Blue fish.";
        private const int C_DefaultLength = 1;
        private const int C_DefaultPoint = 100;
        private const int C_DefaultEraser = 50;
        private Paper _testPaper;
        private Pencil _testPencil;

        [TestInitialize]
        public void Setup()
        {
            _testPaper = new Paper();
            _testPencil = new Pencil(C_DefaultLength, C_DefaultPoint, C_DefaultEraser);
        }

        [TestMethod]
        public void LengthDegradation()
        {
            Assert.AreEqual(C_DefaultLength, _testPencil.Length);
            _testPencil.Sharpen();
            Assert.AreEqual(C_DefaultLength-1, _testPencil.Length);
        }

        [TestMethod]
        public void SharpenWhenLengthZero()
        {
            _testPencil = new Pencil(0, C_DefaultPoint, C_DefaultEraser);
            _testPencil.Write(_testPaper, C_color);
            _testPencil.Sharpen();
            Assert.AreEqual(0, _testPencil.Length);
            Assert.IsTrue(_testPencil.GetPointValue() < C_DefaultPoint);
        }

        [TestMethod]
        public void PencilIntegration()
        {
            _testPencil.Write(_testPaper, C_color);
            Assert.AreEqual(C_color, _testPaper.Text);
            _testPencil.Erase(_testPaper, "Blue");
            Assert.AreEqual("Red fish,      fish.", _testPaper.Text);
            Assert.IsTrue(_testPencil.GetEraserValue() < C_DefaultEraser);
            _testPencil.Write(_testPaper, "Pink", 10);
            Assert.AreEqual("Red fish, Pink fish.", _testPaper.Text);
            _testPencil.Sharpen();
            Assert.AreEqual(C_DefaultPoint, _testPencil.GetPointValue());
        }
    }
}
