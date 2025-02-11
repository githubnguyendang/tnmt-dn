using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class ThongTinCongTrinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaThongTinCongTrinh{ get; set; }
        public int? TenCongTrinhKhaiThac{ get; set; }
        public string? DiaDiemCongTrinh_Xa { get; set; }
        public string? DiaDiemCongTrinh_Huyen { get; set; }
        public string? SoCongTrinh{ get; set; }

        public virtual CheDoKhaiThacCongTrinh? CheDoKhaiThacCongTrinh { get; set; }
        public virtual PhanCapCongTrinhCong? PhanCapCongTrinhCong { get; set; }
        public virtual ToaDoCongTrinh? ToaDoCongTrinh { get; set; }
        public virtual TramBomSanXuat? TramBomSanXuat { get; set; }
        public virtual TramBomSinhHoat? TramBomSinhHoat { get; set; }
        public virtual ThongSoKyThuatCongTrinh? ThongSoKyThuatCongTrinh { get; set; }
        public virtual ThoiGianVanHanhCongTrinh? ThoiGianVanHanhCongTrinh { get; set; }

    }
}
