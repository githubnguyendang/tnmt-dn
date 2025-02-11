using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class KhaNangTiepNhanNuocHoService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        public KhaNangTiepNhanNuocHoService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }
        public async Task<List<KhaNangTiepNhanNuocHoDto>> GetAllAsync()
        {
            var query = await _context.KhaNangTiepNhanNuocHo!
                .Where(gp => gp.DaXoa == false)
                .AsQueryable().ToListAsync();

            // Apply filters based on input parameters

            var listItems = _mapper.Map<List<KhaNangTiepNhanNuocHoDto>>(query);

            return listItems;
        }

        public async Task<KhaNangTiepNhanNuocHoDto> GetByIdAsync(int Id)
        {
            var item = await _context.KhaNangTiepNhanNuocHo!.FindAsync(Id);
            return _mapper.Map<KhaNangTiepNhanNuocHoDto>(item);
        }


        public async Task<bool> SaveAsync(KhaNangTiepNhanNuocHoDto dto)
        {
            var existingItem = await _context.KhaNangTiepNhanNuocHo!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<KhaNangTiepNhanNuocHo>(dto);
                newItem.DaXoa = false;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.KhaNangTiepNhanNuocHo!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.KhaNangTiepNhanNuocHo!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.DaXoa = false;
                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.KhaNangTiepNhanNuocHo!.Update(updateItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.KhaNangTiepNhanNuocHo!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.KhaNangTiepNhanNuocHo!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
