using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class CTKTSDN_PDK_NuocBien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TenCongTrinh { get; set; }
        public string? TenTCCN { get; set; }
        public string? NamVanHanh { get; set; }
        public string? Xa { get; set; }
        public string? Huyen { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public string? TenVungbien { get; set; }
        public string? CheDoLayNuoc { get; set; }
        public string? DiemLayNuoc { get; set; }
        public double? CongSuatTho { get; set; }
        public double? CongSuatTinh { get; set; }
        public string? SoToMay { get; set; }
        public double? LuuLuongKTMax { get; set; }
        public int? SoMayBom { get; set; }
        public string? DiemXaNuocLamMat { get; set; }
        public double? LuuLuongXaMax { get; set; }
        public double? CongSuatThietKe { get; set; }
        public string? PhuongThucKT { get; set; }
        public string? MucDichKT { get; set; }
        public string? CheDoKT { get; set; }
        public string? SoGP { get; set; }
        public string? NgayQuyetDinh { get; set; }
        public string? ThoiGianHieuLuc { get; set; }
        public string? IDCongTrinh { get; set; }
        public string? ThoiGianBatDauKetNoi { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
