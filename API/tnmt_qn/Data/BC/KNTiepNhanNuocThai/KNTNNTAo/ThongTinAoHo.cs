using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class ThongTinAoHo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdHoChua{ get; set; }
        public double? Ftuoi1 { get; set; }
        public double? Ftuoi2 { get; set; }
        public double? Wtru1 { get; set; }
        public double? Wtru2 { get; set; }
        public string? TranXaLu { get; set; }
        //ketqua
        public double? CnnBOD { get; set; }
        public double? CnnCOD { get; set; }
        public double? CnnAmoni { get; set; }
        public double? CnnTongN { get; set; }
        public double? CnnTongP { get; set; }
        public double? CnnTSS { get; set; }
        public double? CnnColiform { get; set; }
        public double? VH { get; set; }
        public double? FS { get; set; }
        //gioi han
        public double? CghBOD { get; set; }
        public double? CghCOD { get; set; }
        public double? CghAmoni { get; set; }
        public double? CghTongN { get; set; }
        public double? CghTongP { get; set; }
        public double? CghTSS { get; set; }
        public double? CghColiform { get; set; }
        public string? GhiChu { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdHoChua")]
        public virtual CT_ThongTin? CT_ThongTin { get; set; }
    }
}
