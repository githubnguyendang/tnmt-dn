using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class SLN_TongLuongNuocMat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? LuuVucSong { get; set; }
        public double? TBNhieuNamDCNam { get; set; }
        public double? KyTruocDCNam { get; set; }
        public double? KyBaoCaoDCNam { get; set; }
        public double? ThayDoiDCNam { get; set; }
        public double? TBNhieuNamDCLu { get; set; }
        public double? KyTruocDCLu { get; set; }
        public double? KyBaoCaoDCLu { get; set; }
        public double? ThayDoiDCLu { get; set; }
        public double? TBNhieuNamDCMuaCan { get; set; }
        public double? KyTruocDCMuaCan { get; set; }
        public double? KyBaoCaoDCMuaCan { get; set; }
        public double? ThayDoiDCMuaCan { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
