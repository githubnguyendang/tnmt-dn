using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class NN_AoHoDamPhaKhongDuocSanLap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TenHoChua { get; set; }
        public string? Xa { get; set; }
        public string? Huyen { get; set; }
        public string? NguonNuoc { get; set; }
        public string? ThuocLVS { get; set; }
        public string? LoaiHinhChucNang { get; set; }
        public double? DienTichMatNuoc { get; set; }
        public double? DungTichToanBo { get; set; }
        public double? DungTichHuuIch { get; set; }
        public double? DungTichPhongLu { get; set; }
        public double? MucNuocDangBinhThuong { get; set; }
        public double? MucNuocChet { get; set; }
        public int? NamHoanThanh { get; set; }
        public string? DonQuayLyVanHanh { get; set; }
        public string? ThuocDanhMucKhongSanLap { get; set; }
        public string? QuyetDinh { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
