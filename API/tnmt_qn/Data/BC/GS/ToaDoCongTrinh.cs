using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class ToaDoCongTrinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaToaDoCongTrinh { get; set; }
        public int? MaThongTinCongTrinh { get; set; }
        public string? ToaDoX_CT { get; set; }
        public string? ToaDoY_CT { get; set; }
        public string? ToaDoLat_CT { get; set; }
        public DateTime? ToaDoLng_CT { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaThongTinCongTrinh ")]
        public virtual ThongTinCongTrinh? ThongTinCongTrinh { get; set; }
    }
}
