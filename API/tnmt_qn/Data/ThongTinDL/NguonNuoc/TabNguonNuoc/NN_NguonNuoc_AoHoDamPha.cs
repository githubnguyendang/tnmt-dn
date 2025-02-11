using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class NN_NguonNuoc_AoHoDamPha
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TenHoChua { get; set; }
        public string? NguonNuoc { get; set; }
        public string? ThuocLVS { get; set; }
        public double? DienTichMatNuoc { get; set; }
        public string? XaPhuongTT { get; set; }
        public string? HuyenTP { get; set; }
        public double? DungTichToanBo { get; set; }
        public double? DungTichHuuIch { get; set; }
        public double? DungTichPhongLu { get; set; }
        public double? MNDBT { get; set; }
        public double? MNC { get; set; }
        public int? NamXayDung { get; set; }
        public string? DonViQuanLyVanHanh { get; set; }
        public string? PhamViHanhLang { get; set; }
        public string? ThuocDienCamMocHanhLang { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
