using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class SLCLNMNDD_WNam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTongLuongNuocNam { get; set; }
        public int? MaLoaiNuoc { get; set; }
        public int? MaLuuVuc { get; set; }
        public double? TongLuongNuocNam { get; set; }
        public double? TongLuongNuocNamKyTruoc { get; set; }
        public double? TongLuongNuocNamKyBaoCao { get; set; }
        public double? TongLuongNuocNamThayDoi { get; set; }
    }
}
