using tnmt_qn.Data;

namespace tnmt_qn.Dto
{
    public class KKTNN_NuocMua_TongLuongDto
    {
        public int? Id { get; set; }
        public int? IdTram { get; set; }
        public string? Nam { get; set; }
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
        public double? muamua => Math.Round((double)((Thang9 ?? 0) + (Thang10 ?? 0) + (Thang11 ?? 0) + (Thang12 ?? 0)), 2);
        public double? muakho => Math.Round((double)((Thang1 ?? 0) + (Thang2 ?? 0) + (Thang3 ?? 0) + (Thang4 ?? 0) + (Thang5 ?? 0) + (Thang6 ?? 0) + (Thang7 ?? 0) + (Thang8 ?? 0)), 2);
        public double? canam => Math.Round((double)((Thang1 ?? 0) + (Thang2 ?? 0) + (Thang3 ?? 0) + (Thang4 ?? 0) + (Thang5 ?? 0) + (Thang6 ?? 0) + (Thang7 ?? 0) + (Thang8 ?? 0) + (Thang9 ?? 0) + (Thang10 ?? 0) + (Thang11 ?? 0) + (Thang12 ?? 0)), 2);
        public bool? Daxoa { get; set; }
    }
}
