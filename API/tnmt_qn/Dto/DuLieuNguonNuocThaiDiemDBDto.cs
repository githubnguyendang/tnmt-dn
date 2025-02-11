namespace tnmt_qn.Dto
{
    public class DuLieuNguonNuocThaiDiemDBDto
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? LuuLuongXaThaiDB { get; set; }


        //tongtailuong
        public double? CtdiemBODDB { get; set; }
        public double? CtdiemCODDB { get; set; }
        public double? CtdiemAmoniDB { get; set; }
        public double? CtdiemTongNDB { get; set; }
        public double? CtdiemTongPDB { get; set; }
        public double? CtdiemTSSDB { get; set; }
        public double? CtdiemColiformDB { get; set; }

        public double? LtdiemBODDB => Math.Round((LuuLuongXaThaiDB ?? 0) * (CtdiemBODDB ?? 0) * 86.4, 2);
        public double? LtdiemCODDB => Math.Round((LuuLuongXaThaiDB ?? 0) * (CtdiemCODDB ?? 0) * 86.4, 2);
        public double? LtdiemAmoniDB => Math.Round((LuuLuongXaThaiDB ?? 0) * (CtdiemAmoniDB ?? 0) * 86.4, 2);
        public double? LtdiemTongNDB => Math.Round((LuuLuongXaThaiDB ?? 0) * (CtdiemTongNDB ?? 0) * 86.4, 2);
        public double? LtdiemTongPDB => Math.Round((LuuLuongXaThaiDB ?? 0) * (CtdiemTongPDB ?? 0) * 86.4, 2);
        public double? LtdiemTSSDB => Math.Round((LuuLuongXaThaiDB ?? 0) * (CtdiemTSSDB ?? 0) * 86.4, 2);
        public double? LtdiemColiformDB => Math.Round((LuuLuongXaThaiDB ?? 0) * (CtdiemColiformDB ?? 0) * 86.4, 2);

        public bool? DaXoa { get; set; }

        public PhanDoanSongDto? PhanDoanSong { get; set; }
    }
}
