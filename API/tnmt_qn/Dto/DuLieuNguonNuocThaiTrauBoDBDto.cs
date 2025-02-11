namespace tnmt_qn.Dto
{
    public class DuLieuNguonNuocThaiTrauBoDBDto
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public int? SoTrauDB { get; set; }
        public int? SoBoDB { get; set; }
        public double? HeSoSuyGiamDB { get; set; }
        //tongtailuong
        public double? CtTrauBoBODDB { get; set; }
        public double? CtTrauBoCODDB { get; set; }
        public double? CtTrauBoAmoniDB { get; set; }
        public double? CtTrauBoTongNDB { get; set; }
        public double? CtTrauBoTongPDB { get; set; }
        public double? CtTrauBoTSSDB { get; set; }
        public double? CtTrauBoColiformDB { get; set; }

        public double? LtTrauBoBODDB => Math.Round(((SoTrauDB + SoBoDB) ?? 0) * (CtTrauBoBODDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrauBoCODDB => Math.Round(((SoTrauDB + SoBoDB) ?? 0) * (CtTrauBoCODDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrauBoAmoniDB => Math.Round(((SoTrauDB + SoBoDB) ?? 0) * (CtTrauBoAmoniDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrauBoTongNDB => Math.Round(((SoTrauDB + SoBoDB) ?? 0) * (CtTrauBoTongNDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrauBoTongPDB => Math.Round(((SoTrauDB + SoBoDB) ?? 0) * (CtTrauBoTongPDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrauBoTSSDB => Math.Round(((SoTrauDB + SoBoDB) ?? 0) * (CtTrauBoTSSDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrauBoColiformDB => Math.Round(((SoTrauDB + SoBoDB) ?? 0) * (CtTrauBoColiformDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public bool? DaXoa { get; set; }

        public PhanDoanSongDto? PhanDoanSong { get; set; }
    }
}
