using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class BieuMauSoHaiBa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ThoiGian { get; set; }
        public double? LuuLuongKhaiThacLonNhat { get; set; }
        public double? LuuLuongKhaiThacNhoNhat { get; set; }
        public double? LuuLuongKTDuocCapPhep { get; set; }
        public string? SoNgayKhaiThac { get; set; }
        public double? MucNuocKhaiThacLonNhat { get; set; }
        public double? MucNuocKhaiThacNhoNhat { get; set; }
        public double? ChieuSauMucNuocDongMax { get; set; }
        public double? TongLuongKhaiThac { get; set; }
        public string? GhiChu { get; set; }
    }
}
