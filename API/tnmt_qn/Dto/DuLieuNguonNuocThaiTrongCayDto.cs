namespace tnmt_qn.Dto
{
    public class DuLieuNguonNuocThaiTrongCayDto
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? DienTichTrongCay { get; set; }
        public double? HeSoSuyGiam { get; set; }


        //tongtailuong
        public double? CtTrongCayBOD { get; set; }
        public double? CtTrongCayCOD { get; set; }
        public double? CtTrongCayAmoni { get; set; }
        public double? CtTrongCayTongN { get; set; }
        public double? CtTrongCayTongP { get; set; }
        public double? CtTrongCayTSS { get; set; }
        public double? CtTrongCayColiform { get; set; }

        public double? LtTrongCayBOD => Math.Round((DienTichTrongCay ?? 0) * (CtTrongCayBOD ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtTrongCayCOD => Math.Round((DienTichTrongCay ?? 0) * (CtTrongCayCOD ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtTrongCayAmoni => Math.Round((DienTichTrongCay ?? 0) * (CtTrongCayAmoni ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtTrongCayTongN => Math.Round((DienTichTrongCay ?? 0) * (CtTrongCayTongN ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtTrongCayTongP => Math.Round((DienTichTrongCay ?? 0) * (CtTrongCayTongP ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtTrongCayTSS => Math.Round((DienTichTrongCay ?? 0) * (CtTrongCayTSS ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtTrongCayColiform => Math.Round((DienTichTrongCay ?? 0) * (CtTrongCayColiform ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);

        public string? GhiChu { get; set; }
        public bool? DaXoa { get; set; }

        public PhanDoanSongDto? PhanDoanSong { get; set; }
    }
}
