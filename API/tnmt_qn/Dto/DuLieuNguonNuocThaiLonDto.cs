namespace tnmt_qn.Dto
{
    public class DuLieuNguonNuocThaiLonDto
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public int? SoLon { get; set; }
        public int? SoDe { get; set; }
        public int? SoGiaSucKhac { get; set; }
        public double? HeSoSuyGiam { get; set; }
        //tongtailuong
        public double? CtLonBOD { get; set; }
        public double? CtLonCOD { get; set; }
        public double? CtLonAmoni { get; set; }
        public double? CtLonTongN { get; set; }
        public double? CtLonTongP { get; set; }
        public double? CtLonTSS { get; set; }
        public double? CtLonColiform { get; set; }

        public double? LtLonBOD => Math.Round((SoLon ??0 + SoDe ??0 + SoGiaSucKhac??0)  * (CtLonBOD ?? 0) * (HeSoSuyGiam ?? 0) /1000, 2);
        public double? LtLonCOD => Math.Round((SoLon ??0 + SoDe??0 + SoGiaSucKhac??0)  * (CtLonCOD ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtLonAmoni => Math.Round((SoLon??0 + SoDe ??0+ SoGiaSucKhac??0) * (CtLonAmoni ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtLonTongN => Math.Round((SoLon ??0 + SoDe??0 + SoGiaSucKhac ?? 0)  * (CtLonTongN ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtLonTongP => Math.Round((SoLon ?? 0 + SoDe ?? 0 + SoGiaSucKhac ?? 0 ) * (CtLonTongP ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtLonTSS => Math.Round((SoLon ?? 0 + SoDe ?? 0 + SoGiaSucKhac ?? 0 ) * (CtLonTSS ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtLonColiform => Math.Round((SoLon ?? 0 + SoDe ?? 0 + SoGiaSucKhac ?? 0 ) * (CtLonColiform ?? 0) * (HeSoSuyGiam ?? 0) / 1000);

        public string? GhiChu { get; set; }
        public bool? DaXoa { get; set; }

        public PhanDoanSongDto? PhanDoanSong { get; set; }
    }
}
