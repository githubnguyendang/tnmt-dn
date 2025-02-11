using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class SLDTKSDCTV_ThongTinVungDieuTra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaThongTinVungDieuTra { get; set; }
        public int? MaPhanLoaiDieuTra { get; set; }
        public int? MaTieuVungQuyHoach { get; set; }
        public int? MaPhuongPhapDieuTraDiaChatThuyVan { get; set; }
        public int? MaSoLieuDieuTra { get; set; }
        public int? MaHuyen { get; set; }
        public int? MaXa { get; set; }
        public string? DiaDiemDieuTra { get; set; }
    }
}
