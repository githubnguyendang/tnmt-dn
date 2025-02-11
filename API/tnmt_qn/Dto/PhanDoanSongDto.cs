using tnmt_qn.Data;

namespace tnmt_qn.Dto
{
    public class PhanDoanSongDto
    {
        public int? Id { get; set; }
        public string? LuuVucSong { get; set; }
        public string? Song { get; set; }
        public string? TenDoanSong { get; set; }
        public string? PhanDoan { get; set; }
        public double? ChieuDai { get; set; }
        public double? DienTichLV { get; set; }
        public double? XDau { get; set; }
        public double? YDau { get; set; }
        public double? XCuoi { get; set; }
        public double? YCuoi { get; set; }
        public string? DiaGioiHanhChinh { get; set; }
        public string? MucDichSuDung { get; set; }
        public string? ChatLuongNuoc { get; set; }
        public string? GhiChu { get; set; }
        public string? FileKML { get; set; }
        public double? HeSoFS { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
        public double? LtBod { get; set; }
        public double? LtCod { get; set; }
        public double? LtAmoni { get; set; }
        public double? LtTongN { get; set; }
        public double? LtTongP { get; set; }
        public double? LtTSS { get; set; }
        public double? LtColiform { get; set; }

        public double? LtnBod { get; set; }
        public double? LtnCod { get; set; }
        public double? LtnAmoni { get; set; }
        public double? LtnTongN { get; set; }
        public double? LtnTongP { get; set; }
        public double? LtnTSS { get; set; }
        public double? LtnColiform { get; set; }

        //dubao
        public double? LtBodDB { get; set; }
        public double? LtCodDB { get; set; }
        public double? LtAmoniDB { get; set; }
        public double? LtTongNDB { get; set; }
        public double? LtTongPDB { get; set; }
        public double? LtTSSDB { get; set; }
        public double? LtColiformDB { get; set; }

        public double? LtnBodDB { get; set; }
        public double? LtnCodDB { get; set; }
        public double? LtnAmoniDB { get; set; }
        public double? LtnTongNDB { get; set; }
        public double? LtnTongPDB { get; set; }
        public double? LtnTSSDB { get; set; }
        public double? LtnColiformDB { get; set; }
        public DuLieuNguonNuocNhanDto? DuLieuNguonNuocNhan { get; set; }
        public DuLieuNguonNuocThaiDiemDto? DuLieuNguonNuocThaiDiem { get; set; }
        public DuLieuNguonNuocThaiSinhHoatDto? DuLieuNguonNuocThaiSinhHoat { get; set; }
        public DuLieuNguonNuocThaiGiaCamDto? DuLieuNguonNuocThaiGiaCam { get; set; }
        public DuLieuNguonNuocThaiLonDto? DuLieuNguonNuocThaiLon { get; set; }
        public DuLieuNguonNuocThaiTrauBoDto? DuLieuNguonNuocThaiTrauBo { get; set; }
        public DuLieuNguonNuocThaiTrongCayDto? DuLieuNguonNuocThaiTrongCay { get; set; }
        public DuLieuNguonNuocThaiTrongLuaDto? DuLieuNguonNuocThaiTrongLua { get; set; }
        public DuLieuNguonNuocThaiTrongRungDto? DuLieuNguonNuocThaiTrongRung { get; set; }
        public DuLieuNguonNuocThaiThuySanDto? DuLieuNguonNuocThaiThuySan { get; set; }

        //db
        public DuLieuNguonNuocNhanDBDto? DuLieuNguonNuocNhanDB { get; set; }
        public DuLieuNguonNuocThaiDiemDBDto? DuLieuNguonNuocThaiDiemDB { get; set; }
        public DuLieuNguonNuocThaiSinhHoatDBDto? DuLieuNguonNuocThaiSinhHoatDB { get; set; }
        public DuLieuNguonNuocThaiGiaCamDBDto? DuLieuNguonNuocThaiGiaCamDB { get; set; }
        public DuLieuNguonNuocThaiLonDBDto? DuLieuNguonNuocThaiLonDB { get; set; }
        public DuLieuNguonNuocThaiTrauBoDBDto? DuLieuNguonNuocThaiTrauBoDB { get; set; }
        public DuLieuNguonNuocThaiTrongCayDBDto? DuLieuNguonNuocThaiTrongCayDB { get; set; }
        public DuLieuNguonNuocThaiTrongLuaDBDto? DuLieuNguonNuocThaiTrongLuaDB { get; set; }
        public DuLieuNguonNuocThaiTrongRungDBDto? DuLieuNguonNuocThaiTrongRungDB { get; set; }
        public DuLieuNguonNuocThaiThuySanDBDto? DuLieuNguonNuocThaiThuySanDB { get; set; }
    }

}
