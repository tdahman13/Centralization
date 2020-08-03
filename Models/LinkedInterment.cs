namespace Centralization.Models
{
    public class LinkedInterment
    {
        public int LinkedIntermentId { get; set; }
        public int Idf { get; set; }
        public string CemNo { get; set; }

        public MemorialApplication Application { get; set; }
    }
}
