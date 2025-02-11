using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class DuLieuNguonNuocThaiGiaCamDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public int? SoGiaCamDB { get; set; }
        public double? HeSoSuyGiamDB { get; set; }

        //tongtailuong
        public double? CtGiaCamBODDB { get; set; }
        public double? CtGiaCamCODDB { get; set; }
        public double? CtGiaCamAmoniDB { get; set; }
        public double? CtGiaCamTongNDB { get; set; }
        public double? CtGiaCamTongPDB { get; set; }
        public double? CtGiaCamTSSDB { get; set; }
        public double? CtGiaCamColiformDB { get; set; }

        public double? LtGiaCamBODDB { get; set; }
        public double? LtGiaCamCODDB { get; set; }
        public double? LtGiaCamAmoniDB { get; set; }
        public double? LtGiaCamTongNDB { get; set; }
        public double? LtGiaCamTongPDB { get; set; }
        public double? LtGiaCamTSSDB { get; set; }
        public double? LtGiaCamColiformDB { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdPhanDoanSong")]
        public virtual PhanDoanSong? PhanDoanSong { get; set; }
    }
}
