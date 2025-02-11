using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class ThongSoDiemQuanTrac
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? IdDiemQT { get; set; }
        public string? Dot {  get; set; }
        public double ? PH { get; set; }
        public double? DO { get; set; }
        public string? TSS { get; set; }
        public string? BOD { get; set;}
        public string? COD { get; set; }
        public string? NO3 { get; set; }
        public string? NO2 { get; set; }
        public string? PO4 { get; set; }
        public string? NH4 { get; set; }
        public string? CL { get; set; }
        public string? FE { get; set; }
        public double? Coliform { get; set; }
        public int ? Year { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
        [ForeignKey("IdDiemQT")]
        public virtual DiemQuanTrac? DiemQuanTrac { get; set; }
    }
}
