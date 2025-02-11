using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class ThongTinChatLuongNuoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? MaThongTinChatLuongNuoc { get; set; }
        public int? MaCongTrinhQuanTracLuuLuong { get; set; }
        public string? NhietDo { get; set; }
        public double? Ph { get; set; }
        public double? Bod5 { get; set; }
        public double? Cod { get; set; }
        public double? Do { get; set; }
        public double? Nh4 { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaCongTrinhQuanTracLuuLuong ")]
        public virtual CongTrinhQuanTracLuuLuongXaDCTT? CongTrinhQuanTracLuuLuong { get; set; }
        public virtual GiaTriQuanTracLuuLuongXa? GiaTriQuanTracLuuLuongXa { get; set; }

    }
}
