namespace tnmt_qn.Dto
{
    public class TaiLuongNuocThaiSongDBDto
    {  //dubao
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? LtBodDB { get; set; }
        public double? LtCodDB { get; set; }
        public double? LtAmoniDB { get; set; }
        public double? LtTongNDB { get; set; }
        public double? LtTongPDB { get; set; }
        public double? LtTSSDB { get; set; }
        public double? LtColiformDB { get; set; }

        public double? LtnBodDB { get; set; }
        public double? LtnCodDB { get; set; }
        public double? LtnAmoniDB { get; set; }
        public double? LtnTongNDB { get; set; }
        public double? LtnTongPDB { get; set; }
        public double? LtnTSSDB { get; set; }
        public double? LtnColiformDB { get; set; }

        //db
        public DuLieuNguonNuocNhanDBDto? DuLieuNguonNuocNhanDB { get; set; }
        public DuLieuNguonNuocThaiDiemDBDto? DuLieuNguonNuocThaiDiemDB { get; set; }
        public DuLieuNguonNuocThaiSinhHoatDBDto? DuLieuNguonNuocThaiSinhHoatDB { get; set; }
        public DuLieuNguonNuocThaiGiaCamDBDto? DuLieuNguonNuocThaiGiaCamDB { get; set; }
        public DuLieuNguonNuocThaiLonDBDto? DuLieuNguonNuocThaiLonDB { get; set; }
        public DuLieuNguonNuocThaiTrauBoDBDto? DuLieuNguonNuocThaiTrauBoDB { get; set; }
        public DuLieuNguonNuocThaiTrongCayDBDto? DuLieuNguonNuocThaiTrongCayDB { get; set; }
        public DuLieuNguonNuocThaiTrongLuaDBDto? DuLieuNguonNuocThaiTrongLuaDB { get; set; }
        public DuLieuNguonNuocThaiTrongRungDBDto? DuLieuNguonNuocThaiTrongRungDB { get; set; }
        public DuLieuNguonNuocThaiThuySanDBDto? DuLieuNguonNuocThaiThuySanDB { get; set; }
        public PhanDoanSongDto? PhanDoanSong { get; set; }
    }
}
