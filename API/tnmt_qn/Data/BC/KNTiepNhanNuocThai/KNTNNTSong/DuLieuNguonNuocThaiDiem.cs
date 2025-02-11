using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class DuLieuNguonNuocThaiDiem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? LuuLuongXaThai { get; set; }
        public string? NguonThaiCongTrinh { get; set; }
        public double? ToaDoX { get; set; }
        public double? ToaDoY { get; set; }

        //tongtailuong
        public double? CtdiemBOD { get; set; }
        public double? CtdiemCOD { get; set; }
        public double? CtdiemAmoni { get; set; }
        public double? CtdiemTongN { get; set; }
        public double? CtdiemTongP { get; set; }
        public double? CtdiemTSS { get; set; }
        public double? CtdiemColiform { get; set; }

        public double? LtdiemBOD { get; set; }
        public double? LtdiemCOD { get; set; }
        public double? LtdiemAmoni { get; set; }
        public double? LtdiemTongN { get; set; }
        public double? LtdiemTongP { get; set; }
        public double? LtdiemTSS { get; set; }
        public double? LtdiemColiform { get; set; }

        public string? GhiChu { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdPhanDoanSong")]
        public virtual PhanDoanSong? PhanDoanSong { get; set; }
    }
}
