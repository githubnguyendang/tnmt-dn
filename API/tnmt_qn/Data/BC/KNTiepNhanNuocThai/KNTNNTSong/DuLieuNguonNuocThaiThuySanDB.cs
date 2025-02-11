using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class DuLieuNguonNuocThaiThuySanDB
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? DienTichThuySanDB { get; set; }
        public double? HeSoSuyGiamDB { get; set; }

        //tongtailuong
        public double? CtThuySanBODDB { get; set; }
        public double? CtThuySanCODDB { get; set; }
        public double? CtThuySanAmoniDB { get; set; }
        public double? CtThuySanTongNDB { get; set; }
        public double? CtThuySanTongPDB { get; set; }
        public double? CtThuySanTSSDB { get; set; }
        public double? CtThuySanColiformDB { get; set; }

        public double? LtThuySanBODDB { get; set; }
        public double? LtThuySanCODDB { get; set; }
        public double? LtThuySanAmoniDB { get; set; }
        public double? LtThuySanTongNDB { get; set; }
        public double? LtThuySanTongPDB { get; set; }
        public double? LtThuySanTSSDB { get; set; }
        public double? LtThuySanColiformDB { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdPhanDoanSong")]
        public virtual PhanDoanSong? PhanDoanSong { get; set; }
    }
}
