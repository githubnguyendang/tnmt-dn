namespace tnmt_qn.Dto
{
    public class DuLieuNguonNuocThaiTrongRungDBDto
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? DienTichTrongRungDB { get; set; }
        public double? HeSoSuyGiamDB { get; set; }

        //tongtailuong
        public double? CtTrongRungBODDB { get; set; }
        public double? CtTrongRungCODDB { get; set; }
        public double? CtTrongRungAmoniDB { get; set; }
        public double? CtTrongRungTongNDB { get; set; }
        public double? CtTrongRungTongPDB { get; set; }
        public double? CtTrongRungTSSDB { get; set; }
        public double? CtTrongRungColiformDB { get; set; }

        public double? LtTrongRungBODDB => Math.Round((DienTichTrongRungDB ?? 0) * (CtTrongRungBODDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrongRungCODDB => Math.Round((DienTichTrongRungDB ?? 0) * (CtTrongRungCODDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrongRungAmoniDB => Math.Round((DienTichTrongRungDB ?? 0) * (CtTrongRungAmoniDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrongRungTongNDB => Math.Round((DienTichTrongRungDB ?? 0) * (CtTrongRungTongNDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrongRungTongPDB => Math.Round((DienTichTrongRungDB ?? 0) * (CtTrongRungTongPDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrongRungTSSDB => Math.Round((DienTichTrongRungDB ?? 0) * (CtTrongRungTSSDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrongRungColiformDB => Math.Round((DienTichTrongRungDB ?? 0) * (CtTrongRungColiformDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public bool? DaXoa { get; set; }

        public PhanDoanSongDto? PhanDoanSong { get; set; }
    }
}
