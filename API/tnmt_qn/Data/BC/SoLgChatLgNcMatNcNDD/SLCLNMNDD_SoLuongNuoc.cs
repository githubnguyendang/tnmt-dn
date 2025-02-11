using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class SLCLNMNDD_SoLuongNuoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaSoLuongNuoc { get; set; }
        public int? MaLuuVuc { get; set; }
        public int? MaLoaiNuoc { get; set; }
        public int? MaViTriDieuTra { get; set; }
        public int? MaTiemNangNuocDuoiDat { get; set; }
        public int? SoLuongGieng { get; set; }
        public double? MucNuocTrungBinh { get; set; }
    }
}
