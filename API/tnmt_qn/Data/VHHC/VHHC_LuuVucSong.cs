using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class VHHC_LuuVucSong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? LuuVucSong { get; set; }
        public string? DienTichLuuVuc { get; set; }
        public string? ChieuDaiSongChinh { get; set; }
        public string? BanDo { get; set; }
        public string? SoDoCacCT { get; set; }
        public string? SoQuyTrinh { get; set; }
        public string? TepDinhKem { get; set; }
        public string? FileKML { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
