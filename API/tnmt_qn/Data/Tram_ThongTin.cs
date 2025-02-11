using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class Tram_ThongTin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? IdXa { get; set; }
        public string? IdHuyen { get; set; }
        public int? IdLoaiTram { get; set; }
        public string? MaTram { get; set; }
        public string? TenTram { get; set; }
        public string? DiaChiTram { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public string? NgayBatDau { get; set; }
        public string? NgayKetThuc { get; set; }
        public string? HoSoThanhLap { get; set; }
        public string? HoSoHoatDong { get; set; }
        public string? CameraLine { get; set; }
        public bool? OnlineStatus { get; set; }
        public string? ChuThich { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdLoaiTram")]
        public virtual Tram_LoaiTram? LoaiTram { get; set; }

        [ForeignKey("IdXa")]
        public virtual Xa? Xa { get; set; }

        [ForeignKey("IdHuyen")]
        public virtual Huyen? Huyen { get; set; }

        public virtual ICollection<KKTNN_NuocMua_TongLuong>? KKTNN_NuocMua_TongLuong { get; set; }
        public virtual ICollection<DuLieuTram>? DuLieuTram { get; set; }

    }
}
