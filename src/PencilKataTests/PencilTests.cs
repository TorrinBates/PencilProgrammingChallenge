using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKataLib;

namespace PencilKataTests
{
    [TestClass]
    public class PencilTests
    {
        private const string C_num = "One fish, Two fish\n";
        private const string C_color = "Red fish, Blue fish.";
        private const int C_DefaultLength = 1;
        private const int C_DefaultPoint = 100;
        private const int C_DefaultEraser = 50;

        private void WriteAndAssert(Pencil pencil, Paper paper, string textToWrite, string expected, int initialDurability, bool checkPoint=true)
        {
            pencil.Write(paper, textToWrite);
            Assert.AreEqual(paper.Text, expected);
            if (checkPoint) Assert.IsTrue(pencil.GetPointValue() < initialDurability);
        }

        [TestMethod]
        [DataRow(10, 50, C_color, C_color)]
        [DataRow(10, 14, "Red fish, Blue      ", "Red fish, Blue      ")]
        public void LengthDegradation(int length, int pointDurability, string expected1, string expected2)
        {
            var pencil = new Pencil(length, pointDurability, C_DefaultEraser);
            Assert.AreEqual(pencil.Length, length);
            WriteAndAssert(pencil, new Paper(), C_color, expected1, pointDurability);
            pencil.Sharpen();
            Assert.AreEqual(pencil.GetPointValue(), pointDurability);
            Assert.AreEqual(pencil.Length, length-1);
            WriteAndAssert(pencil, new Paper(), C_color, expected2, pointDurability);
        }

        [TestMethod]
        public void SharpenWhenLengthZero()
        {
            var paper = new Paper();
            var pencil = new Pencil(0, C_DefaultPoint, C_DefaultEraser);
            WriteAndAssert(pencil, paper, C_num, C_num, C_DefaultPoint);
            pencil.Sharpen();
            Assert.AreEqual(pencil.Length, 0);
            Assert.IsTrue(pencil.GetPointValue() < C_DefaultPoint);
        }
    }
}
