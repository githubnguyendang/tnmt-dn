using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class CLN_NuocMat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? LuuVucSong { get; set; }
        public int? ThoiGianQuanTrac { get; set; }
        public string? SongSuoiHoChua { get; set; }
        public string? ViTriQuanTrac { get; set; }
        public string? KyHieuDiemQuanTrac { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public double? PhDot1 { get; set; }
        public double? PhDot2 { get; set; }
        public double? PhDot3 { get; set; }
        public double? BOD5Dot1 { get; set; }
        public double? BOD5Dot2 { get; set; }
        public double? BOD5Dot3 { get; set; }
        public double? CODDot1 { get; set; }
        public double? CODDot2 { get; set; }
        public double? CODDot3 { get; set; }
        public double? DODot1 { get; set; }
        public double? DODot2 { get; set; }
        public double? DODot3 { get; set; }
        public double? PhotphoDot1 { get; set; }
        public double? PhotphoDot2 { get; set; }
        public double? PhotphoDot3 { get; set; }
        public double? NitoDot1 { get; set; }
        public double? NitoDot2 { get; set; }
        public double? NitoDot3 { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
