namespace tnmt_qn.Dto
{
    public class DuLieuNguonNuocThaiSinhHoatDto
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public int? SoDan { get; set; }
        public double? HeSoSuyGiam { get; set; }
        //tongtailuong
        public double? CtSinhHoatBOD { get; set; }
        public double? CtSinhHoatCOD { get; set; }
        public double? CtSinhHoatAmoni { get; set; }
        public double? CtSinhHoatTongN { get; set; }
        public double? CtSinhHoatTongP { get; set; }
        public double? CtSinhHoatTSS { get; set; }
        public double? CtSinhHoatColiform { get; set; }

        public double? LtSinhHoatBOD => Math.Round((SoDan ?? 0) * (CtSinhHoatBOD ?? 0) * (HeSoSuyGiam ?? 0)/1000, 2);
        public double? LtSinhHoatCOD => Math.Round((SoDan ?? 0) * (CtSinhHoatCOD ?? 0) * (HeSoSuyGiam ?? 0)/1000, 2);
        public double? LtSinhHoatAmoni => Math.Round((SoDan ?? 0) * (CtSinhHoatAmoni ?? 0) * (HeSoSuyGiam ?? 0) / 1000);
        public double? LtSinhHoatTongN => Math.Round((SoDan ?? 0) * (CtSinhHoatTongN ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtSinhHoatTongP => Math.Round((SoDan ?? 0) * (CtSinhHoatTongP ?? 0) * (HeSoSuyGiam ?? 0) / 1000);
        public double? LtSinhHoatTSS => Math.Round((SoDan ?? 0) * (CtSinhHoatTSS ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtSinhHoatColiform => Math.Round((SoDan ?? 0) * (CtSinhHoatColiform ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);

        public string? GhiChu { get; set; }
        public bool? DaXoa { get; set; }

        public PhanDoanSongDto? PhanDoanSong { get; set; }
    }
}
