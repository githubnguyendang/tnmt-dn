using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class NN_LuuVucSong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? MaSong1 { get; set; }
        public string? MaSong2 { get; set; }
        public string? MaSong3 { get; set; }
        public string? MaSong4 { get; set; }
        public string? MaSong5 { get; set; }
        public string? CapSong { get; set; }
        public string? TenSongSuoi { get; set; }
        public string? ChayRa { get; set; }
        public double? ChieuDai { get; set; }
        public double? DienTich { get; set; }
        public string? Tinh { get; set; }
        public string? ThuocLVS { get; set; }
        public string? LoaiSongSuoi { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
