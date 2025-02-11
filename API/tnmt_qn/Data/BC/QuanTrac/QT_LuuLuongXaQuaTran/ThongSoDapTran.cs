using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class ThongSoDapTran
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaThongSoDapTran { get; set; }
        public int? MaHangMucDapTran { get; set; }
        public int? MaCongTrinhHoChua { get; set; }
        public string? HinhThucDapTran { get; set; }
        public string? KetCauDap { get; set; }
        public double? CaoTrinhNguongTran { get; set; }
        public int? SoKhoangTran { get; set; }
        public double? ChieuDaiKhoangTran { get; set; }
        public double? ChieuCaoDapTran { get; set; }
        public double? BeRongKhoanTran { get; set; }
        public double? CaoTrinhDinhTran { get; set; }
        public double? CaoDoMuiPhun { get; set; }
        public double? ChieuCaoDapLonNhat { get; set; }
        public string? KhaNangXaTranUngVoiMnlkt { get; set; }
        public string? KhaNangXaTranUngVoiMnltk { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaHangMucDapTran")]
        public virtual HangMucDapTran? HangMucDapTran { get; set; }

        [ForeignKey("MaCongTrinhHoChua")]
        public virtual CongTrinhHoChua? CongTrinhHoChua { get; set; }
    }
}
