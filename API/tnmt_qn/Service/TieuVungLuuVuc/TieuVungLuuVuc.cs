using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class TieuVungLuuVucService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public TieuVungLuuVucService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<List<TieuVungLuuVucDto>> GetAllAsync()
        {
            var items = await _context.TieuVungLuuVuc!.Where(b => b.DaXoa == false).OrderBy(b => b.TieuVungQuyHoach).ToListAsync();
            return _mapper.Map<List<TieuVungLuuVucDto>>(items);
        }

        public async Task<TieuVungLuuVucDto?> GetByIdAsync(int Id)
        {
            var item = await _context.TieuVungLuuVuc!.FindAsync(Id);
            return _mapper.Map<TieuVungLuuVucDto>(item);
        }


        public async Task<bool> SaveAsync(TieuVungLuuVucDto dto)
        {
            var existingItem = await _context.TieuVungLuuVuc!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<TieuVungLuuVuc>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.TieuVungLuuVuc!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.TieuVungLuuVuc!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

                updateItem = _mapper.Map(dto, updateItem);

                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.TieuVungLuuVuc!.Update(updateItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.TieuVungLuuVuc!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.TieuVungLuuVuc!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
