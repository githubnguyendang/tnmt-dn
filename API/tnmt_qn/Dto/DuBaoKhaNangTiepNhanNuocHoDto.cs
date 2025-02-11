using tnmt_qn.Data;

namespace tnmt_qn.Dto
{
    public class DuBaoKhaNangTiepNhanNuocHoDto
    {
        public int Id { get; set; }
        public int IdHoChua { get; set; }
        public int IdMucPL { get; set; }
        public double? CnnBOD { get; set; }
        public double? CnnCOD { get; set; }
        public double? CnnAmoni { get; set; }
        public double? CnnTongN { get; set; }
        public double? CnnTongP { get; set; }
        public double? CnnTSS { get; set; }
        public double? CnnColiform { get; set; }
        public double? VH { get; set; }
        public double? FS { get; set; }
        //Mtn
        public double? MtnBOD { get; set; }
        public double? MtnCOD { get; set; }
        public double? MtnAmoni { get; set; }
        public double? MtnTongN { get; set; }
        public double? MtnTongP { get; set; }
        public double? MtnTSS { get; set; }
        public double? MtnColiform { get; set; }
        public CT_ThongTin? CT_ThongTin { get; set; }
        public ThongSoCLNDuBao? ThongSoCLNDuBao { get; set; }

    }
}
