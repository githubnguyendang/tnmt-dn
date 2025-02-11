namespace tnmt_qn.Dto
{
    public class DuLieuNguonNuocThaiThuySanDto
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? DienTichThuySan { get; set; }
        public double? HeSoSuyGiam { get; set; }

        //tongtailuong
        public double? CtThuySanBOD { get; set; }
        public double? CtThuySanCOD { get; set; }
        public double? CtThuySanAmoni { get; set; }
        public double? CtThuySanTongN { get; set; }
        public double? CtThuySanTongP { get; set; }
        public double? CtThuySanTSS { get; set; }
        public double? CtThuySanColiform { get; set; }

        public double? LtThuySanBOD => Math.Round(((DienTichThuySan ?? 0) * (CtThuySanBOD ?? 0) *0.8/10) *2*86.4, 2);
        public double? LtThuySanCOD => Math.Round(((DienTichThuySan ?? 0) * (CtThuySanCOD ?? 0) *0.8/10)*2 *86.4, 2);
        public double? LtThuySanAmoni => Math.Round(((DienTichThuySan ?? 0) * (CtThuySanAmoni ?? 0) * 0.8) / 10 *2* 86.4, 2);
        public double? LtThuySanTongN => Math.Round(((DienTichThuySan ?? 0) * (CtThuySanTongN ?? 0) * 0.8) / 10*2 * 86.4, 2);
        public double? LtThuySanTongP => Math.Round(((DienTichThuySan ?? 0) * (CtThuySanTongP ?? 0) * 0.8) / 10 * 2 * 86.4, 2);
        public double? LtThuySanTSS => Math.Round(((DienTichThuySan ?? 0) * (CtThuySanTSS ?? 0) * 0.8) / 10 * 2 * 86.4, 2);
        public double? LtThuySanColiform => Math.Round(((DienTichThuySan ?? 0) * (CtThuySanColiform ?? 0) * 0.8) / 10 * 2 * 86.4, 2);

        public string? GhiChu { get; set; }
        public bool? DaXoa { get; set; }

        public PhanDoanSongDto? PhanDoanSong { get; set; }
    }
}
