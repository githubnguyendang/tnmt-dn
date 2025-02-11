using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class CLNMatTheoWQI
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? MaChatLuongNuocMat { get; set; }
        public int? MaSong_Suoi_KenhRach { get; set; }
        public int? MaLuuVucSong { get; set; }
        public string? TenSong_Suoi { get; set; }
        public DateTime? ThoiGianDanhGia { get; set; }
        public double? GiaTriWqi { get; set; }

        [ForeignKey("MaSong_Suoi_KenhRach ")]
        public virtual Song_Suoi_KenhRach? Song_Suoi_KenhRach { get; set; }

        [ForeignKey("MaLuuVucSong ")]
        public virtual TLN_LuuVucSong? TLN_LuuVucSong { get; set; }
    }
}

