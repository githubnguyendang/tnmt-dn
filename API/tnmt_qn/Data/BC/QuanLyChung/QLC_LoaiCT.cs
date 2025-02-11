using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class QLC_LoaiCT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaLoaiCT { get; set; }
        public string? TenLoaiCT { get; set; }
        public string? KyHieuLoaiCT { get; set; }

        public virtual ICollection<QLC_CongTrinh>? QLC_CongTrinh { get; set; }
    }
}
