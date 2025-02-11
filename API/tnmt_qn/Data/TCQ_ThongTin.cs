using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class TCQ_ThongTin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? IdCon { get; set; }
        public string? SoQDTCQ { get; set; }
        public DateTime? NgayKy { get; set; }
        public string? CoQuanCP { get; set; }
        public double? TongTienCQ { get; set; }
        public string? FilePDF { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        public virtual ICollection<GP_TCQ>? GP_TCQ { get; set; }
    }
}
