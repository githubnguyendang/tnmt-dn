using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class NCKTSDN_NhuCauSuDungNuoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNhuCauSuDungNuoc { get; set; }
        public int? MaLoaiTaiNguyenNuoc { get; set; }
        public int? MaTongLuongNuoc { get; set; }
        public int? MaMucNuocLonNhatCoTheKhaiThac { get; set; }
        public int? MaKhaNangDapUngNguonNuoc { get; set; }
        public string? TieuVungLuuVuc { get; set; }
        public string? LoaiNhuCau { get; set; }
        public double? ThangI { get; set; }
        public double? ThangII { get; set; }
        public double? ThangIII { get; set; }
        public double? ThangIV { get; set; }
        public double? ThangV { get; set; }
        public double? ThangVI { get; set; }
        public double? ThangVII { get; set; }
        public double? ThangVIII { get; set; }
        public double? ThangIX { get; set; }
        public double? ThangX { get; set; }
        public double? ThangXI { get; set; }
        public double? ThangXII { get; set; }
        public double? TBNam { get; set; }
        public double? W { get; set; }
    }
}
