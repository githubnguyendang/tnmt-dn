using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class TaiKhoanKetNoi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTaiKhoanKetNoi { get; set; }
        public int? MaTrangThaiTaiKhoan { get; set; }
        public int? MaCt { get; set; }
        public string? TaiKhoan { get; set; }
        public string? MatKhau { get; set; }


        //tạo  khoá ngoại
        [ForeignKey("MaCt ")]
        public virtual QLC_CongTrinh? QLC_CongTrinh { get; set; }

        [ForeignKey("MaTrangThaiTaiKhoan ")]
        public virtual TrangThaiTaiKhoan? TrangThaiTaiKhoan { get; set; }

        public virtual DuLieuKetNoi? DuLieuKetNoi { get; set; }
        public virtual LichSuKetNoi? LichSuKetNoi { get; set; }


    }
}
