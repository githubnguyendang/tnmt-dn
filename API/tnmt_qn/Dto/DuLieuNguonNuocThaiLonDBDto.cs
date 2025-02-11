namespace tnmt_qn.Dto
{
    public class DuLieuNguonNuocThaiLonDBDto
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public int? SoLonDB { get; set; }
        public int? SoDeDB { get; set; }
        public int? SoGiaSucKhacDB { get; set; }
        public double? HeSoSuyGiamDB { get; set; }
        //tongtailuong
        public double? CtLonBODDB { get; set; }
        public double? CtLonCODDB { get; set; }
        public double? CtLonAmoniDB { get; set; }
        public double? CtLonTongNDB { get; set; }
        public double? CtLonTongPDB { get; set; }
        public double? CtLonTSSDB { get; set; }
        public double? CtLonColiformDB { get; set; }

        public double? LtLonBODDB => Math.Round((SoLonDB ?? 0 + SoDeDB ?? 0 + SoGiaSucKhacDB ?? 0) * (CtLonBODDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtLonCODDB => Math.Round((SoLonDB ?? 0 + SoDeDB ?? 0 + SoGiaSucKhacDB ?? 0) * (CtLonCODDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtLonAmoniDB => Math.Round((SoLonDB ?? 0 + SoDeDB ?? 0 + SoGiaSucKhacDB ?? 0) * (CtLonAmoniDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtLonTongNDB => Math.Round((SoLonDB ?? 0 + SoDeDB ?? 0 + SoGiaSucKhacDB ?? 0) * (CtLonTongNDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtLonTongPDB => Math.Round((SoLonDB ?? 0 + SoDeDB ?? 0 + SoGiaSucKhacDB ?? 0) * (CtLonTongPDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtLonTSSDB => Math.Round((SoLonDB ?? 0 + SoDeDB ?? 0 + SoGiaSucKhacDB ?? 0) * (CtLonTSSDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtLonColiformDB => Math.Round((SoLonDB ?? 0 + SoDeDB ?? 0 + SoGiaSucKhacDB ?? 0) * (CtLonColiformDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000);
        public bool? DaXoa { get; set; }

        public PhanDoanSongDto? PhanDoanSong { get; set; }
    }
}
