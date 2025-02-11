using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tnmt_qn.Dto;

namespace tnmt_qn.Data
{
    public class SLCLNMNDD_TiemNangNuocDuoiDat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTiemNangNuocDuoiDat { get; set; }
        public double? GiaTriModulDongNgam_Min { get; set; }
        public double? GiaTriModulDongNgam_Max { get; set; }
        public double? GiaTriModulDongNgam_TB { get; set; }
        public double? TruLuongDongTuNhienQd { get; set; }
        public double? TenTangChuaNuoc { get; set; }
    }
}
