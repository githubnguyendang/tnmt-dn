using System.ComponentModel.DataAnnotations.Schema;
using tnmt_qn.Data;

namespace tnmt_qn.Dto
{
    public class DuLieuNguonNuocNhanDBDto
    {
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public int IdMucPL { get; set; }
        public double? LuuLuongDongChayDB { get; set; }

        //ketqua
        public double? CnnBODDB { get; set; }
        public double? CnnCODDB { get; set; }
        public double? CnnAmoniDB { get; set; }
        public double? CnnTongNDB { get; set; }
        public double? CnnTongPDB { get; set; }
        public double? CnnTSSDB { get; set; }
        public double? CnnColiformDB { get; set; }

        //tailuong
        public double? LnnBODDB => Math.Round((LuuLuongDongChayDB ?? 0) * (CnnBODDB ?? 0) * 86.4, 2);
        public double? LnnCODDB => Math.Round((LuuLuongDongChayDB ?? 0) * (CnnCODDB ?? 0) * 86.4, 2);
        public double? LnnAmoniDB => Math.Round((LuuLuongDongChayDB ?? 0) * (CnnAmoniDB ?? 0) * 86.4, 2);
        public double? LnnTongNDB => Math.Round((LuuLuongDongChayDB ?? 0) * (CnnTongNDB ?? 0) * 86.4, 2);
        public double? LnnTongPDB => Math.Round((LuuLuongDongChayDB ?? 0) * (CnnTongPDB ?? 0) * 86.4, 2);
        public double? LnnTSSDB => Math.Round((LuuLuongDongChayDB ?? 0) * (CnnTSSDB ?? 0) * 86.4, 2);
        public double? LnnColiformDB => Math.Round((LuuLuongDongChayDB ?? 0) * (CnnColiformDB ?? 0) * 86.4, 2);

        //tailuongtoida
        public double? LtdBODDB { get; set; }
        public double? LtdCODDB { get; set; }
        public double? LtdAmoniDB { get; set; }
        public double? LtdTongNDB { get; set; }
        public double? LtdTongPDB { get; set; }
        public double? LtdTSSDB { get; set; }
        public double? LtdColiformDB { get; set; }
        public bool? DaXoa { get; set; }

        public PhanDoanSongDto? PhanDoanSong { get; set; }
        public ThongSoCLNDuBao? ThongSoCLNDuBao { get; set; }
    }
}
