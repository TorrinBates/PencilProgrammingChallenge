using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKataLib;

namespace PencilKataTests
{
    [TestClass]
    public class PencilTests
    {
        private const string C_num = "One fish, two fish,";
        private const string C_color = " red fish, blue fish.";

        private void WriteAndAssert(Pencil pencil, Paper paper, string textToWrite, string expected)
        {
            pencil.Write(paper, textToWrite);
            Assert.AreEqual(expected, paper.Text);
        }

        [TestMethod]
        [DataRow(C_num, C_color)]
        [DataRow("", C_color)]
        [DataRow(C_num, "")]
        public void TestWriting(string writeFirst, string writeSecond)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            WriteAndAssert(pencil, paper, writeFirst, writeFirst);
            WriteAndAssert(pencil, paper, writeSecond, writeFirst+writeSecond);
        }
    }
}
