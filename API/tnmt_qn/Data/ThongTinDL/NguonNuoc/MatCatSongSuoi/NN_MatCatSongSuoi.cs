using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class NN_MatCatSongSuoi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? SoHieuMatCat { get; set; }
        public string? TenSongSuoi { get; set; }
        public string? ThuocLVS { get; set; }
        public double? XBoTrai { get; set; }
        public double? YBoTrai { get; set; }
        public double? XBoPhai { get; set; }
        public double? YBoPhai { get; set; }
        public string? Xa { get; set; }
        public string? Huyen { get; set; }
        public string? TinhTP { get; set; }
        public string? SoHieuDiem { get; set; }
        public double? KhoangCach { get; set; }
        public double? CaoDoDaySong { get; set; }
        public string? ThoiGianDo { get; set; }
        public double? MucNuocSong { get; set; }
        public string? DonViDoDacKhaoSat { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
