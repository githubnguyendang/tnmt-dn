using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Ten { get; set; }
        public string? LoaiHo { get; set; }
        public string? XaPhuongTT { get; set; }
        public string? DiaPhanHanhChinh { get; set; }
        public string? HuyenTP { get; set; }
        public double? DungTichHo106m3 { get; set; }
        public string? PhamViHanhLang { get; set; }
        public string? ThuocDienCamMocHanhLang { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
