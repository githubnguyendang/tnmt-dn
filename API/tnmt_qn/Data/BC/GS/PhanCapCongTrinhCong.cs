using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class PhanCapCongTrinhCong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaPhanCapCongTrinhCong { get; set; }
        public int? MaThongTinCongTrinh { get; set; }
        public string? CapCongTrinhCong { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaThongTinCongTrinh ")]
        public virtual ThongTinCongTrinh? ThongTinCongTrinh { get; set; }
    }
}
