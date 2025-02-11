using tnmt_qn.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace tnmt_qn.Dto
{
    public class CT_ThongTinDto
    {
        public int? Id { get; set; }
        public int? IdLoaiCT { get; set; } = null;
        public int? IdSong { get; set; } = null;
        public int? IdLuuVuc { get; set; } = null;
        public int? IdTieuLuuVuc { get; set; } = null;
        public int? IdTangChuaNuoc { get; set; } = null;
        public string? TenCT { get; set; }
        public string? MaCT { get; set; }
        public string? ViTriCT { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public string? CapCT { get; set; }
        public int? NamBatDauVanHanh { get; set; }
        public string? NguonNuocKT { get; set; }
        public string? MucDichKT { get; set; }
        public string? PhuongThucKT { get; set; }
        public string? ThoiGianKT { get; set; }
        public string? ThoiGianHNK { get; set; }
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
        public string? TaiKhoan { get; set; }
        public string? ChuThich { get; set; }
        public bool? DaXoa { get; set; } = false;

        public List<CT_HangMucDto>? hangmuc { get; set; }
        public List<LuuLuongTheoMucDichDto>? luuluong_theomd { get; set; }
        public CT_ThongSoDto? thongso { get; set; }
        public List<CT_ViTriDto>? vitri { get; set; }

        //For get more data
        public CT_LoaiDto? loaiCT { get; set; }
        public LuuVucSongDto? luuvuc { get; set; }
        public List<XaDto>? xa { get; set; }
        public List<HuyenDto>? huyen { get; set; }
        public List<GP_ThongTinDto>? giayphep { get; set; }

        [JsonPropertyName("mucdich_kt")]
        public List<MucDichKTDto>? mucdich_kt { get; set; }

        public List<ThanhTraKiemTraDto>? ThanhTraKiemTra { get; set; }
        public double? TongLuuLuong { get; set; }
        public string? DonViTinhLuuLuong { get; set; }

    }
}
