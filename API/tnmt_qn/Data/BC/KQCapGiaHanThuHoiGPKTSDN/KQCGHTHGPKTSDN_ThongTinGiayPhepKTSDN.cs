using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class KQCGHTHGPKTSDN_ThongTinGiayPhepKTSDN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaThongTinGiayPhepKTSDN { get; set; }
        public int? MaCongTrinh { get; set; }
        public string? SoGiayPhepKTSDN { get; set; }
        public string? TenGiayPhepKTSDN { get; set; }
    }
}
