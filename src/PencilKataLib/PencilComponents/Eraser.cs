namespace PencilKataLib
{
    public class Eraser
    {
        public Eraser(int eraserValue)
        {
            EraserValue = eraserValue;
        }

        public int EraserValue { get; private set; }

        public void Erase(Paper paper, string textToErase)
        {
            var startIndex = paper.Text.LastIndexOf(textToErase);
            for (int i = startIndex + textToErase.Length - 1; i >= startIndex && EraserValue > 0; i--)
            {
                if (!char.IsWhiteSpace(paper.Text[i])) EraserValue -= 1;
                paper.ReceivePencil(' ', i);
            }
        }
    }
}
