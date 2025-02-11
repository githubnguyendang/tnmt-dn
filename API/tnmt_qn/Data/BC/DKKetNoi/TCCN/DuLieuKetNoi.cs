using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class DuLieuKetNoi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDuLieuKetNoi { get; set; }
        public int? MaCt { get; set; }
        public int? MaTaiKhoanKetNoi { get; set; }
        public string? LoaiDuLieuKetNoi { get; set; }
        public double? DuLieu { get; set; }
        public string? DonViDo { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaCt ")]
        public virtual QLC_CongTrinh? QLC_CongTrinh { get; set; }

        [ForeignKey("MaTaiKhoanKetNoi ")]
        public virtual TaiKhoanKetNoi? TaiKhoanKetNoi { get; set; }
    }
}
