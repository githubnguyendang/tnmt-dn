using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class NN_NguonNuoc_TangChuaNuoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TenTangChuaNuoc { get; set; }
        public string? LoaiChuaNuoc { get; set; }
        public string? ThuocLVS { get; set; }
        public string? XaPhuongTT { get; set; }
        public string? HuyenTP { get; set; }
        public double? DungTichPhanBo { get; set; }
        public double? KhoangChieuSauPhanBo { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
