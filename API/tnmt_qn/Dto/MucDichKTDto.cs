using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class MucDichKTDto
    {
        public int? Id { get; set; }
        public string? MucDich { get; set; }
        public bool? DaXoa { get; set; } = false;
        public LuuLuongTheoMucDichDto? LuuLuong { get; set; }
    }
}
