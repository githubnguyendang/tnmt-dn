using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class DuLieuNguonNuocThaiTrauBoDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public int? SoTrauDB { get; set; }
        public int? SoBoDB { get; set; }
        public double? HeSoSuyGiamDB { get; set; }
        //tongtailuong
        public double? CtTrauBoBODDB { get; set; }
        public double? CtTrauBoCODDB { get; set; }
        public double? CtTrauBoAmoniDB { get; set; }
        public double? CtTrauBoTongNDB { get; set; }
        public double? CtTrauBoTongPDB { get; set; }
        public double? CtTrauBoTSSDB { get; set; }
        public double? CtTrauBoColiformDB { get; set; }

        public double? LtTrauBoBODDB { get; set; }
        public double? LtTrauBoCODDB { get; set; }
        public double? LtTrauBoAmoniDB { get; set; }
        public double? LtTrauBoTongNDB { get; set; }
        public double? LtTrauBoTongPDB { get; set; }
        public double? LtTrauBoTSSDB { get; set; }
        public double? LtTrauBoColiformDB { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdPhanDoanSong")]
        public virtual PhanDoanSong? PhanDoanSong { get; set; }
    }
}
