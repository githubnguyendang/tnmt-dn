using tnmt_qn.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class DuLieuTram
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdTram { get; set; }
        public DateTime? ThoiGian { get; set; }
        public double? LuongMua { get; set; }
        public double? NhietDo { get; set; }
        public double? DoAm { get; set; }
        public string? HuongGio { get; set; }
        public double? TocDoGio { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdTram")]
        public virtual Tram_ThongTin? Tram { get; set; }
    }
}
