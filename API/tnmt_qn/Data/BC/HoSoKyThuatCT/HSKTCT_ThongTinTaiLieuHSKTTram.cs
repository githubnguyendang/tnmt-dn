using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class HSKTCT_ThongTinTaiLieuHSKTTram
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTaiLieu { get; set; }
        public string? TenTaiLieu { get; set; }
        public string? KyHieuTaiLieu { get; set; }
        public string? NguoiLapHoSo { get; set; }
        public string? NguoiKiemTraHoSo { get; set; }
    }
}
