using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class DuLieuNguonNuocThaiTrauBo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public int? SoTrau { get; set; }
        public int? SoBo { get; set; }
        public double? HeSoSuyGiam { get; set; }
        //tongtailuong
        public double? CtTrauBoBOD { get; set; }
        public double? CtTrauBoCOD { get; set; }
        public double? CtTrauBoAmoni { get; set; }
        public double? CtTrauBoTongN { get; set; }
        public double? CtTrauBoTongP { get; set; }
        public double? CtTrauBoTSS { get; set; }
        public double? CtTrauBoColiform { get; set; }

        public double? LtTrauBoBOD { get; set; }
        public double? LtTrauBoCOD { get; set; }
        public double? LtTrauBoAmoni { get; set; }
        public double? LtTrauBoTongN { get; set; }
        public double? LtTrauBoTongP { get; set; }
        public double? LtTrauBoTSS { get; set; }
        public double? LtTrauBoColiform { get; set; }

        public string? GhiChu { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdPhanDoanSong")]
        public virtual PhanDoanSong? PhanDoanSong { get; set; }
    }
}
