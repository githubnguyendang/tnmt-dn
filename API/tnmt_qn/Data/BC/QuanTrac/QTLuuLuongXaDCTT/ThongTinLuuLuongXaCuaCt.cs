using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class ThongTinLuuLuongXaCuaCt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaThongTinLuuLuongXaCuaCt { get; set; }
        public int? MaCongTrinhQuanTracLuuLuong { get; set; }
        public double? LuuLuongXaLonNhatDuyTriDctt { get; set; }
        public double? LuuLuongXaNhoNhatDuyTriDctt { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaCongTrinhQuanTracLuuLuong ")]
        public virtual CongTrinhQuanTracLuuLuongXaDCTT? CongTrinhQuanTracLuuLuong { get; set; }


    }
}
