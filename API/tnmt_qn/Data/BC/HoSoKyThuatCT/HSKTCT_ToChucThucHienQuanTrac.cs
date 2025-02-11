using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class HSKTCT_ToChucThucHienQuanTrac
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaToChucThucHien { get; set; }
        public string? TenToChucThucHien { get; set; }
    }
}
