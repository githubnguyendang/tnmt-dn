using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class BieuMauSoNam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? Nam { get; set; }
        public string? TenTram { get; set; }
        public double? LuuLuongThang1 { get; set; }
        public double? LuuLuongThang2 { get; set; }
        public double? LuuLuongThang3 { get; set; }
        public double? LuuLuongThang4 { get; set; }
        public double? LuuLuongThang5 { get; set; }
        public double? LuuLuongThang6 { get; set; }
        public double? LuuLuongThang7 { get; set; }
        public double? LuuLuongThang8 { get; set; }
        public double? LuuLuongThang9 { get; set; }
        public double? LuuLuongThang10 { get; set; }
        public double? LuuLuongThang11 { get; set; }
        public double? LuuLuongThang12 { get; set; }
        public double? LuuLuongNam { get; set; }
        public string? GhiChu { get; set; }
    }
}
