namespace tnmt_qn.Dto
{
    public class DuLieuNguonNuocThaiTrongCayDBDto
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? DienTichTrongCayDB { get; set; }
        public double? HeSoSuyGiamDB { get; set; }


        //tongtailuong
        public double? CtTrongCayBODDB { get; set; }
        public double? CtTrongCayCODDB { get; set; }
        public double? CtTrongCayAmoniDB { get; set; }
        public double? CtTrongCayTongNDB { get; set; }
        public double? CtTrongCayTongPDB { get; set; }
        public double? CtTrongCayTSSDB { get; set; }
        public double? CtTrongCayColiformDB { get; set; }

        public double? LtTrongCayBODDB => Math.Round((DienTichTrongCayDB ?? 0) * (CtTrongCayBODDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrongCayCODDB => Math.Round((DienTichTrongCayDB ?? 0) * (CtTrongCayCODDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrongCayAmoniDB => Math.Round((DienTichTrongCayDB ?? 0) * (CtTrongCayAmoniDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrongCayTongNDB => Math.Round((DienTichTrongCayDB ?? 0) * (CtTrongCayTongNDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrongCayTongPDB => Math.Round((DienTichTrongCayDB ?? 0) * (CtTrongCayTongPDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrongCayTSSDB => Math.Round((DienTichTrongCayDB ?? 0) * (CtTrongCayTSSDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrongCayColiformDB => Math.Round((DienTichTrongCayDB ?? 0) * (CtTrongCayColiformDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);

        public bool? DaXoa { get; set; }

        public PhanDoanSongDto? PhanDoanSong { get; set; }
    }
}
