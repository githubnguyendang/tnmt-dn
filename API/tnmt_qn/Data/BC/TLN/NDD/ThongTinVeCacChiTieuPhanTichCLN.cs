using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class ThongTinVeCacChiTieuPhanTichCLN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaChiTieu { get; set; }
        public string? TenChiTieu { get; set; }
        public string? DonVi { get; set; }
        public string? TieuChuan { get; set; }
    }
}
