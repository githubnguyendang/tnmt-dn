namespace tnmt_qn.Dto
{
    public class DuLieuNguonNuocNhanDto
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? LuuLuongDongChay { get; set; }
        //ketqua
        public double? CnnBOD { get; set; }
        public double? CnnCOD { get; set; }
        public double? CnnAmoni { get; set; }
        public double? CnnTongN { get; set; }
        public double? CnnTongP { get; set; }
        public double? CnnTSS { get; set; }
        public double? CnnColiform { get; set; }

        //tailuong
        public double? LnnBOD => Math.Round((LuuLuongDongChay ?? 0) * (CnnBOD ?? 0) * 86.4, 2);
        public double? LnnCOD => Math.Round((LuuLuongDongChay ?? 0) * (CnnCOD ?? 0) * 86.4, 2);
        public double? LnnAmoni => Math.Round((LuuLuongDongChay ?? 0) * (CnnAmoni ?? 0) * 86.4, 2);
        public double? LnnTongN => Math.Round((LuuLuongDongChay ?? 0) * (CnnTongN ?? 0) * 86.4, 2);
        public double? LnnTongP => Math.Round((LuuLuongDongChay ?? 0) * (CnnTongP ?? 0) * 86.4, 2);
        public double? LnnTSS => Math.Round((LuuLuongDongChay ?? 0) * (CnnTSS ?? 0) * 86.4, 2);
        public double? LnnColiform => Math.Round((LuuLuongDongChay ?? 0) * (CnnColiform ?? 0) * 86.4, 2);

        //giatrigioihan
        public double? CqcBOD { get; set; }
        public double? CqcCOD { get; set; }
        public double? CqcAmoni { get; set; }
        public double? CqcTongN { get; set; }
        public double? CqcTongP { get; set; }
        public double? CqcTSS { get; set; }
        public double? CqcColiform { get; set; }

        //tailuongtoida
        public double? LtdBOD => Math.Round((LuuLuongDongChay ?? 0) * (CqcBOD ?? 0) * 86.4,2);
        public double? LtdCOD => Math.Round((LuuLuongDongChay ?? 0) * (CqcCOD ?? 0) * 86.4, 2);
        public double? LtdAmoni => Math.Round((LuuLuongDongChay ?? 0) * (CqcAmoni ?? 0) * 86.4, 2);
        public double? LtdTongN => Math.Round((LuuLuongDongChay ?? 0) * (CqcTongN ?? 0) * 86.4, 2);
        public double? LtdTongP => Math.Round((LuuLuongDongChay ?? 0) * (CqcTongP ?? 0) * 86.4, 2);
        public double? LtdTSS => Math.Round((LuuLuongDongChay ?? 0) * (CqcTSS ?? 0) * 86.4, 2);
        public double? LtdColiform => Math.Round((LuuLuongDongChay ?? 0) * (CqcColiform ?? 0) * 86.4, 2);
        public string? GhiChu { get; set; }
        public bool? DaXoa { get; set; }
        public PhanDoanSongDto? PhanDoanSong { get; set; }
    }
}
