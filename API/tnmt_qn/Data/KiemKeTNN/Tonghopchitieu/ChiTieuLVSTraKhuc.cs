using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class ChiTieuLVSTraKhuc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Stt { get; set; }
        public string? TenChiTieu { get; set; }
        public string? DonViTinh { get; set; }
        public double? Ketqua { get; set; }
        public string? GhiChu { get; set; }
    }
}
