namespace tnmt_qn.Dto
{
    public class KKTNN_NuocMat_KhaiThacSuDungDto
    {
        public int? Id { get; set; }
        public string? ten_ct { get; set; }
        public double? x { get; set; }
        public double? y { get; set; }
        public List<XaDto>? xa { get; set; }
        public List<HuyenDto>? huyen { get; set; }
        public string? tinh { get; set; } = "Quảng Ngãi";
        public string? lv_song { get; set; }
        public string? loai_ct { get; set; }
        public string? nguonnuoc_kt { get; set; }
        public string? mucdich_kt { get; set; }
        public double? dungtich_ho { get; set; }
        public double? q_kt_tuoi { get; set; }
        public double? q_kt_kddv_sx_phi_nn { get; set; }
        public double? congsuat { get; set; }
        public double? mucdich_khac { get; set; }
    }
}
