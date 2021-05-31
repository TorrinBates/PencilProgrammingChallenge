namespace PencilKataLib
{
    public class Pencil
    {
        private PencilPoint _point;
        public Pencil(int pointValue)
        {
            _point = new PencilPoint(pointValue);
        }

        public void Write(Paper paper, string textToWrite) => _point.Write(paper, textToWrite);
    }
}
