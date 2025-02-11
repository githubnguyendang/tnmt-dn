using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class CongTrinhHoChua
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaCongTrinhHoChua { get; set; }
        public int? MaPhanLoaiHoChuaTheoMDSD { get; set; }
        public string? TenCtHoChua { get; set; }
        public double? ToaDoX_Hochua { get; set; }
        public double? ToaDoY_Hochua { get; set; }
        public string? DiaDiemCtHoChua { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaPhanLoaiHoChuaTheoMDSD ")]
        public virtual PhanLoaiHoChuaTheoMDSD? PhanLoaiHoChuaTheoMDSD { get; set; }

        public virtual ThongTinCongTrinhHoChua? ThongTinCongTrinhHoChua { get; set; }
        public virtual CheDoQuanTracMucNuoc? CheDoQuanTracMucNuoc { get; set; }
        public virtual CacCapBaoDongMucNuocLu? CacCapBaoDongMucNuocLu { get; set; }
        public virtual GiaTriMucNuocQuanTrac? GiaTriMucNuocQuanTrac { get; set; }
        public virtual ThongSoThietKeCuaMucNuoc? ThongSoThietKeCuaMucNuoc { get; set; }
        public virtual HangMucDapTran? HangMucDapTran { get; set; }
        public virtual ThongSoDapTran? ThongSoDapTran { get; set; }
        public virtual HangMucNhaMay? HangMucNhaMay { get; set; }
        public virtual GiaTriLuuLuongXaQuaNhaMay? GiaTriLuuLuongXaQuaNhaMay { get; set; }
    }
}
