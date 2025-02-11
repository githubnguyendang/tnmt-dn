using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class CheDoQuanTracLuuLuongXaQuaNhaMay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? MaCheDoQuanTracLuuLuongXaQuaNhaMay { get; set; }
        public int? MaHangMucNhaMay { get; set; }
        public int? QuanTracTrongMuaLu { get; set; }
        public int? QuanTracTruocMuaLu { get; set; }
        public int? QuanTracSauMuaLu { get; set; }
        public int? QuanTracTrongMuaCan { get; set; }
        public int? DieuKienThoiTietBinhThuong { get; set; }
        public int? BaoKhanCap { get; set; }


        //tạo  khoá ngoại
        [ForeignKey("MaHangMucNhaMay ")]
        public virtual HangMucNhaMay? HangMucNhaMay { get; set; }
    }
}
