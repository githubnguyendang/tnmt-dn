namespace tnmt_qn.Dto
{
    public class NN_HanhLangBaoVeNN_AoHoDamTuNhienNhanTaoDto
    {
        public int? Id { get; set; }
        public string? Ten { get; set; }
        public string? XaPhuongTT { get; set; }
        public string? DiaPhanHanhChinh { get; set; }
        public string? HuyenTP { get; set; }
        public double? DungTichHo106m3 { get; set; }
        public string? PhamViHanhLang { get; set; }
        public string? ThuocDienCamMocHanhLang { get; set; }
    }

    public class NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3Dto
    {
        public int? Id { get; set; }
        public string? Ten { get; set; }
        public string? LoaiHo { get; set; }
        public string? XaPhuongTT { get; set; }
        public string? DiaPhanHanhChinh { get; set; }
        public string? HuyenTP { get; set; }
        public double? DungTichHo106m3 { get; set; }
        public string? PhamViHanhLang { get; set; }
        public string? ThuocDienCamMocHanhLang { get; set; }
    }

    public class NN_HanhLangBaoVeNN_HoThuyLoiNhieuHon1m3Dto
    {
        public int? Id { get; set; }
        public string? Ten { get; set; }
        public string? LoaiHo { get; set; }
        public string? XaPhuongTT { get; set; }
        public string? DiaPhanHanhChinh { get; set; }
        public string? HuyenTP { get; set; }
        public double? DungTichHo106m3 { get; set; }
        public string? PhamViHanhLang { get; set; }
        public string? ThuocDienCamMocHanhLang { get; set; }
    }

    public class NN_HanhLangBaoVeNN_SongSuoiDto
    {
        public int Id { get; set; }
        public string? DoanSong { get; set; }
        public string? TenSong { get; set; }
        public double? ChieuDai { get; set; }
        public string? DiaPhanHanhChinh { get; set; }
        public string? Huyen { get; set; }
        public double? XDiemDau { get; set; }
        public double? YDiemDau { get; set; }
        public double? XDiemCuoi { get; set; }
        public double? YDiemCuoi { get; set; }
        public string? ChucNang { get; set; }
        public string? PhamViHanhLangBaoVe { get; set; }
        public string? ThoiGianThucHien { get; set; }
    }
}
