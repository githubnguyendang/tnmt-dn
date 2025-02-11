using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class ThongTinVeTruLuongNuoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? MaThongTinVeTruLuong { get; set; }
        public int? MaCt { get; set; }
        public double? TruLuongHienCo { get; set; }
        public double? TruLuongCoTheKhaiThac { get; set; }
        public double? TruLuongDaKhaiThac { get; set; }
        public DateTime? ThoiGianBaoCaoTruLuongDaKhaiThac { get; set; }
        //tạo  khoá ngoại
        [ForeignKey("MaCt ")]
        public virtual QLC_CongTrinh? QLC_CongTrinh { get; set; }
    }
}
