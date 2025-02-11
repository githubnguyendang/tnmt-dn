using tnmt_qn.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class HTTT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? Nam { get; set; }
        public int? Thang { get; set; }
        public int? Ngay { get; set; }
        public int? Gio { get; set; }
        public string? PhanCapLu { get; set; }
        public int? STTLu { get; set; }
        public string? NhanDangLu { get; set; }
        public string? HinhTheThoiTiet { get; set; }
        public DateTime? NgayHinhThanh { get; set; }
        public string? TamBaoVungAnhHuongManh { get; set; }
        public DateTime? NgayDoBo { get; set; }
        public string? ViTriDoBo { get; set; }
        public string? CapDoBao { get; set; }
        public double? TongLuongMua { get; set; }
        public string? ChiTietTranLu { get; set; }
        public string? GhiChu { get; set; }
        // từ dòng 26 đến 30 giữ nguyên
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
