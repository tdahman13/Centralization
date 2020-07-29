namespace Centralization.Models
{
    public partial class DocFile
    {
        public int Id { get; set; }
        public string Dftif { get; set; }
        public string Tifpath { get; set; }
        public string Lot { get; set; }
        public string Block { get; set; }
        public string Section { get; set; }
        public string Cemid { get; set; }
        //public DateTime? Scandate { get; set; }
        //public bool Badscan { get; set; }
        //public string Dfnum { get; set; }
        //public float? Dfindex { get; set; }
        //public string Dfpart { get; set; }
        //public bool Garbage { get; set; }
        //public DateTime? Date { get; set; }
        public string Gravehigh { get; set; }
        public string Gravelow { get; set; }
        //public string Series { get; set; }
        //public string Comments { get; set; }
        //public string ParentCemNum { get; set; }
        //public bool? Checked { get; set; }
        //public bool? Missing { get; set; }
    }
}
