using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class LichSuKetNoi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaLichSuKetNoi { get; set; }
        public int? MaCt { get; set; }
        public int? MaTaiKhoanKetNoi { get; set; }
        public bool? VanHanhLoi { get; set; }
        public bool? VanHanhDung { get; set; }
        public bool? MatKetNoi { get; set; }


        //tạo  khoá ngoại
        [ForeignKey("MaCt ")]
        public virtual QLC_CongTrinh? QLC_CongTrinh { get; set; }

        [ForeignKey("MaTaiKhoanKetNoi ")]
        public virtual TaiKhoanKetNoi? TaiKhoanKetNoi { get; set; }
    }
}
