namespace tnmt_qn.Dto
{
    public class DuLieuNguonNuocThaiTrongLuaDBDto
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? DienTichTrongLuaDB { get; set; }
        public double? HeSoSuyGiamDB { get; set; }


        //tongtailuong
        public double? CtTrongLuaBODDB { get; set; }
        public double? CtTrongLuaCODDB { get; set; }
        public double? CtTrongLuaAmoniDB { get; set; }
        public double? CtTrongLuaTongNDB { get; set; }
        public double? CtTrongLuaTongPDB { get; set; }
        public double? CtTrongLuaTSSDB { get; set; }
        public double? CtTrongLuaColiformDB { get; set; }

        public double? LtTrongLuaBODDB => Math.Round((DienTichTrongLuaDB ?? 0) * (CtTrongLuaBODDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrongLuaCODDB => Math.Round((DienTichTrongLuaDB ?? 0) * (CtTrongLuaCODDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrongLuaAmoniDB => Math.Round((DienTichTrongLuaDB ?? 0) * (CtTrongLuaAmoniDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrongLuaTongNDB => Math.Round((DienTichTrongLuaDB ?? 0) * (CtTrongLuaTongNDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrongLuaTongPDB => Math.Round((DienTichTrongLuaDB ?? 0) * (CtTrongLuaTongPDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrongLuaTSSDB => Math.Round((DienTichTrongLuaDB ?? 0) * (CtTrongLuaTSSDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);
        public double? LtTrongLuaColiformDB => Math.Round((DienTichTrongLuaDB ?? 0) * (CtTrongLuaColiformDB ?? 0) * (HeSoSuyGiamDB ?? 0) / 1000, 2);

        public string? GhiChu { get; set; }
        public bool? DaXoa { get; set; }

        public PhanDoanSongDto? PhanDoanSong { get; set; }
    }
}
