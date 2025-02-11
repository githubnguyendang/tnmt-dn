using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class CongTrinhQuanTracLuuLuongXaDCTT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaCongTrinhQuanTracLuuLuong { get; set; }
        public int? MaCongTrinhHoChua { get; set; }
        public string? TenCtQuanTracXaDuyTriDctt { get; set; }
        public float? ToaDoX { get; set; }
        public float? ToaDoY { get; set; }
        public string? CapCongTrinh { get; set; }
        public string? NguonNuocKhaiThac { get; set; }
        public float? GiaTriDcttDoiVoiSongSuoi { get; set; }
        public float? GiaTriDcttHaLuuHoChua { get; set; }
        public string? DiaDiemCongTrinh_Xa { get; set; }
        public string? DiaDiemCongTrinh_Huyen { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaCongTrinhHoChua ")]
        public virtual CongTrinhHoChua? CongTrinhHoChua { get; set; }

        public virtual CheDoQuanTracLuuLuongDongChayToiThieu? CheDoQuanTracLuuLuongDongChayToiThieu { get; set; }
        public virtual GiaTriQuanTracLuuLuongXa? GiaTriQuanTracLuuLuongXa { get; set; }
        public virtual ThongTinChatLuongNuoc? ThongTinChatLuongNuoc { get; set; }
        public virtual ThongTinLuuLuongXaCuaCt? ThongTinLuuLuongXaCuaCt { get; set; }
    }
}
