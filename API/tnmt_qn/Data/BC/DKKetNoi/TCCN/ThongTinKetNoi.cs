using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class ThongTinKetNoi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? MaThongTinKetNoi { get; set; }
        public int MaCt { get; set; }
        public string? TaiKhoanKetNoi { get; set; }
        public string? MatKhauKetNoi { get; set; }
        public string? DiaChiNhanDuLieu { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaCt ")]
        public virtual QLC_CongTrinh? QLC_CongTrinh { get; set; }
    }
}
