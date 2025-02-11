using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class BieuMauSoBay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? KhuVuc { get; set; }
        public string? VungDieuTra { get; set; }
        public double? DienTichDuocDieuTra { get; set; }
        public string? TangChuaNuocDieuTra { get; set; }
        public string? TyLeDieuTra { get; set; }
        public string? GhiChu { get; set; }
    }
}
