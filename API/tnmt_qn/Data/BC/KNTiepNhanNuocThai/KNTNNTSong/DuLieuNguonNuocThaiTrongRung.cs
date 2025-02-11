using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class DuLieuNguonNuocThaiTrongRung
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? DienTichTrongRung { get; set; }
        public double? HeSoSuyGiam { get; set; }
        //tongtailuong
        public double? CtTrongRungBOD { get; set; }
        public double? CtTrongRungCOD { get; set; }
        public double? CtTrongRungAmoni { get; set; }
        public double? CtTrongRungTongN { get; set; }
        public double? CtTrongRungTongP { get; set; }
        public double? CtTrongRungTSS { get; set; }
        public double? CtTrongRungColiform { get; set; }

        public double? LtTrongRungBOD { get; set; }
        public double? LtTrongRungCOD { get; set; }
        public double? LtTrongRungAmoni { get; set; }
        public double? LtTrongRungTongN { get; set; }
        public double? LtTrongRungTongP { get; set; }
        public double? LtTrongRungTSS { get; set; }
        public double? LtTrongRungColiform { get; set; }

        public string? GhiChu { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdPhanDoanSong")]
        public virtual PhanDoanSong? PhanDoanSong { get; set; }
    }
}
