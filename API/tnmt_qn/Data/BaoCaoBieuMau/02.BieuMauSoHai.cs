using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class BieuMauSoHai
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TenTram { get; set; }
        public string? ThoiKyQuanTrac { get; set; }
        public double? MuaNamKyTruoc { get; set; }
        public double? MuaNamBaoCao { get; set; }
        public double? MuaNamThayDoi { get; set; }
        public double? MuaMuaKyTruoc { get; set; }
        public double? MuaMuaBaoCao { get; set; }
        public double? MuaMuaThayDoi { get; set; }
        public double? MuaKhoKyTruoc { get; set; }
        public double? MuaKhoBaoCao { get; set; }
        public double? MuaKhoThayDoi { get; set; }
        
    }
}
