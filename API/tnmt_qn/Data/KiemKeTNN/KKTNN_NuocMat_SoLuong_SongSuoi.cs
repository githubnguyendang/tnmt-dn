using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class KKTNN_NuocMat_SoLuong_SongSuoi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? MaSong { get; set; }
        public string? TenSong { get; set; }
        public string? ChayRa { get; set; }
        public double? ChieuDai { get; set; }
        public string? ChieuDaiThuocTinh_ThanhPho { get; set; }
        public string? DauSongX { get; set; }
        public string? DauSongY { get; set; }
        public string? DauSongXaHuyenTinh { get; set; }
        public string? CuoiSongX { get; set; }
        public string? CuoiSongY { get; set; }
        public string? CuoiSongXaHuyenTinh { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
