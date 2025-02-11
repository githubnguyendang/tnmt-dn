using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service.BaoCaoBieuMau
{
    public class BieuMauHaiMuoiService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        // Constructor to initialize the service with required dependencies
        public BieuMauHaiMuoiService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
        }

        // Method to retrieve a list of CT_ThongTin entities based on specified filters
        public async Task<List<CT_ThongTinDto>> GetAllAsync()
        {
            _context.Database.SetCommandTimeout(120);

            var query = _context.CT_ThongTin!
                 .Where(ct => ct.DaXoa == false)
                .Include(ct => ct.LoaiCT)
                .Include(ct => ct.TangChuaNuoc)
                .Include(ct => ct.HangMuc!).ThenInclude(hm => hm.ThongSo)
                .Include(ct => ct.ThongSo)
                .Include(ct => ct.LuuVuc)
                .Include(ct => ct.CT_ViTri!).ThenInclude(vt => vt.Xa)
                .Include(ct => ct.CT_ViTri!).ThenInclude(vt => vt.Huyen)
                .Include(ct => ct.GiayPhep!).ThenInclude(gp => gp.ToChuc_CaNhan)
                .Include(ct => ct.GiayPhep!).ThenInclude(gp => gp.GP_TCQ)
                .Include(ct => ct.LuuLuongTheoMucDich!).ThenInclude(lld => lld.MucDichKT)
                .Where(ct => ct.LoaiCT!.IdCha == 1 || ct.LoaiCT.Id == 7 || ct.LoaiCT.Id == 10)
                .OrderBy(x => x.IdLoaiCT)
                .AsQueryable();

            // Return the list of DTOs
            var congtrinh = await query.ToListAsync();
            var congTrinhDtos = _mapper.Map<List<CT_ThongTinDto>>(congtrinh);

            // Return the list of DTOs
            return congTrinhDtos;
        }
    }
}
