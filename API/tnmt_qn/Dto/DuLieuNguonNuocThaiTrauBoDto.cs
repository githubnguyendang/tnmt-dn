namespace tnmt_qn.Dto
{
    public class DuLieuNguonNuocThaiTrauBoDto
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public int? SoTrau { get; set; }
        public int? SoBo { get; set; }
        public double? HeSoSuyGiam { get; set; }
        //tongtailuong
        public double? CtTrauBoBOD { get; set; }
        public double? CtTrauBoCOD { get; set; }
        public double? CtTrauBoAmoni { get; set; }
        public double? CtTrauBoTongN { get; set; }
        public double? CtTrauBoTongP { get; set; }
        public double? CtTrauBoTSS { get; set; }
        public double? CtTrauBoColiform { get; set; }

        public double? LtTrauBoBOD => Math.Round(((SoTrau + SoBo) ?? 0)* (CtTrauBoBOD ?? 0) * (HeSoSuyGiam ?? 0)/1000, 2);
        public double? LtTrauBoCOD => Math.Round(((SoTrau + SoBo) ?? 0) * (CtTrauBoCOD ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtTrauBoAmoni => Math.Round(((SoTrau + SoBo) ?? 0) * (CtTrauBoAmoni ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtTrauBoTongN => Math.Round(((SoTrau + SoBo) ?? 0) * (CtTrauBoTongN ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtTrauBoTongP => Math.Round(((SoTrau + SoBo) ?? 0) * (CtTrauBoTongP ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtTrauBoTSS => Math.Round(((SoTrau + SoBo) ?? 0) * (CtTrauBoTSS ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtTrauBoColiform => Math.Round(((SoTrau + SoBo) ?? 0) * (CtTrauBoColiform ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);

        public string? GhiChu { get; set; }
        public bool? DaXoa { get; set; }

        public PhanDoanSongDto? PhanDoanSong { get; set; }
    }
}
