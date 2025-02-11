namespace tnmt_qn.Dto
{
    public class DuLieuNguonNuocThaiGiaCamDto
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public int? SoGiaCam { get; set; }
        public double? HeSoSuyGiam { get; set; }
        //tongtailuong
        public double? CtGiaCamBOD { get; set; }
        public double? CtGiaCamCOD { get; set; }
        public double? CtGiaCamAmoni { get; set; }
        public double? CtGiaCamTongN { get; set; }
        public double? CtGiaCamTongP { get; set; }
        public double? CtGiaCamTSS { get; set; }
        public double? CtGiaCamColiform { get; set; }

        public double? LtGiaCamBOD => Math.Round((SoGiaCam ?? 0) * (CtGiaCamBOD ?? 0) * (HeSoSuyGiam ?? 0)/1000 ,2);
        public double? LtGiaCamCOD => Math.Round((SoGiaCam ?? 0) * (CtGiaCamCOD ?? 0) * (HeSoSuyGiam ?? 0) / 1000 ,2);
        public double? LtGiaCamAmoni => Math.Round((SoGiaCam ?? 0) * (CtGiaCamAmoni ?? 0) * (HeSoSuyGiam ?? 0) / 1000,2);
        public double? LtGiaCamTongN => Math.Round((SoGiaCam ?? 0) * (CtGiaCamTongN ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtGiaCamTongP => Math.Round((SoGiaCam ?? 0) * (CtGiaCamTongP ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);  
        public double? LtGiaCamTSS => Math.Round((SoGiaCam ?? 0) * (CtGiaCamTSS ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtGiaCamColiform => Math.Round((SoGiaCam ?? 0) * (CtGiaCamColiform ?? 0) * (HeSoSuyGiam ?? 0) / 1000,2 );

        public string? GhiChu { get; set; }
        public bool? DaXoa { get; set; }

        public PhanDoanSongDto? PhanDoanSong { get; set; }
    }
}
