namespace PencilKataLib
{
    public class Paper
    {
        public Paper()
        {
            Text = "";
        }

        public string Text { get; private set; }
        public void ReceiveWriting(string textToAdd) => Text += textToAdd;
    }
}
