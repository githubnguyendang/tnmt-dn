using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class BieuMauSoBa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TenTram { get; set; }
        public string? ThoiKyQuanTrac { get; set; }
        public double? LuongMuaThang1 { get; set; }
        public double? LuongMuaThang2 { get; set; }
        public double? LuongMuaThang3 { get; set; }
        public double? LuongMuaThang4 { get; set; }
        public double? LuongMuaThang5 { get; set; }
        public double? LuongMuaThang6 { get; set; }
        public double? LuongMuaThang7 { get; set; }
        public double? LuongMuaThang8 { get; set; }
        public double? LuongMuaThang9 { get; set; }
        public double? LuongMuaThang10 { get; set; }
        public double? LuongMuaThang11 { get; set; }
        public double? LuongMuaThang12 { get; set; }
        public double? LuongMuaNam{ get; set; }
        public string? GhiChu { get; set; }
    }
}
