using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class DuLieuNguonNuocThaiTrongLua
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? DienTichTrongLua { get; set; }
        public double? HeSoSuyGiam { get; set; }
        //tongtailuong
        public double? CtTrongLuaBOD { get; set; }
        public double? CtTrongLuaCOD { get; set; }
        public double? CtTrongLuaAmoni { get; set; }
        public double? CtTrongLuaTongN { get; set; }
        public double? CtTrongLuaTongP { get; set; }
        public double? CtTrongLuaTSS { get; set; }
        public double? CtTrongLuaColiform { get; set; }

        public double? LtTrongLuaBOD { get; set; }
        public double? LtTrongLuaCOD { get; set; }
        public double? LtTrongLuaAmoni { get; set; }
        public double? LtTrongLuaTongN { get; set; }
        public double? LtTrongLuaTongP { get; set; }
        public double? LtTrongLuaTSS { get; set; }
        public double? LtTrongLuaColiform { get; set; }

        public string? GhiChu { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdPhanDoanSong")]
        public virtual PhanDoanSong? PhanDoanSong { get; set; }
    }
}
