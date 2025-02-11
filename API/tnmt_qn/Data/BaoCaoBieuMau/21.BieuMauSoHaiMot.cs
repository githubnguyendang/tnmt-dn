using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class BieuMauSoHaiMot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ThoiGian { get; set; }
        public double? LuuLuongDenHoLonNhat { get; set; }
        public double? LuuLuongDenHoNhoNhat { get; set; }
        public double? TongLuuLuongXaLonNhat { get; set; }
        public double? TongLuuLuongXaNhoNhat { get; set; }
        public double? DongChayToiThieuLonNhat { get; set; }
        public double? DongChayToiThieuNhoNhat { get; set; }
        public string? GhiChu { get; set; }
    }
}
