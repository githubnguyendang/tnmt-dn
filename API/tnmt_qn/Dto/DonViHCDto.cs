namespace tnmt_qn.Dto
{
    public class ViTriDto
    {
        public string? IdHuyen { get; set; }
        public string? TenHuyen { get; set; }
        public List<XaDto> Xa { get; set; } = new List<XaDto>();
    }
    public class HuyenDto
    {
        public string? TenHuyen { get; set; }
        public string? IdHuyen { get; set; }
    }
    public class XaDto
    {
        public string? IdHuyen { get; set; }
        public string? TenHuyen { get; set; }
        public string? IdXa { get; set; }
        public string? TenXa { get; set; }
        public string? CapHanhChinh { get; set; }
    }
}
