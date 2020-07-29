using System;

namespace Centralization.Models
{
    public partial class Easements
    {
        public int Id { get; set; }
        public string Ebtif { get; set; }
        public string Tifpath { get; set; }
        public string Lot { get; set; }
        public string Block { get; set; }
        public string Section { get; set; }
        public string Cemid { get; set; }
        //public DateTime? Scandate { get; set; }
        //public bool Badscan { get; set; }
        public DateTime? Date { get; set; }
        public string Easementno { get; set; }
        public string Gravelow { get; set; }
        public string Gravehigh { get; set; }
        //public bool Garbage { get; set; }
        //public string Series { get; set; }
        //public short? Svtpage { get; set; }
        //public string Comments { get; set; }
        //public string ParentCemNum { get; set; }
        //public bool? Checked { get; set; }
        //public bool? Missing { get; set; }
    }
}
