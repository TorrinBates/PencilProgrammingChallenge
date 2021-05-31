namespace PencilKataLib
{
    public class PencilPoint
    {
        public PencilPoint(int pointValue)
        {
            PointValue = pointValue;
        }

        public int PointValue { get; private set; }

        public void Write(Paper paper, string textToWrite)
        {
            foreach (var c in textToWrite)
                paper.ReceiveWriting(DegradePoint(c));
        }

        private char DegradePoint(char c)
        {
            if (c != ' ' && c != '\n')
            {
                var degradeAmount = char.IsUpper(c) ? 2 : 1;
                if (PointValue >= degradeAmount) PointValue -= degradeAmount;
                else c = ' ';
            }
            return c;
        }
    }
}
