using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class DuLieuNguonNuocThaiDiemService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        public DuLieuNguonNuocThaiDiemService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        public async Task<List<DuLieuNguonNuocThaiDiemDto>> GetAllAsync()
        {
            var query = _context.DuLieuNguonNuocThaiDiem!
                .Where(gp => gp.DaXoa == false)
                .Include(x => x.PhanDoanSong)
                .AsQueryable();

            // Apply filters based on input parameters
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);
            
            var listItems = _mapper.Map<List<DuLieuNguonNuocThaiDiemDto>>(query);

            return listItems;
        }

        public async Task<DuLieuNguonNuocThaiDiemDto?> GetByIdAsync(int Id)
        {
            var item = await _context.DuLieuNguonNuocThaiDiem!.FindAsync(Id);
            return _mapper.Map<DuLieuNguonNuocThaiDiemDto>(item);
        }


        public async Task<bool> SaveAsync(DuLieuNguonNuocThaiDiemDto dto)
        {
            var existingItem = await _context.DuLieuNguonNuocThaiDiem!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<DuLieuNguonNuocThaiDiem>(dto);
                newItem.DaXoa = false;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.DuLieuNguonNuocThaiDiem!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.DuLieuNguonNuocThaiDiem!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.DaXoa = false;
                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.DuLieuNguonNuocThaiDiem!.Update(updateItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.DuLieuNguonNuocThaiDiem!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.DuLieuNguonNuocThaiDiem!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
