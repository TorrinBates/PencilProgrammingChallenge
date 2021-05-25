using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKataLib;

namespace PencilKataTests
{
    [TestClass]
    public class PaperTests
    {
        private const string C_shells = "She sells sea shells";
        private const string C_shore = " down by the sea shore";

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
            paper.ReceiveWriting(writeFirst);
            Assert.AreEqual(writeFirst, paper.Text);
            paper.ReceiveWriting(writeSecond);
            Assert.AreEqual(writeFirst+writeSecond, paper.Text);
        }
    }
}
