using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class SLCLNMNDD_WMuaCan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaSoTongLuongNuocMuaCan { get; set; }
        public int? MaLoaiNuoc { get; set; }
        public int? MaLuuVuc { get; set; }
        public double? TongLuongNuocTrungBinhMuaCan { get; set; }
        public double? TongLuongNuocMuaCanKyTruoc { get; set; }
        public double? TongLuongNuocMuaCanKyBaoCao { get; set; }
        public double? TongLuongNuocMuaCanThayDoi { get; set; }
        public double? KhoangThoiGianDuLieuThuThap { get; set; }
    }
}
