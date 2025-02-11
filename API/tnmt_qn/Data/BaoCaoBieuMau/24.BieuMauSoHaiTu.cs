using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class BieuMauSoHaiTu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ThoiGian { get; set; }
        public double? LuuLuongXaThaiLonNhat { get; set; }
        public double? LuuLuongXaThaiNhoNhat { get; set; }
        public double? LuuLuongXaThaiChoPhep { get; set; }
        public double? SoNgayXaThai { get; set; }
        public double? TongLuongXaThai { get; set; }
        public string? GhiChu { get; set; }
    }
}
