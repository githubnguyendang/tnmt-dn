using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class KQCGHTHGPKTSDN_QuanLyNgayCapPhepKTSDN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaQuanLyNgayCapPhepKTSDN { get; set; }
        public int? MaThongTinGiayPhepKTSDN { get; set; }
        public string? NgayKyGiayPhepKTSDN { get; set; }
        public string? NgayGiayPhepCoHieuLucKTSDN { get; set; }
        public string? NgayGiayPhepHetHanKTSDN { get; set; }
        public string? CoQuanCapPhepKTSDN { get; set; }
        public string? TenChuGiayPhepKTSDN { get; set; }
        public string? DiaChiChuGiayPhepKTSDN { get; set; }
    }
}
