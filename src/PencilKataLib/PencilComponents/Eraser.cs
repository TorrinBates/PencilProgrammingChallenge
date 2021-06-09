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
            // loops from the end of word to the beginning while the eraser can still erase
            for (int i = startIndex + textToErase.Length - 1; i >= startIndex && startIndex >= 0 && EraserValue > 0; i--)
            {
                if (!char.IsWhiteSpace(paper.Text[i])) EraserValue -= 1;
                paper.ReceivePencil(' ', i);
            }
        }
    }
}
