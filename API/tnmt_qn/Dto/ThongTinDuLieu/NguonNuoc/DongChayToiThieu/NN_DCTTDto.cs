namespace tnmt_qn.Dto
{
    public class NN_DCTT_HaDuHoChuaDto
    {
        public int? Id { get; set; }
        public string? TenCT { get; set; }
        public string? ThuocLVS { get; set; }
        public string? XaPhuongTT { get; set; }
        public string? HuyenTP { get; set; }
        public string? NguonNuocKhaiThac { get; set; }
        public double? QttSauDap { get; set; }
        public double? QttSauCT { get; set; }
        public double? QttQuyDinhKhac { get; set; }
        public string? LoaiHinhCT { get; set; }
    }

    public class NN_DCTT_SongSuoiDto
    {
        public int? Id { get; set; }
        public string? TenSong { get; set; }
        public string? ThuocLVS { get; set; }
        public string? TenDiem { get; set; }
        public string? XaPhuongTT { get; set; }
        public string? HuyenTP { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public double? DienTichViTriXacDinhQtt { get; set; }
        public double? Qtt { get; set; }
    }
}
