using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKataLib;

namespace PencilKataTests
{
    [TestClass]
    public class PencilTests
    {
        private const string C_num = "One fish, Two fish\n";
        private const string C_color = "Red fish, Blue fish.";

        private void WriteAndAssert(Pencil pencil, Paper paper, string textToWrite, string expected, int initialDurability, bool checkPoint=true)
        {
            pencil.Write(paper, textToWrite);
            Assert.AreEqual(expected, paper.Text);
            if (checkPoint) Assert.IsTrue(pencil.GetPointValue() < initialDurability);
        }

        [TestMethod]
        [DataRow(C_num, C_color)]
        [DataRow("", C_color)]
        [DataRow(C_num, "")]
        public void Writing(string writeFirst, string writeSecond)
        {
            var paper = new Paper();
            var pencil = new Pencil(1, 100);
            WriteAndAssert(pencil, paper, writeFirst, writeFirst, 1, false);
            WriteAndAssert(pencil, paper, writeSecond, writeFirst+writeSecond, 1, false);
        }

        [TestMethod]
        [DataRow(17, C_num, C_num)]
        [DataRow(5, C_color, "Red f               ")]
        public void PointDegradation(int pointDurability, string toWrite, string expected)
        {
            var paper = new Paper();
            var pencil = new Pencil(1, pointDurability);
            Assert.AreEqual(pencil.GetPointValue(), pointDurability);
            WriteAndAssert(pencil, paper, toWrite, expected, pointDurability);
        }

        [TestMethod]
        [DataRow(10, 50, C_color, C_color)]
        [DataRow(10, 14, "Red fish, Blue      ", "Red fish, Blue      ")]
        public void LengthDegradation(int length, int pointDurability, string expected1, string expected2)
        {
            var pencil = new Pencil(length, pointDurability);
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
            var pencil = new Pencil(0, 100);
            WriteAndAssert(pencil, paper, C_num, C_num, 100);
            pencil.Sharpen();
            Assert.AreEqual(pencil.Length, 0);
            Assert.IsTrue(pencil.GetPointValue() < 100);
        }
    }
}
