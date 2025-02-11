using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class ThongTinVeHoatDongCuaCongTrinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaThongTinVeHoatDongCuaCongTrinh { get; set; }
        public int? MaCt { get; set; }
        public string? TinhTrangHoatDong { get; set; }
        public DateTime? NgayBatDauHoatDong { get; set; }
        public DateTime? NgayNgungHoatDong { get; set; }
        public string? LyDoNgungHoatDong { get; set; }
        //tạo  khoá ngoại
        [ForeignKey("MaCt ")]
        public virtual QLC_CongTrinh? QLC_CongTrinh { get; set; }
    }
}
