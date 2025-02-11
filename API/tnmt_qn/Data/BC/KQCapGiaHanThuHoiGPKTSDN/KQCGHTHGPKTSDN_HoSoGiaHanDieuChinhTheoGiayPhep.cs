using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class KQCGHTHGPKTSDN_HoSoGiaHanDieuChinhTheoGiayPhep
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHoSoGiaHan_ThuHoi_DieuChinhTheoGiayPhepKTSDN { get; set; }
        public int? MaThongTinGiayPhepKTSDN { get; set; }
        public string? MaCongTrinh { get; set; }
        public string? HoSoGiaHan_ThuHoi_DieuChinh { get; set; }
    }
}
