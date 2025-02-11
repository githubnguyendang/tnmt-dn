using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class Song
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? IdLuuVuc { get; set; }
        public string? TenSong { get; set; }
        public double? XDauSong { get; set; }
        public double? YDauSong { get; set; }
        public int? IdXaDauSong { get; set; }
        public int? IdHuyenDauSong { get; set; }
        public double? XCuoiSong { get; set; }
        public double? YCuoiSong { get; set; }
        public int? IdXaCuoiSong { get; set; }
        public int? IdHuyenCuoiSong { get; set; }
        public string? MaSong { get; set; }
        public double? Qtt { get; set; }
        public string? ChuGiai { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdLuuVuc")]
        public LuuVucSong? LuuVucSong { get; set; }

        public virtual ICollection<DoanSong>? DoanSong { get; set; }
    }
}
