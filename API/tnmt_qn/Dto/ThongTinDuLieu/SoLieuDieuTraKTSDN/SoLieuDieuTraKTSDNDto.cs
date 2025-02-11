namespace tnmt_qn.Dto
{
    public class SLDTKTSDN_NuocMatDto
    {
        public int? Id { get; set; }
        public string? TenChuHoCT { get; set; }
        public string? LoaiCongTrinh { get; set; }
        public string? Xa { get; set; }
        public string? Huyen { get; set; }
        public string? TenNguonNuocKhaiThac { get; set; }
        public string? MucDichSD { get; set; }
        public double? UocTinhLuongNuocKT { get; set; }
        public double? DienTichTuoi { get; set; }
        public double? DienTichNuoiTrongThuySan { get; set; }
        public double? CongSuatPhatDien { get; set; }
        public string? SoHoDanDuocCapNuoc { get; set; }
        public string? CheDoKT { get; set; }
        public string? FilePDF { get; set; }
        public string? GhiChu { get; set; }
    }
    public class SLDTKTSDN_NDDDto
    {
        public int? Id { get; set; }
        public string? TenChuHoCT { get; set; }
        public string? Xa { get; set; }
        public string? Huyen { get; set; }
        public string? SoLuongGieng { get; set; }
        public double? UocTinhLuongNuocKT { get; set; }
        public string? LoaiCT { get; set; }
        public double? HinhThucKT { get; set; }
        public double? ChieuSauKT { get; set; }
        public double? MucDichSD { get; set; }
        public string? TinhTrangSD { get; set; }
        public string? PhieuDieuTraPDF { get; set; }
        public string? GhiChu { get; set; }
    }
    public class SLDTKTSDN_XaThaiDto
    {
        public int? Id { get; set; }
        public string? TenChuHoCT { get; set; }
        public string? LoaiHinhNuocThai { get; set; }
        public string? Xa { get; set; }
        public string? Huyen { get; set; }
        public string? QuyMo { get; set; }
        public string? MucDichSD { get; set; }
        public double? DienTichTuoi { get; set; }
        public double? DienTichNuoiTrongThuySan { get; set; }
        public double? CongSuatPhatDien { get; set; }
        public string? SoHoDanDuocCapNuoc { get; set; }
        public string? CheDoKT { get; set; }
        public string? PhieuDieuTraPDF { get; set; }
        public string? GhiChu { get; set; }
    }
}
