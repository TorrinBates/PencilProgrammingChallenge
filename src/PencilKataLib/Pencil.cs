namespace PencilKataLib
{
    public class Pencil
    {
        private readonly PencilPoint _point;
        private readonly Eraser _eraser;
        public Pencil(int length, int pointValue, int eraserValue)
        {
            Length = length;
            _point = new PencilPoint(pointValue);
            _eraser = new Eraser(eraserValue);
        }

        public int Length { get; private set; }

        public void Sharpen()
        {
            if (Length > 0)
            {
                _point.Sharpen();
                Length -= 1;
            }
        }

        public void Write(Paper paper, string textToWrite) => _point.Write(paper, textToWrite, paper.Text.Length);

        public void Write(Paper paper, string textToWrite, int startIndex) => _point.Write(paper, textToWrite, startIndex);

        public void Erase(Paper paper, string textToErase) => _eraser.Erase(paper, textToErase);

        public int GetPointValue() => _point.PointValue;

        public int GetEraserValue() => _eraser.EraserValue;
    }
}
