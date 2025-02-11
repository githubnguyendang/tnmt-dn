using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class Ao_Ho_Dam_Pha
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaAo_Ho_Dam_Pha { get; set; }
        public int MaLuuVucSong { get; set; }
        public string? TenAo_Ho_Dam_Pha { get; set; }
        public string? DiaDiemAo_Ho_Dam_Pha { get; set; }
        public string? NguonNuocKhaiThac { get; set; }
        public double? DienTichNuocMat { get; set; }
        public double? DungTichToanBo { get; set; }
        public double? DungTichHuuIch { get; set; }
        public string? MucDichSuDung { get; set; }
        //tạo  khoá ngoại
        [ForeignKey("MaLuuVucSong ")]
        public virtual TLN_LuuVucSong? TLN_LuuVucSong { get; set; }
    }
}
