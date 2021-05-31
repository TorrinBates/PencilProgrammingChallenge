namespace PencilKataLib
{
    public class Pencil
    {
        private PencilPoint _point;
        public Pencil(int length, int pointValue)
        {
            Length = length;
            _point = new PencilPoint(pointValue);
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

        public int GetPointValue() => _point.PointValue;
    }
}
