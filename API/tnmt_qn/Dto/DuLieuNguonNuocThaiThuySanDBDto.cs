namespace tnmt_qn.Dto
{
    public class DuLieuNguonNuocThaiThuySanDBDto
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? DienTichThuySanDB { get; set; }
        public double? HeSoSuyGiamDB { get; set; }

        //tongtailuong
        public double? CtThuySanBODDB { get; set; }
        public double? CtThuySanCODDB { get; set; }
        public double? CtThuySanAmoniDB { get; set; }
        public double? CtThuySanTongNDB { get; set; }
        public double? CtThuySanTongPDB { get; set; }
        public double? CtThuySanTSSDB { get; set; }
        public double? CtThuySanColiformDB { get; set; }

        public double? LtThuySanBODDB => Math.Round(((DienTichThuySanDB ?? 0) * (CtThuySanBODDB ?? 0) * 0.8 / 10) * 2 * 86.4, 2);
        public double? LtThuySanCODDB => Math.Round(((DienTichThuySanDB ?? 0) * (CtThuySanCODDB ?? 0) * 0.8 / 10) * 2 * 86.4, 2);
        public double? LtThuySanAmoniDB => Math.Round(((DienTichThuySanDB ?? 0) * (CtThuySanAmoniDB ?? 0) * 0.8) / 10 * 2 * 86.4, 2);
        public double? LtThuySanTongNDB => Math.Round(((DienTichThuySanDB ?? 0) * (CtThuySanTongNDB ?? 0) * 0.8) / 10 * 2 * 86.4, 2);
        public double? LtThuySanTongPDB => Math.Round(((DienTichThuySanDB ?? 0) * (CtThuySanTongPDB ?? 0) * 0.8) / 10 * 2 * 86.4, 2);
        public double? LtThuySanTSSDB => Math.Round(((DienTichThuySanDB ?? 0) * (CtThuySanTSSDB ?? 0) * 0.8) / 10 * 2 * 86.4, 2);
        public double? LtThuySanColiformDB => Math.Round(((DienTichThuySanDB ?? 0) * (CtThuySanColiformDB ?? 0) * 0.8) / 10 * 2 * 86.4, 2);

        public bool? DaXoa { get; set; }

        public PhanDoanSongDto? PhanDoanSong { get; set; }
    }
}
