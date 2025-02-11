using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class HSKTT_NuocMat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? KyHieuCT { get; set; }
        public string? TenTaiLieuHoSo { get; set; }
        public string? TenToChucThucHienQuanTrac { get; set; }
        public string? NguoiThanhLapHoSo { get; set; }
        public string? NguoiKiemTraHoSo { get; set; }
        public string? FilePDF { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
