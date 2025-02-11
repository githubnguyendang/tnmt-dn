using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class BieuMauSoMuoiBay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Tinh { get; set; }
        public double? TongCTPheDuyetTCQKyTruoc { get; set; }
        public double? TongCTPheDuyetTCQKyBaoCao { get; set; }
        public double? TongCTPheDuyetTCQBoKyTruoc { get; set; }
        public double? TongCTPheDuyetTCQBoKyBaoCao { get; set; }
        public double? TongCTPheDuyetTCQDiaPhuongKyTruoc { get; set; }
        public double? TongCTPheDuyetTCQDiaPhuongKyBaoCao { get; set; }
        public double? TongTCQpKyTruoc { get; set; }
        public double? TongTCQKyBaoCao { get; set; }
        public string? GhiChu { get; set; }
    }
}
