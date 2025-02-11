using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class DuLieuNguonNuocThaiTrongLuaDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPhanDoanSong { get; set; }
        public double? DienTichTrongLuaDB { get; set; }
        public double? HeSoSuyGiamDB { get; set; }
        //tongtailuong
        public double? CtTrongLuaBODDB { get; set; }
        public double? CtTrongLuaCODDB { get; set; }
        public double? CtTrongLuaAmoniDB { get; set; }
        public double? CtTrongLuaTongNDB { get; set; }
        public double? CtTrongLuaTongPDB { get; set; }
        public double? CtTrongLuaTSSDB { get; set; }
        public double? CtTrongLuaColiformDB { get; set; }

        public double? LtTrongLuaBODDB { get; set; }
        public double? LtTrongLuaCODDB { get; set; }
        public double? LtTrongLuaAmoniDB { get; set; }
        public double? LtTrongLuaTongNDB { get; set; }
        public double? LtTrongLuaTongPDB { get; set; }
        public double? LtTrongLuaTSSDB { get; set; }
        public double? LtTrongLuaColiformDB { get; set; }

        public string? GhiChu { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        [ForeignKey("IdPhanDoanSong")]
        public virtual PhanDoanSong? PhanDoanSong { get; set; }
    }
}
