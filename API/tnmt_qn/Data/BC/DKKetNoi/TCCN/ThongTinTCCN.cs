using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class ThongTinTCCN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaThongTinTCCN { get; set; }
        public string? TenTCCN { get; set; }
        public string? DiaChiTCCN { get; set; }
        public string? ThongTinLienHeTCCN { get; set; }
    }
}
