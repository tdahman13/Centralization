namespace Centralization.Models
{
    public partial class LotCardInventory
    {
        public long Id { get; set; }
        public long? LotCardId { get; set; }
        //public string ParentCemNum { get; set; }
        public string CemNum { get; set; }
        public string Grave { get; set; }
        public string Lot { get; set; }
        public string Block { get; set; }
        public string Section { get; set; }
        //public string Status { get; set; }
        //public string GraveType { get; set; }
        //public string PriceClass { get; set; }
        //public DateTime? DateModified { get; set; }
        //public long? OrderId { get; set; }
        //public string EasementNumber { get; set; }
        //public string EasementNumberAuto { get; set; }
    }
}
