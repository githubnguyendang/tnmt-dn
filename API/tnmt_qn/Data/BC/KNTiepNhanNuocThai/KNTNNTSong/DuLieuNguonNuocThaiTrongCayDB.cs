using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class DuLieuNguonNuocThaiTrongCayDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? DienTichTrongCayDB { get; set; }
        public double? HeSoSuyGiamDB { get; set; }
        //tongtailuong
        public double? CtTrongCayBODDB { get; set; }
        public double? CtTrongCayCODDB { get; set; }
        public double? CtTrongCayAmoniDB { get; set; }
        public double? CtTrongCayTongNDB { get; set; }
        public double? CtTrongCayTongPDB { get; set; }
        public double? CtTrongCayTSSDB { get; set; }
        public double? CtTrongCayColiformDB { get; set; }

        public double? LtTrongCayBODDB { get; set; }
        public double? LtTrongCayCODDB { get; set; }
        public double? LtTrongCayAmoniDB { get; set; }
        public double? LtTrongCayTongNDB { get; set; }
        public double? LtTrongCayTongPDB { get; set; }
        public double? LtTrongCayTSSDB { get; set; }
        public double? LtTrongCayColiformDB { get; set; }

        public string? GhiChu { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdPhanDoanSong")]
        public virtual PhanDoanSong? PhanDoanSong { get; set; }
    }
}
