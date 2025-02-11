using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class KKTNN_NuocDuoiDat_ChatLuong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? IdXa { get; set; }
        public int? IdHuyen { get; set; }
        public double? pHMax { get; set; }
        public double? pHMin { get; set; }
        public double? DoCungMax { get; set; }
        public double? DoCungMin { get; set; }
        public double? NitratMax { get; set; }
        public double? NitratMin { get; set; }
        public double? AmoniMax { get; set; }
        public double? AmoniMin { get; set; }
        public double? SulfatMax { get; set; }
        public double? SulfatMin { get; set; }
        public double? AsenMax { get; set; }
        public double? AsenMin { get; set; }
        public bool? DaXoa { get; set; }
    }
}
