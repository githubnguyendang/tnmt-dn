using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class TrangThaiQuanTrac
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTrangThaiQuanTrac { get; set; }
        public int? MaTramQuanTracLuongMua { get; set; }
        public string? TrangThai { get; set; }


        //tạo  khoá ngoại
        [ForeignKey("MaTramQuanTracLuongMua ")]
        public virtual TramQuanTracLuongMua? TramQuanTracLuongMua { get; set; }
    }
}
