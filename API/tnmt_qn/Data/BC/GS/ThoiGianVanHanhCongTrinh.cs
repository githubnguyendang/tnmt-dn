using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class ThoiGianVanHanhCongTrinh

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNamVanHanh { get; set; }
        public int MaThongTinCongTrinh { get; set; }
        public int? NamBatDauVanHanh { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaThongTinCongTrinh ")]
        public virtual ThongTinCongTrinh? ThongTinCongTrinh { get; set; }
    }
}
