using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class DemoService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ILogChangeService _logChangeService;

        public DemoService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, ILogChangeService logChangeService)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _logChangeService = logChangeService;
        }

        public async Task<List<DemoDto>> GetAllAsync()
        {
            var items = await _context.Demo!.Where(b => b.DaXoa == false).ToListAsync();
            return _mapper.Map<List<DemoDto>>(items);
        }

        public async Task<DemoDto> GetByIdAsync(int Id)
        {
            var item = await _context.Demo!.FindAsync(Id);
            return _mapper.Map<DemoDto>(item);
        }

        public async Task<bool> SaveAsync(DemoDto dto)
        {
            var existingItem = await _context.Demo!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);
            var userName = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<Demo>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = userName;

                _context.Demo!.Add(newItem);

                // Log POST action
                await _logChangeService.LogChangeAsync("Demo", "CREATED", null, newItem, userName);
            }
            else
            {
                var oldItem = _mapper.Map<DemoDto>(existingItem);
                var updateItem = _mapper.Map(dto, existingItem);

                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = userName;
                _context.Demo!.Update(updateItem);

                // Log PUT action
                await _logChangeService.LogChangeAsync("Demo", "UPDATE", oldItem, updateItem, userName);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.Demo!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            var oldItem = _mapper.Map<DemoDto>(existingItem);
            existingItem!.DaXoa = true;
            _context.Demo!.Update(existingItem);

            var userName = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";

            // Log DELETE action
            await _logChangeService.LogChangeAsync("Demo", "DELETE", oldItem, null, userName);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
