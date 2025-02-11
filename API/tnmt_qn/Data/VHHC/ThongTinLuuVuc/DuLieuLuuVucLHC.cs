using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class DuLieuLuuVucLHC
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? LVSVHH { get; set; }
        public double? DienTichLV { get; set; }
        public double? ChieuDaiSong { get; set; }
        public string? BanDo { get; set; }
        public string? SoDoCT { get; set; }
        public string? SoQT { get; set; }
        public string? TepDinhKem { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
