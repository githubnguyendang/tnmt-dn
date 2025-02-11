using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class Huyen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string IdHuyen { get; set; }
        public string? TenHuyen { get; set; }
        public string? CapHanhChinh { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        // Navigation property to represent the one-to-many relationship
        public virtual ICollection<Xa>? Xa { get; set; }
        public virtual ICollection<CT_ViTri>? CT_ViTri { get; set; }
        public virtual ICollection<Tram_ThongTin>? Tram { get; set; }
    }

    public class Xa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string IdXa { get; set; }
        public string? TenXa { get; set; }
        public string? CapHanhChinh { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        // Foreign key property
        public string? IdHuyen { get; set; }

        // Navigation property to represent the relationship
        [ForeignKey("IdHuyen")]
        public virtual Huyen? Huyen { get; set; }

        public virtual ICollection<CT_ViTri>? CT_ViTri { get; set; }
        public virtual ICollection<Tram_ThongTin>? Tram { get; set; }
    }

}
