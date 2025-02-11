using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class SLDTKSDCTV_SoLieuDieuTraNDD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaSoLieuDieuTra { get; set; }
        public int? SoHieuLoKhoan { get; set; }
        public double? ChieuSau { get; set; }
        public double? ChieuDayTangChuaNuoc { get; set; }
        public double? MucNuocTinh { get; set; }
        public double? MucNuocHaThap { get; set; }
        public double? LuuLuongThucHut_LS { get; set; }
        public string? LuuLuongThucHut_m3Ngay { get; set; }
        public string? TruLuongKhaiThac { get; set; }
    }
}
