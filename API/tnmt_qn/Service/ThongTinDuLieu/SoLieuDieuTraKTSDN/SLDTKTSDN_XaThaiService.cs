using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using tnmt_qn.Data;
using tnmt_qn.Dto;

using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class SLDTKTSDN_XaThaiService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public SLDTKTSDN_XaThaiService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        public async Task<List<SLDTKTSDN_XaThaiDto>> GetAllSLDTKTSDN_XaThaiAsync()
        {
            var items = await _context.SLDTKTSDN_XaThai!.Where(d => d.DaXoa == false)
                .OrderBy(d => d.Id)
                .AsQueryable().ToListAsync();

            var ttdlDto = _mapper.Map<List<SLDTKTSDN_XaThaiDto>>(items);

            return ttdlDto;
        }
        public async Task<bool> SaveAsync(SLDTKTSDN_XaThaiDto dto)
        {

            var existingItem = await _context.SLDTKTSDN_XaThai!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<SLDTKTSDN_XaThai>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.SLDTKTSDN_XaThai!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.SLDTKTSDN_XaThai!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.SLDTKTSDN_XaThai!.Update(updateItem);
            }

            var res = await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.SLDTKTSDN_XaThai!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.SLDTKTSDN_XaThai!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
