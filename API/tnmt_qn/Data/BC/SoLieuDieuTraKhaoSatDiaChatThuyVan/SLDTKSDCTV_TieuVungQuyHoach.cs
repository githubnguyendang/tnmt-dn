using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class SLDTKSDCTV_TieuVungQuyHoach
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTieuVungQuyHoach { get; set; }
        public string? TieuVungQuyHoach { get; set; }
    }
}
