namespace tnmt_qn.Dto
{
    public class DuLieuNguonNuocThaiTrongRungDto
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? DienTichTrongRung { get; set; }
        public double? HeSoSuyGiam { get; set; }

        //tongtailuong
        public double? CtTrongRungBOD { get; set; }
        public double? CtTrongRungCOD { get; set; }
        public double? CtTrongRungAmoni { get; set; }
        public double? CtTrongRungTongN { get; set; }
        public double? CtTrongRungTongP { get; set; }
        public double? CtTrongRungTSS { get; set; }
        public double? CtTrongRungColiform { get; set; }

        public double? LtTrongRungBOD => Math.Round((DienTichTrongRung ?? 0) * (CtTrongRungBOD ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtTrongRungCOD => Math.Round((DienTichTrongRung ?? 0) * (CtTrongRungCOD ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtTrongRungAmoni => Math.Round((DienTichTrongRung ?? 0) * (CtTrongRungAmoni ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtTrongRungTongN => Math.Round((DienTichTrongRung ?? 0) * (CtTrongRungTongN ?? 0) * (HeSoSuyGiam ?? 0)/1000, 2);
        public double? LtTrongRungTongP => Math.Round((DienTichTrongRung ?? 0) * (CtTrongRungTongP ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtTrongRungTSS => Math.Round((DienTichTrongRung ?? 0) * (CtTrongRungTSS ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtTrongRungColiform => Math.Round((DienTichTrongRung ?? 0) * (CtTrongRungColiform ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);

        public string? GhiChu { get; set; }
        public bool? DaXoa { get; set; }

        public PhanDoanSongDto? PhanDoanSong { get; set; }
    }
}
