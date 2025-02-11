using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class DuLieuNguonNuocThaiTrongRungDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? DienTichTrongRungDB { get; set; }
        public double? HeSoSuyGiamDB { get; set; }
        //tongtailuong
        public double? CtTrongRungBODDB { get; set; }
        public double? CtTrongRungCODDB { get; set; }
        public double? CtTrongRungAmoniDB { get; set; }
        public double? CtTrongRungTongNDB { get; set; }
        public double? CtTrongRungTongPDB { get; set; }
        public double? CtTrongRungTSSDB { get; set; }
        public double? CtTrongRungColiformDB { get; set; }

        public double? LtTrongRungBODDB { get; set; }
        public double? LtTrongRungCODDB { get; set; }
        public double? LtTrongRungAmoniDB { get; set; }
        public double? LtTrongRungTongNDB { get; set; }
        public double? LtTrongRungTongPDB { get; set; }
        public double? LtTrongRungTSSDB { get; set; }
        public double? LtTrongRungColiformDB { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdPhanDoanSong")]
        public virtual PhanDoanSong? PhanDoanSong { get; set; }
    }
}
