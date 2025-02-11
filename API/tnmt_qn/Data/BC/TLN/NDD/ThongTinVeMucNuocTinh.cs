using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class ThongTinVeMucNuocTinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTtVeMucNuocTinh { get; set; }
        public int? MaCt { get; set; }
        public double? MucNuocTinhBanDau { get; set; }
        public double? MucNuocTinhHienTai { get; set; }
        public DateTime? ThoiGianQuanTracMucNuocTinhHienTai { get; set; }
        public double? LuongSuyGiamMucNuocTinh { get; set; }
        public double? TocDoSuyGiamMucNuocTinh { get; set; }
        //tạo  khoá ngoại
        [ForeignKey("MaCt ")]
        public virtual QLC_CongTrinh? QLC_CongTrinh { get; set; }
    }
}
