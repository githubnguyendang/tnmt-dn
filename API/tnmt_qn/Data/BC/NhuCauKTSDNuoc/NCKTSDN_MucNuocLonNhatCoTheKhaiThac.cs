using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class NCKTSDN_MucNuocLonNhatCoTheKhaiThac
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaMucNuocLonNhatCoTheKhaiThac { get; set; }
        public string? SoHieuLoKhoan { get; set; }
        public string? ViTriKhaiThac { get; set; }
        public double? ChieuSauLoKhoan { get; set; }
        public double? MucNuocTinh { get; set; }
        public double? GioiHanChieuSauMucNuocKhaiThac { get; set; }
        public double? ChieuSauMucNuocLonNhatKhaiThac { get; set; }
    }
}
