namespace tnmt_qn.Dto
{
    public class DuLieuNguonNuocThaiGiaCamDBDto
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public int? SoGiaCamDB { get; set; }
        public double? HeSoSuyGiamDB { get; set; }
        //tongtailuong
        public double? CtGiaCamBODDB { get; set; }
        public double? CtGiaCamCODDB { get; set; }
        public double? CtGiaCamAmoniDB { get; set; }
        public double? CtGiaCamTongNDB { get; set; }
        public double? CtGiaCamTongPDB { get; set; }
        public double? CtGiaCamTSSDB { get; set; }
        public double? CtGiaCamColiformDB { get; set; }

        public double? LtGiaCamBODDB => Math.Round((SoGiaCamDB ?? 0) * (CtGiaCamBODDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtGiaCamCODDB => Math.Round((SoGiaCamDB ?? 0) * (CtGiaCamCODDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtGiaCamAmoniDB => Math.Round((SoGiaCamDB ?? 0) * (CtGiaCamAmoniDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtGiaCamTongNDB => Math.Round((SoGiaCamDB ?? 0) * (CtGiaCamTongNDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtGiaCamTongPDB => Math.Round((SoGiaCamDB ?? 0) * (CtGiaCamTongPDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtGiaCamTSSDB => Math.Round((SoGiaCamDB ?? 0) * (CtGiaCamTSSDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtGiaCamColiformDB => Math.Round((SoGiaCamDB ?? 0) * (CtGiaCamColiformDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public bool? DaXoa { get; set; }

        public PhanDoanSongDto? PhanDoanSong { get; set; }
    }
}
