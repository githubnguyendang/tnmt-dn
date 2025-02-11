using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class ThongSoDiemQuanTracService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        public ThongSoDiemQuanTracService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        public async Task<List<ThongSoDiemQuanTracDto>> GetAllAsync(int nam)
        {
            var query = _context.ThongSoDiemQuanTrac!
                .Where(d => d.DaXoa == false && d.Year == nam)
                .Include(x => x.DiemQuanTrac)
                .AsQueryable();

            // Apply filters based on input parameters
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            var listItems = _mapper.Map<List<ThongSoDiemQuanTracDto>>(query);

            return listItems;
        }

        public async Task<List<ThongSoDiemQuanTracDto>> GetAllDataAsync()
        {
            var query = _context.ThongSoDiemQuanTrac!
                .Where(d => d.DaXoa == false )
                .Include(x => x.DiemQuanTrac)
                .AsQueryable();

            // Apply filters based on input parameters
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            var listItems = _mapper.Map<List<ThongSoDiemQuanTracDto>>(query);

            return listItems;
        }


        public async Task<bool> SaveAsync(ThongSoDiemQuanTracDto dto)
        {
            var existingItem = await _context.ThongSoDiemQuanTrac!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<ThongSoDiemQuanTrac>(dto);
                newItem.DaXoa = false;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.ThongSoDiemQuanTrac!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.ThongSoDiemQuanTrac!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.DaXoa = false;
                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.ThongSoDiemQuanTrac!.Update(updateItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.ThongSoDiemQuanTrac!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.ThongSoDiemQuanTrac!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
