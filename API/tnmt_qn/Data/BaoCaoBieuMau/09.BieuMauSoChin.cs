using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class BieuMauSoChin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? LuuVucSong { get; set; }
        public double? TongCongTrinhKyTruoc { get; set; }
        public double? TongCongTrinhKyBaoCao { get; set; }
        public double? CongTrinhNuocMatKyTruoc { get; set; }
        public double? CongTrinhNuocMatKyBaoCao { get; set; }
        public double? CongTrinhNDDKyTruoc { get; set; }
        public double? CongTrinhNDDKyBaoCao { get; set; }
        public string? GhiChu { get; set; }
    }
}
