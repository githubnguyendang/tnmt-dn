using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class TLN_LuuVucSong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaLuuVucSong { get; set; }
        public string? TenLuuVucSong { get; set; }
        public string? ViTriHanhChinhCuaLVS { get; set; }
        public double? DienTichLuuVucSong { get; set; }

        public virtual Ao_Ho_Dam_Pha? Ao_Ho_Dam_Pha { get; set; }
        public virtual Song_Suoi_KenhRach? Song_Suoi_KenhRach { get; set; }
        public virtual DacTrungSongSuoi? DacTrungSongSuoi { get; set; }
        public virtual TongLuongDongChay? TongLuongDongChay { get; set; }
        public virtual CLNMatTheoWQI? CLNMatTheoWQI { get; set; }
    }
}

