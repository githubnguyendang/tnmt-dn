using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class ThongSoVanHanhThucTe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaThongSoVanHanhThucTe { get; set; }
        public int? MaThongTinCongTrinh { get; set; }
        public string? LuuLuongKhaiThacThucTe { get; set; }
        public string? LuuLuongKhaiThacYeuCau { get; set; }
        public string? LuuLuongKhaiThacChenhLech { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaThongTinCongTrinh ")]
        //nối khoá ngoại với khoá chính của bảng thôgn tin công trình
        public virtual ThongTinCongTrinh? ThongTinCongTrinh { get; set; }

        public virtual ThongSoKyThuatCongTrinh? ThongSoKyThuatCongTrinh { get; set; }
    }
}
