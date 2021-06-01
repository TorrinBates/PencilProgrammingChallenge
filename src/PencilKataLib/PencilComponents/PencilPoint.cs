namespace PencilKataLib
{
    public class PencilPoint
    {
        private readonly int _initialPointValue;
        public PencilPoint(int pointValue)
        {
            PointValue = pointValue;
            _initialPointValue = pointValue;
        }

        public int PointValue { get; private set; }

        public void Sharpen() => PointValue = _initialPointValue;

        public void Write(Paper paper, string textToWrite)
        {
            foreach (var c in textToWrite)
                paper.ReceiveWriting(DegradePoint(c));
        }

        private char DegradePoint(char c)
        {
            if (!char.IsWhiteSpace(c))
            {
                var degradeAmount = char.IsUpper(c) ? 2 : 1;
                if (PointValue >= degradeAmount) PointValue -= degradeAmount;
                else c = ' ';
            }
            return c;
        }
    }
}
