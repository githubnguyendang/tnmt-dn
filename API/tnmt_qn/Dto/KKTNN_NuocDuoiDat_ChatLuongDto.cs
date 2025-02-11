namespace tnmt_qn.Dto
{
    public class KKTNN_NuocDuoiDat_ChatLuongDto
    {
        public int? Id { get; set; }
        public int? IdXa { get; set; }
        public int? IdHuyen { get; set; }
        public double? pHMax { get; set; }
        public double? pHMin { get; set; }
        public double? DoCungMax { get; set; }
        public double? DoCungMin { get; set; }
        public double? NitratMax { get; set; }
        public double? NitratMin { get; set; }
        public double? AmoniMax { get; set; }
        public double? AmoniMin { get; set; }
        public double? SulfatMax { get; set; }
        public double? SulfatMin { get; set; }
        public double? AsenMax { get; set; }
        public double? AsenMin { get; set; }
        public ViTriDto? donvi_hanhchinh { get; set; }
    }
}
