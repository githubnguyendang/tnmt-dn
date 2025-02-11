using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class CTKTSDN_KTNDDCuaHoGD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TenCongTrinh { get; set; }
        public string? TenTCCN { get; set; }
        public string? Xa { get; set; }
        public string? Huyen { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public string? SoThuaDat { get; set; }
        public double? ChieuSauGieng { get; set; }
        public double? SoNguoiSD { get; set; }
        public string? TinhTrangChatLuongNuoc { get; set; }
        public string? TinhTrangKeKhai { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
