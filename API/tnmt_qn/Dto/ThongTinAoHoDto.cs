namespace tnmt_qn.Dto
{
    public class ThongTinAoHoDto
    {
        public int Id { get; set; }
        public int IdHoChua { get; set; }
        public double? Ftuoi1 { get; set; }
        public double? Ftuoi2 { get; set; }
        public double? Wtru1 { get; set; }
        public double? Wtru2 { get; set; }
        public string? TranXaLu { get; set; }
        //ketqua
        public double? CnnBOD { get; set; }
        public double? CnnCOD { get; set; }
        public double? CnnAmoni { get; set; }
        public double? CnnTongN { get; set; }
        public double? CnnTongP { get; set; }
        public double? CnnTSS { get; set; }
        public double? CnnColiform { get; set; }

        //gioi han
        public double? CghBOD { get; set; }
        public double? CghCOD { get; set; }
        public double? CghAmoni { get; set; }
        public double? CghTongN { get; set; }
        public double? CghTongP { get; set; }
        public double? CghTSS { get; set; }
        public double? CghColiform { get; set; }

        public double? VH { get; set; }
        public double? FS { get; set; }

        //Mtn
        public double? MtnBOD => (CghBOD - CnnBOD) * (VH * Math.Pow(10, 6) ?? 0) * Math.Pow(10, -3) * FS ?? 0;
        public double? MtnCOD => (CghCOD - CnnCOD) * (VH * Math.Pow(10, 6) ?? 0) * Math.Pow(10, -3) * FS ?? 0;
        public double? MtnAmoni => (CghAmoni - CnnAmoni) * (VH * Math.Pow(10, 6) ?? 0) * Math.Pow(10, -3) * FS ?? 0;
        public double? MtnTongN => (CghTongN - CnnTongN) * (VH * Math.Pow(10, 6) ?? 0) * Math.Pow(10, -3) * FS ?? 0;
        public double? MtnTongP => (CghTongP - CnnTongP) * (VH * Math.Pow(10, 6) ?? 0) * Math.Pow(10, -3) * FS ?? 0;
        public double? MtnTSS => (CghTSS - CnnTSS) * (VH * Math.Pow(10, 6) ?? 0) * Math.Pow(10, -3) * FS ?? 0;
        public double? MtnColiform => (CghColiform - CnnColiform) * (VH * Math.Pow(10, 6) ?? 0) * Math.Pow(10, -3) * FS ?? 0;
        public string? GhiChu { get; set; }
        public CT_ThongTinDto? CT_ThongTin { get; set; }
    }
}
