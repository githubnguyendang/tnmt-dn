using tnmt_qn.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Dto
{
    public class KKTNN_NuocMat_TongLuongDto
    {
        public int? Id { get; set; }
        public int? IdLuuVucSong { get; set; }
        public int? Nam { get; set; }
        public double? Thang1 { get; set; }
        public double? Thang2 { get; set; }
        public double? Thang3 { get; set; }
        public double? Thang4 { get; set; }
        public double? Thang5 { get; set; }
        public double? Thang6 { get; set; }
        public double? Thang7 { get; set; }
        public double? Thang8 { get; set; }
        public double? Thang9 { get; set; }
        public double? Thang10 { get; set; }
        public double? Thang11 { get; set; }
        public double? Thang12 { get; set; }
        public double? MuaLu => Math.Round((double)(Thang1  + Thang2 + Thang3 + Thang4 + Thang5 + Thang6??0), 2);
        public double? MuaKiet => (Thang7 + Thang8 + Thang9 + Thang10 + Thang11 + Thang12);
        public double? CaNam => (MuaLu + MuaKiet);
        public LuuVucSong? LuuVucSong { get; set; }
        public ViTriDto? vitri { get; set; }
        public bool? DaXoa { get; set; }
    }
}
