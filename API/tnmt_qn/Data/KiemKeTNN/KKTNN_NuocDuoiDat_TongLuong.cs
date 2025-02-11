using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class KKTNN_NuocDuoiDat_TongLuong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? IdTangChuaNuoc { get; set; }
        public float? NuocNgot_DienTichPhanBo { get; set; }
        public int? NuocNgot_IdXa { get; set; }
        public int? NuocNgot_IdHuyen { get; set; }
        public double? NuocNgot_TLTiemNang { get; set; }
        public double? NuocNgot_TLCoTheKhaiThac { get; set; }
        public double? NuocMan_DienTichPhanBo { get; set; }
        public int? NuocMan_IdXa { get; set; }
        public int? NuocMan_IdHuyen { get; set; }
        public double? NuocMan_TruLuong { get; set; }
        public bool? DaXoa { get; set; }
        [ForeignKey("IdTangChuaNuoc")]
        public virtual TangChuaNuoc? TangChuaNuoc { get; set; }
    }
}
