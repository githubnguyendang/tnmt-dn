using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class DuLieuNguonNuocThaiSinhHoat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public int? SoDan { get; set; }
        public double? HeSoSuyGiam { get; set; }
        //tongtailuong
        public double? CtSinhHoatBOD { get; set; }
        public double? CtSinhHoatCOD { get; set; }
        public double? CtSinhHoatAmoni { get; set; }
        public double? CtSinhHoatTongN { get; set; }
        public double? CtSinhHoatTongP { get; set; }
        public double? CtSinhHoatTSS { get; set; }
        public double? CtSinhHoatColiform { get; set; }

        public double? LtSinhHoatBOD { get; set; }
        public double? LtSinhHoatCOD { get; set; }
        public double? LtSinhHoatAmoni { get; set; }
        public double? LtSinhHoatTongN { get; set; }
        public double? LtSinhHoatTongP { get; set; }
        public double? LtSinhHoatTSS { get; set; }
        public double? LtSinhHoatColiform { get; set; }

        public string? GhiChu { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdPhanDoanSong")]
        public virtual PhanDoanSong? PhanDoanSong { get; set; }
    }
}
