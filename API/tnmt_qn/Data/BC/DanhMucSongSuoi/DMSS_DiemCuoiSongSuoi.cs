using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class DMSS_DiemCuoiSongSuoi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDiemCuoiSong_Suoi { get; set; }
        public double? DiemCuoiSong_Suoi_ToaDoX { get; set; }
        public double? DiemCuoiSong_Suoi_ToaDoY { get; set; }
        public string? DiemCuoiSong_Suoi_Thon_Ban { get; set; }
        public string? DiemCuoiSong_Suoi_Xa_Phuong_ThiTran { get; set; }
        public string? DiemCuoiSong_Suoi_Huyen_ThanhPho { get; set; }
    }
}
