using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Linq;

namespace tnmt_qn.Service
{
    public class NM_KhaiThacSuDungService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public NM_KhaiThacSuDungService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<List<KKTNN_NuocMat_KhaiThacSuDungDto>> GetAllAsync()
        {
            // Retrieve data from the database asynchronously
            var items = await _context.CT_ThongTin!
                .Where(d => d.DaXoa == false)
                .Include(ct => ct.LoaiCT)
                .Include(ct => ct.TangChuaNuoc)
                .Include(ct => ct.HangMuc!).ThenInclude(hm => hm.ThongSo)
                .Include(ct => ct.ThongSo)
                .Include(ct => ct.LuuVuc)
                .Include(ct => ct.CT_ViTri)
                .Include(ct => ct.CT_ViTri!).ThenInclude(vt => vt.Xa)
                .Include(ct => ct.CT_ViTri!).ThenInclude(vt => vt.Huyen)
                .Include(ct => ct.LuuLuongTheoMucDich!).ThenInclude(lld => lld.MucDichKT)
                .ToListAsync();

            // Filter and categorize the retrieved data
            var hochua_dapdang = items
                .Where(c => c.IdLoaiCT == 4 && c.ThongSo != null && c.ThongSo.DungTichToanBo != null && c.ThongSo.DungTichToanBo >= 0.01);

            var sxnn_ntts = items
                   .Where(c => c.LoaiCT != null && new List<int> { 5, 6 }.Contains(c.LoaiCT.Id)
                   && c.LuuLuongTheoMucDich != null
                   && c.LuuLuongTheoMucDich.Any(lld => lld.MucDichKT != null && lld.MucDichKT.MucDich != null &&
                   (lld.MucDichKT.MucDich!.ToLower().Contains("nuôi trồng thủy sản") || lld.MucDichKT.MucDich!.ToLower().Contains("nông nghiệp")))
                   && c.LuuLuongTheoMucDich.Sum(lld => lld.DonViDo == "m3/ngày đêm" ? lld.LuuLuong ?? 0 * 86400 : lld.LuuLuong ?? 0) > 0.1)
                   .Select(c =>
                   {
                       return c;
                   });

            var kddv_sxpnn = items
                .Where(c => c.LoaiCT != null && new List<int> { 4, 5, 6 }.Contains(c.LoaiCT.Id)
                            && c.LuuLuongTheoMucDich != null && c.LuuLuongTheoMucDich.Any(lld => new List<int?> { 2, 3 }.Contains(lld.IdMucDich))
                            && c.ThongSo!.QKhaiThac > 0.00116 && c.ThongSo.CongSuatLM > 50);

            // Combine filtered data from different categories
            var newData = hochua_dapdang.Concat(sxnn_ntts).Concat(kddv_sxpnn).ToList();

            // Map filtered data to DTOs
            var dtos = _mapper.Map<List<KKTNN_NuocMat_KhaiThacSuDungDto>>(newData);

            // Set additional property for each DTO
            foreach (var dto in dtos)
            {
                dto.tinh = "Quảng Ngãi";
            }

            return dtos;
        }

    }
}
