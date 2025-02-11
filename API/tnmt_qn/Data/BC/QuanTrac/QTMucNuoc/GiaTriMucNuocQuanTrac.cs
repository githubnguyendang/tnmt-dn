using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class GiaTriMucNuocQuanTrac
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaGiaTriMucNuocQuanTrac { get; set; }
        public int? MaCongTrinhHoChua { get; set; }
        public int? MaThongTinCongTrinh { get; set; }
        public double? MucNuocHo { get; set; }
        public double? MucNuocThuongLuu { get; set; }
        public double? MucNuocHaLuu { get; set; }
        public DateTime? ThoiGianQuanTracMucNuoc { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaCongTrinhHoChua")]
        public virtual CongTrinhHoChua? CongTrinhHoChua { get; set; }

        [ForeignKey("MaThongTinCongTrinh")]
        public virtual ThongTinCongTrinh? ThongTinCongTrinh { get; set; }
    }
}
