using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class PhanLoaiDapTran
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaPhanLoaiDapTran { get; set; }
        public int? MaHangMucDapTran { get; set; }
        public bool? PhanLoaiTheoHinhDangCuaVao { get; set; }
        public bool? PhanLoaiTheoHinhDangVaKichThuocMatCatNgangDapTran { get; set; }
        public bool? PhanLoaiTheoHinhDangTuyenDap { get; set; }
        public bool? PhanLoaiTheoCheDoChay { get; set; }

        //tạo  khoá ngoại
        [ForeignKey("MaHangMucDapTran")]
        public virtual HangMucDapTran? HangMucDapTran { get; set; }
    }
}
