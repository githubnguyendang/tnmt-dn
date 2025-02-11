namespace tnmt_qn.Dto
{
    public class DuLieuNguonNuocThaiSinhHoatDBDto
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public int? SoDanDB { get; set; }
        public double? HeSoSuyGiamDB { get; set; }
        //tongtailuong
        public double? CtSinhHoatBODDB { get; set; }
        public double? CtSinhHoatCODDB { get; set; }
        public double? CtSinhHoatAmoniDB { get; set; }
        public double? CtSinhHoatTongNDB { get; set; }
        public double? CtSinhHoatTongPDB { get; set; }
        public double? CtSinhHoatTSSDB { get; set; }
        public double? CtSinhHoatColiformDB { get; set; }

        public double? LtSinhHoatBODDB => Math.Round((SoDanDB ?? 0) * (CtSinhHoatBODDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtSinhHoatCODDB => Math.Round((SoDanDB ?? 0) * (CtSinhHoatCODDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtSinhHoatAmoniDB => Math.Round((SoDanDB ?? 0) * (CtSinhHoatAmoniDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000);
        public double? LtSinhHoatTongNDB => Math.Round((SoDanDB ?? 0) * (CtSinhHoatTongNDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtSinhHoatTongPDB => Math.Round((SoDanDB ?? 0) * (CtSinhHoatTongPDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000);
        public double? LtSinhHoatTSSDB => Math.Round((SoDanDB ?? 0) * (CtSinhHoatTSSDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtSinhHoatColiformDB => Math.Round((SoDanDB ?? 0) * (CtSinhHoatColiformDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);

        public string? GhiChu { get; set; }
        public bool? DaXoa { get; set; }

        public PhanDoanSongDto? PhanDoanSong { get; set; }
    }
}
