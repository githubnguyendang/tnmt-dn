using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class KKTNN_NuocMat_TongLuong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? IdLuuVucSong { get; set; }
        public int? Nam { get; set; }
        public double? Thang1 { get; set; }
        public double? Thang2 { get; set; }
        public double? Thang3 { get; set; }
        public double? Thang4 { get; set; }
        public double? Thang5 { get; set; }
        public double? Thang6 { get; set; }
        public double? Thang7 { get; set; }
        public double? Thang8 { get; set; }
        public double? Thang9 { get; set; }
        public double? Thang10 { get; set; }
        public double? Thang11 { get; set; }
        public double? Thang12 { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdLuuVucSong")]
        public LuuVucSong? LuuVucSong { get; set; }
    }
}
