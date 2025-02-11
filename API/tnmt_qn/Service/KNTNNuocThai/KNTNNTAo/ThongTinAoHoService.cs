using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class ThongTinAoHoService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public ThongTinAoHoService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        public async Task<List<ThongTinAoHoDto>> GetAllAsync()
        {
            var items = await _context.ThongTinAoHo!.Where(b => b.DaXoa == false)
                .Include(p => p.CT_ThongTin)
                .Include(p => p.CT_ThongTin).ThenInclude(ct => ct!.ThongSo)
                .Where(p => p.CT_ThongTin != null)
                .ToListAsync();

            var pdsDtos = _mapper.Map<List<ThongTinAoHoDto>>(items);
            return pdsDtos;
        }

        public async Task<List<ThongTinAoHoDto>> GetDataCaculatePolutantAsync()
        {
            var items = await _context.ThongTinAoHo!.Where(b => b.DaXoa == false)
                .Include(p => p.CT_ThongTin)
                .Include(p => p.CT_ThongTin).ThenInclude(ct => ct!.CT_ViTri)
                .Include(p => p.CT_ThongTin!.CT_ViTri!).ThenInclude(ct => ct!.Xa)
                .Include(p => p.CT_ThongTin!.CT_ViTri!).ThenInclude(ct => ct!.Huyen)
                .Include(p => p.CT_ThongTin).ThenInclude(ct => ct!.ThongSo)
                .Where(p => p.CT_ThongTin != null)
                .ToListAsync();

            var pdsDtos = _mapper.Map<List<ThongTinAoHoDto>>(items);

            foreach (var dto in pdsDtos)
            {
                
                dto.CT_ThongTin = null;
            }

            return pdsDtos;
        }

        public async Task<ThongTinAoHoDto?> GetByIdAsync(int Id)
        {
            var item = await _context.ThongTinAoHo!.FindAsync(Id);
            return _mapper.Map<ThongTinAoHoDto>(item);
        }


        public async Task<bool> SaveAsync(ThongTinAoHoDto dto)
        {
            var existingItem = await _context.ThongTinAoHo!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<ThongTinAoHo>(dto);
                newItem.DaXoa = false;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.ThongTinAoHo!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.ThongTinAoHo!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

                updateItem = _mapper.Map(dto, updateItem);

                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.ThongTinAoHo!.Update(updateItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.ThongTinAoHo!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.ThongTinAoHo!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
