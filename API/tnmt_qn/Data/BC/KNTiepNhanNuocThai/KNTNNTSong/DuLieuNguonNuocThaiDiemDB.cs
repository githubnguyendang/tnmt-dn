using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class DuLieuNguonNuocThaiDiemDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? LuuLuongXaThaiDB { get; set; }

        //tongtailuong
        public double? CtdiemBODDB { get; set; }
        public double? CtdiemCODDB { get; set; }
        public double? CtdiemAmoniDB { get; set; }
        public double? CtdiemTongNDB { get; set; }
        public double? CtdiemTongPDB { get; set; }
        public double? CtdiemTSSDB { get; set; }
        public double? CtdiemColiformDB { get; set; }

        public double? LtdiemBODDB { get; set; }
        public double? LtdiemCODDB { get; set; }
        public double? LtdiemAmoniDB { get; set; }
        public double? LtdiemTongNDB { get; set; }
        public double? LtdiemTongPDB { get; set; }
        public double? LtdiemTSSDB { get; set; }
        public double? LtdiemColiformDB { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdPhanDoanSong")]
        public virtual PhanDoanSong? PhanDoanSong { get; set; }
    }
}
