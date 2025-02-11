using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class SoLieuMua
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? MaSoLieuMua { get; set; }
        public int? MaPhuongPhapTinhMua { get; set; }
        public int? MaTramQuanTracLuongMua { get; set; }
        public int? SoLieuMuaGio { get; set; }
        public int? SoLieuMuaNgay { get; set; }
        public int? SoLieuMuaThang { get; set; }
        public int? SoLieuMuaNam { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaPhuongPhapTinhMua ")]
        public virtual PhuongPhapTinhMua? PhuongPhapTinhMua { get; set; }

        [ForeignKey("MaTramQuanTracLuongMua ")]
        public virtual TramQuanTracLuongMua? TramQuanTracLuongMua { get; set; }

        public virtual TongLuongMua? TongLuongMua { get; set; }
    }
}
