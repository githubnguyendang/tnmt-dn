using tnmt_qn.Data;

namespace tnmt_qn.Dto
{
    public class GP_ThongTinDto
    {
        public int? Id { get; set; }
        public int? IdCon { get; set; }
        public int? IdLoaiGP { get; set; }
        public int? IdTCCN { get; set; }
        public int? IdCT { get; set; }
        public string? TenGP { get; set; }
        public string? SoGP { get; set; }
        public DateTime? NgayKy { get; set; }
        public DateTime? NgayCoHieuLuc { get; set; }
        public DateTime? NgayHetHieuLuc { get; set; }
        public string? ThoiHan { get; set; }
        public string? CoQuanCapPhep { get; set; }
        public string? FileGiayPhep { get; set; }
        public string? FileGiayToLienQuan { get; set; }
        public string? FileDonXinCP { get; set; }
        public bool? DaBiThuHoi { get; set; }
        public bool? DaXoa { get; set; }

        public string? hieuluc_gp
        {
            get
            {
                if (DaBiThuHoi == true)
                {
                    return "da-bi-thu-hoi";
                }
                else if (NgayHetHieuLuc.HasValue)
                {
                    DateTime ngayhethan = NgayHetHieuLuc.Value;
                    if (ngayhethan >= DateTime.Today && ngayhethan < DateTime.Today.AddDays(160))
                    {
                        return "sap-het-hieu-luc";
                    }
                    else if (ngayhethan < DateTime.Today)
                    {
                        return "het-hieu-luc";
                    }
                    else if (ngayhethan > DateTime.Today.AddDays(160))
                    {
                        return "con-hieu-luc";
                    }
                }
                return "con-hieu-luc";
            }
        }

        public GP_ThongTinDto? giayphep_cu { get; set; }
        public GP_LoaiDto? loaiGP { get; set; }
        public TangChuaNuocDto? tangchuanuoc { get; set; }
        public CT_ThongTinDto? congtrinh { get; set; }
        public ToChuc_CaNhanDto? tochuc_canhan { get; set; }
        public List<GP_TCQDto>? gp_tcq { get; set; }
        public List<TCQ_ThongTinDto>? tiencq { get; set; }
        public List<GP_ThongTinDto>? LichSuCapPhep { get; set; }
        public List<GP_ThongTinDto>? GiayPhepCuaToChuc { get; set; }
        public List<ThanhTraKiemTraDto>? ThanhTraKiemTra { get; set; }
    }

    public class GPFilterFormDto
    {
        public string? so_gp { get; set; }
        public string? cong_trinh { get; set; }
        public string? coquan_cp { get; set; }
        public int? loaihinh_cp { get; set; }
        public string? hieuluc_gp { get; set; }
        public int? loai_ct { get; set; }
        public int? tang_chuanuoc { get; set; }
        public int? huyen { get; set; }
        public int? xa { get; set; }
        public int? tieuvung_qh { get; set; }
        public int? tochuc_canhan { get; set; }
        public int? tu_nam { get; set; }
        public int? den_nam { get; set; }
    }

    public class CountFolowLicensingAuthoritiesDto
    {
        public int Total { get; set; } = 0;
        public int Btnmt { get; set; } = 0;
        public int Ubndt { get; set; } = 0;
        public int Stnmt { get; set; } = 0;
    }

    public class CountFolowConstructionTypesDto
    {
        public CountFolowConsTypesData? ktsd_nm { get; set; }
        public CountFolowConsTypesData? ktsd_ndd { get; set; }
        public CountFolowConsTypesData? thamdo_ndd { get; set; }
        public CountFolowConsTypesData? hnk_ndd { get; set; }
        public CountFolowConsTypesData? xathai { get; set; }
    }

    public class CountFolowConsTypesData
    {
        public int total { get; set; }
        public int con_hieuluc { get; set; }
        public int bo_cap { get; set; }
        public int tinh_cap { get; set; }
    }

    public class LicenseStatisticsDto
    {
        public string[]? color { get; set; }
        public int[]? year { get; set; }
        public List<ApexChartSeriesDto>? series { get; set; }
    }
    public class ApexChartSeriesDto
    {
        public string? name { get; set; }
        public List<int>? data { get; set; }
    }
}
