using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKataLib;

namespace PencilKataTests
{
    [TestClass]
    public class PencilTests
    {
        private const string C_num = "One fish, Two fish\n";
        private const string C_color = "Red fish, Blue fish.";

        private void WriteAndAssert(Pencil pencil, Paper paper, string textToWrite, string expected)
        {
            pencil.Write(paper, textToWrite);
            Assert.AreEqual(expected, paper.Text);
        }

        [TestMethod]
        [DataRow(C_num, C_color)]
        [DataRow("", C_color)]
        [DataRow(C_num, "")]
        public void Writing(string writeFirst, string writeSecond)
        {
            var paper = new Paper();
            var pencil = new Pencil(100);
            WriteAndAssert(pencil, paper, writeFirst, writeFirst);
            WriteAndAssert(pencil, paper, writeSecond, writeFirst+writeSecond);
        }

        [TestMethod]
        [DataRow(17, C_num, C_num)]
        [DataRow(5, C_color, "Red f               ")]
        public void PointDegradation(int pointDurability, string toWrite, string expected)
        {
            var paper = new Paper();
            var pencil = new Pencil(pointDurability);
            WriteAndAssert(pencil, paper, toWrite, expected);
        }
    }
}
