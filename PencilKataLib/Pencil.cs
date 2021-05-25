namespace PencilKataLib
{
    public class Pencil
    {
        public void Write(Paper paper, string textToWrite) => paper.ReceiveWriting(textToWrite);
    }
}
