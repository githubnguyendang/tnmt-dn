using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class DacTrungSongSuoi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? MaDacTrungSongSuoi { get; set; }
        public int? MaSong_Suoi_KenhRach { get; set; }
        public int? MaLuuVucSong { get; set; }
        public double? DoDocLongSong { get; set; }
        public double? ChieuDaiSong { get; set; }
        public double? HeSoDongChay { get; set; }
        public double? ModulDongChay { get; set; }
        public double? LuuLuongDongChay { get; set; }
        public string? DienBienLongSong_Suoi { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaSong_Suoi_KenhRach ")]
        public virtual Song_Suoi_KenhRach? Song_Suoi_KenhRach { get; set; }
    }
}
