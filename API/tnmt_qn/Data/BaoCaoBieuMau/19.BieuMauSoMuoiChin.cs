using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class BieuMauSoMuoiChin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Tinh { get; set; }
        public double? SoCuocThanhTraKyTruoc { get; set; }
        public double? SoCuocThanhTraKyBaoCao { get; set; }
        public double? SoDoiTuongThanhTraKyTruoc { get; set; }
        public double? SoDoiTuongThanhTraKyBaoCao { get; set; }
        public double? SoTCCNXuPhatKyTruoc { get; set; }
        public double? SoTCCNXuPhatKyBaoCao { get; set; }
        public double? TongTienXuPhatKyTruoc { get; set; }
        public double? TongTienXuPhatKyBaoCao { get; set; }
        public string? GhiChu { get; set; }
    }
}
