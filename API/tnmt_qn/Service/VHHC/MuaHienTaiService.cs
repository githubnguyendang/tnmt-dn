using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class MuaHienTaiService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public MuaHienTaiService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<List<MuaHienTaiDto>> GetAllAsync()
        {
            var items = await _context.MuaHienTai!.Where(b => b.DaXoa == false).ToListAsync();
            return _mapper.Map<List<MuaHienTaiDto>>(items);
        }

        public async Task<MuaHienTaiDto?> GetByIdAsync(int Id)
        {
            var item = await _context.MuaHienTai!.FindAsync(Id);
            return _mapper.Map<MuaHienTaiDto>(item);
        }


        public async Task<bool> SaveAsync(MuaHienTaiDto dto)
        {
            var existingItem = await _context.MuaHienTai!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<MuaHienTai>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.MuaHienTai!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.MuaHienTai!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

                updateItem = _mapper.Map(dto, updateItem);

                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.MuaHienTai!.Update(updateItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.MuaHienTai!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.MuaHienTai!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
