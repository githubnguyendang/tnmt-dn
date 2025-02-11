using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class GiaTriLuuLuongXaQuaNhaMay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaGiaTriLuuLuongXaQuaNhaMay { get; set; }
        public int? MaHangMucNhaMay { get; set; }
        public int? MaCongTrinhHoChua { get; set; }
        public double? LuuLuongXaQuaNhaMay { get; set; }
        public DateTime? NgayGhiNhanLuuLuongXaQuaNhaMay { get; set; }
        public DateTime? GioGhiNhanLuuLuongXaQuaNhaMay { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaCongTrinhHoChua ")]
        public virtual CongTrinhHoChua? CongTrinhHoChua { get; set; }

        [ForeignKey("MaHangMucNhaMay ")]
        public virtual HangMucNhaMay? HangMucNhaMay { get; set; }
    }
}
