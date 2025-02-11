using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class ThongTinNhaMay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? MaThongTinNhaMay { get; set; }
        public int? MaHangMucNhaMay { get; set; }
        public double? LuuLuongLonNhatQuaNhaMay { get; set; }
        public string? SoToMay { get; set; }
        public double? CongSuatMoiToMay { get; set; }
        public double? KichThuocNhaMay { get; set; }
        public double? CaoTrinhSanLapMay { get; set; }
        public double? CaoTrinhSanChongLuNhaMay { get; set; }
        public double? LuuLuongThietKe { get; set; }
        public double? LuuLuongDamBao { get; set; }
        public double? CongSuatDamBao { get; set; }
        public double? CongSuatLapMay { get; set; }


        //tạo  khoá ngoại

        [ForeignKey("MaHangMucNhaMay ")]
        public virtual HangMucNhaMay? HangMucNhaMay { get; set; }
    }
}
