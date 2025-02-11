namespace tnmt_qn.Dto
{
    public class DuLieuNguonNuocThaiTrongLuaDto
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? DienTichTrongLua { get; set; }
        public double? HeSoSuyGiam { get; set; }


        //tongtailuong
        public double? CtTrongLuaBOD { get; set; }
        public double? CtTrongLuaCOD { get; set; }
        public double? CtTrongLuaAmoni { get; set; }
        public double? CtTrongLuaTongN { get; set; }
        public double? CtTrongLuaTongP { get; set; }
        public double? CtTrongLuaTSS { get; set; }
        public double? CtTrongLuaColiform { get; set; }

        public double? LtTrongLuaBOD => Math.Round((DienTichTrongLua ?? 0) * (CtTrongLuaBOD ?? 0) * (HeSoSuyGiam ?? 0)/1000, 2);
        public double? LtTrongLuaCOD => Math.Round((DienTichTrongLua ?? 0) * (CtTrongLuaCOD ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtTrongLuaAmoni => Math.Round((DienTichTrongLua ?? 0) * (CtTrongLuaAmoni ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtTrongLuaTongN => Math.Round((DienTichTrongLua ?? 0) * (CtTrongLuaTongN ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtTrongLuaTongP => Math.Round((DienTichTrongLua ?? 0) * (CtTrongLuaTongP ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtTrongLuaTSS => Math.Round((DienTichTrongLua ?? 0) * (CtTrongLuaTSS ?? 0) * (HeSoSuyGiam ?? 0) / 1000, 2);
        public double? LtTrongLuaColiform => Math.Round((DienTichTrongLua ?? 0) * (CtTrongLuaColiform ?? 0) * (HeSoSuyGiam ?? 0) / 1000 , 2);

        public string? GhiChu { get; set; }
        public bool? DaXoa { get; set; }

        public PhanDoanSongDto? PhanDoanSong { get; set; }
    }
}
