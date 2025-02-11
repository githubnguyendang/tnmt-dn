using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tnmt_qn.Data
{
    public class GP_TCQ
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdGP { get; set; }
        public int IdTCQ { get; set; }

        // Navigation property to represent the relationship
        [ForeignKey("IdGP")]
        public GP_ThongTin? GP_ThongTin { get; set; }

        [ForeignKey("IdTCQ")]
        public TCQ_ThongTin? TCQ_ThongTin { get; set; }
    }
}
