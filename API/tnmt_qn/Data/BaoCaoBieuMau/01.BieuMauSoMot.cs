using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class BieuMauSoMot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? LuuVucSong { get; set; }
        public double? TongTramQuanTracKyTruoc { get; set; }
        public double? TongTramQuanTracBaoCao { get; set; }
        public double? TramKhiTuongKyTruoc { get; set; }
        public double? TramKhiTuongBaoCao { get; set; }
        public double? TramThuyVanKyTruoc { get; set; }
        public double? TramThuyVanKyBaoCao { get; set; }
        public double? TramTNNKyTruoc { get; set; }
        public double? TramTNNKyBaoCao { get; set; }
        public double? TramQuanTracKyTruoc { get; set; }

        public double? TramQuanTracKyBaoCao { get; set; }
        public string? GhiChu { get; set; }
    }
}
