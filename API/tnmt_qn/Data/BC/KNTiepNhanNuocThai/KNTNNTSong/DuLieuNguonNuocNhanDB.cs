using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class DuLieuNguonNuocNhanDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public int IdMucPL { get; set; }
        public double? LuuLuongDongChayDB { get; set; }

        //ketqua
        public double? CnnBODDB { get; set; }
        public double? CnnCODDB { get; set; }
        public double? CnnAmoniDB { get; set; }
        public double? CnnTongNDB { get; set; }
        public double? CnnTongPDB { get; set; }
        public double? CnnTSSDB { get; set; }
        public double? CnnColiformDB { get; set; }

        //tailuong
        public double? LnnBODDB { get; set; }
        public double? LnnCODDB { get; set; }
        public double? LnnAmoniDB { get; set; }
        public double? LnnTongNDB { get; set; }
        public double? LnnTongPDB { get; set; }
        public double? LnnTSSDB { get; set; }
        public double? LnnColiformDB { get; set; }

        //tailuongtoida
        public double? LtdBODDB { get; set; }
        public double? LtdCODDB { get; set; }
        public double? LtdAmoniDB { get; set; }
        public double? LtdTongNDB { get; set; }
        public double? LtdTongPDB { get; set; }
        public double? LtdTSSDB { get; set; }
        public double? LtdColiformDB { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdPhanDoanSong")]
        public virtual PhanDoanSong? PhanDoanSong { get; set; }
        [ForeignKey("IdMucPL")]
        public virtual ThongSoCLNDuBao? ThongSoCLNDuBao { get; set; }
    }
}
