using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class DuLieuQuanTracCuaCTXaThai
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDuLieuQuanTracCongTrinhXaThai { get; set; }
        public int? MaThongTinCongTrinh { get; set; }
        public double? LuuLuongNuocThaiSauXuLy { get; set; }
        public double? ChatLuongNuocThaiSauXuLy { get; set; }
        public double? LuuLuongNuocThaiTaiNguonTiepNhan { get; set; }
        public string? TrangThaiVH { get; set; }


        //tạo  khoá ngoại
        [ForeignKey("MaThongTinCongTrinh ")]
        public virtual QLC_CongTrinh? QLC_CongTrinh { get; set; }
    }
}
