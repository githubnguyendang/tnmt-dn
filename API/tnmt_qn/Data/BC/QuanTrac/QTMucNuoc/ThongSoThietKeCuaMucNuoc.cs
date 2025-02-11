using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class ThongSoThietKeCuaMucNuoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaThongSoThietKeCuaMucNuoc { get; set; }
        public int? MaCongTrinhHoChua { get; set; }
        public double? MucNuocChet { get; set; }
        public double? MucNuocDangBinhThuong { get; set; }
        public double? MucNuocPhongLu { get; set; }
        public double? MucNuocLuKiemTra { get; set; }
        public double? MucNuocLuThietKe { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaCongTrinhHoChua")]
        public virtual CongTrinhHoChua? CongTrinhHoChua { get; set; }
    }
}
