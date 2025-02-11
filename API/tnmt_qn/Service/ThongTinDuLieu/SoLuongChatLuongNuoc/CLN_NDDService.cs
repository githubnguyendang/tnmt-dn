using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using tnmt_qn.Data;
using tnmt_qn.Dto;

using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class CLN_NDDService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public CLN_NDDService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        public async Task<List<CLN_NDDDto>> GetAllCLN_NDDAsync(int tu_nam, int den_nam)
        {
            var items = _context.CLN_NDD!.Where(d => d.DaXoa == false)
                .OrderBy(d => d.Id)
                .AsQueryable();

            if (tu_nam > 0 || den_nam > 0) items = items.Where(x => x.ThoiGianQuanTrac >= tu_nam && x.ThoiGianQuanTrac <= den_nam);

            var ttdlDto = _mapper.Map<List<CLN_NDDDto>>(await items.ToListAsync());

            return ttdlDto;
        }
        public async Task<bool> SaveAsync(CLN_NDDDto dto)
        {

            var existingItem = await _context.CLN_NDD!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<CLN_NDD>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.CLN_NDD!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.CLN_NDD!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.CLN_NDD!.Update(updateItem);
            }

            var res = await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.CLN_NDD!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.CLN_NDD!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
