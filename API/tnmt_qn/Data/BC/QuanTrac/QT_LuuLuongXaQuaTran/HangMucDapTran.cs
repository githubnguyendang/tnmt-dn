using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class HangMucDapTran
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHangMucDapTran { get; set; }
        public int? MaCongTrinhHoChua { get; set; }
        public string? TenDapTran { get; set; }
        public double? ToaDoX_DapTran { get; set; }
        public double? ToaDoY_DapTran { get; set; }
        public string? DiaDienXayDungDapTran_Xa { get; set; }
        public string? DiaDienXayDungDapTran_Huyen { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaCongTrinhHoChua")]
        public virtual CongTrinhHoChua? CongTrinhHoChua { get; set; }

        public virtual PhanLoaiDapTran? PhanLoaiDapTran { get; set; }
        public virtual ThongSoDapTran? ThongSoDapTran { get; set; }
        public virtual GiaTriQuanTracLuuLuongXaTran? GiaTriQuanTracLuuLuongXaTran { get; set; }
    }
}
