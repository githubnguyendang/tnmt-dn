using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class DuLieuNguonNuocThaiSinhHoatDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public int? SoDanDB { get; set; }
        public double? HeSoSuyGiamDB { get; set; }
        //tongtailuong
        public double? CtSinhHoatBODDB { get; set; }
        public double? CtSinhHoatCODDB { get; set; }
        public double? CtSinhHoatAmoniDB { get; set; }
        public double? CtSinhHoatTongNDB { get; set; }
        public double? CtSinhHoatTongPDB { get; set; }
        public double? CtSinhHoatTSSDB { get; set; }
        public double? CtSinhHoatColiformDB { get; set; }

        public double? LtSinhHoatBODDB { get; set; }
        public double? LtSinhHoatCODDB { get; set; }
        public double? LtSinhHoatAmoniDB { get; set; }
        public double? LtSinhHoatTongNDB { get; set; }
        public double? LtSinhHoatTongPDB { get; set; }
        public double? LtSinhHoatTSSDB { get; set; }
        public double? LtSinhHoatColiformDB { get; set; }

        public string? GhiChu { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdPhanDoanSong")]
        public virtual PhanDoanSong? PhanDoanSong { get; set; }
    }
}
