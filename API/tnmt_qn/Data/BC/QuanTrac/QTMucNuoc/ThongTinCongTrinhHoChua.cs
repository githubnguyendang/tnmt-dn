using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class ThongTinCongTrinhHoChua
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaThongTinCongTrinh { get; set; }
        public int? MaCongTrinhHoChua { get; set; }
        public string? PhuongThucKhaiThac { get; set; }
        public string? CheDoKhaiThac { get; set; }
        public string? MucDichKhaiThac { get; set; }
        public double? DungTichChetCuaHoChua { get; set; }
        public double? DungTichToanBoHoChua { get; set; }
        public double? DungTichHuuIchCuaHoChua { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaCongTrinhHoChua")]
        public virtual CongTrinhHoChua? CongTrinhHoChua { get; set; }

        public virtual GiaTriMucNuocQuanTrac? GiaTriMucNuocQuanTrac { get; set; }
    }
}
