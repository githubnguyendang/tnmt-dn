namespace tnmt_qn.Dto
{
    public class DuLieuNguonNuocThaiDiemDto
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public string? NguonThaiCongTrinh { get; set; }
        public double? ToaDoX { get; set; }
        public double? ToaDoY { get; set; }
        public double? LuuLuongXaThai { get; set; }
       

        //tongtailuong
        public double? CtdiemBOD { get; set; }
        public double? CtdiemCOD { get; set; }
        public double? CtdiemAmoni { get; set; }
        public double? CtdiemTongN { get; set; }
        public double? CtdiemTongP { get; set; }
        public double? CtdiemTSS { get; set; }
        public double? CtdiemColiform { get; set; }

        public double? LtdiemBOD => Math.Round((LuuLuongXaThai ?? 0) * (CtdiemBOD ?? 0) * 86.4, 2);
        public double? LtdiemCOD => Math.Round((LuuLuongXaThai ?? 0) * (CtdiemCOD ?? 0) * 86.4,2);
        public double? LtdiemAmoni => Math.Round((LuuLuongXaThai ?? 0) * (CtdiemAmoni ?? 0) * 86.4,2);
        public double? LtdiemTongN => Math.Round((LuuLuongXaThai ?? 0) * (CtdiemTongN ?? 0) * 86.4,2);
        public double? LtdiemTongP => Math.Round((LuuLuongXaThai ?? 0) * (CtdiemTongP ?? 0) * 86.4,2);
        public double? LtdiemTSS => Math.Round((LuuLuongXaThai ?? 0) * (CtdiemTSS ?? 0) * 86.4,2);
        public double? LtdiemColiform => Math.Round((LuuLuongXaThai ?? 0) * (CtdiemColiform ?? 0) * 86.4,2);

        public string? GhiChu { get; set; }
        public bool? DaXoa { get; set; }

        public PhanDoanSongDto? PhanDoanSong { get; set; }
    }
}
