using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class DuLieuNguonNuocNhan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? LuuLuongDongChay { get; set; }

        //ketqua
        public double? CnnBOD { get; set; }
        public double? CnnCOD { get; set; }
        public double? CnnAmoni { get; set; }
        public double? CnnTongN { get; set; }
        public double? CnnTongP { get; set; }
        public double? CnnTSS { get; set; }
        public double? CnnColiform { get; set; }

        //tailuong
        public double? LnnBOD { get; set; }
        public double? LnnCOD { get; set; }
        public double? LnnAmoni { get; set; }
        public double? LnnTongN { get; set; }
        public double? LnnTongP { get; set; }
        public double? LnnTSS { get; set; }
        public double? LnnColiform { get; set; }

        //giatrigioihan
        public double? CqcBOD { get; set; }
        public double? CqcCOD { get; set; }
        public double? CqcAmoni { get; set; }
        public double? CqcTongN { get; set; }
        public double? CqcTongP { get; set; }
        public double? CqcTSS { get; set; }
        public double? CqcColiform { get; set; }
        
        //tailuongtoida
        public double? LtdBOD { get; set; }
        public double? LtdCOD { get; set; }
        public double? LtdAmoni { get; set; }
        public double? LtdTongN { get; set; }
        public double? LtdTongP { get; set; }
        public double? LtdTSS { get; set; }
        public double? LtdColiform { get; set; }
        public string? GhiChu { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdPhanDoanSong")]
        public virtual PhanDoanSong? PhanDoanSong { get; set; }
    }
}
