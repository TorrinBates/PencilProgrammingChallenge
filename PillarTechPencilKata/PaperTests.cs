using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKataLib;

namespace PencilKataTests
{
    [TestClass]
    public class PaperTests
    {
        [TestMethod]
        public void TestPaperEmpty()
        {
            var paper = new Paper();
            Assert.AreEqual(string.Empty, paper.Text);
        }
    }
}
