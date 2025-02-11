using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class BieuMauSoMuoiSau
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? LoaiGiayPhep { get; set; }
        public double? TongGPCapKyTruoc { get; set; }
        public double? TongGPCapKyBaoCao { get; set; }
        public double? TongGPBoCapKyTruoc { get; set; }
        public double? TongGPBoCapKyBaoCao { get; set; }
        public double? TongGPDiaPhuongCapKyTruoc { get; set; }
        public double? TongGPDiaPhuongCapBaoCao { get; set; }
        public string? GhiChu { get; set; }
    }
}
