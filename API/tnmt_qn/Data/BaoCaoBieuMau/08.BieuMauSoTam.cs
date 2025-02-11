using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class BieuMauSoTam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TangChuaNuoc { get; set; }
        public string? SLGieng { get; set; }
        public double? MucNuocMaxKyTruoc { get; set; }
        public double? MucNuocMaxKyBaoCao { get; set; }
        public double? MucNuocMediumKyTruoc { get; set; }
        public double? MucNuocMediumKyBaoCao { get; set; }
        public double? MucNuocMinKyTruoc { get; set; }
        public double? MucNuocMinKyBaoCao { get; set; }
        public string? GhiChu { get; set; }
    }
}
