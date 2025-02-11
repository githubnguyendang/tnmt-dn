using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class CheDoQuanTracMucNuoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? MaCheDoQuanTracMucNuoc { get; set; }
        public int? MaCongTrinhHoChua { get; set; }
        public string? CheDoQuanTracMucNuocHoMuaLu { get; set; }
        public string? CheDoQuanTracMucNuocHoMuaKiet { get; set; }


        //tạo  khoá ngoại
        [ForeignKey("MaCongTrinhHoChua")]
        public virtual CongTrinhHoChua? CongTrinhHoChua { get; set; }
    }
}
