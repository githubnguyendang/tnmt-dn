using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class Tram_ThongTinService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public Tram_ThongTinService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<List<Tram_ThongTinDto>> GetAllAsync()
        {
            var items = await _context.Tram_ThongTin!.Where(x => x.DaXoa == false).OrderBy(x => x.Id).ToListAsync();
            return _mapper.Map<List<Tram_ThongTinDto>>(items);
        }

        public async Task<Tram_ThongTinDto?> GetByIdAsync(int Id)
        {
            var item = await _context.Tram_ThongTin!.FindAsync(Id);
            return _mapper.Map<Tram_ThongTinDto>(item);
        }


        public async Task<bool> SaveAsync(Tram_ThongTinDto dto)
        {
            var existingItem = await _context.Tram_ThongTin!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<Tram_ThongTin>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.Tram_ThongTin!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.Tram_ThongTin!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

                updateItem = _mapper.Map(dto, updateItem);

                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.Tram_ThongTin!.Update(updateItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.Tram_ThongTin!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.Tram_ThongTin!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
