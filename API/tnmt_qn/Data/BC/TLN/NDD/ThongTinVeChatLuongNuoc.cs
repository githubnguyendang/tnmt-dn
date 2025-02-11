using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class ThongTinVeChatLuongNuoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaThongTinVeChatLuongNuoc { get; set; }
        public int? MaCt { get; set; }
        public int? MaChiTieu { get; set; }
        public string? ChatLuongNuocBanDau { get; set; }
        public string? ChatLuongNuocHienTai { get; set; }
        public DateTime? ThoiGianQuanTracChatLuongNuocHienTai { get; set; }
        public string? MucDoONhiemNuoc { get; set; }
        public string? NguyenNhanONhiemNuoc { get; set; }
        public string? GiaiPhapKhacPhucONhiemNuoc { get; set; }
        //tạo  khoá ngoại
        [ForeignKey("MaCt ")]
        public virtual QLC_CongTrinh? QLC_CongTrinh { get; set; }

        [ForeignKey("MaChiTieu ")]
        public virtual ThongTinVeCacChiTieuPhanTichCLN? ThongTinVeCacChiTieuPhanTichCLN { get; set; }
    }
}
