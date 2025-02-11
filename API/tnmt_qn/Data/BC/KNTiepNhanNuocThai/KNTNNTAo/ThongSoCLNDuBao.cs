using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class ThongSoCLNDuBao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double? BOD { get; set; }
        public double? COD { get; set; }
        public double? TSS { get; set; }
        public double? Amoni { get; set; }
        public double? TongP { get; set; }
        public double? TongN { get; set; }
        public double? TongColiform { get; set; }
        public string? MucPLCLNuoc { get; set; }
    }
}
