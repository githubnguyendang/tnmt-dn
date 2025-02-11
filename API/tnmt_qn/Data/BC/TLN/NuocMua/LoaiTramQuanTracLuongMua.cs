using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class LoaiTramQuanTracLuongMua
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaLoaiTramQuanTracLuongMua { get; set; }
        public string? TenLoaiTram { get; set; }
        public string? KyHieuLoaiTram { get; set; }
        public string? GhiChu { get; set; }
        
        public virtual TramQuanTracLuongMua? TramQuanTracLuongMua { get; set; }
    }
}
