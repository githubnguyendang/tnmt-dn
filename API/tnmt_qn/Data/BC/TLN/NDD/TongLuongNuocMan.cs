using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class TongLuongNuocMan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTongLuongNuocMan { get; set; }
        public int? MaTangChuaNuoc { get; set; }
        public double? DienTichPhanBoCuaNuocMan { get; set; }
        public double? TruLuongNuocMan { get; set; }
        public double? ChieuSauPhanBoTu { get; set; }
        public double? ChieuSauPhanBoDen { get; set; }
        public string? GhiChu { get; set; }
        //tạo  khoá ngoại
        [ForeignKey("MaTangChuaNuoc ")]
        public virtual QLC_TangChuaNuoc? QLC_TangChuaNuoc { get; set; }
    }
}
