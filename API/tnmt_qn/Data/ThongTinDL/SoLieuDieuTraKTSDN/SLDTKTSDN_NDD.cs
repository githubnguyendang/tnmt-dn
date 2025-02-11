using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class SLDTKTSDN_NDD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TenChuHoCT { get; set; }
        public string? Xa { get; set; }
        public string? Huyen { get; set; }
        public string? SoLuongGieng { get; set; }
        public double? UocTinhLuongNuocKT { get; set; }
        public string? LoaiCT { get; set; }
        public double? HinhThucKT { get; set; }
        public double? ChieuSauKT { get; set; }
        public double? MucDichSD { get; set; }
        public string? TinhTrangSD { get; set; }
        public string? PhieuDieuTraPDF { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
