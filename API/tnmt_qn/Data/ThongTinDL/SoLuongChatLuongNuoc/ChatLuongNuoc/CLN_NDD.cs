using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class CLN_NDD
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? ThoiGianQuanTrac { get; set; }
        public string? LuuVucSong { get; set; }
        public string? TangChuaNuoc { get; set; }
        public string? ViTriQuanTrac { get; set; }
        public string? KyHieuDiemQuanTrac { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public double? PhDot1 { get; set; }
        public double? PhDot2 { get; set; }
        public double? PhDot3 { get; set; }
        public double? ColiformDot1 { get; set; }
        public double? ColiformDot2 { get; set; }
        public double? ColiformDot3 { get; set; }
        public double? NitrateDot1 { get; set; }
        public double? NitrateDot2 { get; set; }
        public double? NitrateDot3 { get; set; }
        public double? AmoniDot1 { get; set; }
        public double? AmoniDot2 { get; set; }
        public double? AmoniDot3 { get; set; }
        public double? TDSDot1 { get; set; }
        public double? TDSDot2 { get; set; }
        public double? TDSDot3 { get; set; }
        public double? DoCungDot1 { get; set; }
        public double? DoCungDot2 { get; set; }
        public double? DoCungDot3 { get; set; }
        public double? ArsenicDot1 { get; set; }
        public double? ArsenicDot2 { get; set; }
        public double? ArsenicDot3 { get; set; }
        public double? ChlorideDot1 { get; set; }
        public double? ChlorideDot2 { get; set; }
        public double? ChlorideDot3 { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
