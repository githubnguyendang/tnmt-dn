using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class TaiLuongNuocThaiSongDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public virtual DuLieuNguonNuocNhanDB? DuLieuNguonNuocNhanDB { get; set; }
        public virtual DuLieuNguonNuocThaiDiemDB? DuLieuNguonNuocThaiDiemDB { get; set; }
        public virtual DuLieuNguonNuocThaiSinhHoatDB? DuLieuNguonNuocThaiSinhHoatDB { get; set; }
        public virtual DuLieuNguonNuocThaiGiaCamDB? DuLieuNguonNuocThaiGiaCamDB { get; set; }
        public virtual DuLieuNguonNuocThaiLonDB? DuLieuNguonNuocThaiLonDB { get; set; }
        public virtual DuLieuNguonNuocThaiTrauBoDB? DuLieuNguonNuocThaiTrauBoDB { get; set; }
        public virtual DuLieuNguonNuocThaiTrongCayDB? DuLieuNguonNuocThaiTrongCayDB { get; set; }
        public virtual DuLieuNguonNuocThaiTrongLuaDB? DuLieuNguonNuocThaiTrongLuaDB { get; set; }
        public virtual DuLieuNguonNuocThaiTrongRungDB? DuLieuNguonNuocThaiTrongRungDB { get; set; }
        public virtual DuLieuNguonNuocThaiThuySanDB? DuLieuNguonNuocThaiThuySanDB { get; set; }

        [ForeignKey("IdPhanDoanSong")]
        public virtual PhanDoanSong? PhanDoanSong { get; set; }
    }
}
