using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class NN_VungCamHanCheKTNDD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TenVungCamHanChe { get; set; }
        public string? DienTichVungCamHanChe { get; set; }
        public string? Xa { get; set; }
        public string? Huyen { get; set; }
        public string? TinhTP { get; set; }
        public double? PhamViChieuSau { get; set; }
        public double? CacBienPhapHanCheKT { get; set; }
        public double? QDPheDuyetVungCamKT { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
