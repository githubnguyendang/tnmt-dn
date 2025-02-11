using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class CTKTSDN_PDK_NuocMat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TenCongTrinh { get; set; }
        public string? TenTCN { get; set; }
        public string? NamVanHanh { get; set; }
        public string? Xa { get; set; }
        public string? Huyen { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public string? TenSong { get; set; }
        public string? LuuVucSong { get; set; }
        public string? CaoTrinhDap { get; set; }
        public string? CaoTrinhNguongTran { get; set; }
        public double? LuuLuongXaLuTK { get; set; }
        public double? LuuLuongXaLuKT { get; set; }
        public double? DungTichChet { get; set; }
        public string? SoToMay { get; set; }
        public string? SoGP { get; set; }
        public string? NgayQuyetDinh { get; set; }
        public string? ThoiGianHieuLuc { get; set; }
        public string? IDCongTrinh { get; set; }
        public string? ThoiGianBatDauKetNoi { get; set; }
        public string? CheDoKT { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
