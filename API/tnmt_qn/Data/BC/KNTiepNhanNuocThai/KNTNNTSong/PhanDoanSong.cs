using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class PhanDoanSong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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
        public string? FileKML { get; set; }
        public string? GhiChu { get; set; }
        public double? HeSoFS { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
        public virtual DuLieuNguonNuocNhan? DuLieuNguonNuocNhan { get; set; }
        public virtual DuLieuNguonNuocThaiDiem? DuLieuNguonNuocThaiDiem { get; set; }
        public virtual DuLieuNguonNuocThaiSinhHoat? DuLieuNguonNuocThaiSinhHoat { get; set; }
        public virtual DuLieuNguonNuocThaiGiaCam? DuLieuNguonNuocThaiGiaCam { get; set; }
        public virtual DuLieuNguonNuocThaiLon? DuLieuNguonNuocThaiLon { get; set; }
        public virtual DuLieuNguonNuocThaiTrauBo? DuLieuNguonNuocThaiTrauBo { get; set; }
        public virtual DuLieuNguonNuocThaiTrongCay? DuLieuNguonNuocThaiTrongCay { get; set; }
        public virtual DuLieuNguonNuocThaiTrongLua? DuLieuNguonNuocThaiTrongLua { get; set; }
        public virtual DuLieuNguonNuocThaiTrongRung? DuLieuNguonNuocThaiTrongRung { get; set; }
        public virtual DuLieuNguonNuocThaiThuySan? DuLieuNguonNuocThaiThuySan { get; set; }

        public virtual DuLieuNguonNuocNhanDB? DuLieuNguonNuocNhanDB { get; set; }
        public virtual DuLieuNguonNuocThaiDiemDB? DuLieuNguonNuocThaiDiemDB { get; set; }
        public virtual DuLieuNguonNuocThaiSinhHoatDB? DuLieuNguonNuocThaiSinhHoatDB { get; set; }
        public virtual DuLieuNguonNuocThaiGiaCamDB? DuLieuNguonNuocThaiGiaCamDB { get; set; }
        public virtual DuLieuNguonNuocThaiLonDB? DuLieuNguonNuocThaiLonDB { get; set; }
        public virtual DuLieuNguonNuocThaiTrauBoDB? DuLieuNguonNuocThaiTrauBoDB { get; set; }
        public virtual DuLieuNguonNuocThaiTrongCayDB? DuLieuNguonNuocThaiTrongCayDB { get; set; }
        public virtual DuLieuNguonNuocThaiTrongLuaDB? DuLieuNguonNuocThaiTrongLuaDB { get; set; }
        public virtual DuLieuNguonNuocThaiTrongRungDB? DuLieuNguonNuocThaiTrongRungDB { get; set; }
        public virtual DuLieuNguonNuocThaiThuySanDB? DuLieuNguonNuocThaiThuySanDB { get; set; }

    }
}
