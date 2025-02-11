using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class TramBomSanXuat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTramBomSanXuat { get; set; }
        public int? MaThongTinCongTrinh { get; set; }
        public string? MaToaDoCongTrinh { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaThongTinCongTrinh ")]
        public virtual ThongTinCongTrinh? ThongTinCongTrinh { get; set; }
    }
}
