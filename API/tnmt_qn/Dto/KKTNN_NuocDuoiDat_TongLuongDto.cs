namespace tnmt_qn.Dto
{
    public class KKTNN_NuocDuoiDat_TongLuongDto
    {
        public int? Id { get; set; }
        public int? IdTangChuaNuoc { get; set; }
        public float? NuocNgot_DienTichPhanBo { get; set; }
        public int? NuocNgot_IdXa { get; set; }
        public int? NuocNgot_IdHuyen { get; set; }
        public double? NuocNgot_TLTiemNang { get; set; }
        public double? NuocNgot_TLCoTheKhaiThac { get; set; }
        public double? NuocMan_DienTichPhanBo { get; set; }
        public int? NuocMan_IdXa { get; set; }
        public int? NuocMan_IdHuyen { get; set; }
        public double? NuocMan_TruLuong { get; set; }
        public TangChuaNuocDto? TangChuaNuoc { get; set; }
        public ViTriDto? donvi_hanhchinh { get; set; }
        public NuocManNuocNgotDto? NuocNgot { get; set; }
        public NuocManNuocNgotDto? NuocMan { get; set; }

        public class NuocManNuocNgotDto
        {
            public string? Xa { get; set; }
            public string? Huyen { get; set; }
        }
    }
}
