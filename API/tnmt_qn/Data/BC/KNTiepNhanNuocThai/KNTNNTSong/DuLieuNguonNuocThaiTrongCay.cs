using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class DuLieuNguonNuocThaiTrongCay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? DienTichTrongCay { get; set; }
        public double? HeSoSuyGiam { get; set; }
        //tongtailuong
        public double? CtTrongCayBOD { get; set; }
        public double? CtTrongCayCOD { get; set; }
        public double? CtTrongCayAmoni { get; set; }
        public double? CtTrongCayTongN { get; set; }
        public double? CtTrongCayTongP { get; set; }
        public double? CtTrongCayTSS { get; set; }
        public double? CtTrongCayColiform { get; set; }

        public double? LtTrongCayBOD { get; set; }
        public double? LtTrongCayCOD { get; set; }
        public double? LtTrongCayAmoni { get; set; }
        public double? LtTrongCayTongN { get; set; }
        public double? LtTrongCayTongP { get; set; }
        public double? LtTrongCayTSS { get; set; }
        public double? LtTrongCayColiform { get; set; }

        public string? GhiChu { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdPhanDoanSong")]
        public virtual PhanDoanSong? PhanDoanSong { get; set; }
    }
}
