using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class BieuMauSoMuoiTam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? LuuVucSong { get; set; }
        public double? TongSongPheDuyetBoKyTruoc { get; set; }
        public double? TongSongPheDuyetBoKyBaoCao { get; set; }
        public double? TongSongPheDuyetDiaPhuongKyTruoc { get; set; }
        public double? TongSongPheDuyetDiaPhuongKyBaoCao { get; set; }
        public double? TongHoPheDuyetKyTruoc { get; set; }
        public double? TongHoPheDuyetKyBaoCao { get; set; }
        public string? GhiChu { get; set; }
    }
}
