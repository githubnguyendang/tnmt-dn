using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class CheDoQuanTracLuuLuongDongChayToiThieu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaCheDoQuanTracLuuLuongDongChayToiThieu { get; set; }
        public int? MaCongTrinhQuanTracLuuLuong { get; set; }
        public double? QuanTracLuuLuongXaDuyTriDcttVaoMuaLu { get; set; }
        public double? QuanTracLuuLuongXaDuyTriDcttVaoMuaCan { get; set; }


        //tạo  khoá ngoại
        [ForeignKey("MaCongTrinhQuanTracLuuLuong ")]
        public virtual CongTrinhQuanTracLuuLuongXaDCTT? CongTrinhQuanTracLuuLuong { get; set; }
    }
}
