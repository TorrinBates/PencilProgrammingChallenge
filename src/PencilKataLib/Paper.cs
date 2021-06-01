namespace PencilKataLib
{
    public class Paper
    {
        public string Text { get; private set; } = "";
        public void ReceiveWriting(char textToAdd) => Text += textToAdd;
        public void ReceiveErasing(int indexToErase)
        {
            var textAsArray = Text.ToCharArray();
            textAsArray[indexToErase] = ' ';
            Text = string.Concat(textAsArray);
        }
    }
}
