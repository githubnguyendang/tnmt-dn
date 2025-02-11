using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class MuaHienTai
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TramMua { get; set; }
        public double? LuongMua1Gio { get; set; }
        public double? NguongMua1Gio { get; set; }
        public double? LuongMua3Gio { get; set; }
        public double? NguongMua3Gio { get; set; }
        public double? LuongMua6Gio { get; set; }
        public double? NguongMua6Gio { get; set; }
        public double? LuongMua12Gio { get; set; }
        public double? NguongMua12Gio { get; set; }
        public double? LuongMua24Gio { get; set; }
        public double? NguongMua24Gio { get; set; }
        public string? GhiChu { get; set; }

        // từ dòng 26 đến 30 giữ nguyên
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

    }
}
