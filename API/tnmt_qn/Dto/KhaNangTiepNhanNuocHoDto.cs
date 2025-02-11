using tnmt_qn.Data;

namespace tnmt_qn.Dto
{
    public class KhaNangTiepNhanNuocHoDto
    {
        public int Id { get; set; }
        public string? TenCT { get; set; }
        public string? Xa { get; set; }
        public string? Huyen { get; set; }
        public double? Flv { get; set; }
        public double? Ftuoi1 { get; set; }
        public double? Ftuoi2 { get; set; }
        public double? Wtru1 { get; set; }
        public double? Wtru2 { get; set; }
        public string? TranXaLu { get; set; }
        public double? HeSoFs { get; set; }

        public double? Vh { get; set; }

        //ketqua
        public double? CnnBOD { get; set; }
        public double? CnnCOD { get; set; }
        public double? CnnAmoni { get; set; }
        public double? CnnTongN { get; set; }
        public double? CnnTongP { get; set; }
        public double? CnnTSS { get; set; }
        public double? CnnColiform { get; set; }

        public double? CqcBOD { get; set; }
        public double? CqcCOD { get; set; }
        public double? CqcAmoni { get; set; }
        public double? CqcTongN { get; set; }
        public double? CqcTongP { get; set; }
        public double? CqcTSS { get; set; }
        public double? CqcColiform { get; set; }

        public double? MtnBOD => (CqcBOD - CnnBOD) * (Vh * Math.Pow(10, 6) ?? 0) * Math.Pow(10, -3) * HeSoFs ?? 0;
        public double? MtnCOD => ((CqcCOD - CnnCOD) * (Vh * Math.Pow(10, 6) ?? 0) * Math.Pow(10, -3) * HeSoFs??0);
        public double? MtnAmoni => ((CqcAmoni - CnnAmoni) * (Vh * Math.Pow(10, 6) ?? 0) * Math.Pow(10, -3)* HeSoFs??0);
        public double? MtnTongN => ((CqcTongN - CnnTongN) * (Vh * Math.Pow(10, 6) ?? 0) * Math.Pow(10, -3)* HeSoFs??0);
        public double? MtnTongP => ((CqcTongP - CnnTongP) * (Vh * Math.Pow(10, 6) ?? 0) * Math.Pow(10, -3)* HeSoFs??0);
        public double? MtnTSS => ((CqcTSS - CnnTSS) * (Vh * Math.Pow(10, 6) ?? 0) * Math.Pow(10, -3)* HeSoFs??0);
        public double? MtnColiform => ((CqcColiform - CnnColiform) * (Vh * Math.Pow(10, 6) ?? 0 ) * Math.Pow(10, -3)* HeSoFs??0);

        public string? GhiChu { get; set; }
        public bool? DaXoa { get; set; }
    }
}
