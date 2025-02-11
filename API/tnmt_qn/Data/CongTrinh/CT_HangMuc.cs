using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class CT_HangMuc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? IdCT { get; set; }
        public int? IdTangChuaNuoc { get; set; }
        public string? TenHangMuc { get; set; }
        public string? VịTriHangMuc { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public string? ChuThich { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        // Navigation property to represent the relationship
        [ForeignKey("IdTangChuaNuoc")]
        public virtual TangChuaNuoc? TangChuaNuoc { get; set; }

        [ForeignKey("IdCT")]
        public virtual CT_ThongTin? CongTrinh { get; set; }
        public virtual CT_ThongSo? ThongSo { get; set; }
    }
}
