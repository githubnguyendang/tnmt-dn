using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public interface IThanhTraKiemTraService
    {
        public Task<List<ThanhTraKiemTraDto>> GetAllAsync();
        public Task<ThanhTraKiemTraDto?> GetByIdAsync(int id);
        public Task<bool> SaveAsync(ThanhTraKiemTraDto dto);
        public Task<bool> DeleteAsync(int id);
    }
    public class ThanhTraKiemTraService : IThanhTraKiemTraService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        public ThanhTraKiemTraService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        public async Task<List<ThanhTraKiemTraDto>> GetAllAsync()
        {
            var query = _context.ThanhTraKiemTra!
                 .Where(ttkt => ttkt.DaXoa == false)
                 .Include(ttkt => ttkt.GiayPhep)
                 .Include(ttkt => ttkt.CongTrinh)
                 .Include(ttkt => ttkt.ToChuc_CaNhan)
                 .OrderByDescending(x => x.ThoiGan)
                 .AsQueryable();

            var items = await query.ToListAsync();
            return _mapper.Map<List<ThanhTraKiemTraDto>>(items);
        }

        public async Task<ThanhTraKiemTraDto?> GetByIdAsync(int id)
        {
            var query = _context.ThanhTraKiemTra!
                .Where(ttkt => ttkt.Id == id)
                .Include(ttkt => ttkt.GiayPhep)
                .Include(ttkt => ttkt.CongTrinh)
                .Include(ttkt => ttkt.ToChuc_CaNhan);

            var item = await query.FirstOrDefaultAsync();
            return _mapper.Map<ThanhTraKiemTraDto>(item);
        }

        public async Task<bool> SaveAsync(ThanhTraKiemTraDto dto)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);
            var existingItem = await _context.ThanhTraKiemTra!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<ThanhTraKiemTra>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = currentUser != null ? currentUser.UserName : null;
                _context.ThanhTraKiemTra!.Add(newItem);
            }
            else
            {
                existingItem = _mapper.Map(dto, existingItem);
                existingItem!.DaXoa = false;
                existingItem.ThoiGianSua = DateTime.Now;
                existingItem.TaiKhoanSua = currentUser != null ? currentUser.UserName : null;
                _context.ThanhTraKiemTra!.Update(existingItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingItem = await _context.ThanhTraKiemTra!.FirstOrDefaultAsync(d => d.Id == id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}