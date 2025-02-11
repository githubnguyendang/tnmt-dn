using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class TramQuanTracLuongMua
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTramQuanTracLuongMua { get; set; }
        public int? MaLoaiTramQuanTracLuongMua { get; set; }
        public string? TenTramQuanTracLuongMua { get; set; }
        public double? ToaDoTramX { get; set; }
        public double? ToaDoTramY { get; set; }
        public string? DiaChiXayDuengTramQuanTrac { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaLoaiTramQuanTracLuongMua ")]
        public virtual LoaiTramQuanTracLuongMua? LoaiTramQuanTracLuongMua { get; set; }

        public virtual SoLieuMua? SoLieuMua { get; set; }
        public virtual TongLuongMua? TongLuongMua { get; set; }
        public virtual TrangThaiQuanTrac? TrangThaiQuanTrac { get; set; }
    }
}
