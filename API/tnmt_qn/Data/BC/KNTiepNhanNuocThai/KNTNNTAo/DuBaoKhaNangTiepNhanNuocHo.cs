using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class DuBaoKhaNangTiepNhanNuocHo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdHoChua { get; set; }
        public int IdMucPL{ get; set; }
        public double? CnnBOD { get; set; }
        public double? CnnCOD { get; set; }
        public double? CnnAmoni { get; set; }
        public double? CnnTongN { get; set; }
        public double? CnnTongP { get; set; }
        public double? CnnTSS { get; set; }
        public double? CnnColiform { get; set; }
        public double? VH { get; set; }
        public double? FS { get; set; }
        public double? MtnBOD { get; set; }
        public double? MtnCOD { get; set; }
        public double? MtnAmoni { get; set; }
        public double? MtnTongN { get; set; }
        public double? MtnTongP { get; set; }
        public double? MtnTSS { get; set; }
        public double? MtnColiform { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdHoChua")]
        public virtual CT_ThongTin? CT_ThongTin { get; set; }
        [ForeignKey("IdMucPL")]
        public virtual ThongSoCLNDuBao? ThongSoCLNDuBao { get; set; }
    }
}
