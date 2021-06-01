namespace PencilKataLib
{
    public class Eraser
    {
        public void Erase(Paper paper, string toErase)
        {
            var blankSpace = new string(' ', toErase.Length);
            var index = paper.Text.LastIndexOf(toErase);
            paper.ReceiveErasing(paper.Text.Remove(index, toErase.Length).Insert(index, blankSpace));
        }
    }
}
