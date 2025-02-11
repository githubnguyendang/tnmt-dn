using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class TongLuongMua
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTongLuongMua { get; set; }
        public int? MaTramQuanTracLuongMua { get; set; }
        public int? MaPhuongPhapTinhMua { get; set; }
        public int? MaSoLieuMua { get; set; }
        public double? LuongMuaThangI { get; set; }
        public double? LuongMuaThangII { get; set; }
        public double? LuongMuaThangIII { get; set; }
        public double? LuongMuaThangIV { get; set; }
        public double? LuongMuaThangV { get; set; }
        public double? LuongMuaThangVI { get; set; }
        public double? LuongMuaThangVII { get; set; }
        public double? LuongMuaThangVIII { get; set; }
        public double? LuongMuaThangIX { get; set; }
        public double? LuongMuaThangX { get; set; }
        public double? LuongMuaThangXI { get; set; }
        public double? LuongMuaThangXII { get; set; }
        public double? TongLuongMuaMuaLu { get; set; }
        public double? TongMuaMuaCan { get; set; }
        public double? TongLuongMuaNam { get; set; }


        //tạo  khoá ngoại
        [ForeignKey("MaTramQuanTracLuongMua ")]
        public virtual TramQuanTracLuongMua? TramQuanTracLuongMua { get; set; }

        [ForeignKey("MaSoLieuMua ")]
        public virtual SoLieuMua? SoLieuMua { get; set; }

        [ForeignKey("MaPhuongPhapTinhMua ")]
        public virtual PhuongPhapTinhMua? PhuongPhapTinhMua { get; set; }
    }
}
