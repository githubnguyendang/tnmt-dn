using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class KhaNangTiepNhanNuocHo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
         public string? TenCT {  get; set; }
        public string? Xa { get; set; }
        public string? Huyen { get; set; }
        public double? Flv { get; set; }
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

        public double? CqcBOD { get; set; }
        public double? CqcCOD { get; set; }
        public double? CqcAmoni { get; set; }
        public double? CqcTongN { get; set; }
        public double? CqcTongP { get; set; }
        public double? CqcTSS { get; set; }
        public double? CqcColiform { get; set; }
        public double? Vh { get; set; }
        public double? HeSoFs { get; set; }
        public string? GhiChu { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
