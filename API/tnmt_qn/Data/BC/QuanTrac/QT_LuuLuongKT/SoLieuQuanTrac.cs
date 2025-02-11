using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class SoLieuQuanTrac
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaSoLieuQuanTrac { get; set; }
        public int? MaThongTinCongTrinh { get; set; }
        public double? LuuLuongKTLonNhat { get; set; }
        public double? GiaTriLuuLuongKhaiThac { get; set; }


        //tạo  khoá ngoại
        [ForeignKey("MaThongTinCongTrinh ")]
        public virtual QLC_CongTrinh? QLC_CongTrinh { get; set; }
    }
}
