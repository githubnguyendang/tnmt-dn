using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class DuLieuNguonNuocThaiSinhHoatDBService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        public DuLieuNguonNuocThaiSinhHoatDBService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        public async Task<List<DuLieuNguonNuocThaiSinhHoatDBDto>> GetAllAsync()
        {
            var query = _context.DuLieuNguonNuocThaiSinhHoatDB!
                .Where(gp => gp.DaXoa == false)
                .Include(x => x.PhanDoanSong)
                .AsQueryable();

            // Apply filters based on input parameters
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            var listItems = _mapper.Map<List<DuLieuNguonNuocThaiSinhHoatDBDto>>(query);

            return listItems;
        }

        public async Task<DuLieuNguonNuocThaiSinhHoatDBDto?> GetByIdAsync(int Id)
        {
            var item = await _context.DuLieuNguonNuocThaiSinhHoatDB!.FindAsync(Id);
            return _mapper.Map<DuLieuNguonNuocThaiSinhHoatDBDto>(item);
        }


        public async Task<bool> SaveAsync(DuLieuNguonNuocThaiSinhHoatDBDto dto)
        {
            var existingItem = await _context.DuLieuNguonNuocThaiSinhHoatDB!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<DuLieuNguonNuocThaiSinhHoatDB>(dto);
                newItem.DaXoa = false;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.DuLieuNguonNuocThaiSinhHoatDB!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.DuLieuNguonNuocThaiSinhHoatDB!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.DaXoa = false;
                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.DuLieuNguonNuocThaiSinhHoatDB!.Update(updateItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.DuLieuNguonNuocThaiSinhHoatDB!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.DuLieuNguonNuocThaiSinhHoatDB!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
