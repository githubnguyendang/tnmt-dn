using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class DuLieuNguonNuocThaiThuySanService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        public DuLieuNguonNuocThaiThuySanService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        public async Task<List<DuLieuNguonNuocThaiThuySanDto>> GetAllAsync()
        {
            var query = _context.DuLieuNguonNuocThaiThuySan!
                .Where(gp => gp.DaXoa == false)
                .Include(x => x.PhanDoanSong)
                .AsQueryable();

            // Apply filters based on input parameters
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            var listItems = _mapper.Map<List<DuLieuNguonNuocThaiThuySanDto>>(query);

            return listItems;
        }

        public async Task<DuLieuNguonNuocThaiThuySanDto?> GetByIdAsync(int Id)
        {
            var item = await _context.DuLieuNguonNuocThaiThuySan!.FindAsync(Id);
            return _mapper.Map<DuLieuNguonNuocThaiThuySanDto>(item);
        }


        public async Task<bool> SaveAsync(DuLieuNguonNuocThaiThuySanDto dto)
        {
            var existingItem = await _context.DuLieuNguonNuocThaiThuySan!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<DuLieuNguonNuocThaiThuySan>(dto);
                newItem.DaXoa = false;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.DuLieuNguonNuocThaiThuySan!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.DuLieuNguonNuocThaiThuySan!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.DaXoa = false;
                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.DuLieuNguonNuocThaiThuySan!.Update(updateItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.DuLieuNguonNuocThaiThuySan!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.DuLieuNguonNuocThaiThuySan!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
