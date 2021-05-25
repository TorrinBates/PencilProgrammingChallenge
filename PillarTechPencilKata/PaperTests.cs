using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKataLib;

namespace PencilKataTests
{
    [TestClass]
    public class PaperTests
    {
        private const string C_shells = "She sells sea shells";
        private const string C_shore = " down by the sea shore";

        private void ReceiveAndAssert(Paper paper, string textToWrite, string expected)
        {
            paper.ReceiveWriting(textToWrite);
            Assert.AreEqual(expected, paper.Text);
        }

        [TestMethod]
        public void TestPaperEmptyByDefault()
        { 
            var paper = new Paper();
            Assert.AreEqual(string.Empty, paper.Text);
        }

        [TestMethod]
        [DataRow(C_shells, C_shore)]
        [DataRow("", C_shore)]
        [DataRow(C_shells, "")]
        public void TestRecieveWriting(string writeFirst, string writeSecond)
        {
            var paper = new Paper();
            ReceiveAndAssert(paper, writeFirst, writeFirst);
            ReceiveAndAssert(paper, writeSecond, writeFirst + writeSecond);
        }
    }
}
