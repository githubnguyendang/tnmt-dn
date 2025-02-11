using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class CT_ThongTin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? IdLoaiCT { get; set; }
        public int? IdSong { get; set; }
        public int? IdLuuVuc { get; set; }
        public int? IdTieuLuuVuc { get; set; }
        public int? IdTangChuaNuoc { get; set; }
        public string? TenCT { get; set; }
        public string? MaCT { get; set; }
        public string? ViTriCT { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public string? CapCT { get; set; }
        public int? NamBatDauVanHanh { get; set; }
        public string? NguonNuocKT { get; set; }
        public string? PhuongThucKT { get; set; }
        public string? ThoiGianKT { get; set; }
        public string? ThoiGianHNK { get; set; }
        public string? MucDichKT { get; set; }
        public string? MucDichHNK { get; set; }
        public string? MucDichhTD { get; set; }
        public string? QuyMoHNK { get; set; }
        public string? ThoiGianXD { get; set; }
        public int? SoLuongGiengKT { get; set; }
        public int? SoLuongGiengQT { get; set; }
        public int? SoDiemXaThai { get; set; }
        public int? SoLuongGieng { get; set; }
        public int? KhoiLuongCacHangMucTD { get; set; }
        public int? QKTThietKe { get; set; }
        public int? QKTThucTe { get; set; }
        public string? ViTriXT { get; set; }
        public string? ChuThich { get; set; }
        public string? TaiKhoan { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        // Navigation property to represent the relationship

        [ForeignKey("IdTangChuaNuoc")]
        public virtual TangChuaNuoc? TangChuaNuoc { get; set; }

        [ForeignKey("IdLoaiCT")]
        public virtual CT_Loai? LoaiCT { get; set; }

        [ForeignKey("IdLuuVuc")]
        public virtual LuuVucSong? LuuVuc { get; set; }

        public virtual CT_ThongSo? ThongSo { get; set; }
        public virtual ICollection<CT_HangMuc>? HangMuc { get; set; }
        public virtual ICollection<GP_ThongTin>? GiayPhep { get; set; }
        public virtual ICollection<LuuLuongTheoMucDich>? LuuLuongTheoMucDich { get; set; }
        public virtual ICollection<CT_ViTri>? CT_ViTri { get; set; }

        public virtual ICollection<ThanhTraKiemTra> ThanhTraKiemTra { get; set; } = new List<ThanhTraKiemTra>();
    }
}
