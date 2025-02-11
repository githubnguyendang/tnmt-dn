using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class DuLieuNguonNuocThaiGiaCam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public int? SoGiaCam { get; set; }
        public double? HeSoSuyGiam { get; set; }

        //tongtailuong
        public double? CtGiaCamBOD { get; set; }
        public double? CtGiaCamCOD { get; set; }
        public double? CtGiaCamAmoni { get; set; }
        public double? CtGiaCamTongN { get; set; }
        public double? CtGiaCamTongP { get; set; }
        public double? CtGiaCamTSS { get; set; }
        public double? CtGiaCamColiform { get; set; }

        public double? LtGiaCamBOD { get; set; }
        public double? LtGiaCamCOD { get; set; }
        public double? LtGiaCamAmoni { get; set; }
        public double? LtGiaCamTongN { get; set; }
        public double? LtGiaCamTongP { get; set; }
        public double? LtGiaCamTSS { get; set; }
        public double? LtGiaCamColiform { get; set; }

        public string? GhiChu { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdPhanDoanSong")]
        public virtual PhanDoanSong? PhanDoanSong { get; set; }
    }
}
