using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class DoanSong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TenDoanSong { get; set; }
        public int? IdLVSong { get; set; }
        public int? IdSong { get; set; }
        public double? ChieuDai { get; set; }
        public double? DienTichLV { get; set; }
        public string? DiaGioiHanhChinh { get; set; }

        public string? MucDichSuDung { get; set; }
        public double? XDau { get; set; }
        public double? YDau { get; set; }
        public double? XCuoi { get; set; }
        public double? YCuoi { get; set; }
        public double? Qs { get; set; }
        public virtual ThongSoLtd? ThongSoLtd { get; set; }

        [ForeignKey("IdSong")]
        public virtual Song? Song { get; set; }


    }
}
