using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class NN_CNNN_SongSuoi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? MaSong1 { get; set; }
        public string? MaSong2 { get; set; }
        public string? MaSong3 { get; set; }
        public string? MaSong4 { get; set; }
        public string? MaSong5 { get; set; }
        public string? MaSong6 { get; set; }
        public string? TenSongSuoi { get; set; }
        public string? PhanDoan { get; set; }
        public double? ChayRa { get; set; }
        public double? ChieuDai { get; set; }
        public string? DiaPhanHanhChinh { get; set; }
        public string? Huyen { get; set; }
        public double? XDiemDau { get; set; }
        public double? YDiemDau { get; set; }
        public double? XDiemCuoi { get; set; }
        public double? YDiemCuoi { get; set; }
        public string? ChucNangNguonNuoc { get; set; }
        public string? MucTieuChatLuong { get; set; }
        public DateTime? ThoiGianThucHien { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
