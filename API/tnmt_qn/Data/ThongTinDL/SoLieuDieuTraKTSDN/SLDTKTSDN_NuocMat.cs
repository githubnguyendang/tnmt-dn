using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class SLDTKTSDN_NuocMat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TenChuHoCT { get; set; }
        public string? LoaiCongTrinh { get; set; }
        public string? Xa { get; set; }
        public string? Huyen { get; set; }
        public string? TenNguonNuocKhaiThac { get; set; }
        public string? MucDichSD { get; set; }
        public double? UocTinhLuongNuocKT { get; set; }
        public double? DienTichTuoi { get; set; }
        public double? DienTichNuoiTrongThuySan { get; set; }
        public double? CongSuatPhatDien { get; set; }
        public string? SoHoDanDuocCapNuoc { get; set; }
        public string? CheDoKT { get; set; }
        public string? FilePDF { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
