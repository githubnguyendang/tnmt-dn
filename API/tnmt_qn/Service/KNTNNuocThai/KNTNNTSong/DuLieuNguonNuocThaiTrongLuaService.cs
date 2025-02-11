using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class DuLieuNguonNuocThaiTrongLuaService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        public DuLieuNguonNuocThaiTrongLuaService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        public async Task<List<DuLieuNguonNuocThaiTrongLuaDto>> GetAllAsync()
        {
            var query = _context.DuLieuNguonNuocThaiTrongLua!
                .Where(gp => gp.DaXoa == false)
                .Include(x => x.PhanDoanSong)
                .AsQueryable();

            // Apply filters based on input parameters
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            var listItems = _mapper.Map<List<DuLieuNguonNuocThaiTrongLuaDto>>(query);

            return listItems;
        }

        public async Task<DuLieuNguonNuocThaiTrongLuaDto?> GetByIdAsync(int Id)
        {
            var item = await _context.DuLieuNguonNuocThaiTrongLua!.FindAsync(Id);
            return _mapper.Map<DuLieuNguonNuocThaiTrongLuaDto>(item);
        }


        public async Task<bool> SaveAsync(DuLieuNguonNuocThaiTrongLuaDto dto)
        {
            var existingItem = await _context.DuLieuNguonNuocThaiTrongLua!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<DuLieuNguonNuocThaiTrongLua>(dto);
                newItem.DaXoa = false;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.DuLieuNguonNuocThaiTrongLua!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.DuLieuNguonNuocThaiTrongLua!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.DaXoa = false;
                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.DuLieuNguonNuocThaiTrongLua!.Update(updateItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.DuLieuNguonNuocThaiTrongLua!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.DuLieuNguonNuocThaiTrongLua!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
