﻿namespace Centralization.Models
{
    public class LinkedInterment
    {
        public int LinkedIntermentId { get; set; }
        public int Idf { get; set; }
        public string CemNo { get; set; }
        public int MemorialApplicationId { get; set; }

        public MemorialApplication MemorialApplication { get; set; }
    }
}
