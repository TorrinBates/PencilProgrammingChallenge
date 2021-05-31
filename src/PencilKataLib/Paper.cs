namespace PencilKataLib
{
    public class Paper
    {
        public string Text { get; private set; } = "";
        public void ReceiveWriting(char textToAdd) => Text += textToAdd;
    }
}
