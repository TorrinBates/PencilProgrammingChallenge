using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKataLib;

namespace PencilKataTests
{
    [TestClass]
    public class PaperTests
    {
        private Paper _testPaper;

        private void ReceiveAndAssert(Paper paper, char newChar, string expected, int index)
        {
            paper.ReceivePencil(newChar, index);
            Assert.AreEqual(expected, paper.Text);
        }

        [TestInitialize]
        public void Setup() => _testPaper = new Paper();

        [TestMethod]
        public void PaperEmptyByDefault() => Assert.AreEqual(string.Empty, _testPaper.Text);

        [TestMethod]
        [DataRow('L', 'a')]
        [DataRow(' ', 'z')]
        public void RecieveWriting(char writeFirst, char writeSecond)
        {
            var writeAsString = writeFirst.ToString();
            ReceiveAndAssert(_testPaper, writeFirst, writeAsString, _testPaper.Text.Length);
            ReceiveAndAssert(_testPaper, writeSecond, writeAsString + writeSecond, _testPaper.Text.Length);
        }

        [TestMethod]
        public void RecieveWritingOverWrite()
        {
            ReceiveAndAssert(_testPaper, 'A', "A", 0);
            ReceiveAndAssert(_testPaper, 'B', "B", 0);
        }
    }
}
