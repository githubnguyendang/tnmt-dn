using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class TestService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ILogChangeService _logChangeService;

        public TestService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, ILogChangeService logChangeService)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _logChangeService = logChangeService;
        }

        public async Task<List<TestDto>> GetAllAsync()
        {
            var items = await _context.Test!.Where(b => b.DaXoa == false).ToListAsync();
            return _mapper.Map<List<TestDto>>(items);
        }

        public async Task<TestDto> GetByIdAsync(int Id)
        {
            var item = await _context.Test!.FindAsync(Id);
            return _mapper.Map<TestDto>(item);
        }

        public async Task<bool> SaveAsync(TestDto dto)
        {
            var existingItem = await _context.Test!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);
            var userName = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<Test>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = userName;

                _context.Test!.Add(newItem);

                // Log POST action
                await _logChangeService.LogChangeAsync("Test", "CREATED", null, newItem, userName);
            }
            else
            {
                var oldItem = _mapper.Map<TestDto>(existingItem);
                var updateItem = _mapper.Map(dto, existingItem);

                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = userName;
                _context.Test!.Update(updateItem);

                // Log PUT action
                await _logChangeService.LogChangeAsync("Test", "UPDATE", oldItem, updateItem, userName);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.Test!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            var oldItem = _mapper.Map<TestDto>(existingItem);
            existingItem!.DaXoa = true;
            _context.Test!.Update(existingItem);

            var userName = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";

            // Log DELETE action
            await _logChangeService.LogChangeAsync("Test", "DELETE", oldItem, null, userName);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
