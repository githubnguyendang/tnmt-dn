using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class SLCLNMNDD_WMuaLu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaSoTongLuongNuocMuaLu { get; set; }
        public int? MaLoaiNuoc { get; set; }
        public int? MaLuuVuc { get; set; }
        public double? TongLuongNuocTrungBinhMuaLu { get; set; }
        public double? TongLuongNuocMuaLuKyTruoc { get; set; }
        public double? TongLuongNuocMuaLuKyBaoCao { get; set; }
        public double? TongLuongNuocMuaLuThayDoi { get; set; }
    }
}
