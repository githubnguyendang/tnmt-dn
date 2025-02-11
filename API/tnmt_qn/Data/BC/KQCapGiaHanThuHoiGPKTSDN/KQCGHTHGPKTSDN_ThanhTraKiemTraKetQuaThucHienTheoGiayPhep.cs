using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class KQCGHTHGPKTSDN_ThanhTraKiemTraKetQuaThucHienTheoGiayPhep
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaThanhTra_KiemTraKetQuaThucHienTheoGiayPhepKTSDN { get; set; }
        public int? MaThongTinGiayPhepKTSDN { get; set; }
        public string? MaCongTrinh { get; set; }
        public string? HoSoKetQuaThanhTra_KiemTr { get; set; }
    }
}
