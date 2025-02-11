using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class NCKTSDN_KhaNangDapUngNguonNuoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaKhaNangDapUngNguonNuoc { get; set; }
        public int? MaLoaiTaiNguyenNuoc { get; set; }
        public string? LuuVuc { get; set; }
        public double? TongLuongNuoc { get; set; }
        public double? TongNhuCauNuoc { get; set; }
        public double? TiLeSoVoiNhuCau { get; set; }
    }
}
