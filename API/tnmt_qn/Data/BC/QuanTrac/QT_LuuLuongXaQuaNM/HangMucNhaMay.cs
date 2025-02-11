using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class HangMucNhaMay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHangMucNhaMay { get; set; }
        public int? MaCongTrinhHoChua { get; set; }
        public double? ToaDoX_NhaMay { get; set; }
        public double? ToaDoY_NhaMay { get; set; }
        public string? DiaDiemDatNhaMay_Xa { get; set; }
        public string? DiaDiemDatNhaMay_Huyen { get; set; }


        //tạo  khoá ngoại
        [ForeignKey("MaCongTrinhHoChua ")]
        public virtual CongTrinhHoChua? CongTrinhHoChua { get; set; }

        public virtual CheDoGiamSatLuuLuongXaQuaNhaMay? CheDoGiamSatLuuLuongXaQuaNhaMay { get; set; }
        public virtual CheDoQuanTracLuuLuongXaQuaNhaMay? CheDoQuanTracLuuLuongXaQuaNhaMay { get; set; }
        public virtual GiaTriLuuLuongXaQuaNhaMay? GiaTriLuuLuongXaQuaNhaMay { get; set; }
        public virtual ThongTinNhaMay? ThongTinNhaMay { get; set; }

    }
}
