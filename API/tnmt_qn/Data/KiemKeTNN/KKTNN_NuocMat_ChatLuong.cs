using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class KKTNN_NuocMat_ChatLuong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? NguonNuoc { get; set; }
        public string? Xa { get; set; }
        public string? Huyen { get; set; }
        public string? ThuocLVS {  get; set; }
        public string? GTWQI { get; set; }
        public string? ThoiGian { get; set; }
        public bool? DaXoa { get; set; }
    }
}
