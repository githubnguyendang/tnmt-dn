using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class ThongSoLtd
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? IdDoanSong { get; set; }
        public double? pHTd { get; set; }
        public double? BODTd { get; set; }
        public double? CODTd { get; set; }
        public double? TSSTd { get; set; }
        public double? TongPTd { get; set; }
        public double? TongNTd { get; set; }
        public double? TongColiformTd { get; set; }
        public double? AmoniTd { get; set; }

        [ForeignKey("IdDoanSong")]
        public virtual DoanSong? DoanSong { get; set; }
    }
}
