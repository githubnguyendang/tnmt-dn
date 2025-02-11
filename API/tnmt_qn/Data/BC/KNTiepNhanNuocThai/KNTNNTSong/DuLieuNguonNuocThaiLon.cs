using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class DuLieuNguonNuocThaiLon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public int? SoLon { get; set; }
        public int? SoDe { get; set; }
        public int? SoGiaSucKhac { get; set; }
        public double? HeSoSuyGiam { get; set; }
        //tongtailuong
        public double? CtLonBOD { get; set; }
        public double? CtLonCOD { get; set; }
        public double? CtLonAmoni { get; set; }
        public double? CtLonTongN { get; set; }
        public double? CtLonTongP { get; set; }
        public double? CtLonTSS { get; set; }
        public double? CtLonColiform { get; set; }

        public double? LtLonBOD { get; set; }
        public double? LtLonCOD { get; set; }
        public double? LtLonAmoni { get; set; }
        public double? LtLonTongN { get; set; }
        public double? LtLonTongP { get; set; }
        public double? LtLonTSS { get; set; }
        public double? LtLonColiform { get; set; }

        public string? GhiChu { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdPhanDoanSong")]
        public virtual PhanDoanSong? PhanDoanSong { get; set; }
    }
}
