namespace PencilKataLib
{
    public class Pencil
    {
        private PencilPoint _point;
        private Eraser _eraser;
        public Pencil(int length, int pointValue)
        {
            Length = length;
            _point = new PencilPoint(pointValue);
            _eraser = new Eraser();
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

        public void Write(Paper paper, string textToWrite) => _point.Write(paper, textToWrite);

        public void Erase(Paper paper, string textToErase) => _eraser.Erase(paper, textToErase);

        public int GetPointValue() => _point.PointValue;
    }
}
