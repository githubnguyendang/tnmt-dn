using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class BieuMauSoSau
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? LuuVucSong { get; set; }
        public double? SLHoChua { get; set; }
        public double? DungTichToanBo { get; set; }
        public double? DungTichHuuich { get; set; }
        public double? DungTichPhongLu { get; set; }
        public double? DungTichTichDuoc { get; set; }
        public string? GhiChu { get; set; }
    }
}
