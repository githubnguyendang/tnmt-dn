using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class NN_NguongKhaiThacNDD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TenTCN { get; set; }
        public string? LoaiChuaNuoc { get; set; }
        public string? Xa { get; set; }
        public string? Huyen { get; set; }
        public string? TinhTP { get; set; }
        public double? DienTichPhanBo { get; set; }
        public double? KhoangChieuSauPhanBo { get; set; }
        public double? NguongGHKTLuuLuong { get; set; }
        public double? NguongGHKTMucNuoc { get; set; }
        public string? QDPheDuyetNguongGioiHanKT { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
