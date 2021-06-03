namespace PencilKataLib
{
    public class Paper
    {
        public string Text { get; private set; } = "";
        public void ReceivePencil(char newChar, int index)
        {
            if (index > Text.Length-1) Text += newChar;
            else AlterExistingText(newChar, index);
        }

        private void AlterExistingText(char newChar, int index)
        {
            var textAsArray = Text.ToCharArray();
            textAsArray[index] = newChar;
            Text = string.Concat(textAsArray);
        }
    }
}
