using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class HSKTCT_FilePDFHSKTCongTrinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaFilePDFHoSoKyThuatCongTrinh { get; set; }
        public string? CacTaiLieuHsktTramDuoiDangFilePDF { get; set; }
    }
}
