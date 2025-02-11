using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class DuLieuNguonNuocThaiThuySan
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? DienTichThuySan { get; set; }
        public double? HeSoSuyGiam { get; set; }

        //tongtailuong
        public double? CtThuySanBOD { get; set; }
        public double? CtThuySanCOD { get; set; }
        public double? CtThuySanAmoni { get; set; }
        public double? CtThuySanTongN { get; set; }
        public double? CtThuySanTongP { get; set; }
        public double? CtThuySanTSS { get; set; }
        public double? CtThuySanColiform { get; set; }

        public double? LtThuySanBOD { get; set; }
        public double? LtThuySanCOD { get; set; }
        public double? LtThuySanAmoni { get; set; }
        public double? LtThuySanTongN { get; set; }
        public double? LtThuySanTongP { get; set; }
        public double? LtThuySanTSS { get; set; }
        public double? LtThuySanColiform { get; set; }

        public string? GhiChu { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdPhanDoanSong")]
        public virtual PhanDoanSong? PhanDoanSong { get; set; }
    }
}
