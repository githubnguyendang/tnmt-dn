using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class CheDoGiamSatLuuLuongXaQuaNhaMay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaCheDoGiamSatLuuLuongXaQuaNhaMay { get; set; }
        public int? MaHangMucNhaMay { get; set; }
        public bool? GiamSatTuDong { get; set; }
        public bool? GiamSatDinhKy { get; set; }
        public bool? GiamSatDinhKyMuaLu { get; set; }
        public bool? GiamSatDinhKyMuaCan { get; set; }


        //tạo  khoá ngoại

        [ForeignKey("MaHangMucNhaMay ")]
        public virtual HangMucNhaMay? HangMucNhaMay { get; set; }
    }
}
