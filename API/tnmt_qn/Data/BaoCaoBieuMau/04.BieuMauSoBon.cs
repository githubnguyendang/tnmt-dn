using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class BieuMauSoBon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? LuuVucSong { get; set; }
        public double? DongChayTBNam { get; set; }
        public double? DongChayKyTruoc { get; set; }
        public double? DongChayKyBaoCao { get; set; }
        public double? DongChayMuaLuTB { get; set; }
        public double? DongChayMuaLuKyTruoc { get; set; }
        public double? DongChayMuaLuKyBaoCao { get; set; }
        public double? DongChayMuaCanTB { get; set; }
        public double? DongChayMuaCanKyTruoc { get; set; }
        public double? DongChayMuaCanKyBaoCao { get; set; }
        public string? GhiChu { get; set; }
    }
}
