using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class TongLuongDongChay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTongLuongDongChay { get; set; }
        public int? MaLuuVucSong { get; set; }
        public double? TongLuongDongChayThangI { get; set; }
        public double? TongLuongDongChayThangII { get; set; }
        public double? TongLuongDongChayThangIII { get; set; }
        public double? TongLuongDongChayThangIV { get; set; }
        public double? TongLuongDongChayThangV { get; set; }
        public double? TongLuongDongChayThangVI { get; set; }
        public double? TongLuongDongChayThangVII { get; set; }
        public double? TongLuongDongChayThangVIII { get; set; }
        public double? TongLuongDongChayThangIX { get; set; }
        public double? TongLuongDongChayThangX { get; set; }
        public double? TongLuongDongChayThangXI { get; set; }
        public double? TongLuongDongChayThangXII { get; set; }
        public double? TongLuongDongChayMuaLu { get; set; }
        public double? TongDongChayMuaCan { get; set; }
        public double? TongLuongDongChayNam { get; set; }


        //tạo  khoá ngoại
        [ForeignKey("MaLuuVucSong ")]
        public virtual TLN_LuuVucSong? TLN_LuuVucSong { get; set; }
    }
}
