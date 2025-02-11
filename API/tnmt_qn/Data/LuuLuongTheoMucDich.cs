using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class LuuLuongTheoMucDich
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? IdCT { get; set; }
        public int? IdMucDich { get; set; }
        public double? LuuLuong { get; set; }
        public string? DonViDo { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdCT")]
        public virtual CT_ThongTin? CT_ThongTin { get; set; }

        [ForeignKey("IdMucDich")]
        public virtual MucDichKT? MucDichKT { get; set; }
    }
}
