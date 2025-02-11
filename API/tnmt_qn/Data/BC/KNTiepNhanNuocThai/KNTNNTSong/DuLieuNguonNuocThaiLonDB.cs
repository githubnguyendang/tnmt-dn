using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class DuLieuNguonNuocThaiLonDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public int? SoLonDB { get; set; }
        public int? SoDeDB { get; set; }
        public int? SoGiaSucKhacDB { get; set; }
        public double? HeSoSuyGiamDB { get; set; }
        //tongtailuong
        public double? CtLonBODDB { get; set; }
        public double? CtLonCODDB { get; set; }
        public double? CtLonAmoniDB { get; set; }
        public double? CtLonTongNDB { get; set; }
        public double? CtLonTongPDB { get; set; }
        public double? CtLonTSSDB { get; set; }
        public double? CtLonColiformDB { get; set; }

        public double? LtLonBODDB { get; set; }
        public double? LtLonCODDB { get; set; }
        public double? LtLonAmoniDB { get; set; }
        public double? LtLonTongNDB { get; set; }
        public double? LtLonTongPDB { get; set; }
        public double? LtLonTSSDB { get; set; }
        public double? LtLonColiformDB { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdPhanDoanSong")]
        public virtual PhanDoanSong? PhanDoanSong { get; set; }
    }
}
