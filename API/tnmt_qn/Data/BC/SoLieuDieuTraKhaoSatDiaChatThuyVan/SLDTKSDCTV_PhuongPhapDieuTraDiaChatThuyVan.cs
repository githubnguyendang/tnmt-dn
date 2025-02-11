using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class SLDTKSDCTV_PhuongPhapDieuTraDiaChatThuyVan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaPhuongPhapDieuTraDiaChatThuyVan { get; set; }
        public string? PhuongPhapVienTham { get; set; }
        public string? PhuongPhapDiaVatLy { get; set; }
        public string? PhuongPhapDiaChat { get; set; }
    }
}
