using System.ComponentModel.DataAnnotations.Schema;
using tnmt_qn.Data;

namespace tnmt_qn.Dto
{
    public class ThongSoDiemQuanTracDto
    {
        public int Id { get; set; }
        public int? IdDiemQT { get; set; }
        public string? Dot { get; set; }
        public double? PH { get; set; }
        public double? DO { get; set; }
        public string? TSS { get; set; }
        public string? BOD { get; set; }
        public string? COD { get; set; }
        public string? NO3 { get; set; }
        public string? NO2 { get; set; }
        public string? PO4 { get; set; }
        public string? NH4 { get; set; }
        public string? CL { get; set; }
        public string? FE { get; set; }
        public double? Coliform { get; set; }
        public int? Year { get; set; }
        public bool? DaXoa { get; set; }
        [ForeignKey("IdDiemQT")]
        public virtual DiemQuanTrac? DiemQuanTrac { get; set; }
    }
}
