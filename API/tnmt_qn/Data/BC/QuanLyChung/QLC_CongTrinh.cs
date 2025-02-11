using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class QLC_CongTrinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaCT { get; set; }
        public int? MaTangChuaNuoc { get; set; }
        public int? MaLoaiCT { get; set; }
        public int? MaThongTinTCCN { get; set; }
        public string? TenCT { get; set; }
        public string? KyHieuCT { get; set; }
        public string? DiaChiCT { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }

        [ForeignKey("MaLoaiCT ")]
        public virtual QLC_LoaiCT? QLC_LoaiCT { get; set; }

        [ForeignKey("MaTangChuaNuoc ")]
        public virtual QLC_TangChuaNuoc? QLC_TangChuaNuoc { get; set; }

        [ForeignKey("MaThongTinTCCN ")]
        public virtual ThongTinTCCN? ThongTinTCCN { get; set; }

        public virtual ThongTinVeMucNuocTinh? ThongTinVeMucNuocTinh { get; set; }
        public virtual ThongTinVeTruLuongNuoc? ThongTinVeTruLuongNuoc { get; set; }
        public virtual ThongTinVeChatLuongNuoc? ThongTinVeChatLuongNuoc { get; set; }
        public virtual ThongTinVeHoatDongCuaCongTrinh? ThongTinVeHoatDongCuaCongTrinh { get; set; }
        public virtual ThongTinKetNoi? ThongTinKetNoi { get; set; }
        public virtual DuLieuKetNoi? DuLieuKetNoi { get; set; }
        public virtual LichSuKetNoi? LichSuKetNoi { get; set; }
        public virtual TrangThaiTaiKhoan? TrangThaiTaiKhoan { get; set; }
        public virtual TaiKhoanKetNoi? TaiKhoanKetNoi { get; set; }
    }
}
