using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using tnmt_qn.Data;
using tnmt_qn.Dto;

using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class DanhMucNN_NoiTinh_AoHoService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public DanhMucNN_NoiTinh_AoHoService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        public async Task<List<DanhMucNN_NoiTinh_AoHoDto>> GetAllDanhMucNN_NoiTinh_AoHoAsync()
        {
            var items = await _context.DanhMucNN_NoiTinh_AoHo!.Where(d => d.DaXoa == false)
                .OrderBy(d => d.Id)
                .AsQueryable().ToListAsync();

            var ttdlDto = _mapper.Map<List<DanhMucNN_NoiTinh_AoHoDto>>(items);

            return ttdlDto;
        }
        public async Task<bool> SaveAsync(DanhMucNN_NoiTinh_AoHoDto dto)
        {

            var existingItem = await _context.DanhMucNN_NoiTinh_AoHo!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<DanhMucNN_NoiTinh_AoHo>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.DanhMucNN_NoiTinh_AoHo!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.DanhMucNN_NoiTinh_AoHo!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.DanhMucNN_NoiTinh_AoHo!.Update(updateItem);
            }

            var res = await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.DanhMucNN_NoiTinh_AoHo!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.DanhMucNN_NoiTinh_AoHo!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
