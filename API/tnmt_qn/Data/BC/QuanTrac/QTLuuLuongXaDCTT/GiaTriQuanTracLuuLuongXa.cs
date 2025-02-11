using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class GiaTriQuanTracLuuLuongXa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaGiaTriQuanTracLuuLuongXa { get; set; }
        public int? MaCongTrinhQuanTracLuuLuong { get; set; }
        public int? MaThongTinChatLuongNuoc { get; set; }
        public DateTime? ThoiGianQuanTracLuuLuongXaDuyTriDctt { get; set; }
        public string? TanSuatQuanTracLuuLuongXaDuyTriDctt { get; set; }
        public string? ViTriQuanTracLuuLuongDuyTriDctt { get; set; }
        public double? LuuLuongXaCuaCongTrinh { get; set; }
        public string? TinhTrang { get; set; }
        public double? MucNuocHoTruocKhiXa { get; set; }
        public double? MucNuocHoSauKhiXa { get; set; }
        public double? MucNuocSong { get; set; }
        public double? DungTichHoHuaIchCuaHoChuaSauKhiXa { get; set; }
        public double? DungTichToanBoHoChuaSauKhiXa { get; set; }



        //tạo  khoá ngoại
        [ForeignKey("MaCongTrinhQuanTracLuuLuong ")]
        public virtual CongTrinhQuanTracLuuLuongXaDCTT? CongTrinhQuanTracLuuLuong { get; set; }

        [ForeignKey("MaThongTinChatLuongNuoc ")]
        public virtual ThongTinChatLuongNuoc? ThongTinChatLuongNuoc { get; set; }
    }
}
