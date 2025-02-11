using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class ToChuc_CaNhan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TenTCCN { get; set; }
        public string? DiaChi { get; set; }
        public string? MaSoThue { get; set; }
        public string? SDT { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? GiamDoc { get; set; }
        public string? NguoiDuocUyQuyen { get; set; }
        public string? NguoiDaiDienPhapLuat { get; set; }
        public string? TaiKhoan { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        // Navigation property to represent the relationship
        public virtual ICollection<GP_ThongTin>? GiayPhep { get; set; }

        public virtual ICollection<ThanhTraKiemTra> ThanhTraKiemTra { get; set; } = new List<ThanhTraKiemTra>();
    }
}
