using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class Song_Suoi_KenhRach
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaSong_Suoi_KenhRach { get; set; }
        public int? MaLuuVucSong { get; set; }
        public string? TenSongSuoi_KenhRach { get; set; }
        public string? ViTriDauSongSuoi { get; set; }
        public double? ToaDoX_DauSong { get; set; }
        public double? ToaDoY_DauSong { get; set; }
        public string? ViTriCuoiSongSuoi { get; set; }
        public double? ToaDoX_CuoiSong { get; set; }
        public double? ToaDoY_CuoiSong { get; set; }
        //tạo  khoá ngoại
        [ForeignKey("MaLuuVucSong ")]
        public virtual TLN_LuuVucSong? TLN_LuuVucSong { get; set; }
    }
}
