using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKataLib;

namespace PencilKataTests
{
    [TestClass]
    public class PaperTests
    {
        private void ReceiveAndAssert(Paper paper, char newChar, string expected)
        {
            paper.ReceivePencil(newChar, paper.Text.Length);
            Assert.AreEqual(expected, paper.Text);
        }

        [TestMethod]
        public void PaperEmptyByDefault()
        { 
            var paper = new Paper();
            Assert.AreEqual(string.Empty, paper.Text);
        }

        [TestMethod]
        [DataRow('L', 'a')]
        [DataRow(' ', 'z')]
        public void RecieveWriting(char writeFirst, char writeSecond)
        {
            var paper = new Paper();
            var writeAsString = writeFirst.ToString();
            ReceiveAndAssert(paper, writeFirst, writeAsString);
            ReceiveAndAssert(paper, writeSecond, writeAsString + writeSecond);
        }
    }
}
