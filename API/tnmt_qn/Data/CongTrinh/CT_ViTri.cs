using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class CT_ViTri
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdCongTrinh { get; set; }
        public string? IdXa { get; set; }
        public string? IdHuyen { get; set; }

        // Navigation property to represent the relationship
        [ForeignKey("IdCongTrinh")]
        public virtual CT_ThongTin? CongTrinh { get; set; }

        [ForeignKey("IdXa")]
        public virtual Xa? Xa { get; set; }

        [ForeignKey("IdHuyen")]
        public virtual Huyen? Huyen { get; set; }
    }
}
