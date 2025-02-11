using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Dto
{
    public class ThanhTraKiemTraDto
    {
        public int? Id { get; set; }
        public int? IdGP { get; set; }
        public int? IdCT { get; set; }
        public int? IdTCCN { get; set; }
        public string? SoVanBan { get; set; }
        public string? Dot { get; set; }
        public string? DonVi { get; set; }
        public DateTime? ThoiGan { get; set; }
        public double? TienPhat { get; set; }
        public string? GhiChu { get; set; }
        public string? TaiLieu { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        public CT_ThongTinDto? CT { get; set; }
        public GP_ThongTinDto? GP { get; set; }
        public ToChuc_CaNhanDto? TCCN { get; set; }
    }
}
