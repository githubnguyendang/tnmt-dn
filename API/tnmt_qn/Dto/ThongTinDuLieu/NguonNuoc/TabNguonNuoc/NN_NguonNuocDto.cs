namespace tnmt_qn.Dto
{
    public class NN_NguonNuoc_AoHoDamPhaDto
    {
        public int? Id { get; set; }
        public string? TenHoChua { get; set; }
        public string? NguonNuoc { get; set; }
        public string? ThuocLVS { get; set; }
        public double? DienTichMatNuoc { get; set; }
        public string? XaPhuongTT { get; set; }
        public string? HuyenTP { get; set; }
        public double? DungTichToanBo { get; set; }
        public double? DungTichHuuIch { get; set; }
        public double? DungTichPhongLu { get; set; }
        public double? MNDBT { get; set; }
        public double? MNC { get; set; }
        public int? NamXayDung { get; set; }
        public string? DonViQuanLyVanHanh { get; set; }
        public string? PhamViHanhLang { get; set; }
        public string? ThuocDienCamMocHanhLang { get; set; }
    }

    public class NN_NguonNuoc_SongSuoiDto
    {
        public int? Id { get; set; }
        public string? MaSong { get; set; }
        public string? TenSongSuoi { get; set; }
        public double? ChayRa { get; set; }
        public double? ChieuDai { get; set; }
        public string? DiaPhanHanhChinh { get; set; }
        public string? Huyen { get; set; }
        public double? XDiemDau { get; set; }
        public double? YDiemDau { get; set; }
        public double? XDiemCuoi { get; set; }
        public double? YDiemCuoi { get; set; }
        public string? ChucNang { get; set; }
        public string? PhamViHanhLangBaoVe { get; set; }
        public string? GhiChu { get; set; }
    }

    public class NN_NguonNuoc_TangChuaNuocDto
    {
        public int? Id { get; set; }
        public string? TenTangChuaNuoc { get; set; }
        public string? LoaiChuaNuoc { get; set; }
        public string? ThuocLVS { get; set; }
        public string? XaPhuongTT { get; set; }
        public string? HuyenTP { get; set; }
        public double? DungTichPhanBo { get; set; }
        public double? KhoangChieuSauPhanBo { get; set; }
    }
}
