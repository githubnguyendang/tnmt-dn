using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class GiaTriQuanTracLuuLuongXaTran
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaGiaTriQuanTracLuuLuongXaTran { get; set; }
        public int? MaHangMucDapTran { get; set; }
        public double? MucNuocHoChua { get; set; }
        public double? MucNuocThuongLuu { get; set; }
        public double? MucNuocHaLuu { get; set; }
        public double? LuuLuongNuocVeHo { get; set; }
        public double? LuuLuongXaQuaTranLonNhat { get; set; }
        public double? LuuLuongXaQuaTranNhoNhat { get; set; }
        public double? LuuLuongXaQuaTranTrungBinh { get; set; }
        public DateTime? ThoiGianBatDauXaTran { get; set; }
        public DateTime? ThoiGianKetThucXaTran { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaHangMucDapTran")]
        public virtual HangMucDapTran? HangMucDapTran { get; set; }
    }
}
