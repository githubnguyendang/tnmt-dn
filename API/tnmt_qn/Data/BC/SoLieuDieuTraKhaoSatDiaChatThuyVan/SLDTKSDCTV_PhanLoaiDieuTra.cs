using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class SLDTKSDCTV_PhanLoaiDieuTra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaPhanLoaiDieuTra { get; set; }
        public string? Tenloaidieutra { get; set; }
    }
}
