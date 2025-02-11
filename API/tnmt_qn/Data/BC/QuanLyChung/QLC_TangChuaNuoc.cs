using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class QLC_TangChuaNuoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTangChuaNuoc { get; set; }
        public string? TenTCN { get; set; }
        public string? KyHieuTCN { get; set; }
        public virtual SoLuongNDD? SoLuongNDD { get; set; }
        public virtual TongLuongNuocMan? TongLuongNuocMan { get; set; }

        public virtual ICollection<QLC_CongTrinh>? QLC_CongTrinh { get; set; }
    }
}
